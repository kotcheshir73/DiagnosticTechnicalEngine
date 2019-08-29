using System;

namespace DTE_Model_Level.Models
{
    public class LogData
    {
        public int Id { get; set; }

        public DateTime DateLog { get; set; }

        public string MessageLogType { get; set; }

        public string MessageLogTitle { get; set; }

        public string MessageLog { get; set; }
    }
}