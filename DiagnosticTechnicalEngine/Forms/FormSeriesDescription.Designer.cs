namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormSeriesDescription
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
			this.labelName = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.buttonSave = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.checkBoxNeedForecast = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
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
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(78, 6);
			this.textBoxName.MaxLength = 50;
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(250, 20);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(12, 46);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(60, 13);
			this.labelDescription.TabIndex = 2;
			this.labelDescription.Text = "Описание:";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(78, 43);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(250, 130);
			this.textBoxDescription.TabIndex = 3;
			this.textBoxDescription.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(94, 219);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 5;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(221, 219);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 6;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// checkBoxNeedForecast
			// 
			this.checkBoxNeedForecast.AutoSize = true;
			this.checkBoxNeedForecast.Location = new System.Drawing.Point(94, 184);
			this.checkBoxNeedForecast.Name = "checkBoxNeedForecast";
			this.checkBoxNeedForecast.Size = new System.Drawing.Size(103, 17);
			this.checkBoxNeedForecast.TabIndex = 4;
			this.checkBoxNeedForecast.Text = "Нужен прогноз";
			this.checkBoxNeedForecast.UseVisualStyleBackColor = true;
			this.checkBoxNeedForecast.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// FormSeriesDescription
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(344, 254);
			this.Controls.Add(this.checkBoxNeedForecast);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSeriesDescription";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Описание временного ряда";
			this.Load += new System.EventHandler(this.FormSeriesDescription_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.CheckBox checkBoxNeedForecast;
	}
}