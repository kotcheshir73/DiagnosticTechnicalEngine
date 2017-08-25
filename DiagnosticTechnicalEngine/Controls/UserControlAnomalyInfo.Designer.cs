namespace DiagnosticTechnicalEngine.Controls
{
    partial class UserControlAnomalyInfo
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
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnSetSituation = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnCountMeet = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnNotAnomaly = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ColumnNotDetected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.panelStatisticEntropyMove = new System.Windows.Forms.Panel();
			this.buttonWatch = new System.Windows.Forms.Button();
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panelStatisticEntropyMove.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.dataGridView);
			this.groupBox.Controls.Add(this.panelStatisticEntropyMove);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(600, 400);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Ряд";
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.AllowUserToResizeRows = false;
			this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnSetSituation,
            this.ColumnCountMeet,
            this.ColumnDescription,
            this.ColumnNotAnomaly,
            this.ColumnNotDetected});
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(3, 16);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView.Size = new System.Drawing.Size(594, 351);
			this.dataGridView.TabIndex = 0;
			// 
			// ColumnId
			// 
			this.ColumnId.HeaderText = "Id";
			this.ColumnId.Name = "ColumnId";
			this.ColumnId.ReadOnly = true;
			this.ColumnId.Visible = false;
			// 
			// ColumnName
			// 
			this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnName.HeaderText = "Название";
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.ReadOnly = true;
			this.ColumnName.Width = 82;
			// 
			// ColumnSetSituation
			// 
			this.ColumnSetSituation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnSetSituation.HeaderText = "Набор ситуаций";
			this.ColumnSetSituation.Name = "ColumnSetSituation";
			this.ColumnSetSituation.ReadOnly = true;
			this.ColumnSetSituation.Width = 104;
			// 
			// ColumnCountMeet
			// 
			this.ColumnCountMeet.HeaderText = "Количество";
			this.ColumnCountMeet.Name = "ColumnCountMeet";
			this.ColumnCountMeet.ReadOnly = true;
			// 
			// ColumnDescription
			// 
			this.ColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ColumnDescription.HeaderText = "Описание";
			this.ColumnDescription.Name = "ColumnDescription";
			this.ColumnDescription.ReadOnly = true;
			// 
			// ColumnNotAnomaly
			// 
			this.ColumnNotAnomaly.FillWeight = 40F;
			this.ColumnNotAnomaly.HeaderText = "Аномалия";
			this.ColumnNotAnomaly.Name = "ColumnNotAnomaly";
			this.ColumnNotAnomaly.ReadOnly = true;
			// 
			// ColumnNotDetected
			// 
			this.ColumnNotDetected.HeaderText = "Не выявляемая";
			this.ColumnNotDetected.Name = "ColumnNotDetected";
			this.ColumnNotDetected.ReadOnly = true;
			// 
			// panelStatisticEntropyMove
			// 
			this.panelStatisticEntropyMove.Controls.Add(this.buttonWatch);
			this.panelStatisticEntropyMove.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelStatisticEntropyMove.Location = new System.Drawing.Point(3, 367);
			this.panelStatisticEntropyMove.Name = "panelStatisticEntropyMove";
			this.panelStatisticEntropyMove.Size = new System.Drawing.Size(594, 30);
			this.panelStatisticEntropyMove.TabIndex = 1;
			// 
			// buttonWatch
			// 
			this.buttonWatch.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonWatch.Location = new System.Drawing.Point(3, 4);
			this.buttonWatch.Name = "buttonWatch";
			this.buttonWatch.Size = new System.Drawing.Size(90, 23);
			this.buttonWatch.TabIndex = 0;
			this.buttonWatch.Text = "Посмотреть";
			this.buttonWatch.UseVisualStyleBackColor = true;
			this.buttonWatch.Click += new System.EventHandler(this.buttonWatch_Click);
			// 
			// UserControlAnomalyInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.groupBox);
			this.Name = "UserControlAnomalyInfo";
			this.Size = new System.Drawing.Size(600, 400);
			this.groupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panelStatisticEntropyMove.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelStatisticEntropyMove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSetSituation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCountMeet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnNotAnomaly;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnNotDetected;
		private System.Windows.Forms.Button buttonWatch;
	}
}
