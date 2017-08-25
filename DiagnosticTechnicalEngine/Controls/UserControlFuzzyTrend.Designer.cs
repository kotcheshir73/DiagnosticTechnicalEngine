namespace DiagnosticTechnicalEngine.Controls
{
	partial class UserControlFuzzyTrend
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
			this.panel = new System.Windows.Forms.Panel();
			this.buttonClear = new System.Windows.Forms.Button();
			this.buttonGeneric = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			this.groupBox.Controls.Add(this.dataGridView);
			this.groupBox.Controls.Add(this.panel);
			this.groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox.Location = new System.Drawing.Point(0, 0);
			this.groupBox.Name = "groupBox";
			this.groupBox.Size = new System.Drawing.Size(530, 200);
			this.groupBox.TabIndex = 0;
			this.groupBox.TabStop = false;
			this.groupBox.Text = "Нечеткие тенденции";
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
			// panel
			// 
			this.panel.Controls.Add(this.buttonClear);
			this.panel.Controls.Add(this.buttonGeneric);
			this.panel.Controls.Add(this.buttonDel);
			this.panel.Controls.Add(this.buttonUpd);
			this.panel.Controls.Add(this.buttonAdd);
			this.panel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel.Location = new System.Drawing.Point(3, 167);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(524, 30);
			this.panel.TabIndex = 1;
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
			// buttonGeneric
			// 
			this.buttonGeneric.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.buttonGeneric.Location = new System.Drawing.Point(420, 3);
			this.buttonGeneric.Name = "buttonGeneric";
			this.buttonGeneric.Size = new System.Drawing.Size(100, 23);
			this.buttonGeneric.TabIndex = 4;
			this.buttonGeneric.Text = "Сгенерировать";
			this.buttonGeneric.UseVisualStyleBackColor = true;
			this.buttonGeneric.Click += new System.EventHandler(this.buttonGeneric_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Anchor = System.Windows.Forms.AnchorStyles.None;
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
			// ColumnId
			// 
			this.ColumnId.HeaderText = "ColumnId";
			this.ColumnId.Name = "ColumnId";
			this.ColumnId.ReadOnly = true;
			this.ColumnId.Visible = false;
			// 
			// ColumnName
			// 
			this.ColumnName.HeaderText = "Название";
			this.ColumnName.Name = "ColumnName";
			this.ColumnName.ReadOnly = true;
			this.ColumnName.Width = 200;
			// 
			// ColumnWeight
			// 
			this.ColumnWeight.HeaderText = "Вес";
			this.ColumnWeight.Name = "ColumnWeight";
			this.ColumnWeight.ReadOnly = true;
			// 
			// UserControlFuzzyTrend
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.groupBox);
			this.Name = "UserControlFuzzyTrend";
			this.Size = new System.Drawing.Size(530, 200);
			this.groupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Button buttonGeneric;
		private System.Windows.Forms.Button buttonDel;
		private System.Windows.Forms.Button buttonUpd;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWeight;
	}
}
