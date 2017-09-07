using DatabaseModule.BaseClassies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseModule
{
	/// <summary>
	/// 
	/// </summary>
	public class DiagnosticTest : BaseClassSeriesDescription
	{
        public string TestNumber { get; set; }

		public DateTime DateTest { get; set; }

		public int Count { get; set; }

		public string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("DiagnosticTestId")]
		public virtual ICollection<DiagnosticTestRecord> DiagnosticTestRecords { get; set; }
		/// <summary>
		/// Гранулы по мере энтропии по функции принадлежности
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleUX> GranuleUXs { get; set; }
		/// <summary>
		/// Гранулы по мере энтропии по нечеткой тенденции
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleFT> GranuleFTs { get; set; }
		/// <summary>
		/// Гранулы по мерам энтропий
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleEntropy> GranuleEntropys { get; set; }
		/// <summary>
		/// Гранулы по нечеткости
		/// </summary>
		[ForeignKey("DiagnosticTestId")]
		public virtual ICollection<GranuleFuzzy> GranuleFuzzys { get; set; }
	}
}
