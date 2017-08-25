namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormStatisticFuzzy
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
			this.groupBoxStartState = new System.Windows.Forms.GroupBox();
			this.comboBoxStartStateFT = new System.Windows.Forms.ComboBox();
			this.labelStartStateFT = new System.Windows.Forms.Label();
			this.comboBoxStartStateFL = new System.Windows.Forms.ComboBox();
			this.labelStartStateFL = new System.Windows.Forms.Label();
			this.textBoxNumberSituation = new System.Windows.Forms.TextBox();
			this.labelNumberSituation = new System.Windows.Forms.Label();
			this.groupBoxEndState = new System.Windows.Forms.GroupBox();
			this.comboBoxEndStateFT = new System.Windows.Forms.ComboBox();
			this.labelEndStateFT = new System.Windows.Forms.Label();
			this.comboBoxEndStateFL = new System.Windows.Forms.ComboBox();
			this.labelEndStateFL = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.labelDescription = new System.Windows.Forms.Label();
			this.groupBoxStartState.SuspendLayout();
			this.groupBoxEndState.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxStartState
			// 
			this.groupBoxStartState.Controls.Add(this.comboBoxStartStateFT);
			this.groupBoxStartState.Controls.Add(this.labelStartStateFT);
			this.groupBoxStartState.Controls.Add(this.comboBoxStartStateFL);
			this.groupBoxStartState.Controls.Add(this.labelStartStateFL);
			this.groupBoxStartState.Location = new System.Drawing.Point(12, 32);
			this.groupBoxStartState.Name = "groupBoxStartState";
			this.groupBoxStartState.Size = new System.Drawing.Size(366, 101);
			this.groupBoxStartState.TabIndex = 2;
			this.groupBoxStartState.TabStop = false;
			this.groupBoxStartState.Text = "Предыдущее состояние";
			// 
			// comboBoxStartStateFT
			// 
			this.comboBoxStartStateFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStartStateFT.FormattingEnabled = true;
			this.comboBoxStartStateFT.Location = new System.Drawing.Point(181, 62);
			this.comboBoxStartStateFT.Name = "comboBoxStartStateFT";
			this.comboBoxStartStateFT.Size = new System.Drawing.Size(179, 21);
			this.comboBoxStartStateFT.TabIndex = 3;
			// 
			// labelStartStateFT
			// 
			this.labelStartStateFT.AutoSize = true;
			this.labelStartStateFT.Location = new System.Drawing.Point(17, 65);
			this.labelStartStateFT.Name = "labelStartStateFT";
			this.labelStartStateFT.Size = new System.Drawing.Size(129, 13);
			this.labelStartStateFT.TabIndex = 2;
			this.labelStartStateFT.Text = "По нечеткой тенденции:";
			// 
			// comboBoxStartStateFL
			// 
			this.comboBoxStartStateFL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStartStateFL.FormattingEnabled = true;
			this.comboBoxStartStateFL.Location = new System.Drawing.Point(181, 23);
			this.comboBoxStartStateFL.Name = "comboBoxStartStateFL";
			this.comboBoxStartStateFL.Size = new System.Drawing.Size(179, 21);
			this.comboBoxStartStateFL.TabIndex = 1;
			// 
			// labelStartStateFL
			// 
			this.labelStartStateFL.AutoSize = true;
			this.labelStartStateFL.Location = new System.Drawing.Point(17, 26);
			this.labelStartStateFL.Name = "labelStartStateFL";
			this.labelStartStateFL.Size = new System.Drawing.Size(107, 13);
			this.labelStartStateFL.TabIndex = 0;
			this.labelStartStateFL.Text = "По нечеткой метке:";
			// 
			// textBoxNumberSituation
			// 
			this.textBoxNumberSituation.Location = new System.Drawing.Point(111, 6);
			this.textBoxNumberSituation.MaxLength = 3;
			this.textBoxNumberSituation.Name = "textBoxNumberSituation";
			this.textBoxNumberSituation.Size = new System.Drawing.Size(50, 20);
			this.textBoxNumberSituation.TabIndex = 1;
			this.textBoxNumberSituation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// labelNumberSituation
			// 
			this.labelNumberSituation.AutoSize = true;
			this.labelNumberSituation.Location = new System.Drawing.Point(12, 9);
			this.labelNumberSituation.Name = "labelNumberSituation";
			this.labelNumberSituation.Size = new System.Drawing.Size(93, 13);
			this.labelNumberSituation.TabIndex = 0;
			this.labelNumberSituation.Text = "Номер ситуации:";
			// 
			// groupBoxEndState
			// 
			this.groupBoxEndState.Controls.Add(this.comboBoxEndStateFT);
			this.groupBoxEndState.Controls.Add(this.labelEndStateFT);
			this.groupBoxEndState.Controls.Add(this.comboBoxEndStateFL);
			this.groupBoxEndState.Controls.Add(this.labelEndStateFL);
			this.groupBoxEndState.Location = new System.Drawing.Point(12, 139);
			this.groupBoxEndState.Name = "groupBoxEndState";
			this.groupBoxEndState.Size = new System.Drawing.Size(366, 101);
			this.groupBoxEndState.TabIndex = 3;
			this.groupBoxEndState.TabStop = false;
			this.groupBoxEndState.Text = "Текущее состояние";
			// 
			// comboBoxEndStateFT
			// 
			this.comboBoxEndStateFT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEndStateFT.FormattingEnabled = true;
			this.comboBoxEndStateFT.Location = new System.Drawing.Point(181, 62);
			this.comboBoxEndStateFT.Name = "comboBoxEndStateFT";
			this.comboBoxEndStateFT.Size = new System.Drawing.Size(179, 21);
			this.comboBoxEndStateFT.TabIndex = 3;
			// 
			// labelEndStateFT
			// 
			this.labelEndStateFT.AutoSize = true;
			this.labelEndStateFT.Location = new System.Drawing.Point(17, 65);
			this.labelEndStateFT.Name = "labelEndStateFT";
			this.labelEndStateFT.Size = new System.Drawing.Size(129, 13);
			this.labelEndStateFT.TabIndex = 2;
			this.labelEndStateFT.Text = "По нечеткой тенденции:";
			// 
			// comboBoxEndStateFL
			// 
			this.comboBoxEndStateFL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEndStateFL.FormattingEnabled = true;
			this.comboBoxEndStateFL.Location = new System.Drawing.Point(181, 23);
			this.comboBoxEndStateFL.Name = "comboBoxEndStateFL";
			this.comboBoxEndStateFL.Size = new System.Drawing.Size(179, 21);
			this.comboBoxEndStateFL.TabIndex = 1;
			// 
			// labelEndStateFL
			// 
			this.labelEndStateFL.AutoSize = true;
			this.labelEndStateFL.Location = new System.Drawing.Point(17, 26);
			this.labelEndStateFL.Name = "labelEndStateFL";
			this.labelEndStateFL.Size = new System.Drawing.Size(107, 13);
			this.labelEndStateFL.TabIndex = 0;
			this.labelEndStateFL.Text = "По нечеткой метке:";
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(220, 316);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 7;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(78, 250);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(300, 50);
			this.textBoxDescription.TabIndex = 5;
			// 
			// labelDescription
			// 
			this.labelDescription.AutoSize = true;
			this.labelDescription.Location = new System.Drawing.Point(12, 253);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(60, 13);
			this.labelDescription.TabIndex = 4;
			this.labelDescription.Text = "Описание:";
			// 
			// FormStatisticFuzzy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(384, 352);
			this.Controls.Add(this.groupBoxStartState);
			this.Controls.Add(this.textBoxNumberSituation);
			this.Controls.Add(this.labelNumberSituation);
			this.Controls.Add(this.groupBoxEndState);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelDescription);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormStatisticFuzzy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Статистика по нечеткости";
			this.Load += new System.EventHandler(this.FormStatisticFuzzy_Load);
			this.groupBoxStartState.ResumeLayout(false);
			this.groupBoxStartState.PerformLayout();
			this.groupBoxEndState.ResumeLayout(false);
			this.groupBoxEndState.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxStartState;
        private System.Windows.Forms.ComboBox comboBoxStartStateFT;
        private System.Windows.Forms.Label labelStartStateFT;
        private System.Windows.Forms.ComboBox comboBoxStartStateFL;
        private System.Windows.Forms.Label labelStartStateFL;
        private System.Windows.Forms.TextBox textBoxNumberSituation;
        private System.Windows.Forms.Label labelNumberSituation;
        private System.Windows.Forms.GroupBox groupBoxEndState;
        private System.Windows.Forms.ComboBox comboBoxEndStateFT;
        private System.Windows.Forms.Label labelEndStateFT;
        private System.Windows.Forms.ComboBox comboBoxEndStateFL;
        private System.Windows.Forms.Label labelEndStateFL;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
    }
}