using System;

namespace DTE_Interface_Level.ViewModels
{
	public class DiagnosticTestViewModel
	{
		public int Id { get; set; }

        public string TestNumber { get; set; }

        public int SeriesDiscriptionId { get; set; }

		public DateTime DateTest { get; set; }

		public int Count { get; set; }

		public string FileName { get; set; }
	}
}