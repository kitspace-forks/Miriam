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
            this.buttonFillAll = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.LabelTempBoxC = new System.Windows.Forms.Label();
            this.LabelTempEC = new System.Windows.Forms.Label();
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
            // buttonChangeSettings
            // 
            this.buttonChangeSettings.Location = new System.Drawing.Point(8, 53);
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
            this.ClientSize = new System.Drawing.Size(555, 375);
            this.Controls.Add(this.buttonChangeSettings);
            this.Controls.Add(this.LabelTempBoxC);
            this.Controls.Add(this.LabelTempEC);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonFillAll);
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
        private Button buttonFillAll;
        private Button buttonClearAll;
        private SaveFileDialog saveFileDialog1;
        private Label LabelTempBoxC;
        private Label LabelTempEC;
        private Button buttonChangeSettings;
    }
}

