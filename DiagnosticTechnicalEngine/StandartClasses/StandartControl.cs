using ServicesModule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.StandartClasses
{
	public class StandartControl<T, U, Z> : UserControl where Z : StandartForm<T, U>, new()
	{
		#region Элементы контрола
		protected GroupBox groupBox;
		protected DataGridView dataGridView;
		protected Panel panel;
		private Button buttonDel;
		private Button buttonUpd;
		private Button buttonAdd;
		private Button buttonClear;
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
			dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGridView_CellMouseDoubleClick);
			buttonAdd = new Button
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
				Location = new System.Drawing.Point(3, 3),
				Name = "buttonAdd",
				Size = new System.Drawing.Size(75, 23),
				TabIndex = 0,
				Text = "Добавить",
				UseVisualStyleBackColor = true
			};
			buttonAdd.Click += new EventHandler(ButtonAdd_Click);
			buttonUpd = new Button
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
				Location = new System.Drawing.Point(93, 3),
				Name = "buttonUpd",
				Size = new System.Drawing.Size(75, 23),
				TabIndex = 1,
				Text = "Изменить",
				UseVisualStyleBackColor = true
			};
			buttonUpd.Click += new EventHandler(ButtonUpd_Click);
			buttonDel = new Button
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
				Location = new System.Drawing.Point(183, 3),
				Name = "buttonDel",
				Size = new System.Drawing.Size(75, 23),
				TabIndex = 2,
				Text = "Удалить",
				UseVisualStyleBackColor = true
			};
			buttonDel.Click += new EventHandler(ButtonDel_Click);
			buttonClear = new Button
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
				Location = new System.Drawing.Point(273, 3),
				Name = "buttonClear",
				Size = new System.Drawing.Size(75, 23),
				TabIndex = 3,
				Text = "Отчистить",
				UseVisualStyleBackColor = true
			};
			buttonClear.Click += new EventHandler(ButtonClear_Click);
			buttonRefresh = new Button
			{
				Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left),
				Location = new System.Drawing.Point(363, 3),
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
			panel.Controls.Add(buttonAdd);
			panel.Controls.Add(buttonUpd);
			panel.Controls.Add(buttonDel);
			panel.Controls.Add(buttonClear);
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
		public StandartControl()
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
		/// Вызов формы для добавления нового элемента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonAdd_Click(object sender, EventArgs e)
		{
			var form = new Z();
			form.Initialize(_logicClass, _parentId);
			if (form.ShowDialog() == DialogResult.OK)
			{
				GetList();
			}
		}

		/// <summary>
		/// Вызов формы для редактирования элемента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count > 0)
			{
				var form = new Z();
				form.Initialize(_logicClass, _parentId, Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
				if (form.ShowDialog() == DialogResult.OK)
				{
					GetList();
				}
			}
		}

		/// <summary>
		/// Двойной клик по записи, вызываем форму для редактирования
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			ButtonUpd_Click(sender, e);
		}

		/// <summary>
		/// Удаление элемента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonDel_Click(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView.SelectedRows.Count > 0)
				{
					if (MessageBox.Show("Вы хотите удалить?", "Анализ временных рядов", MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
					{
						for (int i = 0; i < dataGridView.SelectedRows.Count; ++i)
						{
							_logicClass.DeleteElement(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value));
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при удалении: " + ex.Message, "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				GetList();
			}
		}

		/// <summary>
		/// Отчистка всего списка
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonClear_Click(object sender, EventArgs e)
		{
			try
			{
				if (dataGridView.SelectedRows.Count > 0)
				{
					if (MessageBox.Show("Вы хотите удалить?", "Анализ временных рядов", MessageBoxButtons.YesNo,
						MessageBoxIcon.Question) == DialogResult.Yes)
					{
						_logicClass.DeleteElements(_parentId);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при удалении: " + ex.Message, "Анализ временных рядов",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				GetList();
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

		protected void ChangeVisibiles(string controlElement, bool visibles)
		{
			panel.Controls.Find(controlElement, false).First().Visible = visibles;
		}
	}
}
