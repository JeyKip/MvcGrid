using System;
using System.Collections.Generic;

namespace MvcGridExamples.Models
{
    public class DataReference
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Created { get; set; }
        public List<DataReferenceValue> Values { get; set; }
    }
}