using DatabaseModule;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicesModule.BindingModels
{
	public class PointTrendBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int SeriesId { get; set; }

		public int StartPoint { get; set; }

		public int FinishPoint { get; set; }
		
		public int Count { get; set; }

		public double Weight { get; set; }
	}

	public class PointTrendCalcBindingModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "required")]
		public int SeriesDiscriptionId { get; set; }

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

        public List<APIData> List { get; set; }

    }
}
