namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormFuzzyLabel
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
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelWeight = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.textBoxMinVal = new System.Windows.Forms.TextBox();
            this.labelMinVal = new System.Windows.Forms.Label();
            this.textBoxCenter = new System.Windows.Forms.TextBox();
            this.labelCenter = new System.Windows.Forms.Label();
            this.textBoxMaxVal = new System.Windows.Forms.TextBox();
            this.labelMaxVal = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(12, 9);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(63, 13);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Тип метки:";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Фаззификация. Треугольник",
            "FCM-кластеризация"});
            this.comboBoxType.Location = new System.Drawing.Point(81, 6);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(250, 21);
            this.comboBoxType.TabIndex = 1;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(81, 43);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(250, 20);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 46);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(60, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Название:";
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(12, 85);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(29, 13);
            this.labelWeight.TabIndex = 4;
            this.labelWeight.Text = "Вес:";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(81, 82);
            this.textBoxWeight.MaxLength = 4;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(50, 20);
            this.textBoxWeight.TabIndex = 5;
            this.textBoxWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxWeight.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxMinVal
            // 
            this.textBoxMinVal.Location = new System.Drawing.Point(155, 121);
            this.textBoxMinVal.MaxLength = 10;
            this.textBoxMinVal.Name = "textBoxMinVal";
            this.textBoxMinVal.Size = new System.Drawing.Size(50, 20);
            this.textBoxMinVal.TabIndex = 7;
            this.textBoxMinVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxMinVal.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelMinVal
            // 
            this.labelMinVal.AutoSize = true;
            this.labelMinVal.Location = new System.Drawing.Point(12, 124);
            this.labelMinVal.Name = "labelMinVal";
            this.labelMinVal.Size = new System.Drawing.Size(131, 13);
            this.labelMinVal.TabIndex = 6;
            this.labelMinVal.Text = "Минимальное значение:";
            // 
            // textBoxCenter
            // 
            this.textBoxCenter.Location = new System.Drawing.Point(257, 82);
            this.textBoxCenter.MaxLength = 10;
            this.textBoxCenter.Name = "textBoxCenter";
            this.textBoxCenter.Size = new System.Drawing.Size(50, 20);
            this.textBoxCenter.TabIndex = 9;
            this.textBoxCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCenter.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelCenter
            // 
            this.labelCenter.AutoSize = true;
            this.labelCenter.Location = new System.Drawing.Point(210, 85);
            this.labelCenter.Name = "labelCenter";
            this.labelCenter.Size = new System.Drawing.Size(41, 13);
            this.labelCenter.TabIndex = 8;
            this.labelCenter.Text = "Центр:";
            // 
            // textBoxMaxVal
            // 
            this.textBoxMaxVal.Location = new System.Drawing.Point(155, 156);
            this.textBoxMaxVal.MaxLength = 10;
            this.textBoxMaxVal.Name = "textBoxMaxVal";
            this.textBoxMaxVal.Size = new System.Drawing.Size(50, 20);
            this.textBoxMaxVal.TabIndex = 11;
            this.textBoxMaxVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxMaxVal.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // labelMaxVal
            // 
            this.labelMaxVal.AutoSize = true;
            this.labelMaxVal.Location = new System.Drawing.Point(12, 159);
            this.labelMaxVal.Name = "labelMaxVal";
            this.labelMaxVal.Size = new System.Drawing.Size(137, 13);
            this.labelMaxVal.TabIndex = 10;
            this.labelMaxVal.Text = "Максимальное значение:";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(196, 187);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 13;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(69, 187);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormFuzzyLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 222);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxMaxVal);
            this.Controls.Add(this.labelMaxVal);
            this.Controls.Add(this.textBoxCenter);
            this.Controls.Add(this.labelCenter);
            this.Controls.Add(this.textBoxMinVal);
            this.Controls.Add(this.labelMinVal);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.labelWeight);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFuzzyLabel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Нечеткая метка";
            this.Load += new System.EventHandler(this.FormFuzzyLabel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxMinVal;
        private System.Windows.Forms.Label labelMinVal;
        private System.Windows.Forms.TextBox textBoxCenter;
        private System.Windows.Forms.Label labelCenter;
        private System.Windows.Forms.TextBox textBoxMaxVal;
        private System.Windows.Forms.Label labelMaxVal;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
    }
}