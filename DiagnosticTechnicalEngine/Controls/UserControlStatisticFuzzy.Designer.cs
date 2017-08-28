namespace DiagnosticTechnicalEngine.Controls
{
    partial class UserControlStatisticFuzzy
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
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDefinition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelStatisticEntropyMove = new System.Windows.Forms.Panel();
            this.buttonWatch = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
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
            this.ColumnNumber,
            this.ColumnFrom,
            this.ColumnTo,
            this.ColumnDefinition,
            this.ColumnPercent});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 16);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(594, 351);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.HeaderText = "Номер";
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            this.ColumnNumber.Width = 80;
            // 
            // ColumnFrom
            // 
            this.ColumnFrom.HeaderText = "Предыдущее состояние";
            this.ColumnFrom.Name = "ColumnFrom";
            this.ColumnFrom.ReadOnly = true;
            this.ColumnFrom.Width = 200;
            // 
            // ColumnTo
            // 
            this.ColumnTo.HeaderText = "Следующее состояние";
            this.ColumnTo.Name = "ColumnTo";
            this.ColumnTo.ReadOnly = true;
            this.ColumnTo.Width = 200;
            // 
            // ColumnDefinition
            // 
            this.ColumnDefinition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDefinition.HeaderText = "Описание ситуации";
            this.ColumnDefinition.Name = "ColumnDefinition";
            this.ColumnDefinition.ReadOnly = true;
            // 
            // ColumnPercent
            // 
            this.ColumnPercent.HeaderText = "Вероятность";
            this.ColumnPercent.Name = "ColumnPercent";
            this.ColumnPercent.ReadOnly = true;
            // 
            // panelStatisticEntropyMove
            // 
            this.panelStatisticEntropyMove.Controls.Add(this.buttonRefresh);
            this.panelStatisticEntropyMove.Controls.Add(this.buttonWatch);
            this.panelStatisticEntropyMove.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatisticEntropyMove.Location = new System.Drawing.Point(3, 367);
            this.panelStatisticEntropyMove.Name = "panelStatisticEntropyMove";
            this.panelStatisticEntropyMove.Size = new System.Drawing.Size(594, 30);
            this.panelStatisticEntropyMove.TabIndex = 1;
            // 
            // buttonWatch
            // 
            this.buttonWatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonWatch.Location = new System.Drawing.Point(3, 3);
            this.buttonWatch.Name = "buttonWatch";
            this.buttonWatch.Size = new System.Drawing.Size(95, 23);
            this.buttonWatch.TabIndex = 0;
            this.buttonWatch.Text = "Посмотреть";
            this.buttonWatch.UseVisualStyleBackColor = true;
            this.buttonWatch.Click += new System.EventHandler(this.buttonWatch_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRefresh.Location = new System.Drawing.Point(113, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(100, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Обновить";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // UserControlStatisticFuzzy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "UserControlStatisticFuzzy";
            this.Size = new System.Drawing.Size(600, 400);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelStatisticEntropyMove.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDefinition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPercent;
        private System.Windows.Forms.Panel panelStatisticEntropyMove;
		private System.Windows.Forms.Button buttonWatch;
        private System.Windows.Forms.Button buttonRefresh;
    }
}
