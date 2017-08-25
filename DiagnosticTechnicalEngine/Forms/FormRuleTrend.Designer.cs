namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormRuleTrend
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
            this.labelTrend = new System.Windows.Forms.Label();
            this.comboBoxTrends = new System.Windows.Forms.ComboBox();
            this.labelFuzzyLabelFrom = new System.Windows.Forms.Label();
            this.comboBoxFuzzyLabelFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxFuzzyLabelTo = new System.Windows.Forms.ComboBox();
            this.labelFuzzyLabelTo = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTrend
            // 
            this.labelTrend.AutoSize = true;
            this.labelTrend.Location = new System.Drawing.Point(12, 9);
            this.labelTrend.Name = "labelTrend";
            this.labelTrend.Size = new System.Drawing.Size(65, 13);
            this.labelTrend.TabIndex = 0;
            this.labelTrend.Text = "Тенденция:";
            // 
            // comboBoxTrends
            // 
            this.comboBoxTrends.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrends.FormattingEnabled = true;
            this.comboBoxTrends.Location = new System.Drawing.Point(83, 6);
            this.comboBoxTrends.Name = "comboBoxTrends";
            this.comboBoxTrends.Size = new System.Drawing.Size(250, 21);
            this.comboBoxTrends.TabIndex = 1;
            this.comboBoxTrends.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // labelFuzzyLabelFrom
            // 
            this.labelFuzzyLabelFrom.AutoSize = true;
            this.labelFuzzyLabelFrom.Location = new System.Drawing.Point(12, 52);
            this.labelFuzzyLabelFrom.Name = "labelFuzzyLabelFrom";
            this.labelFuzzyLabelFrom.Size = new System.Drawing.Size(147, 13);
            this.labelFuzzyLabelFrom.TabIndex = 2;
            this.labelFuzzyLabelFrom.Text = "Нечеткая метка - источник:";
            // 
            // comboBoxFuzzyLabelFrom
            // 
            this.comboBoxFuzzyLabelFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuzzyLabelFrom.FormattingEnabled = true;
            this.comboBoxFuzzyLabelFrom.Location = new System.Drawing.Point(169, 49);
            this.comboBoxFuzzyLabelFrom.Name = "comboBoxFuzzyLabelFrom";
            this.comboBoxFuzzyLabelFrom.Size = new System.Drawing.Size(164, 21);
            this.comboBoxFuzzyLabelFrom.TabIndex = 3;
            this.comboBoxFuzzyLabelFrom.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // comboBoxFuzzyLabelTo
            // 
            this.comboBoxFuzzyLabelTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFuzzyLabelTo.FormattingEnabled = true;
            this.comboBoxFuzzyLabelTo.Location = new System.Drawing.Point(169, 92);
            this.comboBoxFuzzyLabelTo.Name = "comboBoxFuzzyLabelTo";
            this.comboBoxFuzzyLabelTo.Size = new System.Drawing.Size(164, 21);
            this.comboBoxFuzzyLabelTo.TabIndex = 5;
            this.comboBoxFuzzyLabelTo.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // labelFuzzyLabelTo
            // 
            this.labelFuzzyLabelTo.AutoSize = true;
            this.labelFuzzyLabelTo.Location = new System.Drawing.Point(12, 95);
            this.labelFuzzyLabelTo.Name = "labelFuzzyLabelTo";
            this.labelFuzzyLabelTo.Size = new System.Drawing.Size(151, 13);
            this.labelFuzzyLabelTo.TabIndex = 4;
            this.labelFuzzyLabelTo.Text = "Нечеткая метка - приемник:";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(210, 129);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(83, 129);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormRuleTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(344, 162);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxFuzzyLabelTo);
            this.Controls.Add(this.labelFuzzyLabelTo);
            this.Controls.Add(this.comboBoxFuzzyLabelFrom);
            this.Controls.Add(this.labelFuzzyLabelFrom);
            this.Controls.Add(this.comboBoxTrends);
            this.Controls.Add(this.labelTrend);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 200);
            this.Name = "FormRuleTrend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Правила вычилсения тенденции";
            this.Load += new System.EventHandler(this.FormRuleTrend_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTrend;
        private System.Windows.Forms.ComboBox comboBoxTrends;
        private System.Windows.Forms.Label labelFuzzyLabelFrom;
        private System.Windows.Forms.ComboBox comboBoxFuzzyLabelFrom;
        private System.Windows.Forms.ComboBox comboBoxFuzzyLabelTo;
        private System.Windows.Forms.Label labelFuzzyLabelTo;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
    }
}