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
            ((System.ComponentModel.ISupportInitialize)(this.Plate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Results)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(437, 6);
            this.ButtonStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.LabelTempU.Location = new System.Drawing.Point(90, 36);
            this.LabelTempU.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempU.Name = "LabelTempU";
            this.LabelTempU.Size = new System.Drawing.Size(62, 13);
            this.LabelTempU.TabIndex = 18;
            this.LabelTempU.Text = "Upper temp";
            // 
            // LabelTempM
            // 
            this.LabelTempM.AutoSize = true;
            this.LabelTempM.Location = new System.Drawing.Point(5, 36);
            this.LabelTempM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempM.Name = "LabelTempM";
            this.LabelTempM.Size = new System.Drawing.Size(64, 13);
            this.LabelTempM.TabIndex = 17;
            this.LabelTempM.Text = "Middle temp";
            // 
            // LabelDuration
            // 
            this.LabelDuration.AutoSize = true;
            this.LabelDuration.Location = new System.Drawing.Point(177, 36);
            this.LabelDuration.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelDuration.Name = "LabelDuration";
            this.LabelDuration.Size = new System.Drawing.Size(69, 13);
            this.LabelDuration.TabIndex = 16;
            this.LabelDuration.Text = "Duration[min]";
            // 
            // CboxTempU
            // 
            this.CboxTempU.FormattingEnabled = true;
            this.CboxTempU.Location = new System.Drawing.Point(93, 51);
            this.CboxTempU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CboxTempU.Name = "CboxTempU";
            this.CboxTempU.Size = new System.Drawing.Size(82, 21);
            this.CboxTempU.TabIndex = 15;
            // 
            // CboxTempM
            // 
            this.CboxTempM.FormattingEnabled = true;
            this.CboxTempM.Location = new System.Drawing.Point(8, 51);
            this.CboxTempM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CboxTempM.Name = "CboxTempM";
            this.CboxTempM.Size = new System.Drawing.Size(82, 21);
            this.CboxTempM.TabIndex = 14;
            // 
            // CboxDuration
            // 
            this.CboxDuration.FormattingEnabled = true;
            this.CboxDuration.Location = new System.Drawing.Point(177, 51);
            this.CboxDuration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CboxDuration.Name = "CboxDuration";
            this.CboxDuration.Size = new System.Drawing.Size(82, 21);
            this.CboxDuration.TabIndex = 13;
            // 
            // Plate
            // 
            this.Plate.AllowDrop = true;
            this.Plate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Plate.Location = new System.Drawing.Point(8, 73);
            this.Plate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Plate.Name = "Plate";
            this.Plate.RowTemplate.Height = 28;
            this.Plate.Size = new System.Drawing.Size(537, 255);
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
            this.LabelTempMC.Location = new System.Drawing.Point(117, 6);
            this.LabelTempMC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelTempMC.Name = "LabelTempMC";
            this.LabelTempMC.Size = new System.Drawing.Size(82, 13);
            this.LabelTempMC.TabIndex = 21;
            this.LabelTempMC.Text = "Temperature M:";
            // 
            // ButtonHeat
            // 
            this.ButtonHeat.Location = new System.Drawing.Point(358, 6);
            this.ButtonHeat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonHeat.Name = "ButtonHeat";
            this.ButtonHeat.Size = new System.Drawing.Size(75, 30);
            this.ButtonHeat.TabIndex = 22;
            this.ButtonHeat.Text = "Heat";
            this.ButtonHeat.UseVisualStyleBackColor = true;
            this.ButtonHeat.Click += new System.EventHandler(this.ButtonHeat_Click);
            // 
            // AskHeat
            // 
            this.AskHeat.Location = new System.Drawing.Point(358, 40);
            this.AskHeat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.Data.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(42, 56);
            this.Data.TabIndex = 24;
            this.Data.Visible = false;
            // 
            // Results
            // 
            chartArea1.Name = "ChartArea1";
            this.Results.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Results.Legends.Add(legend1);
            this.Results.Location = new System.Drawing.Point(8, 332);
            this.Results.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Results.Name = "Results";
            this.Results.Size = new System.Drawing.Size(537, 315);
            this.Results.TabIndex = 25;
            this.Results.Text = "chart1";
            this.Results.Visible = false;
            // 
            // ButtonWrite
            // 
            this.ButtonWrite.Location = new System.Drawing.Point(517, 6);
            this.ButtonWrite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.COM_label.Location = new System.Drawing.Point(514, 36);
            this.COM_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.COM_label.Name = "COM_label";
            this.COM_label.Size = new System.Drawing.Size(52, 13);
            this.COM_label.TabIndex = 28;
            this.COM_label.Text = "COM port";
            // 
            // COM
            // 
            this.COM.FormattingEnabled = true;
            this.COM.Location = new System.Drawing.Point(517, 51);
            this.COM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.COM.Name = "COM";
            this.COM.Size = new System.Drawing.Size(82, 21);
            this.COM.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Measure interval [s]";
            // 
            // CboxInterval
            // 
            this.CboxInterval.FormattingEnabled = true;
            this.CboxInterval.Location = new System.Drawing.Point(259, 51);
            this.CboxInterval.Margin = new System.Windows.Forms.Padding(2);
            this.CboxInterval.Name = "CboxInterval";
            this.CboxInterval.Size = new System.Drawing.Size(85, 21);
            this.CboxInterval.TabIndex = 30;
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(602, 341);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Control";
            this.Text = "Control_Serial";
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
    }
}

