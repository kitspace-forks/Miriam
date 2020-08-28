﻿using System;
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
        private string port = "";
        private Boolean started = false;
        private int nGridRows = 8;
        private int nGridCols = 12;


        public Control()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            string[] ports = SerialPort.GetPortNames();
            
            for(int i = 0; i <ports.Length;i++)
            {
                COM.Items.Add(ports[i]);
            }

            if(ports.Length != 0)
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
            for (int i = 0; i < 150; i++)
            {
                CboxDuration.Items.Add(i);
            }
            CboxTempU.Text = "90";
            CboxTempM.Text = "65";
            CboxDuration.Text = "120";

            Plate.ColumnCount = nGridCols;
            for (int i = 0; i < nGridCols; i++)
            {
                DataGridViewColumn column = Plate.Columns[i];

                column.Name = (i+1).ToString();
                column.Width = 40;
            }

            Plate.AllowUserToAddRows = false;



            //Plate.RowCount = 8;

            String alphabets = "ABCDEFGH";
            String cur_letter;
            for (int i = 0; i<nGridRows; i++)
            {                                
                Plate.Rows.Add("", "", "", "", "", "", "", "", "", "", "", ""); // [AT] todo: use nGridCols as a number of elements
                cur_letter = alphabets[i].ToString(); //[AT] fill cells automatically 
                Plate.Rows[i].HeaderCell.Value = cur_letter;
                Plate.RowHeadersWidth = Plate.RowHeadersWidth + 1;                
                for (int col = 0; col < Plate.ColumnCount; col++)
                {
                    Plate.Rows[i].Cells[col].Value = cur_letter + Plate.Columns[col].Name;
                }
            }

            //Results.Visible = true;


        }
        
        private void ButtonHeat_Click(object sender, EventArgs e)
        {
            // Set upper temperature

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

                String ReceivedData;

                //RecievedData = serialPort.ReadLine();
                //serialPort.DataReceived += new SerialDataReceivedEventHandler(responseHandler);
                // [AT] SW 'M param' (middle wanted temperature, i.e. M 63) - FW 'temperatureMiddleSet'
                serialPort.Write("M " + CboxTempM.Text + "\r\n");

                Boolean conti = true;
                do
                {
                    ReceivedData = serialPort.ReadLine();
                    if (ReceivedData.Contains('$'))
                    {
                        conti = false;
                    }
                } while (conti);


                ReceivedData = "";

                serialPort.Write("U " + CboxTempU.Text + "\r\n");

                conti = true;
                do
                {
                    ReceivedData = serialPort.ReadLine();
                    if (ReceivedData.Contains('$'))
                    {
                        conti = false;
                    }
                } while (conti);


                ReceivedData = "";

                serialPort.Write("H\r\n");

                conti = true;
                do
                {
                    ReceivedData = serialPort.ReadLine();
                    if (ReceivedData.Contains('$'))
                    {
                        conti = false;
                    }
                } while (conti);


                ReceivedData = "";

                serialPort.Write("i\r\n");

                conti = true;
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

                AppendHeatLabel("Temperature U:" + ReceivedData.Split(',')[4] + "," + "Temperature M:" + ReceivedData.Split(',')[5]);


                serialPort.Close();

            }
            catch (Exception exc)
            {
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
            LabelTempUC.Text = value.Split(',')[0];
            LabelTempMC.Text = value.Split(',')[1];

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

                String ReceivedData;
                //RecievedData = serialPort.ReadLine();
                //serialPort.DataReceived += new SerialDataReceivedEventHandler(responseHandler);
                serialPort.Write("i" + "\r\n");

                Boolean conti = true;
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

                AppendHeatLabel("Temperature U:" + ReceivedData.Split(',')[4] + "," + "Temperature M:" + ReceivedData.Split(',')[5]);

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
                f.Size = new Size(f.Size.Width, 700);
                started = true;
                Results.Visible = true;
                port = COM.Text;

                DateTime localDate = DateTime.Now;


                duration = localDate.Hour * 60 * 60 + localDate.Minute * 60 + localDate.Second +
                    Convert.ToInt32(CboxDuration.Text) * 60;

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

                List<int> list = new List<int>();
                int counter = 3;
                string msg = "Time,U,M,";

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

                Data.Items.Add(msg);
                arrayNames = msg;

                Color[] clr;

                clr = new Color[10];
                clr[0] = Color.Red;
                clr[1] = Color.Blue;
                clr[2] = Color.Yellow;
                clr[3] = Color.Green;
                clr[4] = Color.Black;
                clr[5] = Color.Aqua;
                clr[6] = Color.DimGray;
                clr[7] = Color.DarkViolet;
                clr[8] = Color.DeepPink;
                clr[9] = Color.Gray;

                int clrsUsed = 0;

                

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


                Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(doAssay));

                // put to background to force to close if program exit
                t.IsBackground = true;


                t.Start();
            }
            


        }


        private void AppendResult(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendResult), new object[] { value });
                return;
            }

            for(int i = 3;i<arrayNames.Split(',').Length;i++)
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

        private void doAssay()
        {
            Boolean cont = true;

            int loop = 0;

            do
            {
                DateTime current = DateTime.Now;
				// AT: time when the current measurement started
				int endCycle = current.Hour * 60 * 60 + current.Minute * 60 + current.Second; 

				// AT:stop if the specified duration passed (from the textbox)
				if (duration < endCycle) 
                {
                    cont = false;
                    
                }
                
                // [AT][?] why recreate this object for every cycle? Would it be enough to create once? + can put it in a child class
                SerialPort serialPort = null;

                // Create a new SerialPort object with default settings.
                serialPort = new SerialPort();

                // Allow the user to set the appropriate properties.
                serialPort.PortName = port;
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
                    //RecievedData = serialPort.ReadLine();
                    //serialPort.DataReceived += new SerialDataReceivedEventHandler(responseHandler);
                    serialPort.Write("R" + "\r\n"); // [AT] SW 'R' (read assay) - FW 'A1,A2,A3...E12' 

                    Boolean conti = true;
                    do
                    {
                        ReceivedData = serialPort.ReadLine(); // [AT] can be more than 1 line coming from the serial port, and we are interested in one containing $ 
                        if (ReceivedData.Contains('$'))
                        {
                            conti = false;
                        }
                    } while (conti);


                    conti = true;

                    serialPort.Write("i" + "\r\n");
                    // [AT] SW 'i' (info) - FW '[0] outputMiddle, [1] outputUpper, [2] temperatureMiddle, [3] temperatureUpper, [4] temperatureMiddleC, [5] temperatureUpperC'
                    String ReceivedData1;
                    do
                    {
                        ReceivedData1 = serialPort.ReadLine();
                        if (ReceivedData1.Contains('$'))
                        {
                            conti = false;
                        }
                    } while (conti);


                    conti = true;


                    Thread.Sleep(2000); // [AT] sleep 2s
                   
                    ReceivedData = ReceivedData.Replace("$", "");
                    ReceivedData1 = ReceivedData1.Replace("$", "");
                    ReceivedData = ReceivedData.Replace("\r", "");
                    ReceivedData1 = ReceivedData1.Replace("\r", "");
                    ReceivedData = ReceivedData.Replace("\n", "");
                    ReceivedData1 = ReceivedData1.Replace("\n", "");
                    // [AT] 4: temperatureMiddleC, 5: temperatureUpperC. Check what is C and what is correct? (in this string it is the other way around). Upd: works correct, so probably there is a typo in the documentation.
                    AppendHeatLabel("Temperature U:" + ReceivedData1.Split(',')[4] + "," + "Temperature M:" + ReceivedData1.Split(',')[5]);

                    // [AT] The columns of the grid are reversed, it is received as A12,...A1, B12,...,B1, ...
                    ReceivedData = ReverseColumnOrder(ReceivedData);

                    AppendData(loop.ToString() + "," + ReceivedData1.Split(',')[4] + "," +
                    ReceivedData1.Split(',')[5] + "," + ReceivedData);

                    string resToAppend = loop.ToString() + ",U,M,";
                
                    AppendResult(loop.ToString() + "," + ReceivedData1.Split(',')[4] + "," +
                        ReceivedData1.Split(',')[5] + "," + ReceivedData);

                    Thread.Sleep(2000);

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
                    if (endCycle + 2 < wait.Hour * 60 * 60 + wait.Minute * 60 + wait.Second)
                    {
                        timeRunning = false;
                    }
                    Thread.Sleep(100);
                } while (timeRunning);
                loop += 1;

            } while (cont);

            // Cancel the heat
            SerialPort serialPortCancel = null; 
            try
            {


                // Create a new SerialPort object with default settings.
                serialPortCancel = new SerialPort();

                // Allow the user to set the appropriate properties.
                serialPortCancel.PortName = port;
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
                serialPortCancel.Write("C" + "\r\n");

                Boolean conti = true;
                do
                {
                    ReceivedData = serialPortCancel.ReadLine();
                    if (ReceivedData.Contains('$'))
                    {
                        conti = false;
                    }
                } while (conti);


                ReceivedData = ReceivedData.Replace("$", "");
                ReceivedData = ReceivedData.Replace("\r", "");
                ReceivedData = ReceivedData.Replace("\n", "");

                serialPortCancel.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Serial could not be opened, please check that the device is correct one");
                serialPortCancel.Close();
            }
            MessageBox.Show("Assay ready");
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
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Miriam_serial_data.csv", csv.ToString());
            }
            catch (IOException)
            {
                MessageBox.Show("File not writable");
            }
        }

        void OnProcessExit(object sender, EventArgs e)
        {
            // Cancel the heat
            SerialPort serialPortCancel = null;
            try
            {


                // Create a new SerialPort object with default settings.
                serialPortCancel = new SerialPort();

                // Allow the user to set the appropriate properties.
                serialPortCancel.PortName = COM.SelectedItem.ToString();
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
                serialPortCancel.Write("C" + "\r\n");

                Boolean conti = true;
                do
                {
                    ReceivedData = serialPortCancel.ReadLine();
                    if (ReceivedData.Contains('$'))
                    {
                        conti = false;
                    }
                } while (conti);


                ReceivedData = ReceivedData.Replace("$", "");
                ReceivedData = ReceivedData.Replace("\r", "");
                ReceivedData = ReceivedData.Replace("\n", "");

                serialPortCancel.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show("Serial could not be opened, please check that the device is correct one. The heat could not be turned off.");
                serialPortCancel.Close();
            }
        }
    }
}
