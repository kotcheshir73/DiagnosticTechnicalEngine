using ServicesModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.StandartClasses
{
	public class StandartDiagnosticTestControl<T, U> : UserControl
	{
		#region Элементы контрола
		protected GroupBox groupBox;
		protected DataGridView dataGridView;
		protected Panel panel;
		private Button buttonRefresh;
		#endregion

		#region Component Designer generated code
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

		#endregion

		/// <summary>
		/// Переопределяем InitializeComponent (описывается контрол + основыне кнокпи и табличный элемент)
		/// В перегрузке требуется добавить колонки в таблицу и кнокпи, если требуется
		/// </summary>
		protected virtual void InitializeComponent()
		{
			dataGridView = new DataGridView
			{
				AllowUserToAddRows = false,
				AllowUserToDeleteRows = false,
				AllowUserToResizeRows = false,
				BackgroundColor = System.Drawing.SystemColors.ControlLightLight,
				ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(3, 16),
				Name = "dataGridView",
				ReadOnly = true,
				RowHeadersVisible = false,
				SelectionMode = DataGridViewSelectionMode.FullRowSelect,
				Size = new System.Drawing.Size(594, 151),
				TabIndex = 0
			};
			buttonRefresh = new Button
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
				Location = new System.Drawing.Point(3, 3),
				Name = "buttonRefresh",
				Size = new System.Drawing.Size(75, 23),
				TabIndex = 4,
				Text = "Обновить",
				UseVisualStyleBackColor = true
			};
			buttonRefresh.Click += new EventHandler(ButtonRefresh_Click);
			panel = new Panel
			{
				Dock = DockStyle.Bottom,
				Location = new System.Drawing.Point(3, 167),
				Name = "panel",
				Size = new System.Drawing.Size(594, 30),
				TabIndex = 1
			};
			panel.Controls.Add(buttonRefresh);
			groupBox = new GroupBox
			{
				Dock = DockStyle.Fill,
				Location = new System.Drawing.Point(0, 0),
				Name = "groupBox",
				Size = new System.Drawing.Size(600, 200),
				TabIndex = 0,
				TabStop = false
			};
			groupBox.SuspendLayout();
			groupBox.Controls.Add(dataGridView);
			groupBox.Controls.Add(panel);
			((System.ComponentModel.ISupportInitialize)(dataGridView)).BeginInit();
			panel.SuspendLayout();
			SuspendLayout();
			// 
			// UserControl
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Transparent;
			Controls.Add(groupBox);
			MinimumSize = new System.Drawing.Size(530, 200);
			Name = "UserControl";
			Size = new System.Drawing.Size(600, 200);
			groupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(dataGridView)).EndInit();
			panel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#region Пользовательские поля
		protected int _parentId;

		protected ISeriesDescriptionModel<T, U> _logicClass;

		protected IEnumerable<T> _list;

		public int ParentId { set { _parentId = value; if (_parentId > 0) { GetList(); } } }
		#endregion

		/// <summary>
		/// Конструктор, вызывает инициализацию контрола
		/// </summary>
		public StandartDiagnosticTestControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Метод, принимающий параметры для работы контроола
		/// </summary>
		/// <param name="logicClass"></param>
		public void Initialize(ISeriesDescriptionModel<T, U> logicClass)
		{
			_logicClass = logicClass;
		}

		/// <summary>
		/// Получение данных для заполнения таблицы
		/// Требуется перегрузка для заполнения полей таблицы, исходя из объекта
		/// </summary>
		protected virtual void LoadData() { }

		private void GetList()
		{
			try
			{
				_list = _logicClass.GetElements(_parentId);
				dataGridView.Rows.Clear();
				LoadData();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке: " + ex.Message, "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Обновление списка
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ButtonRefresh_Click(object sender, EventArgs e)
		{
			GetList();
		}
	}
}
