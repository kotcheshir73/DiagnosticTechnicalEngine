namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormStatisticEntropy
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
			this.labelNumberSituation = new System.Windows.Forms.Label();
			this.textBoxNumberSituation = new System.Windows.Forms.TextBox();
			this.groupBoxStartState = new System.Windows.Forms.GroupBox();
			this.comboBoxStartStateFT = new System.Windows.Forms.ComboBox();
			this.labelStartStateFFT = new System.Windows.Forms.Label();
			this.comboBoxStartStateUX = new System.Windows.Forms.ComboBox();
			this.labelStartStatePUX = new System.Windows.Forms.Label();
			this.groupBoxEndState = new System.Windows.Forms.GroupBox();
			this.comboBoxEndStateFT = new System.Windows.Forms.ComboBox();
			this.labelEndStateFFT = new System.Windows.Forms.Label();
			this.comboBoxEndStateUX = new System.Windows.Forms.ComboBox();
			this.labelEndStatePUX = new System.Windows.Forms.Label();
			this.labelDescription = new System.Windows.Forms.Label();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.buttonClose = new System.Windows.Forms.Button();
			this.groupBoxStartState.SuspendLayout();
			this.groupBoxEndState.SuspendLayout();
			this.SuspendLayout();
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
			// textBoxNumberSituation
			// 
			this.textBoxNumberSituation.Location = new System.Drawing.Point(111, 6);
			this.textBoxNumberSituation.MaxLength = 3;
			this.textBoxNumberSituation.Name = "textBoxNumberSituation";
			this.textBoxNumberSituation.Size = new System.Drawing.Size(50, 20);
			this.textBoxNumberSituation.TabIndex = 1;
			this.textBoxNumberSituation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBoxStartState
			// 
			this.groupBoxStartState.Controls.Add(this.comboBoxStartStateFT);
			this.groupBoxStartState.Controls.Add(this.labelStartStateFFT);
			this.groupBoxStartState.Controls.Add(this.comboBoxStartStateUX);
			this.groupBoxStartState.Controls.Add(this.labelStartStatePUX);
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
			// labelStartStateFFT
			// 
			this.labelStartStateFFT.AutoSize = true;
			this.labelStartStateFFT.Location = new System.Drawing.Point(17, 65);
			this.labelStartStateFFT.Name = "labelStartStateFFT";
			this.labelStartStateFFT.Size = new System.Drawing.Size(138, 13);
			this.labelStartStateFFT.TabIndex = 2;
			this.labelStartStateFFT.Text = "По отклонению прогноза:";
			// 
			// comboBoxStartStateUX
			// 
			this.comboBoxStartStateUX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxStartStateUX.FormattingEnabled = true;
			this.comboBoxStartStateUX.Location = new System.Drawing.Point(181, 23);
			this.comboBoxStartStateUX.Name = "comboBoxStartStateUX";
			this.comboBoxStartStateUX.Size = new System.Drawing.Size(179, 21);
			this.comboBoxStartStateUX.TabIndex = 1;
			// 
			// labelStartStatePUX
			// 
			this.labelStartStatePUX.AutoSize = true;
			this.labelStartStatePUX.Location = new System.Drawing.Point(17, 26);
			this.labelStartStatePUX.Name = "labelStartStatePUX";
			this.labelStartStatePUX.Size = new System.Drawing.Size(158, 13);
			this.labelStartStatePUX.TabIndex = 0;
			this.labelStartStatePUX.Text = "По функции принадлежности:";
			// 
			// groupBoxEndState
			// 
			this.groupBoxEndState.Controls.Add(this.comboBoxEndStateFT);
			this.groupBoxEndState.Controls.Add(this.labelEndStateFFT);
			this.groupBoxEndState.Controls.Add(this.comboBoxEndStateUX);
			this.groupBoxEndState.Controls.Add(this.labelEndStatePUX);
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
			// labelEndStateFFT
			// 
			this.labelEndStateFFT.AutoSize = true;
			this.labelEndStateFFT.Location = new System.Drawing.Point(17, 65);
			this.labelEndStateFFT.Name = "labelEndStateFFT";
			this.labelEndStateFFT.Size = new System.Drawing.Size(138, 13);
			this.labelEndStateFFT.TabIndex = 2;
			this.labelEndStateFFT.Text = "По отклонению прогноза:";
			// 
			// comboBoxEndStateUX
			// 
			this.comboBoxEndStateUX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxEndStateUX.FormattingEnabled = true;
			this.comboBoxEndStateUX.Location = new System.Drawing.Point(181, 23);
			this.comboBoxEndStateUX.Name = "comboBoxEndStateUX";
			this.comboBoxEndStateUX.Size = new System.Drawing.Size(179, 21);
			this.comboBoxEndStateUX.TabIndex = 1;
			// 
			// labelEndStatePUX
			// 
			this.labelEndStatePUX.AutoSize = true;
			this.labelEndStatePUX.Location = new System.Drawing.Point(17, 26);
			this.labelEndStatePUX.Name = "labelEndStatePUX";
			this.labelEndStatePUX.Size = new System.Drawing.Size(158, 13);
			this.labelEndStatePUX.TabIndex = 0;
			this.labelEndStatePUX.Text = "По функции принадлежности:";
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
			// textBoxDescription
			// 
			this.textBoxDescription.Location = new System.Drawing.Point(78, 250);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(300, 50);
			this.textBoxDescription.TabIndex = 5;
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
			// FormStatisticEntropy
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(384, 352);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.textBoxDescription);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.groupBoxEndState);
			this.Controls.Add(this.groupBoxStartState);
			this.Controls.Add(this.textBoxNumberSituation);
			this.Controls.Add(this.labelNumberSituation);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormStatisticEntropy";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Статистика по энтропии";
			this.Load += new System.EventHandler(this.FormStatisticEntropy_Load);
			this.groupBoxStartState.ResumeLayout(false);
			this.groupBoxStartState.PerformLayout();
			this.groupBoxEndState.ResumeLayout(false);
			this.groupBoxEndState.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumberSituation;
        private System.Windows.Forms.TextBox textBoxNumberSituation;
        private System.Windows.Forms.GroupBox groupBoxStartState;
        private System.Windows.Forms.ComboBox comboBoxStartStateUX;
        private System.Windows.Forms.Label labelStartStatePUX;
        private System.Windows.Forms.ComboBox comboBoxStartStateFT;
        private System.Windows.Forms.Label labelStartStateFFT;
        private System.Windows.Forms.GroupBox groupBoxEndState;
        private System.Windows.Forms.ComboBox comboBoxEndStateFT;
        private System.Windows.Forms.Label labelEndStateFFT;
        private System.Windows.Forms.ComboBox comboBoxEndStateUX;
        private System.Windows.Forms.Label labelEndStatePUX;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonClose;
    }
}