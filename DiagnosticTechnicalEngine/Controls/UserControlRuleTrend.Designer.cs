namespace DiagnosticTechnicalEngine.Controls
{
    partial class UserControlRuleTrend
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
            this.ColumnTrendName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuzzyLabelFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuzzyLabelTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelRuleTrendMove = new System.Windows.Forms.Panel();
            this.buttonMakeRules = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelRuleTrendMove.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.dataGridView);
            this.groupBox.Controls.Add(this.panelRuleTrendMove);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(530, 200);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Правила вычисления тенденций";
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
            this.ColumnFuzzyLabelFrom,
            this.ColumnFuzzyLabelTo});
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 16);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(524, 151);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ColumnId";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnTrendName
            // 
            this.ColumnTrendName.HeaderText = "Тенденция";
            this.ColumnTrendName.Name = "ColumnTrendName";
            this.ColumnTrendName.ReadOnly = true;
            this.ColumnTrendName.Width = 150;
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
            // panelRuleTrendMove
            // 
            this.panelRuleTrendMove.Controls.Add(this.buttonClear);
            this.panelRuleTrendMove.Controls.Add(this.buttonMakeRules);
            this.panelRuleTrendMove.Controls.Add(this.buttonDel);
            this.panelRuleTrendMove.Controls.Add(this.buttonUpd);
            this.panelRuleTrendMove.Controls.Add(this.buttonAdd);
            this.panelRuleTrendMove.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRuleTrendMove.Location = new System.Drawing.Point(3, 167);
            this.panelRuleTrendMove.Name = "panelRuleTrendMove";
            this.panelRuleTrendMove.Size = new System.Drawing.Size(524, 30);
            this.panelRuleTrendMove.TabIndex = 1;
            // 
            // buttonMakeRules
            // 
            this.buttonMakeRules.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonMakeRules.Location = new System.Drawing.Point(420, 3);
            this.buttonMakeRules.Name = "buttonMakeRules";
            this.buttonMakeRules.Size = new System.Drawing.Size(100, 23);
            this.buttonMakeRules.TabIndex = 4;
            this.buttonMakeRules.Text = "Сформировать";
            this.buttonMakeRules.UseVisualStyleBackColor = true;
            this.buttonMakeRules.Click += new System.EventHandler(this.buttonMakeRules_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonDel.Location = new System.Drawing.Point(185, 3);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(75, 23);
            this.buttonDel.TabIndex = 2;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUpd.Location = new System.Drawing.Point(95, 3);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(75, 23);
            this.buttonUpd.TabIndex = 1;
            this.buttonUpd.Text = "Изменить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClear.Location = new System.Drawing.Point(275, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Отчистить";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // UserControlRuleTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox);
            this.MinimumSize = new System.Drawing.Size(530, 200);
            this.Name = "UserControlRuleTrend";
            this.Size = new System.Drawing.Size(530, 200);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelRuleTrendMove.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Panel panelRuleTrendMove;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTrendName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFuzzyLabelFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFuzzyLabelTo;
        private System.Windows.Forms.Button buttonMakeRules;
        private System.Windows.Forms.Button buttonClear;
    }
}
