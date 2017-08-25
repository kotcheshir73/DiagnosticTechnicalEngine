namespace DiagnosticTechnicalEngine.Controls
{
    partial class UserControlAnalysisSeries
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonDownToList = new System.Windows.Forms.Button();
            this.buttonUpToList = new System.Windows.Forms.Button();
            this.buttonCancelSelect = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.listBoxSelected = new System.Windows.Forms.ListBox();
            this.listBoxElements = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.checkBoxGetForecast = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveLog = new System.Windows.Forms.CheckBox();
            this.labelCountLoadPoints = new System.Windows.Forms.Label();
            this.textBoxCountPointsForMemmory = new System.Windows.Forms.TextBox();
            this.comboBoxTypeFile = new System.Windows.Forms.ComboBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.checkBoxGranuleUX = new System.Windows.Forms.CheckBox();
            this.checkBoxGranuleFT = new System.Windows.Forms.CheckBox();
            this.checkBoxGranuleFuzzy = new System.Windows.Forms.CheckBox();
            this.checkBoxGranuleEntropy = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.richTextBox);
            this.splitContainer.Size = new System.Drawing.Size(800, 500);
            this.splitContainer.SplitterDistance = 298;
            this.splitContainer.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonDownToList);
            this.splitContainer1.Panel1.Controls.Add(this.buttonUpToList);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCancelSelect);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSelect);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxSelected);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxElements);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxTypeFile);
            this.splitContainer1.Panel1.Controls.Add(this.buttonLoad);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxGranuleEntropy);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxGranuleFuzzy);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxGranuleFT);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxGranuleUX);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxNumber);
            this.splitContainer1.Panel2.Controls.Add(this.labelNumber);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxGetForecast);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxSaveLog);
            this.splitContainer1.Panel2.Controls.Add(this.labelCountLoadPoints);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxCountPointsForMemmory);
            this.splitContainer1.Size = new System.Drawing.Size(800, 298);
            this.splitContainer1.SplitterDistance = 495;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonDownToList
            // 
            this.buttonDownToList.Location = new System.Drawing.Point(197, 117);
            this.buttonDownToList.Name = "buttonDownToList";
            this.buttonDownToList.Size = new System.Drawing.Size(75, 23);
            this.buttonDownToList.TabIndex = 5;
            this.buttonDownToList.Text = "Вниз";
            this.buttonDownToList.UseVisualStyleBackColor = true;
            this.buttonDownToList.Click += new System.EventHandler(this.buttonDownToList_Click);
            // 
            // buttonUpToList
            // 
            this.buttonUpToList.Location = new System.Drawing.Point(197, 88);
            this.buttonUpToList.Name = "buttonUpToList";
            this.buttonUpToList.Size = new System.Drawing.Size(75, 23);
            this.buttonUpToList.TabIndex = 4;
            this.buttonUpToList.Text = "Вверх";
            this.buttonUpToList.UseVisualStyleBackColor = true;
            this.buttonUpToList.Click += new System.EventHandler(this.buttonUpToList_Click);
            // 
            // buttonCancelSelect
            // 
            this.buttonCancelSelect.Location = new System.Drawing.Point(197, 43);
            this.buttonCancelSelect.Name = "buttonCancelSelect";
            this.buttonCancelSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelSelect.TabIndex = 3;
            this.buttonCancelSelect.Text = "<<";
            this.buttonCancelSelect.UseVisualStyleBackColor = true;
            this.buttonCancelSelect.Click += new System.EventHandler(this.buttonCancelSelect_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(197, 14);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = ">>";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // listBoxSelected
            // 
            this.listBoxSelected.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBoxSelected.FormattingEnabled = true;
            this.listBoxSelected.Location = new System.Drawing.Point(285, 0);
            this.listBoxSelected.Name = "listBoxSelected";
            this.listBoxSelected.Size = new System.Drawing.Size(210, 298);
            this.listBoxSelected.TabIndex = 1;
            // 
            // listBoxElements
            // 
            this.listBoxElements.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBoxElements.FormattingEnabled = true;
            this.listBoxElements.Location = new System.Drawing.Point(0, 0);
            this.listBoxElements.Name = "listBoxElements";
            this.listBoxElements.Size = new System.Drawing.Size(191, 298);
            this.listBoxElements.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сколько точек держать в памяти";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Location = new System.Drawing.Point(192, 11);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(50, 20);
            this.textBoxNumber.TabIndex = 1;
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(10, 14);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(72, 13);
            this.labelNumber.TabIndex = 0;
            this.labelNumber.Text = "Номер теста";
            // 
            // checkBoxGetForecast
            // 
            this.checkBoxGetForecast.AutoSize = true;
            this.checkBoxGetForecast.Location = new System.Drawing.Point(13, 72);
            this.checkBoxGetForecast.Name = "checkBoxGetForecast";
            this.checkBoxGetForecast.Size = new System.Drawing.Size(125, 17);
            this.checkBoxGetForecast.TabIndex = 4;
            this.checkBoxGetForecast.Text = "Учитывать прогноз";
            this.checkBoxGetForecast.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaveLog
            // 
            this.checkBoxSaveLog.AutoSize = true;
            this.checkBoxSaveLog.Location = new System.Drawing.Point(13, 172);
            this.checkBoxSaveLog.Name = "checkBoxSaveLog";
            this.checkBoxSaveLog.Size = new System.Drawing.Size(99, 17);
            this.checkBoxSaveLog.TabIndex = 9;
            this.checkBoxSaveLog.Text = "Сохранить лог";
            this.checkBoxSaveLog.UseVisualStyleBackColor = true;
            // 
            // labelCountLoadPoints
            // 
            this.labelCountLoadPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCountLoadPoints.AutoSize = true;
            this.labelCountLoadPoints.Location = new System.Drawing.Point(10, 258);
            this.labelCountLoadPoints.Name = "labelCountLoadPoints";
            this.labelCountLoadPoints.Size = new System.Drawing.Size(71, 13);
            this.labelCountLoadPoints.TabIndex = 10;
            this.labelCountLoadPoints.Text = "Обработано:";
            // 
            // textBoxCountPointsForMemmory
            // 
            this.textBoxCountPointsForMemmory.Location = new System.Drawing.Point(192, 37);
            this.textBoxCountPointsForMemmory.Name = "textBoxCountPointsForMemmory";
            this.textBoxCountPointsForMemmory.Size = new System.Drawing.Size(50, 20);
            this.textBoxCountPointsForMemmory.TabIndex = 3;
            this.textBoxCountPointsForMemmory.Text = "10";
            this.textBoxCountPointsForMemmory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxTypeFile
            // 
            this.comboBoxTypeFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxTypeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeFile.FormattingEnabled = true;
            this.comboBoxTypeFile.Items.AddRange(new object[] {
            "xls",
            "xlsx",
            "txt"});
            this.comboBoxTypeFile.Location = new System.Drawing.Point(197, 170);
            this.comboBoxTypeFile.Name = "comboBoxTypeFile";
            this.comboBoxTypeFile.Size = new System.Drawing.Size(75, 21);
            this.comboBoxTypeFile.TabIndex = 6;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoad.Enabled = false;
            this.buttonLoad.Location = new System.Drawing.Point(197, 258);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 7;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(800, 198);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // checkBoxGranuleUX
            // 
            this.checkBoxGranuleUX.AutoSize = true;
            this.checkBoxGranuleUX.Checked = true;
            this.checkBoxGranuleUX.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGranuleUX.Location = new System.Drawing.Point(13, 100);
            this.checkBoxGranuleUX.Name = "checkBoxGranuleUX";
            this.checkBoxGranuleUX.Size = new System.Drawing.Size(106, 17);
            this.checkBoxGranuleUX.TabIndex = 5;
            this.checkBoxGranuleUX.Text = "Гранулы по ФП";
            this.checkBoxGranuleUX.UseVisualStyleBackColor = true;
            // 
            // checkBoxGranuleFT
            // 
            this.checkBoxGranuleFT.AutoSize = true;
            this.checkBoxGranuleFT.Checked = true;
            this.checkBoxGranuleFT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGranuleFT.Location = new System.Drawing.Point(13, 129);
            this.checkBoxGranuleFT.Name = "checkBoxGranuleFT";
            this.checkBoxGranuleFT.Size = new System.Drawing.Size(102, 17);
            this.checkBoxGranuleFT.TabIndex = 6;
            this.checkBoxGranuleFT.Text = "Гранулы по НТ";
            this.checkBoxGranuleFT.UseVisualStyleBackColor = true;
            // 
            // checkBoxGranuleFuzzy
            // 
            this.checkBoxGranuleFuzzy.AutoSize = true;
            this.checkBoxGranuleFuzzy.Checked = true;
            this.checkBoxGranuleFuzzy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGranuleFuzzy.Location = new System.Drawing.Point(148, 100);
            this.checkBoxGranuleFuzzy.Name = "checkBoxGranuleFuzzy";
            this.checkBoxGranuleFuzzy.Size = new System.Drawing.Size(144, 17);
            this.checkBoxGranuleFuzzy.TabIndex = 7;
            this.checkBoxGranuleFuzzy.Text = "Гранулы по нечеткости";
            this.checkBoxGranuleFuzzy.UseVisualStyleBackColor = true;
            // 
            // checkBoxGranuleEntropy
            // 
            this.checkBoxGranuleEntropy.AutoSize = true;
            this.checkBoxGranuleEntropy.Checked = true;
            this.checkBoxGranuleEntropy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGranuleEntropy.Location = new System.Drawing.Point(148, 129);
            this.checkBoxGranuleEntropy.Name = "checkBoxGranuleEntropy";
            this.checkBoxGranuleEntropy.Size = new System.Drawing.Size(134, 17);
            this.checkBoxGranuleEntropy.TabIndex = 8;
            this.checkBoxGranuleEntropy.Text = "Гранулы по энтропии";
            this.checkBoxGranuleEntropy.UseVisualStyleBackColor = true;
            // 
            // UserControlAnalysisSeries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "UserControlAnalysisSeries";
            this.Size = new System.Drawing.Size(800, 500);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonDownToList;
        private System.Windows.Forms.Button buttonUpToList;
        private System.Windows.Forms.Button buttonCancelSelect;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ListBox listBoxSelected;
        private System.Windows.Forms.ListBox listBoxElements;
        private System.Windows.Forms.Label labelCountLoadPoints;
        private System.Windows.Forms.TextBox textBoxCountPointsForMemmory;
        private System.Windows.Forms.ComboBox comboBoxTypeFile;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.CheckBox checkBoxSaveLog;
		private System.Windows.Forms.CheckBox checkBoxGetForecast;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxGranuleFT;
        private System.Windows.Forms.CheckBox checkBoxGranuleUX;
        private System.Windows.Forms.CheckBox checkBoxGranuleFuzzy;
        private System.Windows.Forms.CheckBox checkBoxGranuleEntropy;
    }
}
