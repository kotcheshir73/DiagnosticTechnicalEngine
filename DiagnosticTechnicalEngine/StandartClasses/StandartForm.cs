using ServicesModule.Interfaces;
using System;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.StandartClasses
{
	public class StandartForm<T, U> : Form
	{
		protected Button buttonClose;

		protected Button buttonSave;

		protected int? _id;

		protected int _seriesId;

		protected ISeriesDescriptionModel<T, U> _logicClass;

		protected T _element;

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

		public StandartForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Конструктор, загружаем форму
		/// </summary>
		/// <param name="seriesId"></param>
		/// <param name="id"></param>
		public void Initialize(ISeriesDescriptionModel<T, U> logicClass, int seriesId, int? id = null)
		{
			_id = id;
			_seriesId = seriesId;
			_logicClass = logicClass;
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		protected virtual void InitializeComponent()
		{
			buttonClose = new Button();
			buttonSave = new Button();
		}

		protected virtual void LoadComboBox() { }

		protected virtual void LoadElement()
		{
			LoadComboBox();
			if (_id.HasValue)
			{
				_element = _logicClass.GetElement(_id.Value);
			}
		}

		protected virtual U GetInsertedElement() { return default(U); }

		protected virtual U GetUpdateedElement() { return default(U); }

		protected void Form_Load(object sender, EventArgs e)
		{
			try
			{
				LoadElement();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ошибка при загрузке: " + ex.Message, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected void ComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		protected void TextBox_TextChanged(object sender, EventArgs e)
		{
			buttonSave.Enabled = true;
		}

		protected void ButtonSave_Click(object sender, EventArgs e)
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
				MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Анализ временных рядов",
				 MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		protected void ButtonClose_Click(object sender, EventArgs e)
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
	}
}
