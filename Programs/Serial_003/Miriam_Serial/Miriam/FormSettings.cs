using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Control.melting_enabled = checkBoxEnableMelting.Checked;
            Control.settings_melting["TUp"] = CboxTempU.Text;
            Control.settings_melting["TMiddle"] = CboxTempM.Text;
            Control.settings_melting["TExtra"] = CboxTempE.Text;
            Control.settings_melting["Interval"] = CboxInterval.Text;
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
            checkBoxEnableMelting.Checked = Control.melting_enabled;
            CboxTempU.Text = Control.settings_melting["TUp"];
            CboxTempM.Text = Control.settings_melting["TMiddle"];
            CboxTempE.Text = Control.settings_melting["TExtra"];
            CboxInterval.Text = Control.settings_melting["Interval"];
            CboxTolerance.Text = Control.settings_melting["Tolerance"];
        }
    }
}
