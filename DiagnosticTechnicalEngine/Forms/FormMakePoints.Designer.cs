namespace DiagnosticTechnicalEngine.Forms
{
	partial class FormMakePoints
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
			this.buttonDownToList = new System.Windows.Forms.Button();
			this.buttonUpToList = new System.Windows.Forms.Button();
			this.buttonCancelSelect = new System.Windows.Forms.Button();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.listBoxSelected = new System.Windows.Forms.ListBox();
			this.listBoxElements = new System.Windows.Forms.ListBox();
			this.comboBoxTypeFile = new System.Windows.Forms.ComboBox();
			this.buttonLoad = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonDownToList
			// 
			this.buttonDownToList.Location = new System.Drawing.Point(197, 117);
			this.buttonDownToList.Name = "buttonDownToList";
			this.buttonDownToList.Size = new System.Drawing.Size(75, 23);
			this.buttonDownToList.TabIndex = 20;
			this.buttonDownToList.Text = "Вниз";
			this.buttonDownToList.UseVisualStyleBackColor = true;
			this.buttonDownToList.Click += new System.EventHandler(this.buttonDownToList_Click);
			// 
			// buttonUpToList
			// 
			this.buttonUpToList.Location = new System.Drawing.Point(197, 88);
			this.buttonUpToList.Name = "buttonUpToList";
			this.buttonUpToList.Size = new System.Drawing.Size(75, 23);
			this.buttonUpToList.TabIndex = 19;
			this.buttonUpToList.Text = "Вверх";
			this.buttonUpToList.UseVisualStyleBackColor = true;
			this.buttonUpToList.Click += new System.EventHandler(this.buttonUpToList_Click);
			// 
			// buttonCancelSelect
			// 
			this.buttonCancelSelect.Location = new System.Drawing.Point(197, 43);
			this.buttonCancelSelect.Name = "buttonCancelSelect";
			this.buttonCancelSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonCancelSelect.TabIndex = 18;
			this.buttonCancelSelect.Text = "<<";
			this.buttonCancelSelect.UseVisualStyleBackColor = true;
			this.buttonCancelSelect.Click += new System.EventHandler(this.buttonCancelSelect_Click);
			// 
			// buttonSelect
			// 
			this.buttonSelect.Location = new System.Drawing.Point(197, 14);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(75, 23);
			this.buttonSelect.TabIndex = 17;
			this.buttonSelect.Text = ">>";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
			// 
			// listBoxSelected
			// 
			this.listBoxSelected.Dock = System.Windows.Forms.DockStyle.Right;
			this.listBoxSelected.FormattingEnabled = true;
			this.listBoxSelected.Location = new System.Drawing.Point(288, 0);
			this.listBoxSelected.Name = "listBoxSelected";
			this.listBoxSelected.Size = new System.Drawing.Size(210, 424);
			this.listBoxSelected.TabIndex = 16;
			// 
			// listBoxElements
			// 
			this.listBoxElements.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBoxElements.FormattingEnabled = true;
			this.listBoxElements.Location = new System.Drawing.Point(0, 0);
			this.listBoxElements.Name = "listBoxElements";
			this.listBoxElements.Size = new System.Drawing.Size(191, 424);
			this.listBoxElements.TabIndex = 15;
			// 
			// comboBoxTypeFile
			// 
			this.comboBoxTypeFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTypeFile.FormattingEnabled = true;
			this.comboBoxTypeFile.Items.AddRange(new object[] {
            "xls",
            "xlsx",
            "txt"});
			this.comboBoxTypeFile.Location = new System.Drawing.Point(197, 167);
			this.comboBoxTypeFile.Name = "comboBoxTypeFile";
			this.comboBoxTypeFile.Size = new System.Drawing.Size(75, 21);
			this.comboBoxTypeFile.TabIndex = 21;
			// 
			// buttonLoad
			// 
			this.buttonLoad.Location = new System.Drawing.Point(197, 208);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new System.Drawing.Size(75, 23);
			this.buttonLoad.TabIndex = 22;
			this.buttonLoad.Text = "Загрузить";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
			// 
			// FormMakePoints
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 424);
			this.Controls.Add(this.comboBoxTypeFile);
			this.Controls.Add(this.buttonLoad);
			this.Controls.Add(this.buttonDownToList);
			this.Controls.Add(this.buttonUpToList);
			this.Controls.Add(this.buttonCancelSelect);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.listBoxSelected);
			this.Controls.Add(this.listBoxElements);
			this.Name = "FormMakePoints";
			this.Text = "Формирование точек";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonDownToList;
		private System.Windows.Forms.Button buttonUpToList;
		private System.Windows.Forms.Button buttonCancelSelect;
		private System.Windows.Forms.Button buttonSelect;
		private System.Windows.Forms.ListBox listBoxSelected;
		private System.Windows.Forms.ListBox listBoxElements;
		private System.Windows.Forms.ComboBox comboBoxTypeFile;
		private System.Windows.Forms.Button buttonLoad;
	}
}