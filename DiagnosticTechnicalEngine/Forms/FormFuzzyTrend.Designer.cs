namespace DiagnosticTechnicalEngine.Forms
{
	partial class FormFuzzyTrend
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
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.textBoxWeight = new System.Windows.Forms.TextBox();
			this.labelWeight = new System.Windows.Forms.Label();
			this.labelName = new System.Windows.Forms.Label();
			this.comboBoxTrendNames = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(217, 82);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 5;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(90, 82);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 4;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// textBoxWeight
			// 
			this.textBoxWeight.Location = new System.Drawing.Point(81, 45);
			this.textBoxWeight.MaxLength = 4;
			this.textBoxWeight.Name = "textBoxWeight";
			this.textBoxWeight.Size = new System.Drawing.Size(50, 20);
			this.textBoxWeight.TabIndex = 3;
			this.textBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBoxWeight.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// labelWeight
			// 
			this.labelWeight.AutoSize = true;
			this.labelWeight.Location = new System.Drawing.Point(12, 48);
			this.labelWeight.Name = "labelWeight";
			this.labelWeight.Size = new System.Drawing.Size(29, 13);
			this.labelWeight.TabIndex = 2;
			this.labelWeight.Text = "Вес:";
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 9);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(60, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Название:";
			// 
			// comboBoxTrendNames
			// 
			this.comboBoxTrendNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTrendNames.FormattingEnabled = true;
			this.comboBoxTrendNames.Items.AddRange(new object[] {
            "Фаззификация. Треугольник",
            "FCM-кластеризация"});
			this.comboBoxTrendNames.Location = new System.Drawing.Point(78, 6);
			this.comboBoxTrendNames.Name = "comboBoxTrendNames";
			this.comboBoxTrendNames.Size = new System.Drawing.Size(250, 21);
			this.comboBoxTrendNames.TabIndex = 1;
			// 
			// FormFuzzyTrend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(344, 122);
			this.Controls.Add(this.comboBoxTrendNames);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxWeight);
			this.Controls.Add(this.labelWeight);
			this.Controls.Add(this.labelName);
			this.Name = "FormFuzzyTrend";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Нечеткая тенденция";
			this.Load += new System.EventHandler(this.FormFuzzyTrend_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TextBox textBoxWeight;
		private System.Windows.Forms.Label labelWeight;
		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.ComboBox comboBoxTrendNames;
	}
}