using DiagnosticTechnicalEngine.StandartClasses;
using DTE_Implement_Level.StaticClasses;
using DTE_Interface_Level.BindingModels;
using DTE_Interface_Level.ViewModels;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
    public class FormStatisticByEntropy : StandartForm<StatisticsByEntropyViewModel, StatisticsByEntropyBindingModel>
	{
		#region Контролы для работы
		private Label labelNumberSituation;
		private Label labelStartStatePUX;
		private Label labelStartStateFFT;
		private Label labelEndStateFFT;
		private Label labelEndStatePUX;
		private Label labelDescription;
		private TextBox textBoxNumberSituation;
		private GroupBox groupBoxStartState;
		private ComboBox comboBoxStartStateUX;
		private ComboBox comboBoxStartStateFT;
		private GroupBox groupBoxEndState;
		private ComboBox comboBoxEndStateFT;
		private ComboBox comboBoxEndStateUX;
		private TextBox textBoxDescription;
		#endregion

		protected override void InitializeComponent()
		{
			base.InitializeComponent();
			SuspendLayout();
			labelNumberSituation = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 9),
				Name = "labelNumberSituation",
				Size = new System.Drawing.Size(93, 13),
				TabIndex = 0,
				Text = "Номер ситуации:"
			};
			labelStartStateFFT = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 65),
				Name = "labelStartStateFFT",
				Size = new System.Drawing.Size(138, 13),
				TabIndex = 2,
				Text = "По отклонению прогноза:"
			};
			labelStartStatePUX = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 26),
				Name = "labelStartStatePUX",
				Size = new System.Drawing.Size(158, 13),
				TabIndex = 0,
				Text = "По функции принадлежности:"
			};
			labelEndStateFFT = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 65),
				Name = "labelEndStateFFT",
				Size = new System.Drawing.Size(138, 13),
				TabIndex = 2,
				Text = "По отклонению прогноза:"
			};
			labelEndStatePUX = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 26),
				Name = "labelEndStatePUX",
				Size = new System.Drawing.Size(158, 13),
				TabIndex = 0,
				Text = "По функции принадлежности:"
			};
			labelDescription = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(12, 253),
				Name = "labelDescription",
				Size = new System.Drawing.Size(60, 13),
				TabIndex = 4,
				Text = "Описание:"
			};
			textBoxNumberSituation = new TextBox
			{
				Location = new System.Drawing.Point(111, 6),
				MaxLength = 3,
				Name = "textBoxNumberSituation",
				Size = new System.Drawing.Size(50, 20),
				TabIndex = 1,
				TextAlign = HorizontalAlignment.Right
			};
			groupBoxStartState = new GroupBox
			{
				Location = new System.Drawing.Point(12, 32),
				Name = "groupBoxStartState",
				Size = new System.Drawing.Size(366, 101),
				TabIndex = 2,
				TabStop = false,
				Text = "Предыдущее состояние"
			};
			groupBoxStartState.SuspendLayout();
			groupBoxStartState.Controls.Add(comboBoxStartStateFT);
			groupBoxStartState.Controls.Add(labelStartStateFFT);
			groupBoxStartState.Controls.Add(comboBoxStartStateUX);
			groupBoxStartState.Controls.Add(labelStartStatePUX);
			comboBoxStartStateFT = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 62),
				Name = "comboBoxStartStateFT",
				Size = new System.Drawing.Size(179, 21),
				TabIndex = 3
			};
			comboBoxStartStateUX = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 23),
				Name = "comboBoxStartStateUX",
				Size = new System.Drawing.Size(179, 21),
				TabIndex = 1
			};
			groupBoxEndState = new GroupBox
			{
				Location = new System.Drawing.Point(12, 139),
				Name = "groupBoxEndState",
				Size = new System.Drawing.Size(366, 101),
				TabIndex = 3,
				TabStop = false,
				Text = "Текущее состояние"
			};
			groupBoxEndState.SuspendLayout();
			groupBoxEndState.Controls.Add(comboBoxEndStateFT);
			groupBoxEndState.Controls.Add(labelEndStateFFT);
			groupBoxEndState.Controls.Add(comboBoxEndStateUX);
			groupBoxEndState.Controls.Add(labelEndStatePUX);
			comboBoxEndStateFT = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 62),
				Name = "comboBoxEndStateFT",
				Size = new System.Drawing.Size(179, 21),
				TabIndex = 3
			};
			comboBoxEndStateUX = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 23),
				Name = "comboBoxEndStateUX",
				Size = new System.Drawing.Size(179, 21),
				TabIndex = 1
			};
			textBoxDescription = new TextBox
			{
				Location = new System.Drawing.Point(78, 250),
				Multiline = true,
				Name = "textBoxDescription",
				Size = new System.Drawing.Size(300, 50),
				TabIndex = 5
			};

			buttonClose.Location = new System.Drawing.Point(220, 316);
			buttonSave.Visible = false;

			ClientSize = new System.Drawing.Size(384, 352);
			Controls.Add(buttonClose);
			Controls.Add(textBoxDescription);
			Controls.Add(labelDescription);
			Controls.Add(groupBoxEndState);
			Controls.Add(groupBoxStartState);
			Controls.Add(textBoxNumberSituation);
			Controls.Add(labelNumberSituation);
			Name = "FormStatisticEntropy";
			Text = "Статистика по энтропии";
			groupBoxStartState.ResumeLayout(false);
			groupBoxStartState.PerformLayout();
			groupBoxEndState.ResumeLayout(false);
			groupBoxEndState.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		protected override void LoadComboBox()
		{
			for (int i = 0; i < EntropyByUX.Entropyes.Count; ++i)
			{
				comboBoxStartStateUX.Items.Add(EntropyByUX.Entropyes[i]);
				comboBoxEndStateUX.Items.Add(EntropyByUX.Entropyes[i]);
			}
			for (int i = 0; i < EntropyByFT.Entropyes.Count; ++i)
			{
				comboBoxStartStateFT.Items.Add(EntropyByFT.Entropyes[i]);
				comboBoxEndStateFT.Items.Add(EntropyByFT.Entropyes[i]);
			}
		}

		protected override void LoadElement()
		{
			textBoxNumberSituation.Text = _element.NumberSituation.ToString();
			textBoxNumberSituation.Enabled = false;
			comboBoxStartStateUX.SelectedIndex = comboBoxStartStateUX.Items.IndexOf(_element.StartStateLingvistUX);
			comboBoxStartStateUX.Enabled = false;
			comboBoxStartStateFT.SelectedIndex = comboBoxStartStateFT.Items.IndexOf(_element.StartStateLingvistFT);
			comboBoxStartStateFT.Enabled = false;
			comboBoxEndStateUX.SelectedIndex = comboBoxEndStateUX.Items.IndexOf(_element.EndStateLingvistUX);
			comboBoxEndStateUX.Enabled = false;
			comboBoxEndStateFT.SelectedIndex = comboBoxEndStateFT.Items.IndexOf(_element.EndStateLingvistFT);
			comboBoxEndStateFT.Enabled = false;
			textBoxDescription.Text = _element.Description;
		}
	}
}
