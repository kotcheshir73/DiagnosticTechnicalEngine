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
			groupBox = new GroupBox();
			dataGridView = new DataGridView();
			panel = new Panel();
			buttonRefresh = new Button();
			buttonClear = new Button();
			buttonDel = new Button();
			buttonUpd = new Button();
			buttonAdd = new Button();
			groupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(dataGridView)).BeginInit();
			panel.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox
			// 
			groupBox.Controls.Add(dataGridView);
			groupBox.Controls.Add(panel);
			groupBox.Dock = DockStyle.Fill;
			groupBox.Location = new System.Drawing.Point(0, 0);
			groupBox.Name = "groupBox";
			groupBox.Size = new System.Drawing.Size(600, 200);
			groupBox.TabIndex = 0;
			groupBox.TabStop = false;
			// 
			// dataGridView
			// 
			dataGridView.AllowUserToAddRows = false;
			dataGridView.AllowUserToDeleteRows = false;
			dataGridView.AllowUserToResizeRows = false;
			dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Dock = DockStyle.Fill;
			dataGridView.Location = new System.Drawing.Point(3, 16);
			dataGridView.Name = "dataGridView";
			dataGridView.ReadOnly = true;
			dataGridView.RowHeadersVisible = false;
			dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView.Size = new System.Drawing.Size(594, 151);
			dataGridView.TabIndex = 0;
			dataGridView.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(DataGridView_CellMouseDoubleClick);
			// 
			// panel
			// 
			panel.Controls.Add(buttonRefresh);
			panel.Controls.Add(buttonClear);
			panel.Controls.Add(buttonDel);
			panel.Controls.Add(buttonUpd);
			panel.Controls.Add(buttonAdd);
			panel.Dock = DockStyle.Bottom;
			panel.Location = new System.Drawing.Point(3, 167);
			panel.Name = "panel";
			panel.Size = new System.Drawing.Size(594, 30);
			panel.TabIndex = 1;
			// 
			// buttonRefresh
			// 
			buttonRefresh.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left);
			buttonRefresh.Location = new System.Drawing.Point(363, 3);
			buttonRefresh.Name = "buttonRefresh";
			buttonRefresh.Size = new System.Drawing.Size(75, 23);
			buttonRefresh.TabIndex = 4;
			buttonRefresh.Text = "Обновить";
			buttonRefresh.UseVisualStyleBackColor = true;
			buttonRefresh.Click += new EventHandler(ButtonRefresh_Click);
			// 
			// buttonClear
			// 
			buttonClear.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left);
			buttonClear.Location = new System.Drawing.Point(273, 3);
			buttonClear.Name = "buttonClear";
			buttonClear.Size = new System.Drawing.Size(75, 23);
			buttonClear.TabIndex = 3;
			buttonClear.Text = "Отчистить";
			buttonClear.UseVisualStyleBackColor = true;
			buttonClear.Click += new EventHandler(ButtonClear_Click);
			// 
			// buttonDel
			// 
			buttonDel.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left);
			buttonDel.Location = new System.Drawing.Point(183, 3);
			buttonDel.Name = "buttonDel";
			buttonDel.Size = new System.Drawing.Size(75, 23);
			buttonDel.TabIndex = 2;
			buttonDel.Text = "Удалить";
			buttonDel.UseVisualStyleBackColor = true;
			buttonDel.Click += new EventHandler(ButtonDel_Click);
			// 
			// buttonUpd
			// 
			buttonUpd.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left);
			buttonUpd.Location = new System.Drawing.Point(93, 3);
			buttonUpd.Name = "buttonUpd";
			buttonUpd.Size = new System.Drawing.Size(75, 23);
			buttonUpd.TabIndex = 1;
			buttonUpd.Text = "Изменить";
			buttonUpd.UseVisualStyleBackColor = true;
			buttonUpd.Click += new EventHandler(ButtonUpd_Click);
			// 
			// buttonAdd
			// 
			buttonAdd.Anchor = ((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left);
			buttonAdd.Location = new System.Drawing.Point(3, 3);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new System.Drawing.Size(75, 23);
			buttonAdd.TabIndex = 0;
			buttonAdd.Text = "Добавить";
			buttonAdd.UseVisualStyleBackColor = true;
			buttonAdd.Click += new EventHandler(ButtonAdd_Click);
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

		public int ParentId { set { _parentId = value; if (_parentId > 0) { LoadData(); } } }
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
		protected virtual void LoadData()
		{
			try
			{
				_list = _logicClass.GetElements(_parentId);
				dataGridView.Rows.Clear();
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
				LoadData();
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
					LoadData();
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
				LoadData();
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
				LoadData();
			}
		}

		/// <summary>
		/// Обновление списка
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ButtonRefresh_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}
