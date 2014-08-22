using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcGridExamples.Models;

namespace MvcGridExamples.Data
{
    public static class DataReferenceReader
    {
        private static List<DataReference> dr = new List<DataReference>() 
        {
            new DataReference()
            {
                Id = 1,
                Code = "Gender",
                Description = "Gender of watch",
                Status = 0,
                Created = new DateTime(2014, 8, 18),
                Values = new List<DataReferenceValue>()
                {
                    new DataReferenceValue()
                    {
                        Id = 1,
                        DataReferenceId = 1,
                        Status = 1,
                        Value = "Male"
                    },
                    new DataReferenceValue()
                    {
                        Id = 2,
                        DataReferenceId = 1,
                        Status = 1,
                        Value = "Female"
                    },
                    new DataReferenceValue()
                    {
                        Id = 3,
                        DataReferenceId = 1,
                        Status = 0,
                        Value = "Unisex"
                    }
                }
            },
            new DataReference()
            {
                Id = 2,
                Code = "Crystal",
                Description = "Crystal in watch",
                Status = 1,
                Created = new DateTime(2014, 8, 18),
                Values = new List<DataReferenceValue>()
                {
                    new DataReferenceValue()
                    {
                        Id = 4,
                        DataReferenceId = 2,
                        Status = 1,
                        Created = new DateTime(2014, 8, 18),
                        Value = "Acrylic"
                    },
                    new DataReferenceValue()
                    {
                        Id = 5,
                        DataReferenceId = 2,
                        Status = 1,
                        Created = new DateTime(2014, 8, 18),
                        Value = "Mineral Glass"
                    },
                    new DataReferenceValue()
                    {
                        Id = 6,
                        DataReferenceId = 2,
                        Status = 1,
                        Created = new DateTime(2014, 8, 18),
                        Value = "Sapphire"
                    }
                }
            }
        };

        public static List<DataReference> GetDataReferenceList()
        {
            return dr;
        }

        public static List<DataReferenceValue> GetValues(int drId)
        {
            return dr.FirstOrDefault(x => x.Id == drId).Values;
        }
    }
}