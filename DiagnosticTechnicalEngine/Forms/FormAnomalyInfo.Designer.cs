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
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(12, 47);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(60, 13);
			this.labelName.TabIndex = 2;
			this.labelName.Text = "Название:";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(116, 44);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(216, 20);
			this.textBoxName.TabIndex = 3;
			this.textBoxName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// labelSetSituation
			// 
			this.labelSetSituation.AutoSize = true;
			this.labelSetSituation.Location = new System.Drawing.Point(12, 109);
			this.labelSetSituation.Name = "labelSetSituation";
			this.labelSetSituation.Size = new System.Drawing.Size(98, 13);
			this.labelSetSituation.TabIndex = 4;
			this.labelSetSituation.Text = "Набор состояний:";
			// 
			// textBoxSetSituation
			// 
			this.textBoxSetSituation.Location = new System.Drawing.Point(116, 106);
			this.textBoxSetSituation.MaxLength = 50;
			this.textBoxSetSituation.Name = "textBoxSetSituation";
			this.textBoxSetSituation.Size = new System.Drawing.Size(216, 20);
			this.textBoxSetSituation.TabIndex = 5;
			this.textBoxSetSituation.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(209, 327);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 13;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(116, 220);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(216, 101);
			this.textBoxDescription.TabIndex = 11;
			this.textBoxDescription.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(12, 223);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(60, 13);
			this.labelDescription.TabIndex = 10;
			this.labelDescription.Text = "Описание:";
			// 
			// labelType
			// 
			this.labelType.AutoSize = true;
			this.labelType.Location = new System.Drawing.Point(12, 9);
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
			this.comboBoxTypeSituation.Location = new System.Drawing.Point(176, 6);
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
			this.comboBoxTypeMemory.Location = new System.Drawing.Point(176, 144);
			this.comboBoxTypeMemory.Name = "comboBoxTypeMemory";
			this.comboBoxTypeMemory.Size = new System.Drawing.Size(156, 21);
			this.comboBoxTypeMemory.TabIndex = 7;
			// 
			// labelTypeMemory
			// 
			this.labelTypeMemory.AutoSize = true;
			this.labelTypeMemory.Location = new System.Drawing.Point(12, 147);
			this.labelTypeMemory.Name = "labelTypeMemory";
			this.labelTypeMemory.Size = new System.Drawing.Size(132, 13);
			this.labelTypeMemory.TabIndex = 6;
			this.labelTypeMemory.Text = "Тип хранимых значений:";
			// 
			// textBoxSetValues
			// 
			this.textBoxSetValues.Location = new System.Drawing.Point(116, 183);
			this.textBoxSetValues.MaxLength = 50;
			this.textBoxSetValues.Name = "textBoxSetValues";
			this.textBoxSetValues.Size = new System.Drawing.Size(216, 20);
			this.textBoxSetValues.TabIndex = 9;
			this.textBoxSetValues.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// labelSetValues
			// 
			this.labelSetValues.AutoSize = true;
			this.labelSetValues.Location = new System.Drawing.Point(12, 186);
			this.labelSetValues.Name = "labelSetValues";
			this.labelSetValues.Size = new System.Drawing.Size(92, 13);
			this.labelSetValues.TabIndex = 8;
			this.labelSetValues.Text = "Набор значений:";
			// 
			// checkBoxNotAnomaly
			// 
			this.checkBoxNotAnomaly.AutoSize = true;
			this.checkBoxNotAnomaly.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.checkBoxNotAnomaly.Location = new System.Drawing.Point(15, 248);
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
			this.textBoxAnomalySituation.Location = new System.Drawing.Point(176, 73);
			this.textBoxAnomalySituation.Name = "textBoxAnomalySituation";
			this.textBoxAnomalySituation.Size = new System.Drawing.Size(156, 20);
			this.textBoxAnomalySituation.TabIndex = 16;
			this.textBoxAnomalySituation.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// labelAnomalySituation
			// 
			this.labelAnomalySituation.AutoSize = true;
			this.labelAnomalySituation.Location = new System.Drawing.Point(12, 76);
			this.labelAnomalySituation.Name = "labelAnomalySituation";
			this.labelAnomalySituation.Size = new System.Drawing.Size(158, 13);
			this.labelAnomalySituation.TabIndex = 15;
			this.labelAnomalySituation.Text = "Номер аномальной ситуации:";
			// 
			// checkBoxNotDetected
			// 
			this.checkBoxNotDetected.AutoSize = true;
			this.checkBoxNotDetected.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
			this.checkBoxNotDetected.Location = new System.Drawing.Point(15, 290);
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
			this.buttonSave.Location = new System.Drawing.Point(82, 327);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 12;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// FormAnomalyInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(344, 362);
			this.Controls.Add(this.checkBoxNotDetected);
			this.Controls.Add(this.textBoxAnomalySituation);
			this.Controls.Add(this.labelAnomalySituation);
			this.Controls.Add(this.checkBoxNotAnomaly);
			this.Controls.Add(this.textBoxSetValues);
			this.Controls.Add(this.labelSetValues);
			this.Controls.Add(this.comboBoxTypeMemory);
			this.Controls.Add(this.labelTypeMemory);
			this.Controls.Add(this.comboBoxTypeSituation);
			this.Controls.Add(this.labelType);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.textBoxSetSituation);
			this.Controls.Add(this.labelSetSituation);
			this.Controls.Add(this.textBoxName);
			this.Controls.Add(this.labelName);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAnomalyInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Информация по аномалии";
			this.Load += new System.EventHandler(this.FormAnomalyInfo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

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
	}
}