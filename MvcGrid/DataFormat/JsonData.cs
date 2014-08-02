using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcGrid.DataFormat
{
    public class JsonData
    {
        //cell: "cell",
        //id: "id",
        //userdata: "userdata",
        //subgrid: {root:"rows", 
        //   repeatitems: true, 
        //  cell:"cell"
        //}
        public IEnumerable Rows { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int Records { get; set; }
        public object UserData { get; set; }
    }
}