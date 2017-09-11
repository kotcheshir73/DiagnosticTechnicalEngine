using ServicesModule.Interfaces;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.StandartClasses
{
	public class StandartForm<T, U> : Form
	{
		// Две кнопки будут всегда
		protected Button buttonClose;

		protected Button buttonSave;

		#region Стандартные методы для формы
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
		/// Переопределяем InitializeComponent (инициализация 2-х кнопок + общие настройки для формы)
		/// </summary>
		protected virtual void InitializeComponent()
		{
			buttonClose = new Button();
			buttonSave = new Button();
			// 
			// buttonClose
			// 
			buttonClose.Name = "buttonClose";
			buttonClose.Size = new System.Drawing.Size(75, 23);
			buttonClose.TabIndex = 13;
			buttonClose.Text = "Закрыть";
			buttonClose.UseVisualStyleBackColor = true;
			buttonClose.Click += new EventHandler(ButtonClose_Click);
			// 
			// buttonSave
			// 
			buttonSave.Enabled = false;
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new System.Drawing.Size(75, 23);
			buttonSave.TabIndex = 12;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += new EventHandler(ButtonSave_Click);
			// 
			// Form
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			Controls.Add(buttonClose);
			Controls.Add(buttonSave);
			MaximizeBox = false;
			MinimizeBox = false;
			StartPosition = FormStartPosition.CenterScreen;
			Load += new EventHandler(Form_Load);
		}

		/// <summary>
		/// Метод загрузки формы
		/// Вызывает вирутальный метод LoadElement, который должен быть перегружен для каждого дочернего класса
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Load(object sender, EventArgs e)
		{
			try
			{
				LoadComboBox();
				if (_id.HasValue)
				{
					_element = _logicClass.GetElement(_id.Value);
					LoadElement();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке: " + ex.Message, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Обработка нажатия кнопки сохранения
		/// Вызывает метод вставки или обновления из сервиса. В методы передаются объекты, полученные из методов GetInsertedElement и GetUpdateedElement
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (!_id.HasValue)
				{
					_logicClass.InsertElement(GetInsertedElement());
				}
				else
				{
					_logicClass.UpdateElement(GetUpdateedElement());
				}
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Анализ временных рядов", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Обработка нажатия кнопки закрытия
		/// Если были изменения, предлагаетс их сохранить, иначе просто закрывает. При сохранении вызывается метод обработки нажатия кнокпи сохранения
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonClose_Click(object sender, EventArgs e)
		{
			if (buttonSave.Enabled)
			{
				if (MessageBox.Show("Сохранить изменения?", "Анализ временных рядов", MessageBoxButtons.YesNo,
					MessageBoxIcon.Question) == DialogResult.Yes)
				{
					ButtonSave_Click(sender, e);
				}
				else
				{
					DialogResult = DialogResult.Cancel;
					Close();
				}
			}
			else
			{
				DialogResult = DialogResult.None;
				Close();
			}
		}

		/// <summary>
		/// Конструктор
		/// Вызывает метод инициализации компонентов
		/// </summary>
		public StandartForm()
		{
			InitializeComponent();
		}

		#region Пользовательские поля
		/// <summary>
		/// Идентификатор объекта
		/// Если Null, то новый объект
		/// </summary>
		protected int? _id;

		/// <summary>
		/// Идентификатор временного ряда или диагностическогго теста
		/// </summary>
		protected int _parentId;

		/// <summary>
		/// Класс, в котором реализован сервис
		/// </summary>
		protected ISeriesDescriptionModel<T, U> _logicClass;

		/// <summary>
		/// Элемент для заполнения данных на форме из полученных от класса-сервиса
		/// Используется в LoadElement в перегрузках дочерних классов
		/// </summary>
		protected T _element;
		#endregion

		/// <summary>
		/// Инициализация пользовательских параметров
		/// </summary>
		/// <param name="parentId"></param>
		/// <param name="id"></param>
		public void Initialize(ISeriesDescriptionModel<T, U> logicClass, int parentId, int? id = null)
		{
			_id = id;
			_parentId = parentId;
			_logicClass = logicClass;
		}

		/// <summary>
		/// Заполнение элементов формы - выпадающих списков, если таки есть на форме
		/// Перегружается в дочерних классах при наличии таких элементов
		/// </summary>
		protected virtual void LoadComboBox() { }

		/// <summary>
		/// Получение данных по элементу для редактирования из БД через класс-сервис
		/// Перегружать в дочерних классах для заполнения полей формы данными
		/// </summary>
		protected virtual void LoadElement()
		{
		}

		/// <summary>
		/// Формирует объект с данными для последующего добавления в БД через класс-сервис
		/// Обязателньо перегружать в дочерних классах
		/// </summary>
		/// <returns></returns>
		protected virtual U GetInsertedElement() { return default(U); }

		/// <summary>
		/// Формирует объект с данными для последующего изменения в БД через класс-сервис
		/// Обязателньо перегружать в дочерних классах
		/// </summary>
		/// <returns></returns>
		protected virtual U GetUpdateedElement() { return default(U); }

		/// <summary>
		/// Привязывается ко всем выпадающим спискам
		/// Делает активной кнопку сохранения, если происходят изменения в выпадающем спискам
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		/// <summary>
		/// Привязывается ко всем текстовым полям
		/// Делает активной кнопку сохранения, если происходят изменения в текстовом поле
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void TextBox_TextChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}
	}
}
