using DiagnosticTechnicalEngine.StandartClasses;
using ServicesModule;
using ServicesModule.BindingModels;
using ServicesModule.ViewModels;
using System.Linq;
using System.Windows.Forms;

namespace DiagnosticTechnicalEngine.Forms
{
	public class FormStatisticByFuzzy : StandartForm<StatisticsByFuzzyViewModel, StatisticsByFuzzyBindingModel>
	{
		#region Контролы для работы
		private Label labelNumberSituation;
		private Label labelStartStateFT;
		private Label labelStartStateFL;
		private Label labelEndStateFT;
		private Label labelEndStateFL;
		private Label labelDescription;
		private TextBox textBoxNumberSituation;
		private GroupBox groupBoxStartState;
		private ComboBox comboBoxStartStateFT;
		private ComboBox comboBoxStartStateFL;
		private GroupBox groupBoxEndState;
		private ComboBox comboBoxEndStateFT;
		private ComboBox comboBoxEndStateFL;
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
			labelStartStateFT = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 65),
				Name = "labelStartStateFT",
				Size = new System.Drawing.Size(129, 13),
				TabIndex = 2,
				Text = "По нечеткой тенденции:"
			};
			labelStartStateFL = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 26),
				Name = "labelStartStateFL",
				Size = new System.Drawing.Size(107, 13),
				TabIndex = 0,
				Text = "По нечеткой метке:"
			};
			labelEndStateFT = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 65),
				Name = "labelEndStateFT",
				Size = new System.Drawing.Size(129, 13),
				TabIndex = 2,
				Text = "По нечеткой тенденции:"
			};
			labelEndStateFL = new Label
			{
				AutoSize = true,
				Location = new System.Drawing.Point(17, 26),
				Name = "labelEndStateFL",
				Size = new System.Drawing.Size(107, 13),
				TabIndex = 0,
				Text = "По нечеткой метке:"
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
			groupBoxStartState.Controls.Add(labelStartStateFT);
			groupBoxStartState.Controls.Add(comboBoxStartStateFL);
			groupBoxStartState.Controls.Add(labelStartStateFL);
			comboBoxStartStateFT = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 62),
				Name = "comboBoxStartStateFT",
				Size = new System.Drawing.Size(179, 21),
				TabIndex = 3
			};
			comboBoxStartStateFL = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 23),
				Name = "comboBoxStartStateFL",
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
			groupBoxEndState.Controls.Add(labelEndStateFT);
			groupBoxEndState.Controls.Add(comboBoxEndStateFL);
			groupBoxEndState.Controls.Add(labelEndStateFL);
			comboBoxEndStateFT = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 62),
				Name = "comboBoxEndStateFT",
				Size = new System.Drawing.Size(179, 21),
				TabIndex = 3
			};
			comboBoxEndStateFL = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				FormattingEnabled = true,
				Location = new System.Drawing.Point(181, 23),
				Name = "comboBoxEndStateFL",
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
			Controls.Add(groupBoxStartState);
			Controls.Add(textBoxNumberSituation);
			Controls.Add(labelNumberSituation);
			Controls.Add(groupBoxEndState);
			Controls.Add(buttonClose);
			Controls.Add(textBoxDescription);
			Controls.Add(labelDescription);
			Name = "FormStatisticFuzzy";
			Text = "Статистика по нечеткости";
			groupBoxStartState.ResumeLayout(false);
			groupBoxStartState.PerformLayout();
			groupBoxEndState.ResumeLayout(false);
			groupBoxEndState.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		protected override void LoadComboBox()
		{
			var trends = (new FuzzyTrendService()).GetElements(_parentId);
			comboBoxStartStateFT.DataSource = trends.Select(t => new { Value = t.Id, Display = t.TrendName }).ToList();
			comboBoxStartStateFT.ValueMember = "Value";
			comboBoxStartStateFT.DisplayMember = "Display";
			comboBoxEndStateFT.DataSource = trends.Select(t => new { Value = t.Id, Display = t.TrendName }).ToList();
			comboBoxEndStateFT.ValueMember = "Value";
			comboBoxEndStateFT.DisplayMember = "Display";

			var labels = (new FuzzyLabelService()).GetElements(_parentId);
			comboBoxStartStateFL.DataSource = labels.Select(t => new { Value = t.Id, Display = t.FuzzyLabelName }).ToList();
			comboBoxStartStateFL.ValueMember = "Value";
			comboBoxStartStateFL.DisplayMember = "Display";
			comboBoxEndStateFL.DataSource = labels.Select(t => new { Value = t.Id, Display = t.FuzzyLabelName }).ToList();
			comboBoxEndStateFL.ValueMember = "Value";
			comboBoxEndStateFL.DisplayMember = "Display";
		}

		protected override void LoadElement()
		{
			textBoxNumberSituation.Text = _element.NumberSituation.ToString();
			textBoxNumberSituation.Enabled = false;
			comboBoxStartStateFL.SelectedValue = _element.StartStateFuzzyLabelId;
			comboBoxStartStateFL.Enabled = false;
			comboBoxStartStateFT.SelectedValue = _element.StartStateFuzzyTrendId;
			comboBoxStartStateFT.Enabled = false;
			comboBoxEndStateFL.SelectedValue = _element.EndStateFuzzyLabelId;
			comboBoxEndStateFL.Enabled = false;
			comboBoxEndStateFT.SelectedValue = _element.EndStateFuzzyTrendId;
			comboBoxEndStateFT.Enabled = false;
			textBoxDescription.Text = _element.Description;
		}
	}
}
