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
			this.labelForecast = new System.Windows.Forms.Label();
			this.checkBoxGetForecast = new System.Windows.Forms.CheckBox();
			this.checkBoxSaveLog = new System.Windows.Forms.CheckBox();
			this.labelCountLoadPoints = new System.Windows.Forms.Label();
			this.textBoxCountPointsForMemmory = new System.Windows.Forms.TextBox();
			this.comboBoxTypeFile = new System.Windows.Forms.ComboBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.richTextBox = new System.Windows.Forms.RichTextBox();
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
			this.splitContainer.Size = new System.Drawing.Size(700, 500);
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
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.labelForecast);
			this.splitContainer1.Panel2.Controls.Add(this.checkBoxGetForecast);
			this.splitContainer1.Panel2.Controls.Add(this.checkBoxSaveLog);
			this.splitContainer1.Panel2.Controls.Add(this.labelCountLoadPoints);
			this.splitContainer1.Panel2.Controls.Add(this.textBoxCountPointsForMemmory);
			this.splitContainer1.Panel2.Controls.Add(this.comboBoxTypeFile);
			this.splitContainer1.Panel2.Controls.Add(this.buttonLoad);
			this.splitContainer1.Size = new System.Drawing.Size(700, 298);
			this.splitContainer1.SplitterDistance = 488;
			this.splitContainer1.TabIndex = 0;
			// 
			// buttonDownToList
			// 
			this.buttonDownToList.Location = new System.Drawing.Point(197, 117);
			this.buttonDownToList.Name = "buttonDownToList";
			this.buttonDownToList.Size = new System.Drawing.Size(75, 23);
			this.buttonDownToList.TabIndex = 14;
			this.buttonDownToList.Text = "Вниз";
			this.buttonDownToList.UseVisualStyleBackColor = true;
			this.buttonDownToList.Click += new System.EventHandler(this.buttonDownToList_Click);
			// 
			// buttonUpToList
			// 
			this.buttonUpToList.Location = new System.Drawing.Point(197, 88);
			this.buttonUpToList.Name = "buttonUpToList";
			this.buttonUpToList.Size = new System.Drawing.Size(75, 23);
			this.buttonUpToList.TabIndex = 13;
			this.buttonUpToList.Text = "Вверх";
			this.buttonUpToList.UseVisualStyleBackColor = true;
			this.buttonUpToList.Click += new System.EventHandler(this.buttonUpToList_Click);
			// 
			// buttonCancelSelect
			// 
			this.buttonCancelSelect.Location = new System.Drawing.Point(197, 43);
			this.buttonCancelSelect.Name = "buttonCancelSelect";
			this.buttonCancelSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonCancelSelect.TabIndex = 12;
			this.buttonCancelSelect.Text = "<<";
			this.buttonCancelSelect.UseVisualStyleBackColor = true;
			this.buttonCancelSelect.Click += new System.EventHandler(this.buttonCancelSelect_Click);
			// 
			// buttonSelect
			// 
			this.buttonSelect.Location = new System.Drawing.Point(197, 14);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 11;
			this.buttonSelect.Text = ">>";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
			// 
			// listBoxSelected
			// 
			this.listBoxSelected.Dock = System.Windows.Forms.DockStyle.Right;
			this.listBoxSelected.FormattingEnabled = true;
			this.listBoxSelected.Location = new System.Drawing.Point(278, 0);
			this.listBoxSelected.Name = "listBoxSelected";
			this.listBoxSelected.Size = new System.Drawing.Size(210, 298);
			this.listBoxSelected.TabIndex = 10;
			// 
			// listBoxElements
			// 
			this.listBoxElements.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBoxElements.FormattingEnabled = true;
			this.listBoxElements.Location = new System.Drawing.Point(0, 0);
			this.listBoxElements.Name = "listBoxElements";
			this.listBoxElements.Size = new System.Drawing.Size(191, 298);
			this.listBoxElements.TabIndex = 9;
			// 
			// labelForecast
			// 
			this.labelForecast.AutoSize = true;
			this.labelForecast.Location = new System.Drawing.Point(33, 227);
			this.labelForecast.Name = "labelForecast";
			this.labelForecast.Size = new System.Drawing.Size(53, 13);
			this.labelForecast.TabIndex = 21;
			this.labelForecast.Text = "Прогноз:";
			// 
			// checkBoxGetForecast
			// 
			this.checkBoxGetForecast.AutoSize = true;
			this.checkBoxGetForecast.Location = new System.Drawing.Point(15, 197);
			this.checkBoxGetForecast.Name = "checkBoxGetForecast";
			this.checkBoxGetForecast.Size = new System.Drawing.Size(117, 17);
			this.checkBoxGetForecast.TabIndex = 20;
			this.checkBoxGetForecast.Text = "Получить прогноз";
			this.checkBoxGetForecast.UseVisualStyleBackColor = true;
			// 
			// checkBoxSaveLog
			// 
			this.checkBoxSaveLog.AutoSize = true;
			this.checkBoxSaveLog.Location = new System.Drawing.Point(15, 145);
			this.checkBoxSaveLog.Name = "checkBoxSaveLog";
			this.checkBoxSaveLog.Size = new System.Drawing.Size(99, 17);
			this.checkBoxSaveLog.TabIndex = 19;
			this.checkBoxSaveLog.Text = "Сохранить лог";
			this.checkBoxSaveLog.UseVisualStyleBackColor = true;
			// 
			// labelCountLoadPoints
			// 
			this.labelCountLoadPoints.AutoSize = true;
			this.labelCountLoadPoints.Location = new System.Drawing.Point(12, 272);
			this.labelCountLoadPoints.Name = "labelCountLoadPoints";
			this.labelCountLoadPoints.Size = new System.Drawing.Size(71, 13);
			this.labelCountLoadPoints.TabIndex = 18;
			this.labelCountLoadPoints.Text = "Обработано:";
			// 
			// textBoxCountPointsForMemmory
			// 
			this.textBoxCountPointsForMemmory.Location = new System.Drawing.Point(15, 16);
			this.textBoxCountPointsForMemmory.Name = "textBoxCountPointsForMemmory";
			this.textBoxCountPointsForMemmory.Size = new System.Drawing.Size(75, 20);
			this.textBoxCountPointsForMemmory.TabIndex = 17;
			this.textBoxCountPointsForMemmory.Text = "10";
			this.textBoxCountPointsForMemmory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// comboBoxTypeFile
			// 
			this.comboBoxTypeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTypeFile.FormattingEnabled = true;
			this.comboBoxTypeFile.Items.AddRange(new object[] {
            "xls",
            "xlsx",
            "txt"});
			this.comboBoxTypeFile.Location = new System.Drawing.Point(15, 56);
			this.comboBoxTypeFile.Name = "comboBoxTypeFile";
			this.comboBoxTypeFile.Size = new System.Drawing.Size(75, 21);
			this.comboBoxTypeFile.TabIndex = 15;
			// 
			// buttonLoad
			// 
			this.buttonLoad.Enabled = false;
			this.buttonLoad.Location = new System.Drawing.Point(15, 97);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(75, 23);
			this.buttonLoad.TabIndex = 16;
			this.buttonLoad.Text = "Загрузить";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// richTextBox
			// 
			this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox.Location = new System.Drawing.Point(0, 0);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(700, 198);
			this.richTextBox.TabIndex = 0;
			this.richTextBox.Text = "";
			// 
			// UserControlAnalysisSeries
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer);
			this.Name = "UserControlAnalysisSeries";
			this.Size = new System.Drawing.Size(700, 500);
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
		private System.Windows.Forms.Label labelForecast;
		private System.Windows.Forms.CheckBox checkBoxGetForecast;
	}
}
