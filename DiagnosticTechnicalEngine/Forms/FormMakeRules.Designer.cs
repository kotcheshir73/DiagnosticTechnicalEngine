namespace DiagnosticTechnicalEngine.Forms
{
    partial class FormMakeRules
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
			this.buttonMakeRules = new System.Windows.Forms.Button();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.panelMakeRuleMove = new System.Windows.Forms.Panel();
			this.buttonApply = new System.Windows.Forms.Button();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTrendName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnFuzzyLabelFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnFuzzyLabelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnTrendId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnLabelFromId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnLabelToId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panelMakeRuleMove.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonMakeRules
			// 
			this.buttonMakeRules.Location = new System.Drawing.Point(3, 3);
			this.buttonMakeRules.Name = "buttonMakeRules";
			this.buttonMakeRules.Size = new System.Drawing.Size(100, 23);
			this.buttonMakeRules.TabIndex = 0;
			this.buttonMakeRules.Text = "Сформировать";
			this.buttonMakeRules.UseVisualStyleBackColor = true;
			this.buttonMakeRules.Click += new System.EventHandler(this.buttonMakeRules_Click);
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
            this.ColumnTrendName,
            this.ColumnWeight,
            this.ColumnFuzzyLabelFrom,
            this.ColumnFuzzyLabelTo,
            this.ColumnTrendId,
            this.ColumnLabelFromId,
            this.ColumnLabelToId});
			this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView.Location = new System.Drawing.Point(0, 30);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersVisible = false;
			this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dataGridView.Size = new System.Drawing.Size(659, 427);
			this.dataGridView.TabIndex = 1;
			// 
			// panelMakeRuleMove
			// 
			this.panelMakeRuleMove.Controls.Add(this.buttonApply);
			this.panelMakeRuleMove.Controls.Add(this.buttonMakeRules);
			this.panelMakeRuleMove.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelMakeRuleMove.Location = new System.Drawing.Point(0, 0);
			this.panelMakeRuleMove.Name = "panelMakeRuleMove";
			this.panelMakeRuleMove.Size = new System.Drawing.Size(659, 30);
			this.panelMakeRuleMove.TabIndex = 0;
			// 
			// buttonApply
			// 
			this.buttonApply.Location = new System.Drawing.Point(547, 4);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(100, 23);
			this.buttonApply.TabIndex = 1;
			this.buttonApply.Text = "Применить";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// ColumnId
			// 
			this.ColumnId.HeaderText = "ColumnId";
			this.ColumnId.Name = "ColumnId";
			this.ColumnId.Visible = false;
			// 
			// ColumnTrendName
			// 
			this.ColumnTrendName.HeaderText = "Тенденция";
			this.ColumnTrendName.Name = "ColumnTrendName";
			this.ColumnTrendName.Width = 150;
			// 
			// ColumnWeight
			// 
			this.ColumnWeight.HeaderText = "Вес";
			this.ColumnWeight.Name = "ColumnWeight";
			// 
			// ColumnFuzzyLabelFrom
			// 
			this.ColumnFuzzyLabelFrom.HeaderText = "Нечеткая метка - исходник";
			this.ColumnFuzzyLabelFrom.Name = "ColumnFuzzyLabelFrom";
			this.ColumnFuzzyLabelFrom.ReadOnly = true;
			this.ColumnFuzzyLabelFrom.Width = 170;
			// 
			// ColumnFuzzyLabelTo
			// 
			this.ColumnFuzzyLabelTo.HeaderText = "Нечеткая метка - приемник";
			this.ColumnFuzzyLabelTo.Name = "ColumnFuzzyLabelTo";
			this.ColumnFuzzyLabelTo.ReadOnly = true;
			this.ColumnFuzzyLabelTo.Width = 180;
			// 
			// ColumnTrendId
			// 
			this.ColumnTrendId.HeaderText = "ColumnTrendId";
			this.ColumnTrendId.Name = "ColumnTrendId";
			this.ColumnTrendId.Visible = false;
			// 
			// ColumnLabelFromId
			// 
			this.ColumnLabelFromId.HeaderText = "ColumnLabelFromId";
			this.ColumnLabelFromId.Name = "ColumnLabelFromId";
			this.ColumnLabelFromId.Visible = false;
			// 
			// ColumnLabelToId
			// 
			this.ColumnLabelToId.HeaderText = "ColumnLabelToId";
			this.ColumnLabelToId.Name = "ColumnLabelToId";
			this.ColumnLabelToId.Visible = false;
			// 
			// FormMakeRules
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(659, 457);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.panelMakeRuleMove);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMakeRules";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Формирование правил";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panelMakeRuleMove.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMakeRules;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelMakeRuleMove;
        private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTrendName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeight;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFuzzyLabelFrom;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFuzzyLabelTo;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTrendId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLabelFromId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLabelToId;
	}
}