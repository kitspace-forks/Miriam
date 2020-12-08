using System;
using System.Windows.Forms;

namespace Miriam
{
    partial class Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Control));
            this.ButtonStart = new System.Windows.Forms.Button();
            this.LabelTempU = new System.Windows.Forms.Label();
            this.LabelTempM = new System.Windows.Forms.Label();
            this.LabelDuration = new System.Windows.Forms.Label();
            this.CboxTempU = new System.Windows.Forms.ComboBox();
            this.CboxTempM = new System.Windows.Forms.ComboBox();
            this.CboxDuration = new System.Windows.Forms.ComboBox();
            this.Plate = new System.Windows.Forms.DataGridView();
            this.LabelTempUC = new System.Windows.Forms.Label();
            this.LabelTempMC = new System.Windows.Forms.Label();
            this.ButtonHeat = new System.Windows.Forms.Button();
            this.AskHeat = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.ListBox();
            this.Results = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ButtonWrite = new System.Windows.Forms.Button();
            this.COM_label = new System.Windows.Forms.Label();
            this.COM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboxInterval = new System.Windows.Forms.ComboBox();
            this.buttonFillAll = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonSaveAs = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserSaveRes = new System.Windows.Forms.FolderBrowserDialog();
            this.LabelTempBoxC = new System.Windows.Forms.Label();
            this.LabelTempEC = new System.Windows.Forms.Label();
            this.labelTempE = new System.Windows.Forms.Label();
            this.CboxTempE = new System.Windows.Forms.ComboBox();
            this.labelThr = new System.Windows.Forms.Label();
            this.CboxTempThr = new System.Windows.Forms.ComboBox();
            this.buttonChangeSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Plate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Results)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(361, 6);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(75, 64);
            this.ButtonStart.TabIndex = 12;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // LabelTempU
            // 
            this.LabelTempU.AutoSize = true;
            this.LabelTempU.Location = new System.Drawing.Point(103, 51);
            this.LabelTempU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempU.Name = "LabelTempU";
            this.LabelTempU.Size = new System.Drawing.Size(62, 13);
            this.LabelTempU.TabIndex = 18;
            this.LabelTempU.Text = "Upper temp";
            // 
            // LabelTempM
            // 
            this.LabelTempM.AutoSize = true;
            this.LabelTempM.Location = new System.Drawing.Point(11, 51);
            this.LabelTempM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempM.Name = "LabelTempM";
            this.LabelTempM.Size = new System.Drawing.Size(64, 13);
            this.LabelTempM.TabIndex = 17;
            this.LabelTempM.Text = "Middle temp";
            // 
            // LabelDuration
            // 
            this.LabelDuration.AutoSize = true;
            this.LabelDuration.Location = new System.Drawing.Point(11, 85);
            this.LabelDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelDuration.Name = "LabelDuration";
            this.LabelDuration.Size = new System.Drawing.Size(69, 13);
            this.LabelDuration.TabIndex = 16;
            this.LabelDuration.Text = "Duration[min]";
            // 
            // CboxTempU
            // 
            this.CboxTempU.FormattingEnabled = true;
            this.CboxTempU.Location = new System.Drawing.Point(103, 64);
            this.CboxTempU.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTempU.Name = "CboxTempU";
            this.CboxTempU.Size = new System.Drawing.Size(82, 21);
            this.CboxTempU.TabIndex = 15;
            // 
            // CboxTempM
            // 
            this.CboxTempM.FormattingEnabled = true;
            this.CboxTempM.Location = new System.Drawing.Point(11, 64);
            this.CboxTempM.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTempM.Name = "CboxTempM";
            this.CboxTempM.Size = new System.Drawing.Size(82, 21);
            this.CboxTempM.TabIndex = 14;
            // 
            // CboxDuration
            // 
            this.CboxDuration.FormattingEnabled = true;
            this.CboxDuration.Location = new System.Drawing.Point(11, 100);
            this.CboxDuration.Margin = new System.Windows.Forms.Padding(2);
            this.CboxDuration.Name = "CboxDuration";
            this.CboxDuration.Size = new System.Drawing.Size(82, 21);
            this.CboxDuration.TabIndex = 13;
            // 
            // Plate
            // 
            this.Plate.AllowDrop = true;
            this.Plate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Plate.Location = new System.Drawing.Point(5, 125);
            this.Plate.Margin = new System.Windows.Forms.Padding(2);
            this.Plate.Name = "Plate";
            this.Plate.RowTemplate.Height = 28;
            this.Plate.Size = new System.Drawing.Size(539, 255);
            this.Plate.TabIndex = 19;
            // 
            // LabelTempUC
            // 
            this.LabelTempUC.AutoSize = true;
            this.LabelTempUC.Location = new System.Drawing.Point(5, 6);
            this.LabelTempUC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempUC.Name = "LabelTempUC";
            this.LabelTempUC.Size = new System.Drawing.Size(81, 13);
            this.LabelTempUC.TabIndex = 20;
            this.LabelTempUC.Text = "Temperature U:";
            // 
            // LabelTempMC
            // 
            this.LabelTempMC.AutoSize = true;
            this.LabelTempMC.Location = new System.Drawing.Point(137, 6);
            this.LabelTempMC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempMC.Name = "LabelTempMC";
            this.LabelTempMC.Size = new System.Drawing.Size(82, 13);
            this.LabelTempMC.TabIndex = 21;
            this.LabelTempMC.Text = "Temperature M:";
            // 
            // ButtonHeat
            // 
            this.ButtonHeat.Location = new System.Drawing.Point(282, 6);
            this.ButtonHeat.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonHeat.Name = "ButtonHeat";
            this.ButtonHeat.Size = new System.Drawing.Size(75, 30);
            this.ButtonHeat.TabIndex = 22;
            this.ButtonHeat.Text = "Heat";
            this.ButtonHeat.UseVisualStyleBackColor = true;
            this.ButtonHeat.Click += new System.EventHandler(this.ButtonHeat_Click);
            // 
            // AskHeat
            // 
            this.AskHeat.Location = new System.Drawing.Point(282, 40);
            this.AskHeat.Margin = new System.Windows.Forms.Padding(2);
            this.AskHeat.Name = "AskHeat";
            this.AskHeat.Size = new System.Drawing.Size(75, 30);
            this.AskHeat.TabIndex = 23;
            this.AskHeat.Text = "Ask heat";
            this.AskHeat.UseVisualStyleBackColor = true;
            this.AskHeat.Click += new System.EventHandler(this.AskHeat_Click);
            // 
            // Data
            // 
            this.Data.FormattingEnabled = true;
            this.Data.Location = new System.Drawing.Point(262, 146);
            this.Data.Margin = new System.Windows.Forms.Padding(2);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(42, 56);
            this.Data.TabIndex = 24;
            this.Data.Visible = false;
            // 
            // Results
            // 
            this.Results.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.Results.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Results.Legends.Add(legend1);
            this.Results.Location = new System.Drawing.Point(5, 375);
            this.Results.Margin = new System.Windows.Forms.Padding(2);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(531, 332);
            this.Results.TabIndex = 25;
            this.Results.Text = "chart1";
            this.Results.Visible = false;
            // 
            // ButtonWrite
            // 
            this.ButtonWrite.Location = new System.Drawing.Point(441, 6);
            this.ButtonWrite.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonWrite.Name = "ButtonWrite";
            this.ButtonWrite.Size = new System.Drawing.Size(75, 30);
            this.ButtonWrite.TabIndex = 26;
            this.ButtonWrite.Text = "Write CSV";
            this.ButtonWrite.UseVisualStyleBackColor = true;
            this.ButtonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
            // 
            // COM_label
            // 
            this.COM_label.AutoSize = true;
            this.COM_label.Location = new System.Drawing.Point(441, 40);
            this.COM_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.COM_label.Name = "COM_label";
            this.COM_label.Size = new System.Drawing.Size(52, 13);
            this.COM_label.TabIndex = 28;
            this.COM_label.Text = "COM port";
            // 
            // COM
            // 
            this.COM.FormattingEnabled = true;
            this.COM.Location = new System.Drawing.Point(441, 55);
            this.COM.Margin = new System.Windows.Forms.Padding(2);
            this.COM.Name = "COM";
            this.COM.Size = new System.Drawing.Size(82, 21);
            this.COM.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Measure interval [s]";
            // 
            // CboxInterval
            // 
            this.CboxInterval.FormattingEnabled = true;
            this.CboxInterval.Location = new System.Drawing.Point(103, 102);
            this.CboxInterval.Margin = new System.Windows.Forms.Padding(2);
            this.CboxInterval.Name = "CboxInterval";
            this.CboxInterval.Size = new System.Drawing.Size(99, 21);
            this.CboxInterval.TabIndex = 30;
            // 
            // buttonFillAll
            // 
            this.buttonFillAll.Location = new System.Drawing.Point(388, 98);
            this.buttonFillAll.Name = "buttonFillAll";
            this.buttonFillAll.Size = new System.Drawing.Size(75, 23);
            this.buttonFillAll.TabIndex = 33;
            this.buttonFillAll.Text = "Fill all";
            this.buttonFillAll.UseVisualStyleBackColor = true;
            this.buttonFillAll.Click += new System.EventHandler(this.buttonFillAll_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(469, 97);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAll.TabIndex = 34;
            this.buttonClearAll.Text = "Clear all";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonSaveAs
            // 
            this.buttonSaveAs.Location = new System.Drawing.Point(521, 7);
            this.buttonSaveAs.Name = "buttonSaveAs";
            this.buttonSaveAs.Size = new System.Drawing.Size(28, 29);
            this.buttonSaveAs.TabIndex = 35;
            this.buttonSaveAs.Text = "...";
            this.buttonSaveAs.UseVisualStyleBackColor = true;
            this.buttonSaveAs.Click += new System.EventHandler(this.buttonSaveAs_Click);
            // 
            // folderBrowserSaveRes
            // 
            this.folderBrowserSaveRes.Description = "Select the directory to save the measurements data";
            // 
            // LabelTempBoxC
            // 
            this.LabelTempBoxC.AutoSize = true;
            this.LabelTempBoxC.Location = new System.Drawing.Point(137, 21);
            this.LabelTempBoxC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempBoxC.Name = "LabelTempBoxC";
            this.LabelTempBoxC.Size = new System.Drawing.Size(91, 13);
            this.LabelTempBoxC.TabIndex = 37;
            this.LabelTempBoxC.Text = "Temperature Box:";
            // 
            // LabelTempEC
            // 
            this.LabelTempEC.AutoSize = true;
            this.LabelTempEC.Location = new System.Drawing.Point(5, 21);
            this.LabelTempEC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempEC.Name = "LabelTempEC";
            this.LabelTempEC.Size = new System.Drawing.Size(97, 13);
            this.LabelTempEC.TabIndex = 36;
            this.LabelTempEC.Text = "Temperature Extra:";
            // 
            // labelTempE
            // 
            this.labelTempE.AutoSize = true;
            this.labelTempE.Location = new System.Drawing.Point(196, 51);
            this.labelTempE.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTempE.Name = "labelTempE";
            this.labelTempE.Size = new System.Drawing.Size(57, 13);
            this.labelTempE.TabIndex = 39;
            this.labelTempE.Text = "Extra temp";
            // 
            // CboxTempE
            // 
            this.CboxTempE.FormattingEnabled = true;
            this.CboxTempE.Location = new System.Drawing.Point(196, 64);
            this.CboxTempE.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTempE.Name = "CboxTempE";
            this.CboxTempE.Size = new System.Drawing.Size(82, 21);
            this.CboxTempE.TabIndex = 38;
            // 
            // labelThr
            // 
            this.labelThr.AutoSize = true;
            this.labelThr.Location = new System.Drawing.Point(221, 87);
            this.labelThr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelThr.Name = "labelThr";
            this.labelThr.Size = new System.Drawing.Size(97, 13);
            this.labelThr.TabIndex = 41;
            this.labelThr.Text = "Box temp threshold";
            // 
            // CboxTempThr
            // 
            this.CboxTempThr.FormattingEnabled = true;
            this.CboxTempThr.Location = new System.Drawing.Point(221, 100);
            this.CboxTempThr.Margin = new System.Windows.Forms.Padding(2);
            this.CboxTempThr.Name = "CboxTempThr";
            this.CboxTempThr.Size = new System.Drawing.Size(82, 21);
            this.CboxTempThr.TabIndex = 40;
            // 
            // buttonChangeSettings
            // 
            this.buttonChangeSettings.Location = new System.Drawing.Point(308, 98);
            this.buttonChangeSettings.Name = "buttonChangeSettings";
            this.buttonChangeSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeSettings.TabIndex = 42;
            this.buttonChangeSettings.Text = "Settings...";
            this.buttonChangeSettings.UseVisualStyleBackColor = true;
            this.buttonChangeSettings.Click += new System.EventHandler(this.buttonChangeSettings_Click);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(555, 373);
            this.Controls.Add(this.buttonChangeSettings);
            this.Controls.Add(this.labelThr);
            this.Controls.Add(this.CboxTempThr);
            this.Controls.Add(this.labelTempE);
            this.Controls.Add(this.CboxTempE);
            this.Controls.Add(this.LabelTempBoxC);
            this.Controls.Add(this.LabelTempEC);
            this.Controls.Add(this.buttonSaveAs);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonFillAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CboxInterval);
            this.Controls.Add(this.COM);
            this.Controls.Add(this.COM_label);
            this.Controls.Add(this.ButtonWrite);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.AskHeat);
            this.Controls.Add(this.ButtonHeat);
            this.Controls.Add(this.LabelTempMC);
            this.Controls.Add(this.LabelTempUC);
            this.Controls.Add(this.Plate);
            this.Controls.Add(this.LabelTempU);
            this.Controls.Add(this.LabelTempM);
            this.Controls.Add(this.LabelDuration);
            this.Controls.Add(this.CboxTempU);
            this.Controls.Add(this.CboxTempM);
            this.Controls.Add(this.CboxDuration);
            this.Controls.Add(this.ButtonStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Control";
            this.Text = "Control_Serial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Control_FormClosing);
            this.Load += new System.EventHandler(this.Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Plate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Results)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Label LabelTempU;
        private System.Windows.Forms.Label LabelTempM;
        private System.Windows.Forms.Label LabelDuration;
        private System.Windows.Forms.ComboBox CboxTempU;
        private System.Windows.Forms.ComboBox CboxTempM;
        private System.Windows.Forms.ComboBox CboxDuration;
        private System.Windows.Forms.DataGridView Plate;
        private Label LabelTempUC;
        private Label LabelTempMC;
        private Button ButtonHeat;
        private Button AskHeat;
        private ListBox Data;
        private System.Windows.Forms.DataVisualization.Charting.Chart Results;
        private Button ButtonWrite;
        private Label COM_label;
        private ComboBox COM;
        private Label label1;
        private ComboBox CboxInterval;
        private Button buttonFillAll;
        private Button buttonClearAll;
        private Button buttonSaveAs;
        private SaveFileDialog saveFileDialog1;
        private FolderBrowserDialog folderBrowserSaveRes;
        private Label LabelTempBoxC;
        private Label LabelTempEC;
        private Label labelTempE;
        private ComboBox CboxTempE;
        private Label labelThr;
        private ComboBox CboxTempThr;
        private Button buttonChangeSettings;
    }
}

