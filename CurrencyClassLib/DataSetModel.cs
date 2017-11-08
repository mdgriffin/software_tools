using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class DataSetModel
    {
        public string Collapse { get; set; }
        public object ColumnIndex { get; set; }
        public string[] ColumnNames { get; set; }
        public List<List<object>> Data { get; set; }
        public string DatabaseCode { get; set; }
        public long DatabaseId { get; set; }
        public string DatasetCode { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public string Frequency { get; set; }
        public long Id { get; set; }
        public object Limit { get; set; }
        public string Name { get; set; }
        public string NewestAvailableDate { get; set; }
        public string OldestAvailableDate { get; set; }
        public object Order { get; set; }
        public bool Premium { get; set; }
        public string RefreshedAt { get; set; }
        public string StartDate { get; set; }
        public object Transform { get; set; }
        public string Type { get; set; }
    }

    public struct TimePoint
    {
        public string String;
        public double? Double;
    }
}
