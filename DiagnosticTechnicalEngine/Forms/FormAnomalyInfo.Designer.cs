namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormAnomalyInfo
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSetSituation = new System.Windows.Forms.Label();
            this.textBoxSetSituation = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxTypeSituation = new System.Windows.Forms.ComboBox();
            this.comboBoxTypeMemory = new System.Windows.Forms.ComboBox();
            this.labelTypeMemory = new System.Windows.Forms.Label();
            this.textBoxSetValues = new System.Windows.Forms.TextBox();
            this.labelSetValues = new System.Windows.Forms.Label();
            this.checkBoxNotAnomaly = new System.Windows.Forms.CheckBox();
            this.textBoxAnomalySituation = new System.Windows.Forms.TextBox();
            this.labelAnomalySituation = new System.Windows.Forms.Label();
            this.checkBoxNotDetected = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMainInfo = new System.Windows.Forms.TabPage();
            this.tabPageGraphic = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageDescription = new System.Windows.Forms.TabPage();
            this.textBoxDesription = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageMainInfo.SuspendLayout();
            this.tabPageGraphic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tabPageDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(6, 51);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(110, 48);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(216, 20);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelSetSituation
            // 
            this.labelSetSituation.AutoSize = true;
            this.labelSetSituation.Location = new System.Drawing.Point(6, 113);
            this.labelSetSituation.Name = "labelSetSituation";
            this.labelSetSituation.Size = new System.Drawing.Size(98, 13);
            this.labelSetSituation.TabIndex = 4;
            this.labelSetSituation.Text = "Набор состояний:";
            // 
            // textBoxSetSituation
            // 
            this.textBoxSetSituation.Location = new System.Drawing.Point(110, 110);
            this.textBoxSetSituation.MaxLength = 50;
            this.textBoxSetSituation.Name = "textBoxSetSituation";
            this.textBoxSetSituation.Size = new System.Drawing.Size(216, 20);
            this.textBoxSetSituation.TabIndex = 5;
            this.textBoxSetSituation.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(433, 230);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(332, 32);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(189, 175);
            this.textBoxDescription.TabIndex = 11;
            this.textBoxDescription.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(332, 13);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 10;
            this.labelDescription.Text = "Описание:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(6, 13);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(158, 13);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "К каким ситуациям относить:";
            // 
            // comboBoxTypeSituation
            // 
            this.comboBoxTypeSituation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeSituation.FormattingEnabled = true;
            this.comboBoxTypeSituation.Items.AddRange(new object[] {
            "Энтропии",
            "Нечеткость"});
            this.comboBoxTypeSituation.Location = new System.Drawing.Point(170, 10);
            this.comboBoxTypeSituation.Name = "comboBoxTypeSituation";
            this.comboBoxTypeSituation.Size = new System.Drawing.Size(156, 21);
            this.comboBoxTypeSituation.TabIndex = 1;
            this.comboBoxTypeSituation.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxTypeMemory
            // 
            this.comboBoxTypeMemory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeMemory.FormattingEnabled = true;
            this.comboBoxTypeMemory.Items.AddRange(new object[] {
            "Числовое значение",
            "Функция принадлежности"});
            this.comboBoxTypeMemory.Location = new System.Drawing.Point(170, 148);
            this.comboBoxTypeMemory.Name = "comboBoxTypeMemory";
            this.comboBoxTypeMemory.Size = new System.Drawing.Size(156, 21);
            this.comboBoxTypeMemory.TabIndex = 7;
            // 
            // labelTypeMemory
            // 
            this.labelTypeMemory.AutoSize = true;
            this.labelTypeMemory.Location = new System.Drawing.Point(6, 151);
            this.labelTypeMemory.Name = "labelTypeMemory";
            this.labelTypeMemory.Size = new System.Drawing.Size(132, 13);
            this.labelTypeMemory.TabIndex = 6;
            this.labelTypeMemory.Text = "Тип хранимых значений:";
            // 
            // textBoxSetValues
            // 
            this.textBoxSetValues.Location = new System.Drawing.Point(110, 187);
            this.textBoxSetValues.MaxLength = 50;
            this.textBoxSetValues.Name = "textBoxSetValues";
            this.textBoxSetValues.Size = new System.Drawing.Size(216, 20);
            this.textBoxSetValues.TabIndex = 9;
            this.textBoxSetValues.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelSetValues
            // 
            this.labelSetValues.AutoSize = true;
            this.labelSetValues.Location = new System.Drawing.Point(6, 190);
            this.labelSetValues.Name = "labelSetValues";
            this.labelSetValues.Size = new System.Drawing.Size(92, 13);
            this.labelSetValues.TabIndex = 8;
            this.labelSetValues.Text = "Набор значений:";
            // 
            // checkBoxNotAnomaly
            // 
            this.checkBoxNotAnomaly.AutoSize = true;
            this.checkBoxNotAnomaly.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxNotAnomaly.Location = new System.Drawing.Point(26, 225);
            this.checkBoxNotAnomaly.Name = "checkBoxNotAnomaly";
            this.checkBoxNotAnomaly.Size = new System.Drawing.Size(78, 31);
            this.checkBoxNotAnomaly.TabIndex = 14;
            this.checkBoxNotAnomaly.Text = "Не аномалия";
            this.checkBoxNotAnomaly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxNotAnomaly.UseVisualStyleBackColor = true;
            this.checkBoxNotAnomaly.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // textBoxAnomalySituation
            // 
            this.textBoxAnomalySituation.Location = new System.Drawing.Point(170, 77);
            this.textBoxAnomalySituation.Name = "textBoxAnomalySituation";
            this.textBoxAnomalySituation.Size = new System.Drawing.Size(156, 20);
            this.textBoxAnomalySituation.TabIndex = 16;
            this.textBoxAnomalySituation.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelAnomalySituation
            // 
            this.labelAnomalySituation.AutoSize = true;
            this.labelAnomalySituation.Location = new System.Drawing.Point(6, 80);
            this.labelAnomalySituation.Name = "labelAnomalySituation";
            this.labelAnomalySituation.Size = new System.Drawing.Size(158, 13);
            this.labelAnomalySituation.TabIndex = 15;
            this.labelAnomalySituation.Text = "Номер аномальной ситуации:";
            // 
            // checkBoxNotDetected
            // 
            this.checkBoxNotDetected.AutoSize = true;
            this.checkBoxNotDetected.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxNotDetected.Location = new System.Drawing.Point(125, 225);
            this.checkBoxNotDetected.Name = "checkBoxNotDetected";
            this.checkBoxNotDetected.Size = new System.Drawing.Size(94, 31);
            this.checkBoxNotDetected.TabIndex = 17;
            this.checkBoxNotDetected.Text = "Не фиксируется";
            this.checkBoxNotDetected.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxNotDetected.UseVisualStyleBackColor = true;
            this.checkBoxNotDetected.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(306, 230);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMainInfo);
            this.tabControl1.Controls.Add(this.tabPageDescription);
            this.tabControl1.Controls.Add(this.tabPageGraphic);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 302);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageMainInfo
            // 
            this.tabPageMainInfo.Controls.Add(this.labelType);
            this.tabPageMainInfo.Controls.Add(this.buttonClose);
            this.tabPageMainInfo.Controls.Add(this.buttonSave);
            this.tabPageMainInfo.Controls.Add(this.checkBoxNotDetected);
            this.tabPageMainInfo.Controls.Add(this.labelName);
            this.tabPageMainInfo.Controls.Add(this.checkBoxNotAnomaly);
            this.tabPageMainInfo.Controls.Add(this.textBoxAnomalySituation);
            this.tabPageMainInfo.Controls.Add(this.textBoxName);
            this.tabPageMainInfo.Controls.Add(this.labelAnomalySituation);
            this.tabPageMainInfo.Controls.Add(this.labelDescription);
            this.tabPageMainInfo.Controls.Add(this.textBoxDescription);
            this.tabPageMainInfo.Controls.Add(this.labelSetSituation);
            this.tabPageMainInfo.Controls.Add(this.textBoxSetSituation);
            this.tabPageMainInfo.Controls.Add(this.textBoxSetValues);
            this.tabPageMainInfo.Controls.Add(this.comboBoxTypeSituation);
            this.tabPageMainInfo.Controls.Add(this.labelSetValues);
            this.tabPageMainInfo.Controls.Add(this.labelTypeMemory);
            this.tabPageMainInfo.Controls.Add(this.comboBoxTypeMemory);
            this.tabPageMainInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageMainInfo.Name = "tabPageMainInfo";
            this.tabPageMainInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMainInfo.Size = new System.Drawing.Size(536, 276);
            this.tabPageMainInfo.TabIndex = 0;
            this.tabPageMainInfo.Text = "Основная информация";
            this.tabPageMainInfo.UseVisualStyleBackColor = true;
            // 
            // tabPageGraphic
            // 
            this.tabPageGraphic.Controls.Add(this.chart);
            this.tabPageGraphic.Location = new System.Drawing.Point(4, 22);
            this.tabPageGraphic.Name = "tabPageGraphic";
            this.tabPageGraphic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraphic.Size = new System.Drawing.Size(536, 276);
            this.tabPageGraphic.TabIndex = 1;
            this.tabPageGraphic.Text = "График";
            this.tabPageGraphic.UseVisualStyleBackColor = true;
            // 
            // chart
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(3, 3);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.MarkerBorderWidth = 2;
            series1.MarkerSize = 8;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series1.Name = "Series";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(530, 270);
            this.chart.TabIndex = 2;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title";
            title1.Text = "График аномалии";
            this.chart.Titles.Add(title1);
            // 
            // tabPageDescription
            // 
            this.tabPageDescription.Controls.Add(this.textBoxDesription);
            this.tabPageDescription.Location = new System.Drawing.Point(4, 22);
            this.tabPageDescription.Name = "tabPageDescription";
            this.tabPageDescription.Size = new System.Drawing.Size(536, 276);
            this.tabPageDescription.TabIndex = 2;
            this.tabPageDescription.Text = "Описание ситуаций";
            this.tabPageDescription.UseVisualStyleBackColor = true;
            // 
            // textBoxDesription
            // 
            this.textBoxDesription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDesription.Location = new System.Drawing.Point(0, 0);
            this.textBoxDesription.Multiline = true;
            this.textBoxDesription.Name = "textBoxDesription";
            this.textBoxDesription.ReadOnly = true;
            this.textBoxDesription.Size = new System.Drawing.Size(536, 276);
            this.textBoxDesription.TabIndex = 0;
            // 
            // FormAnomalyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(544, 302);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAnomalyInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация по аномалии";
            this.Load += new System.EventHandler(this.FormAnomalyInfo_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageMainInfo.ResumeLayout(false);
            this.tabPageMainInfo.PerformLayout();
            this.tabPageGraphic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tabPageDescription.ResumeLayout(false);
            this.tabPageDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelSetSituation;
        private System.Windows.Forms.TextBox textBoxSetSituation;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxTypeSituation;
        private System.Windows.Forms.ComboBox comboBoxTypeMemory;
        private System.Windows.Forms.Label labelTypeMemory;
        private System.Windows.Forms.TextBox textBoxSetValues;
        private System.Windows.Forms.Label labelSetValues;
        private System.Windows.Forms.CheckBox checkBoxNotAnomaly;
        private System.Windows.Forms.TextBox textBoxAnomalySituation;
        private System.Windows.Forms.Label labelAnomalySituation;
        private System.Windows.Forms.CheckBox checkBoxNotDetected;
		private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMainInfo;
        private System.Windows.Forms.TabPage tabPageGraphic;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.TabPage tabPageDescription;
        private System.Windows.Forms.TextBox textBoxDesription;
    }
}