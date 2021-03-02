using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
//using YamlDotNet.Serialization;


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
            apply_settings();

            this.DialogResult = DialogResult.OK;
        }

        private void apply_settings()
        {

            //for correct string <-> double convertion using '.' as a decimal separator
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // apply assay settings
            Control.settings_measurement.TMiddle = Convert.ToDouble(cBoxMesMTemp.Text);
            Control.settings_measurement.TUp = Convert.ToDouble(cBoxMesUTemp.Text);
            Control.settings_measurement.TExtra = Convert.ToDouble(cBoxMesETemp.Text);
            Control.settings_measurement.TThreshold = Convert.ToDouble(cBoxMesThrTemp.Text);
            Control.settings_measurement.MeasureIntervalSec = Convert.ToInt32(cBoxMesInterval.Text);
            Control.settings_measurement.DurationMin = Convert.ToDouble(cBoxMesDuration.Text);

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

            // update the settings (redundant copy!)
            Control.settings.measurement = Control.settings_measurement;
            Control.settings.melting = Control.settings_melting;
            Control.settings.melting_enabled = Control.melting_enabled;

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
            //for correct string <-> double convertion using '.' as a decimal separator
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

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

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            apply_settings();

            var stringBuilder = new StringBuilder();
            var serializer = new Serializer();

            var yaml_all = serializer.Serialize(Control.settings);
            Console.WriteLine(yaml_all);

            SaveFileDialog saveSettingsYaml = new SaveFileDialog();
            saveSettingsYaml.InitialDirectory = folderBrowserSaveRes.SelectedPath;
            saveSettingsYaml.FileName = "miriam_settings.yaml";
            saveSettingsYaml.Filter = "Yaml files|*.yaml;*.yml|All files|*.*";
            saveSettingsYaml.Title = "Save measurement settings...";
            saveSettingsYaml.ShowDialog();
            if (saveSettingsYaml.FileName != "")
            {
                File.WriteAllText(saveSettingsYaml.FileName, yaml_all + Environment.NewLine);
            }
        }

        private void buttonLoadSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadSettingsYaml = new OpenFileDialog();
            loadSettingsYaml.InitialDirectory = folderBrowserSaveRes.SelectedPath;
            loadSettingsYaml.FileName = "miriam_settings.yaml";
            loadSettingsYaml.Filter = "Yaml files|*.yaml;*.yml|All files|*.*";
            loadSettingsYaml.Title = "Load measurement settings...";
            loadSettingsYaml.ShowDialog();

            if (loadSettingsYaml.FileName != "")
            {
                Console.WriteLine("loading file: {0}", loadSettingsYaml.FileName);
                //                Control.load_yam_settings(loadSettingsYaml.FileName);

                var deserializer = new DeserializerBuilder().Build();

                using (var reader = new StreamReader(loadSettingsYaml.FileName))
                {
                    // Load the stream
                    var yaml = new YamlStream();
                    yaml.Load(reader);
                    var mapping = (YamlMappingNode)yaml.Documents[0].RootNode;

                    var measurement_params = (YamlMappingNode)mapping.Children[new YamlScalarNode("measurement")];
                    var melting_params = (YamlMappingNode)mapping.Children[new YamlScalarNode("melting")];

                    foreach (var entry in mapping.Children)
                    {
                        var key = ((YamlScalarNode)entry.Key).Value;
                        Console.WriteLine(key);
                        if (key.ToString() == "melting_enabled")
                            checkBoxEnableMelting.Checked = bool.Parse(entry.Value.ToString());
                    }

                    foreach (var entry in measurement_params.Children)
                    {
                        var key = ((YamlScalarNode)entry.Key).Value;
                        Console.WriteLine(key);
                        switch (key)
                        {
                            case "TUp":
                                cBoxMesUTemp.Text = entry.Value.ToString();
                                break;
                            case "TMiddle":
                                cBoxMesMTemp.Text = entry.Value.ToString();
                                break;
                            case "TExtra":
                                cBoxMesETemp.Text = entry.Value.ToString();
                                break;
                            case "TThreshold":
                                cBoxMesThrTemp.Text = entry.Value.ToString();
                                break;
                            case "MeasureIntervalSec":
                                cBoxMesInterval.Text = entry.Value.ToString();
                                break;
                            case "DurationMin":
                                cBoxMesDuration.Text = entry.Value.ToString();
                                break;
                        }
                    }
                    foreach (var entry in melting_params.Children)
                    {
                        var key = ((YamlScalarNode)entry.Key).Value;
                        Console.WriteLine(key);
                        switch (key)
                        {
                            case "TUp":
                                CboxTempU.Text = entry.Value.ToString();
                                break;
                            case "TMiddle":
                                CboxTempM.Text = entry.Value.ToString();
                                break;
                            case "TExtra":
                                CboxTempE.Text = entry.Value.ToString();
                                break;
                            case "Interval":
                                CboxInterval.Text = entry.Value.ToString();
                                break;
                            case "Tolerance":
                                CboxTolerance.Text = entry.Value.ToString();
                                break;
                        }
                    }
                }
            }   
        }
    }
}
