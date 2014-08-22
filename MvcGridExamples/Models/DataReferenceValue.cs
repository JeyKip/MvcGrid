using System;

namespace MvcGridExamples.Models
{
    public class DataReferenceValue
    {
        public int Id { get; set; }
        public int DataReferenceId { get; set; }
        public string Value { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; }
    }
}