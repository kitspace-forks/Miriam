using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic.FileIO;

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
        private int duration;
        private string arrayNames;
        private int maximumValue = 0;
        private string port_measurement = "";
        private string port_heating = "";
        private Boolean started = false;
        private readonly int nGridRows = 8;
        private readonly int nGridCols = 12;
        private readonly string cells_fname = @".cells.tsv";
        private int betweenMesSec;
        private string folderName;
        private volatile bool _exiting = false;
        private Thread assay_thread;

        private Dictionary<string, int> temperatureInfoMap;
        private Dictionary<string, string> currentTemperatureInfo;

        public Control()
        {
            InitializeComponent();
            assay_thread = new System.Threading.Thread(new System.Threading.ThreadStart(doAssay));
            temperatureInfoMap = new Dictionary<string, int>
            {
                { "Up", 4 },
                { "Middle", 5 },
                { "Extra", 9 },
                { "Box", 10 }
            };
            currentTemperatureInfo = new Dictionary<string, string>
            {
                { "Up", "" },
                { "Middle", "" },
                { "Extra", "" },
                { "Box", "" }
            };

            string[] ports = SerialPort.GetPortNames();

            for (int i = 0; i < ports.Length; i++)
            {
                COM.Items.Add(ports[i]);
            }

            if (ports.Length != 0)
            {
                COM.SelectedIndex = 0;
            }


            for (int i = 55; i < 70; i++)
            {
                CboxTempM.Items.Add(i);
            }
            for (int i = 80; i < 90; i++)
            {
                CboxTempU.Items.Add(i);
            }
            for (int i = 55; i < 90; i++)
            {
                CboxTempE.Items.Add(i);
            }
            for (int i = 40; i < 80; i++)
            {
                CboxTempThr.Items.Add(i);
            }

            for (int i = 0; i < 150; i++)
            {
                CboxDuration.Items.Add(i);
            }
            for (int i = 10; i < 600; i++)
            {
                CboxInterval.Items.Add(i); // AT: minimum time a measurement takes is 11 seconds
            }
            CboxTempU.Text = "90";
            CboxTempM.Text = "65";
            CboxTempE.Text = "65";
            CboxDuration.Text = "120";
            CboxInterval.Text = "10";

            //CreatePlate();
            CreateEmptyPlate();            
            // todo: load from file button
            // todo: don't load if cannot load
            FillPlate(cells_fname);
            //Results.Visible = true;
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

//        private void ArduinoCommand(SerialPort serialPort, string command)
//          { }
        private string ArduinoReadout(SerialPort serialPort, string command)
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
            // Set upper temperature

            SerialPort serialPort = null;

            // Create a new SerialPort object with default settings.
            serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            serialPort.PortName = COM.Text;
            port_heating = COM.Text;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.BaudRate = 9600;

            // Set the read/write timeouts
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

            try
            {
                serialPort.Open();
                serialPort.DiscardOutBuffer();
                serialPort.DiscardInBuffer();

                String ReceivedData;

                //RecievedData = serialPort.ReadLine();
                //serialPort.DataReceived += new SerialDataReceivedEventHandler(responseHandler);
                // [AT] SW 'M param' (middle wanted temperature, i.e. M 63) - FW 'temperatureMiddleSet'
                var s = ArduinoReadout(serialPort, "M " + CboxTempM.Text);
                Console.WriteLine(s);

                s = ArduinoReadout(serialPort, "U " + CboxTempU.Text);
                Console.WriteLine(s);

                s = ArduinoReadout(serialPort, "E " + CboxTempE.Text);
                Console.WriteLine(s);

                s = ArduinoReadout(serialPort, "T " + CboxTempThr.Text);
                Console.WriteLine(s);

                s = ArduinoReadout(serialPort, "H");
                Console.WriteLine(s);
                // [AT] maybe sleep here a bit?

                ReceivedData = ArduinoReadout(serialPort, "i");
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
            catch (Exception exc) 
            {
                // [AT] todo: show exception
                MessageBox.Show("Serial could not be opened, please check that the device is correct one");
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
            SerialPort serialPort = null;

            // Create a new SerialPort object with default settings.
            serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            serialPort.PortName = COM.Text;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.BaudRate = 9600;

            // Set the read/write timeouts
            serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500;

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


        private void AppendData(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendData), new object[] { value });
                return;
            }
            Data.Items.Add(value);

        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            if(started == false)
            {
                Results.Visible = true;
                Form f = Control.ActiveForm;
                f.Size = new Size(f.Size.Width, 750);
                started = true;
                Results.Visible = true;
                Results.Anchor |= AnchorStyles.Bottom;
                port_measurement = COM.Text;
                
                DateTime localDate = DateTime.Now;


                duration = localDate.Hour * 60 * 60 + localDate.Minute * 60 + localDate.Second +
                    Convert.ToInt32(CboxDuration.Text) * 60;

                betweenMesSec = Convert.ToInt32(CboxInterval.Text);

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
                string msg = "Time,U,M,Extra,Box,"; // [AT] csv file header. 

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
                Data.Items.Add(msg); //[AT] Data -- invisible ListBox
                arrayNames = msg; //[AT] header

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
            


        }

        // [AT] appends result to the plot
        private void AppendResult(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendResult), new object[] { value });
                return;
            }

            for(int i = 5;i<arrayNames.Split(',').Length;i++)
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
        private void cancelHeat()
        {
            SerialPort serialPortCancel = null;
            try
            {
                // Create a new SerialPort object with default settings.
                serialPortCancel = new SerialPort();
                
                if (port_measurement == "")
                {
                    serialPortCancel.PortName = port_heating;
                }
                else
                {
                    serialPortCancel.PortName = port_measurement;
                }
                if (serialPortCancel.PortName == "")
                {
                    serialPortCancel.PortName = COM.Text;                    
                }
                    
                    
                serialPortCancel.DataBits = 8;
                serialPortCancel.Parity = Parity.None;
                serialPortCancel.StopBits = StopBits.One;
                serialPortCancel.BaudRate = 9600;

                // Set the read/write timeouts
                serialPortCancel.ReadTimeout = 500;
                serialPortCancel.WriteTimeout = 500;

                serialPortCancel.Open();
                serialPortCancel.DiscardOutBuffer();
                serialPortCancel.DiscardInBuffer();

                String ReceivedData;
                //RecievedData = serialPort.ReadLine();
                //serialPort.DataReceived += new SerialDataReceivedEventHandler(responseHandler);

                string s = ArduinoReadout(serialPortCancel, "C");
                Console.WriteLine(s);

                serialPortCancel.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Serial could not be opened, please check that the device is correct one");
                serialPortCancel.Close();
            }

        }

        private void doAssay()
        {
            // Boolean cont = true;
            bool cont_assay = true;            
            int loop = 0;
            Boolean assay_ready = false;

            do
            {
                DateTime current = DateTime.Now;
				// AT: time when the current measurement started
				int endCycle = current.Hour * 60 * 60 + current.Minute * 60 + current.Second;
                string timestr = current.ToString("s"); //[AT] "s" -- sortable datetime format

				// AT:stop if the specified duration passed (from the textbox)
				if (_exiting || (duration < endCycle))
                {
                    cont_assay = false;
                    if (!_exiting)
                        assay_ready = true;
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

                    AppendData(timestr + "," +
                        currentTemperatureInfo["Up"] + "," +
                        currentTemperatureInfo["Middle"] + "," +
                        currentTemperatureInfo["Extra"] + "," +
                        currentTemperatureInfo["Box"] + "," +
                        ReceivedData);
                        
                    // todo: fix appendData and AppendResult
                    //string resToAppend = loop.ToString() + ",U,M,";  // [AT] not used, so i commented this line

                    AppendResult(loop.ToString() + "," + 
                        currentTemperatureInfo["Up"] + "," +
                        currentTemperatureInfo["Middle"] + "," +
                        currentTemperatureInfo["Extra"] + "," +
                        currentTemperatureInfo["Box"] + "," +
                        ReceivedData);

                    Thread.Sleep(2000); // 2s
                    Console.WriteLine("end sleep 2");

                    serialPort.Close();

                }
                catch (Exception exc)
                {
                    MessageBox.Show("Serial could not be opened, please check that the device is correct one");
                    serialPort.Close();
                }


                Boolean timeRunning = true;

                // wait until getting the next measurement
                do
                {
                    DateTime wait = DateTime.Now;
                    if (endCycle + betweenMesSec < wait.Hour * 60 * 60 + wait.Minute * 60 + wait.Second)
                    {
                        timeRunning = false;
                    }
                    Thread.Sleep(100);
                } while (timeRunning);
                loop += 1;

            } while (cont_assay && (!_exiting));


            // Cancel the heat
            // [AT] don't do canceling here, but only on exit?
            cancelHeat(); 
            
            if (assay_ready)
                MessageBox.Show("Assay ready");   
            else if(_exiting)
                MessageBox.Show("Assay Aborted");
        }

        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //before your loop
                var csv = new StringBuilder();

                for(int i = 0; i<Data.Items.Count;i++)
                {                
                    var newLine = string.Format(Data.Items[i].ToString() + Environment.NewLine);
                    csv.Append(newLine);
                }

                //after your loop
                //[AT] todo: change path option
                //string fname = "Miriam_serial_data.csv";
                string fname = folderName + @"\miriam_" + DateTime.Now.ToString("yyyyddMM_HHmmss") + ".csv";
                Console.WriteLine();                
                Console.WriteLine("Saving csv: {0}", fname);
                // string fname = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Miriam_serial_data.csv";
                File.WriteAllText(fname, csv.ToString());                                                                
            }
            catch (IOException)
            {
                MessageBox.Show("File not writable");
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
            Miriam_Serial.Properties.Settings.Default.settFolderRes = folderBrowserSaveRes.SelectedPath;

            Miriam_Serial.Properties.Settings.Default.settTemperatureMid = CboxTempM.Text;
            Miriam_Serial.Properties.Settings.Default.settTemperatureUp = CboxTempU.Text;
            Miriam_Serial.Properties.Settings.Default.settTemperatureExtra = CboxTempE.Text;
            Miriam_Serial.Properties.Settings.Default.settBoxTemperatureThreshold = CboxTempThr.Text;
            Miriam_Serial.Properties.Settings.Default.settDuration = CboxDuration.Text;

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
            }

            // Cancel the heat    
            cancelHeat();
            Console.WriteLine("Heat cancelled?");

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

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserSaveRes.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserSaveRes.SelectedPath;                
            }
        }

        private void Control_Load(object sender, EventArgs e)
        {
            Console.WriteLine(Miriam_Serial.Properties.Settings.Default.settFolderRes);
            if (Miriam_Serial.Properties.Settings.Default.settFolderRes == "")
            {
                folderName = folderBrowserSaveRes.RootFolder.ToString();                                
            }
            else
            {
                folderName = Miriam_Serial.Properties.Settings.Default.settFolderRes;
                folderBrowserSaveRes.SelectedPath = Miriam_Serial.Properties.Settings.Default.settFolderRes;
            }
            Console.WriteLine("folder: {0}", folderName);
            CboxTempU.Text = Miriam_Serial.Properties.Settings.Default.settTemperatureUp;
            CboxTempM.Text = Miriam_Serial.Properties.Settings.Default.settTemperatureMid;
            CboxTempE.Text = Miriam_Serial.Properties.Settings.Default.settTemperatureExtra;
            CboxDuration.Text = Miriam_Serial.Properties.Settings.Default.settDuration;
            CboxTempThr.Text = Miriam_Serial.Properties.Settings.Default.settBoxTemperatureThreshold;
        }
    }
}
