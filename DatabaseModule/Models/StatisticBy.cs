using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModule
{
    public class StatisticBy
    {
        public int Id { get; set; }

		public int SeriesDiscriptionId { get; set; }

		public SeriesDescription SeriesDescription { get; set; }
		/// <summary>
		/// Номер ситуации
		/// </summary>
		public int NumberSituation { get; set; }
        /// <summary>
        /// Описание ситуации
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Сколкьо раз ситуация встречалась во ВР
        /// </summary>
        public int CountMeet { get; set; }
        /// <summary>
        /// Значение пары в начальной точке
        /// </summary>
        [NotMapped]
        public virtual string StartState { get; }
        /// <summary>
        /// Значение пары в конечной точке
        /// </summary>
        [NotMapped]
        public virtual string EndState { get; }
    }
}
