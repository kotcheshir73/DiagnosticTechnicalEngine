namespace DiagnosticTechnicalEngine.Controls
{
	partial class UserControlPountTrend
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnStartPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnFinishPount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panelRuleTrendMove = new System.Windows.Forms.Panel();
			this.buttonClear = new System.Windows.Forms.Button();
			this.buttonMakeRules = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
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
            this.ColumnStartPoint,
            this.ColumnFinishPount,
            this.ColumnCount,
            this.ColumnWeight});
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
			// ColumnStartPoint
			// 
			this.ColumnStartPoint.HeaderText = "Нначальная точка";
			this.ColumnStartPoint.Name = "ColumnStartPoint";
			this.ColumnStartPoint.ReadOnly = true;
			this.ColumnStartPoint.Width = 130;
			// 
			// ColumnFinishPount
			// 
			this.ColumnFinishPount.HeaderText = "Конечная точка";
			this.ColumnFinishPount.Name = "ColumnFinishPount";
			this.ColumnFinishPount.ReadOnly = true;
			this.ColumnFinishPount.Width = 120;
			// 
			// ColumnCount
			// 
			this.ColumnCount.HeaderText = "Количество";
			this.ColumnCount.Name = "ColumnCount";
			this.ColumnCount.ReadOnly = true;
			// 
			// ColumnWeight
			// 
			this.ColumnWeight.HeaderText = "Вес";
			this.ColumnWeight.Name = "ColumnWeight";
			this.ColumnWeight.ReadOnly = true;
			this.ColumnWeight.Width = 80;
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
			// UserControlPountTrend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.groupBox);
			this.Name = "UserControlPountTrend";
			this.Size = new System.Drawing.Size(530, 200);
			this.groupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panelRuleTrendMove.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Panel panelRuleTrendMove;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Button buttonMakeRules;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.Button buttonUpd;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStartPoint;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinishPount;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeight;
	}
}
