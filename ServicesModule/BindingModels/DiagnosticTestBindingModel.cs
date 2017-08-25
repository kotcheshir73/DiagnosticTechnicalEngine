using DatabaseModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class DiagnosticTestBindingModel
	{
		public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        public string TestNumber { get; set; }

        [Required(ErrorMessage = "required")]
		public int SeriesDiscriptionId { get; set; }

		[Required(ErrorMessage = "required")]
		public DateTime DateTest { get; set; }

		[Required(ErrorMessage = "required")]
		public int Count { get; set; }

		[Required(ErrorMessage = "required")]
		public bool NeedForecast { get; set; }

		[Required(ErrorMessage = "required")]
		public string FileName { get; set; }
		/// <summary>
		/// Тип файла
		/// </summary>
		public TypeFile TypeFile { get; set; }
		/// <summary>
		/// Порядок хранения данных в файле и какие данные в нем храняться
		/// например: первым идет "дата", потом "числовое значение"
		/// </summary>
		public List<TypeDataInFile> DatasInFile { get; set; }
		/// <summary>
		/// Кол-во точек, которые следует хранить для идентификации аномалии
		/// </summary>
		public int CountPointsForMemmory { get; set; }
		/// <summary>
		/// Делегат для вывода сообщений при анализе ВР
		/// </summary>
		public Action<string> MessagerEvent { get; set; }
		/// <summary>
		/// Делегат для вывода сообщений о количестве обработанных точек
		/// </summary>
		public Action<string> MessageCountPoint { get; set; }

		public bool? MakeGranuleUX { get; set; }

		public bool? MakeGranuleFT { get; set; }

		public bool? MakeGranuleEntropy { get; set; }

		public bool? MakeGranuleFuzzy { get; set; }
	}
}
