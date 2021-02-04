using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.FileIO;
//using Miriam_Serial;

/*
 * Miriam control
 *  
 * Miriam is an isothermal amplification unit capable of real time detection that supports a 96 well PCR plate
 * This software allows the control over serial port string messages
 *   
 * (c) 2016 Juho Terrijarvi juho@miroculus.com, Miroculus Inc.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *    
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace Miriam
{
    public partial class Control : Form
    {
        private System.Diagnostics.FileVersionInfo file_version_info;
        private int time_to_stop_assay;
        private string arrayNames;
        private int maximumValue = 0;
        private string port_measurement = "";
        private string port_heating = "";
        private Boolean started = false;
        private readonly int nGridRows = 8;
        private readonly int nGridCols = 12;
        private readonly string cells_fname = @".cells.tsv";
        private int betweenMesSec;
        public static string folderName;
        private volatile bool _exiting = false;
        private Thread assay_thread;

        private int ninfo;

        private Dictionary<string, int> temperatureInfoMap;
        private Dictionary<string, string> currentTemperatureInfo;

        private string csv_filename;
        FormSettings SettingsForm;

        public static bool melting_enabled;
        public static string filename_prefix;
        public static char datafile_separator;
        public string firmware_version;
        public string software_version;
        public static Dictionary<string, string> settings_melting = new Dictionary<string, string>
            {
                { "TUp", "80" },
                { "TMiddle", "80" },
                { "TExtra", "80" },
                { "Interval", "30" },
                { "Tolerance", "0.1"}
            };
        public struct SettingsMeasurement
        {
            // in the firmware all the temperatures are converted to int! 
            public double TUp;
            public double TMiddle;
            public double TExtra;
            public double TThreshold;
            public int MeasureIntervalSec;
            public double DurationMin;
        }
        public static SettingsMeasurement settings_measurement;
        private static string ArduinoReadout(SerialPort serialPort, string command)
        {
            serialPort.Write(command + "\r\n");
            string ReceivedData;
            bool conti = true;
            do
            {
                ReceivedData = serialPort.ReadLine();
                if (ReceivedData.Contains('$'))
                {
                    conti = false;
                }
            } while (conti);

            ReceivedData = ReceivedData.Replace("$", "");
            ReceivedData = ReceivedData.Replace("\r", "");
            ReceivedData = ReceivedData.Replace("\n", "");

            return ReceivedData;
        }

        public class SerialPortForHeat : SerialPort
        {
            public SerialPortForHeat(string portname)
            {
                PortName = portname;
                DataBits = 8;
                Parity = Parity.None;
                StopBits = StopBits.One;
                BaudRate = 9600;

                // Set the read/write timeouts                
                ReadTimeout = 500;
                WriteTimeout = 500;
            }
            public bool cancel()
            {
                try
                {
                    Open();
                    DiscardOutBuffer();
                    DiscardInBuffer();

                    string s = ArduinoReadout(this, "C");
                    Console.WriteLine(s);

                    Close();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show("SerialPort error \n" + e.Message);
                    Close();
                    return false;
                    //throw;
                }
            }
            public bool start_heat(string t_up, string t_middle, string t_extra, string threshold = "", bool melting=false)
            {
                try
                {
                    Open();
                    DiscardOutBuffer();
                    DiscardInBuffer();

                    string heat_command = melting ? "W" : "H";

                    //String ReceivedData;
                    String s;

                    if (melting)
                        {
                            s = ArduinoReadout(this, "w"); // melt init sets the output values
                            Console.WriteLine(s);
                            s = ArduinoReadout(this, heat_command);
                            Console.WriteLine(s);
                        }

                    s = ArduinoReadout(this, "M " + t_middle);
                    Console.WriteLine(s);

                    s = ArduinoReadout(this, "U " + t_up);
                    Console.WriteLine(s);

                    s = ArduinoReadout(this, "E " + t_extra);
                    Console.WriteLine(s);

                    if (threshold != "")
                    {
                        s = ArduinoReadout(this, "T " + threshold);
                        Console.WriteLine(s);
                    }

                    if (!melting)  
                        {
                            s = ArduinoReadout(this, heat_command);
                            Console.WriteLine(s);
                        }                    
                    // [AT] maybe sleep here a bit?
                }
                catch (Exception exc)
                {
                    string whatiam = melting ? "melting" : "heating";
                    MessageBox.Show($"Could not start {whatiam}. Serial port error:\n" + exc.Message);
                    this.Close();
                    return false;
                }
                return true;
            }
        };

        public Control()
        {
            InitializeComponent();

            //for correct string <-> double convertion using '.' as a decimal separator
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //datafile_separator = '\t'; // windows doesn't handle tsv files very well :(
            datafile_separator = ','; //csv
            //datafile_separator = ';';


            Assembly assembly = Assembly.GetExecutingAssembly();
            file_version_info = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            software_version = file_version_info.FileVersion;

            settings_measurement = new SettingsMeasurement();
            assay_thread = new System.Threading.Thread(new System.Threading.ThreadStart(doAssay));
            
            // indices in the arduino "i" readout
            temperatureInfoMap = new Dictionary<string, int>
            {
                { "Up", 4 },
                { "Middle", 5 },
                { "Extra", 9 },
                { "Box", 10 },
                { "OutUp", 1 },
                { "OutMiddle", 0 },
                { "OutExtra", 6 },
            };

            currentTemperatureInfo = new Dictionary<string, string>
            {
                { "Up", "" },
                { "Middle", "" },
                { "Extra", "" },
                { "Box", "" },
                { "OutUp", "" },
                { "OutMiddle", "" },
                { "OutExtra", "" },

            };

            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i < ports.Length; i++)
            {
                COM.Items.Add(ports[i]);
            }

            foreach (string port in ports)
            {
                try
                {
                    if(check_firmware_version(port))
                    {
                        COM.SelectedItem = port;
                        break;
                    }
                }
                catch (Exception exc)
                {
                    Console.Write("Version check failed: " + exc.ToString());
                    Console.WriteLine();
                }
            }

            if (ports.Length != 0 && COM.SelectedIndex == -1)
            {
                COM.SelectedIndex = 0;
            }

            //CreatePlate();
            CreateEmptyPlate();            
            // todo: load from file button
            // todo: don't load if cannot load
            FillPlate(cells_fname);
            //Results.Visible = true;
        }

        private bool check_firmware_version(string port)
        {
            SerialPort serial = new SerialPortForHeat(port);
            try
            {
                serial.Open();
                Console.WriteLine(port);

                serial.DiscardInBuffer();
                serial.DiscardOutBuffer();

                string ver = ArduinoReadout(serial, "V");
                bool result = check_version(ver);
                serial.Close();
                return result;
            }
            catch (Exception exc)
            {
                serial.Close();              
                exc.Data.Add("UserMessage", "Version check failed. Does the firmware have a version number?");
                throw;                
            }
            
        }

        public bool check_version(string val)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            //string version = fvi.FileVersion;
            firmware_version = val;
            Console.WriteLine("software version:" + software_version);
            Console.WriteLine("firmware version:" + firmware_version);
            var v0 = Convert.ToInt32(firmware_version.Split('.')[0]);
            var v1 = Convert.ToInt32(firmware_version.Split('.')[1]);
            
            return (v0 == file_version_info.FileMajorPart) && (v1 == file_version_info.FileMinorPart);
        }

        private void ParseTemperatureInfo(string received_data)
        {
            Console.WriteLine(received_data);
            List<string> keys = new List<string>(currentTemperatureInfo.Keys);
            int tindex;

            foreach (var loc in keys)
            {
                tindex = temperatureInfoMap[loc];
                if(received_data.Split(',').Length >= tindex+1)
                    currentTemperatureInfo[loc] = received_data.Split(',')[temperatureInfoMap[loc]];
                    Console.WriteLine("T {0}: {1}", loc, currentTemperatureInfo[loc]);
            }                        
        }

        private bool temperature_reached()
        {
            //for correct string <-> double convertion using '.' as a decimal separator
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            float eps = float.Parse(settings_melting["Tolerance"]);

            float t_up_val = float.Parse(currentTemperatureInfo["Up"]);
            float t_mid_val = float.Parse(currentTemperatureInfo["Middle"]);
            float t_extra_val = float.Parse(currentTemperatureInfo["Extra"]);

            bool t_up = (t_up_val - float.Parse(settings_melting["TUp"]) >= -eps);
            bool t_mid = (t_mid_val - float.Parse(settings_melting["TMiddle"]) >= -eps);
            bool t_extra = (t_extra_val - float.Parse(settings_melting["TExtra"]) >= -eps);
            return t_up && t_mid && t_extra;
        }

        private void CreateEmptyPlate()
        {
            Plate.ColumnCount = nGridCols;
            //Plate.RowCount = 8;
            for (int i = 0; i < nGridCols; i++)
            {
                DataGridViewColumn column = Plate.Columns[i];
                column.Name = (i + 1).ToString();
                column.Width = 40;
            }
            Plate.AllowUserToAddRows = false;

            String alphabets = "ABCDEFGH";
            String cur_letter;
            for (int i = 0; i < nGridRows; i++)
            {
                Plate.Rows.Add("", "", "", "", "", "", "", "", "", "", "", ""); // [AT] todo: use nGridCols as a number of elements
                cur_letter = alphabets[i].ToString(); //[AT] fill cells automatically 
                Plate.Rows[i].HeaderCell.Value = cur_letter;
                Plate.RowHeadersWidth = Plate.RowHeadersWidth + 1;
            }
        }

        private void FillPlate(string filename)
        {
            if (!File.Exists(filename))
            { return; }
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("\t");
                int istring = 0;
                string[] fields = parser.ReadFields(); // skip header
                while (!parser.EndOfData)
                {
                    //Process row
                    fields = parser.ReadFields();
                    int jcol = -1;
                    foreach (string field in fields)
                    {
                        if (jcol >= 0) Plate.Rows[istring].Cells[jcol].Value = field;
                        jcol++;
                    }
                    istring++;
                }
            }            
        }

        private void AutofillPlate()
        {
            String alphabets = "ABCDEFGH";
            String cur_letter;
            for (int i = 0; i < nGridRows; i++)
            {                
                cur_letter = alphabets[i].ToString();                                
                for (int col = 0; col < Plate.ColumnCount; col++)
                {
                    Plate.Rows[i].Cells[col].Value = cur_letter + Plate.Columns[col].Name;
                }
            }
        }

        private void ButtonHeat_Click(object sender, EventArgs e)
        {
            SerialPortForHeat serialPort = new SerialPortForHeat(COM.Text);
            

            try 
            { 
                bool heat_started = serialPort.start_heat(settings_measurement.TUp.ToString(),
                    settings_measurement.TMiddle.ToString(), settings_measurement.TExtra.ToString(),
                    threshold: settings_measurement.TThreshold.ToString(), melting: false);

                if (heat_started)
                {
                    port_heating = COM.Text;
                    string ReceivedData = ArduinoReadout(serialPort, "i");
                    ParseTemperatureInfo(ReceivedData);
                    //                AppendHeatLabel("Temperature U:" + currentTemperatureInfo["Up"] + "," + "Temperature M:" + currentTemperatureInfo["Middle"]);
                    AppendHeatLabel("Temperature U:" + currentTemperatureInfo["Up"] + "," +
                        "Temperature M:" + currentTemperatureInfo["Middle"] + "," +
                        "Temperature Extra:" + currentTemperatureInfo["Extra"] + "," +
                        "Temperature Box:" + currentTemperatureInfo["Box"]);

                    // AppendHeatLabel("Temperature U:" + ReceivedData.Split(',')[4] + "," + "Temperature M:" + ReceivedData.Split(',')[5]);
                    Console.WriteLine();
                    Console.WriteLine("i output: {0}", ReceivedData);

                    serialPort.Close();
                }
            }            
            catch (Exception exc) 
            {
                // [AT] todo: show exception
                MessageBox.Show("Serial could not be opened, please check that the device is correct one\n"+exc.Message);
                serialPort.Close();
            }

        }
        

        private void AppendHeatLabel(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendHeatLabel), new object[] { value });
                return;
            }
            Console.WriteLine(value);
            LabelTempUC.Text = value.Split(',')[0];
            LabelTempMC.Text = value.Split(',')[1];
            LabelTempEC.Text = value.Split(',')[2];
            LabelTempBoxC.Text = value.Split(',')[3];

        }

        private void AskHeat_Click(object sender, EventArgs e)
        {
            SerialPortForHeat serialPort = null;

            // Create a new SerialPort object with appropriate settings.
            serialPort = new SerialPortForHeat(COM.Text);

            try
            {
                serialPort.Open();
                serialPort.DiscardOutBuffer();
                serialPort.DiscardInBuffer();

                String ReceivedData = ArduinoReadout(serialPort, "i");
                ParseTemperatureInfo(ReceivedData);
                AppendHeatLabel("Temperature U:" + currentTemperatureInfo["Up"] + "," + 
                    "Temperature M:" + currentTemperatureInfo["Middle"] + "," +
                    "Temperature Extra:" + currentTemperatureInfo["Extra"] + "," +
                    "Temperature Box:" + currentTemperatureInfo["Box"]);

                serialPort.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Serial could not be opened, please check that the device is correct one");
                serialPort.Close();
            }
        }

        private void AppendToCsv(string value, bool live=true, string filename="")
        {
            string append_string = value.TrimEnd(',') + Environment.NewLine;
            append_string = append_string.Replace(',', datafile_separator);
            if (live)
                filename = csv_filename;
            //[AT] value has the ',' after the last value, don't write it to the csv
            File.AppendAllText(filename, append_string, Encoding.UTF8);
            Console.WriteLine("Append to csv: {0}", value);
        }

        private void AppendData(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendData), new object[] { value });
                return;
            }
            Data.Items.Add(value);
            AppendToCsv(value);
        }

        private string CreateCsv(string header)
        {
            // header - comma-separated
            string file_ext = datafile_separator == '\t' ? ".tsv" : ".csv";
            header = header.Replace(',', datafile_separator);
            string filename = folderName + @"\" + filename_prefix + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + file_ext;
            Console.WriteLine();
            Console.WriteLine("Creating csv: {0}", csv_filename);
            string metadata = $"# software-version: {software_version}\n# firmware-version: {firmware_version}";
            File.WriteAllText(filename, metadata + Environment.NewLine, Encoding.UTF8);
            File.AppendAllText(filename, header.Remove(header.Length - 1, 1) + Environment.NewLine, Encoding.UTF8);
            return filename;
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if (started) return;            

            port_measurement = COM.Text;

            try
            {
                if (!check_firmware_version(port_measurement)) // changes firmware_version //todo: refactor: fwv=get_firmware_version(port); if !check_v() ... 
                {
                    MessageBox.Show($"Version of firmware ({firmware_version}) does not match version of software ({software_version})! Please update.");
                    return;
                }
            }
            catch (TimeoutException exc)
            {
                string complain = "Timeout reading from Serial Port";
                if (exc.Data.Contains("UserMessage"))
                {
                    complain = exc.Data["UserMessage"].ToString();
                }
                MessageBox.Show(complain + "\n\n" + exc.ToString());
                return;
            }
            catch (UnauthorizedAccessException exc)
            {
                string complain = "Serial could not be opened, please check that the device is correct one";
                if (exc.Data.Contains("UserMessage"))
                {
                    complain = exc.Data["UserMessage"].ToString();
                }
                MessageBox.Show(complain + "\n\n" + exc.ToString());
                return;
            }

            Results.Visible = true;
            Form f = Control.ActiveForm;
            f.Size = new Size(f.Size.Width, 750);
            started = true;
            Results.Visible = true;
            Results.Anchor |= AnchorStyles.Bottom;
            DateTime localDate = DateTime.Now;

            time_to_stop_assay = localDate.Hour * 60 * 60 + localDate.Minute * 60 + localDate.Second +
                Convert.ToInt32(settings_measurement.DurationMin * 60);

            betweenMesSec = settings_measurement.MeasureIntervalSec;

            Boolean noneFound = true;
            List<String> dupl = new List<String>();
            // clear duplicates
            for (int i = 0; i < Plate.RowCount; i++)
            {
                for (int j = 0; j < Plate.ColumnCount; j++)
                {
                    if (Plate.Rows[i].Cells[j].Value != null)
                    {
                        if (!Plate.Rows[i].Cells[j].Value.ToString().Equals(""))
                        {
                            for (int k = 0; k < dupl.Count; k++)
                            {
                                if (dupl[k].Equals(Plate.Rows[i].Cells[j].Value.ToString()))
                                {
                                    Plate.Rows[i].Cells[j].Value = Plate.Rows[i].Cells[j].Value.ToString() + "_";
                                }

                            }
                            dupl.Add(Plate.Rows[i].Cells[j].Value.ToString());
                            noneFound = false;
                        }
                    } else
                    {
                        Plate.Rows[i].Cells[j].Value = "";
                    }
                        
                }
            }
                
            if (noneFound)
            {
                Plate.Rows[0].Cells[0].Value = "TimeTrack";
            }

            List<int> list = new List<int>(); //[AT] list of wells with names <int - number in array of values>

            int counter = 5;
            //string msg = "Time,U,M,"; // [AT] csv file header. 
            //string msg = "Time,U,M,Extra,Box,"; // [AT] csv file header. 
            string msg = "Time,TemperatureUpper,TemperatureLower,TemperatureWire,TemperatureBox,";
            //msg += "OutU, OutM, OutE,"; // add output values
            msg += "HeatCommandUpper,HeatCommandLower,HeatCommandWire,";
            counter += 3;
            ninfo = counter;

            for (int i = 0; i < Plate.RowCount; i++)
            {
                for (int j = 0; j < Plate.ColumnCount; j++)
                {

                    msg += Plate.Rows[i].Cells[j].Value.ToString() + ",";
                    if (!Plate.Rows[i].Cells[j].Value.ToString().Equals(""))
                    {
                        list.Add(counter);
                    }
                    counter += 1;
                }
            }
            Console.WriteLine(msg);

            Data.Items.Add(msg); //[AT] Data -- invisible ListBox
            arrayNames = msg; //[AT] header

            csv_filename = CreateCsv(msg);

            Color[] clr;

            clr = new Color[10];
            clr[0] = Color.Red;
            clr[1] = Color.Blue;
            clr[2] = Color.Chocolate;
            clr[3] = Color.Green;
            clr[4] = Color.Black;
            clr[5] = Color.Aqua;
            clr[6] = Color.DimGray;
            clr[7] = Color.DarkViolet;
            clr[8] = Color.DeepPink;
            clr[9] = Color.Gray;

            int clrsUsed = 0;
                
            //[AT] add series for all named wells 
            for (int i = 0; i < list.Count; i++)
            {
                Results.Series.Add(msg.Split(',')[list[i]]);
                Results.Series[msg.Split(',')[list[i]]].ChartType =
                                SeriesChartType.FastLine;                    
                Results.Series[msg.Split(',')[list[i]]].Color = clr[clrsUsed];
                clrsUsed += 1;
                if (clrsUsed > 9)
                {
                    clrsUsed = 0;
                }
            }

            // put to background to force to close if program exit
            assay_thread.IsBackground = true;

            assay_thread.Start();       
        }

        // [AT] appends result to the plot
        private void AppendResult(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendResult), new object[] { value });
                return;
            }
            
            for(int i = ninfo; i<arrayNames.Split(',').Length; i++)
            {
                if(!arrayNames.Split(',')[i].Equals(""))
                {
                    Results.Series[arrayNames.Split(',')[i]].Points.AddXY
                        (Convert.ToInt32(value.Split(',')[0]), 
                        Convert.ToInt32(value.Split(',')[i]));

                    if (Convert.ToInt32(value.Split(',')[i]) > maximumValue)
                    {
                        maximumValue = Convert.ToInt32(value.Split(',')[i]);
                    }
                    Results.ChartAreas[0].AxisY.Maximum = maximumValue + 10;
                    Results.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(value.Split(',')[0]) + 1;
                    Results.ChartAreas[0].AxisY.Minimum = 0;
                    Results.ChartAreas[0].AxisX.Minimum = 0;
                    
                }
               
            }
            

        }
        public string ReverseColumnOrder(String received_vals)
        {
            string[] values = received_vals.Split(',');
            string ans = "";
    
            for (int irow = 0; irow < nGridRows; irow++)
            {
                for (int jcol = nGridCols - 1; jcol >= 0; jcol--)
                { 
                    ans += values[irow * nGridCols + jcol] + ",";
                }
            }
            return ans;
        }

        public string RearrangeColumnOrder(String received_vals) // not tested yet: 1,2,3,4,5,6 -> 5,6,3,4,1,2
        {
            string[] values = received_vals.Split(',');
            string ans = "";
            string[] vals_reversed = new string[nGridCols * nGridRows];

            for (int irow = 0; irow < nGridRows; irow++)
            {
                for (int jcol = nGridCols - 1, jrev=0; jcol >= 0; jcol--, jrev++)
                {
                    //ans += values[irow * nGridCols + jcol] + ",";
                    vals_reversed[irow * nGridCols + jrev] = values[irow * nGridCols + jcol];
                }
            }

            for (int irow = 0; irow < nGridRows; irow++)
            {
                for (int jrev=0; jrev+1 < nGridCols; jrev+=2)
                { 
                    ans += vals_reversed[irow * nGridCols + jrev + 1] + "," + vals_reversed[irow * nGridCols + jrev] + ",";                    
                }
            }
            return ans;
        }
        private bool cancelHeat()
        {
            
            string portname = "";
            if (port_measurement == "")
            {
                if (port_heating != "") portname = port_heating;
            }
            else
            {
                portname = port_measurement;
            }
            if (portname=="")
            {
                portname = COM.Text;
            }

            SerialPortForHeat serialPortCancel = new SerialPortForHeat(portname);
            return serialPortCancel.cancel();
        }

        private void doAssay()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // Boolean cont = true;
            bool cont_assay = true;            
            int loop = 0;
            Boolean assay_ready = false;
            bool now_melting = false;
            bool stop_condition = false;            
            do
            {
                DateTime current = DateTime.Now;
				// AT: time when the current measurement started
				int time_current_measurement = current.Hour * 60 * 60 + current.Minute * 60 + current.Second;
                string timestr = current.ToString("s"); //[AT] "s" -- sortable datetime format

                if (!now_melting) stop_condition = (time_to_stop_assay < time_current_measurement);
                else stop_condition = temperature_reached();

                // AT:stop if the specified duration passed (from the textbox)
                if (_exiting || stop_condition)
                {
                    cont_assay = false;
                    if (!_exiting) // not exiting on form close
                    {
                        assay_ready = true;
                    }
                }
                
                // [AT][?] why recreate this object for every cycle? Would it be enough to create once? + can put it in a child class
                SerialPort serialPort = null;

                // Create a new SerialPort object with default settings.
                serialPort = new SerialPort();

                // Allow the user to set the appropriate properties.
                serialPort.PortName = port_measurement;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.BaudRate = 9600;

                // Set the read/write timeouts
                serialPort.ReadTimeout = 10000;
                serialPort.WriteTimeout = 500;

                try
                {
                    serialPort.Open();
                    serialPort.DiscardOutBuffer();
                    serialPort.DiscardInBuffer();

                    String ReceivedData;
                    ReceivedData = ArduinoReadout(serialPort, "l"); // turn on the status LED (don't need to do it every time...)
                    Console.WriteLine(ReceivedData);

                    ReceivedData = ArduinoReadout(serialPort, "R"); // read the measurements

                    // [AT] ReceivedData -- string of values for each well
                    // [AT] ReceivedData1 -- info string (temperatures etc)

                    String ReceivedData1 = ArduinoReadout(serialPort, "i"); // read the temperatures

                    Thread.Sleep(2000); // [AT] sleep 2s
                    Console.WriteLine("end sleep i");

                    if (_exiting)
                    {
                        Console.WriteLine("Exit 2");
                        serialPort.Close();
                        break;
                    }

                    ParseTemperatureInfo(ReceivedData1);
                                        
                    AppendHeatLabel("Temperature U:" + currentTemperatureInfo["Up"] + "," +
                        "Temperature M:" + currentTemperatureInfo["Middle"] + "," +
                        "Temperature Extra:" + currentTemperatureInfo["Extra"] + "," +
                        "Temperature Box:" + currentTemperatureInfo["Box"]);
                    // [AT] The columns of the grid are reversed, it is received as A12,...A1, B12,...,B1, ...
                    // ReceivedData = ReverseColumnOrder(ReceivedData);
                    // [AT] upd: The columns of the grid are mixed, it is received as A11,A12,...A1,A2, B11,B12,...,B1,B2, ...
                    ReceivedData = RearrangeColumnOrder(ReceivedData);

                    string tinfocsv = currentTemperatureInfo["Up"] + "," +
                        currentTemperatureInfo["Middle"] + "," +
                        currentTemperatureInfo["Extra"] + "," +
                        currentTemperatureInfo["Box"] + "," +
                        currentTemperatureInfo["OutUp"] + "," +
                        currentTemperatureInfo["OutMiddle"] + "," +
                        currentTemperatureInfo["OutExtra"] + ",";
                    AppendData(timestr + "," + tinfocsv + ReceivedData);
                        
                    // todo: fix appendData and AppendResult
                    //string resToAppend = loop.ToString() + ",U,M,";  // [AT] not used, so i commented this line

                    AppendResult(loop.ToString() + "," + tinfocsv + ReceivedData);

                    Thread.Sleep(2000); // 2s
                    Console.WriteLine("end sleep 2");

                    serialPort.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Serial could not be opened, please check that the device is correct one.\n"+ exc.ToString());
                    serialPort.Close();
                }

                Boolean timeRunning = true;

                if ((!now_melting) && assay_ready && melting_enabled)
                {
                    cont_assay = true;
                    if (apply_settings_melting())
                    {
                        now_melting = true;
                        assay_ready = false;                        
                    }
                 }

                if (cont_assay)
                {
                    // wait until getting the next measurement                
                    do
                    {
                        DateTime wait = DateTime.Now;
                        if (time_current_measurement + betweenMesSec < wait.Hour * 60 * 60 + wait.Minute * 60 + wait.Second)
                        {
                            timeRunning = false;
                        }
                        Thread.Sleep(100);
                    } while (timeRunning);
                    loop += 1;
                }
                // if need to start melting after the measurements were taken for specified duration
            } while (cont_assay && (!_exiting));


            // Cancel the heat
            // [AT] don't do canceling here, but only on exit?
            bool heat_canceled = cancelHeat();

            if (!heat_canceled)
                MessageBox.Show("Warning! Heat was not canceled");

            if (assay_ready)
                MessageBox.Show("Assay ready");   
            else if(_exiting)
                MessageBox.Show("Assay Aborted");
        }

        private bool apply_settings_melting()        {
            Console.WriteLine(settings_melting);
            betweenMesSec = Convert.ToInt32(settings_melting["Interval"]);

            SerialPortForHeat serialPort = new SerialPortForHeat(port_measurement);
            bool started = serialPort.start_heat(settings_melting["TUp"], settings_melting["TMiddle"], settings_melting["TExtra"], melting: true);
            serialPort.Close();
            return started;
        }

        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string fname = CreateCsv(Data.Items[0].ToString());
                for (int i = 1; i < Data.Items.Count; i++)
                {
                    AppendToCsv(Data.Items[i].ToString(), live: false, filename: fname);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("File not writable");
            }
            catch (ArgumentOutOfRangeException exc)
            {
                MessageBox.Show("No data to write \n" + exc.Message);
            }
        }

        private void buttonFillAll_Click(object sender, EventArgs e)
        {
            AutofillPlate();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in Plate.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                { cell.Value = ""; }
        }

        private void Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            _exiting = true;

            savePlateCells(cells_fname);
            Miriam_Serial.Properties.Settings.Default.settFolderRes = folderName;

            //Miriam_Serial.Properties.Settings.Default.settTemperatureMid = CboxTempM.Text;
            //Miriam_Serial.Properties.Settings.Default.settTemperatureUp = CboxTempU.Text;
            //Miriam_Serial.Properties.Settings.Default.settTemperatureExtra = CboxTempE.Text;
            //Miriam_Serial.Properties.Settings.Default.settBoxTemperatureThreshold = CboxTempThr.Text;
            //Miriam_Serial.Properties.Settings.Default.settDuration = CboxDuration.Text;
            //Miriam_Serial.Properties.Settings.Default.settInterval = CboxInterval.Text;
            Miriam_Serial.Properties.Settings.Default.settTemperatureMid = settings_measurement.TMiddle.ToString();
            Miriam_Serial.Properties.Settings.Default.settTemperatureUp = settings_measurement.TUp.ToString();
            Miriam_Serial.Properties.Settings.Default.settTemperatureExtra = settings_measurement.TExtra.ToString();
            Miriam_Serial.Properties.Settings.Default.settBoxTemperatureThreshold = settings_measurement.TThreshold.ToString();
            Miriam_Serial.Properties.Settings.Default.settDuration = settings_measurement.DurationMin.ToString();
            Miriam_Serial.Properties.Settings.Default.settInterval = settings_measurement.MeasureIntervalSec.ToString();

            Miriam_Serial.Properties.Settings.Default.meltTemperatureUp = settings_melting["TUp"];
            Miriam_Serial.Properties.Settings.Default.meltTemperatureMid = settings_melting["TMiddle"];
            Miriam_Serial.Properties.Settings.Default.meltTemperatureExtra = settings_melting["TExtra"];
            Miriam_Serial.Properties.Settings.Default.meltInterval = settings_melting["Interval"];
            Miriam_Serial.Properties.Settings.Default.meltTolerance = settings_melting["Tolerance"];

            Miriam_Serial.Properties.Settings.Default.meltingEnabled = melting_enabled;

            Miriam_Serial.Properties.Settings.Default.filenamePrefix = filename_prefix;

            Console.WriteLine(Miriam_Serial.Properties.Settings.Default.settFolderRes);
            Miriam_Serial.Properties.Settings.Default.Save();

            if (assay_thread.IsAlive)
            {
                Console.WriteLine("Waiting end of measurement...");
                assay_thread.Join(10000);
            }
            else
            {
                Console.WriteLine("No measurement, canceling heat...");
                cancelHeat();
                Console.WriteLine("Heat cancelled?");
            }
            Console.WriteLine("Bye!");
        }

        private void savePlateCells(string filename, string sep="\t")
        {            
            string columnNames = "";
            string[] output = new string[Plate.RowCount + 1];
            for (int i = 0; i < nGridCols; i++)
            {
                columnNames += sep + Plate.Columns[i].Name.ToString();
            }
            output[0] += columnNames;
            for (int row = 0; row < Plate.RowCount; row++)
            {
                output[row + 1] += Plate.Rows[row].HeaderCell.Value.ToString();
                for (int j = 0; j < nGridCols; j++)
                {
                    output[row + 1] += sep+ Plate.Rows[row].Cells[j].Value.ToString();
                }
            }
            File.WriteAllLines(filename, output, System.Text.Encoding.UTF8);
        }

        private void Control_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Miriam_Serial.Properties.Settings.Default.settFolderRes);
            if (Miriam_Serial.Properties.Settings.Default.settFolderRes == "")
            {
                folderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //folderBrowserSaveRes.RootFolder.ToString();                                -
            }
            else
            {
                folderName = Miriam_Serial.Properties.Settings.Default.settFolderRes;
                //folderBrowserSaveRes.SelectedPath = Miriam_Serial.Properties.Settings.Default.settFolderRes;
            }
            Console.WriteLine("folder: {0}", folderName);

            //for correct string <-> double convertion using '.' as a decimal separator
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

//            settings_measurement.TMiddle = Convert.ToDouble(Miriam_Serial.Properties.Settings.Default.settTemperatureMid, CultureInfo.InvariantCulture);
            settings_measurement.TMiddle = Convert.ToDouble(Miriam_Serial.Properties.Settings.Default.settTemperatureMid);
            settings_measurement.TUp = Convert.ToDouble(Miriam_Serial.Properties.Settings.Default.settTemperatureUp);
            settings_measurement.TExtra = Convert.ToDouble(Miriam_Serial.Properties.Settings.Default.settTemperatureExtra);
            settings_measurement.DurationMin = Convert.ToDouble(Miriam_Serial.Properties.Settings.Default.settDuration);
            settings_measurement.MeasureIntervalSec = Convert.ToInt32(Miriam_Serial.Properties.Settings.Default.settInterval);
            settings_measurement.TThreshold = Convert.ToDouble(Miriam_Serial.Properties.Settings.Default.settBoxTemperatureThreshold);

            settings_melting["TUp"] = Miriam_Serial.Properties.Settings.Default.meltTemperatureUp;
            settings_melting["TMiddle"] = Miriam_Serial.Properties.Settings.Default.meltTemperatureMid;
            settings_melting["TExtra"] = Miriam_Serial.Properties.Settings.Default.meltTemperatureExtra;
            settings_melting["Interval"] = Miriam_Serial.Properties.Settings.Default.meltInterval;
            settings_melting["Tolerance"] = Miriam_Serial.Properties.Settings.Default.meltTolerance;
            melting_enabled = Miriam_Serial.Properties.Settings.Default.meltingEnabled;

            filename_prefix = Miriam_Serial.Properties.Settings.Default.filenamePrefix;

            SettingsForm = new FormSettings();
        }

        private void buttonChangeSettings_Click(object sender, EventArgs e)
        {
            SettingsForm.ShowDialog();
        }
    }
}
