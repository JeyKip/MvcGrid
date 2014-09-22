using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcGrid.Columns
{
    public class GridImageButtonColumn : GridColumnBase<GridImageButtonColumn>
    {
        protected override GridImageButtonColumn GetInstance()
        {
            return this;
        }
    }
}
