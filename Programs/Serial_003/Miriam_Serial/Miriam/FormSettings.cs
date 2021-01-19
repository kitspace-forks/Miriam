using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Miriam
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            for (int i = 70; i < 90; i++)
            {
                CboxTempM.Items.Add(i);
            }
            for (int i = 80; i < 110; i++)
            {
                CboxTempU.Items.Add(i);
            }
            for (int i = 60; i < 110; i++)
            {
                CboxTempE.Items.Add(i);
            }
            for (int i = 11; i < 100; i++)
            {
                CboxInterval.Items.Add(i); 
            }


            for (int i = 55; i < 70; i++)
            {
                cBoxMesMTemp.Items.Add(i);                
            }
            for (int i = 80; i < 90; i++)
            {
                cBoxMesUTemp.Items.Add(i);                
            }
            for (int i = 55; i < 90; i++)
            {
                cBoxMesETemp.Items.Add(i);
                
            }
            for (int i = 40; i < 80; i++)
            {
                cBoxMesThrTemp.Items.Add(i);                
            }

            for (int i = 0; i < 150; i++)
            {
                cBoxMesDuration.Items.Add(i);                
            }
            for (int i = 10; i < 600; i++)
            {
                cBoxMesInterval.Items.Add(i);
                //CboxInterval.Items.Add(i); // AT: minimum time a measurement takes is 11 seconds
            }
            //CboxTempU.Text = "90";
            //CboxTempM.Text = "65";
            //CboxTempE.Text = "65";
            ////CboxDuration.Text = "120";
            //CboxInterval.Text = "10";

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // apply assay settings
            Control.settings_measurement.TMiddle = Convert.ToDouble(cBoxMesMTemp.Text, CultureInfo.InvariantCulture);
            Control.settings_measurement.TUp = Convert.ToDouble(cBoxMesUTemp.Text, CultureInfo.InvariantCulture);
            Control.settings_measurement.TExtra = Convert.ToDouble(cBoxMesETemp.Text, CultureInfo.InvariantCulture);
            Control.settings_measurement.TThreshold = Convert.ToDouble(cBoxMesThrTemp.Text, CultureInfo.InvariantCulture);
            Control.settings_measurement.MeasureIntervalSec = Convert.ToInt32(cBoxMesInterval.Text);
            Control.settings_measurement.DurationMin = Convert.ToDouble(cBoxMesDuration.Text, CultureInfo.InvariantCulture);

            // apply melting settings
            Control.melting_enabled = checkBoxEnableMelting.Checked;
            Control.settings_melting["TUp"] = CboxTempU.Text;
            Control.settings_melting["TMiddle"] = CboxTempM.Text;
            Control.settings_melting["TExtra"] = CboxTempE.Text;
            Control.settings_melting["Interval"] = CboxInterval.Text;
            Control.settings_melting["Tolerance"] = CboxTolerance.Text;

            // results storage 
            Control.folderName = folderBrowserSaveRes.SelectedPath;
            Control.filename_prefix = textBoxFnamePrefix.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void checkBoxEnableMelting_CheckedChanged(object sender, EventArgs e)
        {
            panelMelting.Enabled = checkBoxEnableMelting.Checked;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            // melting settings
            checkBoxEnableMelting.Checked = Control.melting_enabled;
            CboxTempU.Text = Control.settings_melting["TUp"];
            CboxTempM.Text = Control.settings_melting["TMiddle"];
            CboxTempE.Text = Control.settings_melting["TExtra"];
            CboxInterval.Text = Control.settings_melting["Interval"];
            CboxTolerance.Text = Control.settings_melting["Tolerance"];

            // measurement settings
            cBoxMesMTemp.Text = Control.settings_measurement.TMiddle.ToString();
            cBoxMesUTemp.Text = Control.settings_measurement.TUp.ToString();
            cBoxMesETemp.Text = Control.settings_measurement.TExtra.ToString();
            cBoxMesThrTemp.Text = Control.settings_measurement.TThreshold.ToString();
            cBoxMesInterval.Text = Control.settings_measurement.MeasureIntervalSec.ToString();
            cBoxMesDuration.Text = Control.settings_measurement.DurationMin.ToString();

            // results storage folder
            folderBrowserSaveRes.SelectedPath = Control.folderName;            
            textBoxFolder.Text = folderBrowserSaveRes.SelectedPath;
            textBoxFnamePrefix.Text = Control.filename_prefix;
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserSaveRes.ShowDialog();
            if (result == DialogResult.OK)
            {                
                textBoxFolder.Text = folderBrowserSaveRes.SelectedPath;
            }
        }

        private void cBoxMesInterval_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
