namespace DiagnosticTechnicalEngine.Forms
{
	partial class FormPointTrend
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
			this.labelStartPoint = new System.Windows.Forms.Label();
			this.textBoxStartPoint = new System.Windows.Forms.TextBox();
			this.textBoxFinishPoint = new System.Windows.Forms.TextBox();
			this.labelFinishPoint = new System.Windows.Forms.Label();
			this.textBoxCount = new System.Windows.Forms.TextBox();
			this.labelCount = new System.Windows.Forms.Label();
			this.textBoxWeight = new System.Windows.Forms.TextBox();
			this.labelWeight = new System.Windows.Forms.Label();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelStartPoint
			// 
			this.labelStartPoint.AutoSize = true;
			this.labelStartPoint.Location = new System.Drawing.Point(12, 9);
			this.labelStartPoint.Name = "labelStartPoint";
			this.labelStartPoint.Size = new System.Drawing.Size(96, 13);
			this.labelStartPoint.TabIndex = 0;
			this.labelStartPoint.Text = "Начальная точка:";
			// 
			// textBoxStartPoint
			// 
			this.textBoxStartPoint.Location = new System.Drawing.Point(118, 6);
			this.textBoxStartPoint.Name = "textBoxStartPoint";
			this.textBoxStartPoint.ReadOnly = true;
			this.textBoxStartPoint.Size = new System.Drawing.Size(47, 20);
			this.textBoxStartPoint.TabIndex = 1;
			// 
			// textBoxFinishPoint
			// 
			this.textBoxFinishPoint.Location = new System.Drawing.Point(288, 6);
			this.textBoxFinishPoint.Name = "textBoxFinishPoint";
			this.textBoxFinishPoint.ReadOnly = true;
			this.textBoxFinishPoint.Size = new System.Drawing.Size(47, 20);
			this.textBoxFinishPoint.TabIndex = 3;
			// 
			// labelFinishPoint
			// 
			this.labelFinishPoint.AutoSize = true;
			this.labelFinishPoint.Location = new System.Drawing.Point(186, 9);
			this.labelFinishPoint.Name = "labelFinishPoint";
			this.labelFinishPoint.Size = new System.Drawing.Size(89, 13);
			this.labelFinishPoint.TabIndex = 2;
			this.labelFinishPoint.Text = "Конечная точка:";
			// 
			// textBoxCount
			// 
			this.textBoxCount.Location = new System.Drawing.Point(118, 40);
			this.textBoxCount.Name = "textBoxCount";
			this.textBoxCount.ReadOnly = true;
			this.textBoxCount.Size = new System.Drawing.Size(47, 20);
			this.textBoxCount.TabIndex = 5;
			// 
			// labelCount
			// 
			this.labelCount.AutoSize = true;
			this.labelCount.Location = new System.Drawing.Point(12, 43);
			this.labelCount.Name = "labelCount";
			this.labelCount.Size = new System.Drawing.Size(100, 13);
			this.labelCount.TabIndex = 4;
			this.labelCount.Text = "Количство встреч:";
			// 
			// textBoxWeight
			// 
			this.textBoxWeight.Location = new System.Drawing.Point(288, 40);
			this.textBoxWeight.Name = "textBoxWeight";
			this.textBoxWeight.Size = new System.Drawing.Size(47, 20);
			this.textBoxWeight.TabIndex = 7;
			this.textBoxWeight.TextChanged += new System.EventHandler(this.textBox_TextChanged);
			// 
			// labelWeight
			// 
			this.labelWeight.AutoSize = true;
			this.labelWeight.Location = new System.Drawing.Point(186, 43);
			this.labelWeight.Name = "labelWeight";
			this.labelWeight.Size = new System.Drawing.Size(29, 13);
			this.labelWeight.TabIndex = 6;
			this.labelWeight.Text = "Вес:";
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(199, 83);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 9;
			this.buttonClose.Text = "Закрыть";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonSave
			// 
			this.buttonSave.Enabled = false;
			this.buttonSave.Location = new System.Drawing.Point(72, 83);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(75, 23);
			this.buttonSave.TabIndex = 8;
			this.buttonSave.Text = "Сохранить";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// FormPointTrend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 121);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonSave);
			this.Controls.Add(this.textBoxWeight);
			this.Controls.Add(this.labelWeight);
			this.Controls.Add(this.textBoxCount);
			this.Controls.Add(this.labelCount);
			this.Controls.Add(this.textBoxFinishPoint);
			this.Controls.Add(this.labelFinishPoint);
			this.Controls.Add(this.textBoxStartPoint);
			this.Controls.Add(this.labelStartPoint);
			this.Name = "FormPointTrend";
			this.Text = "Правило смены точек на фазовом простарнстве";
			this.Load += new System.EventHandler(this.FormPointTrend_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelStartPoint;
		private System.Windows.Forms.TextBox textBoxStartPoint;
		private System.Windows.Forms.TextBox textBoxFinishPoint;
		private System.Windows.Forms.Label labelFinishPoint;
		private System.Windows.Forms.TextBox textBoxCount;
		private System.Windows.Forms.Label labelCount;
		private System.Windows.Forms.TextBox textBoxWeight;
		private System.Windows.Forms.Label labelWeight;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSave;
	}
}