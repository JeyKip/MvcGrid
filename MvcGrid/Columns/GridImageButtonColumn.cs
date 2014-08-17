using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcGrid.Columns
{
    public class GridImageButtonColumn : GridColumnBase
    {
        /// <summary>
        /// Style that describes the column style. Uses instead of ImageUrl
        /// </summary>
        public string CssClass { get; set; }
    }
}
