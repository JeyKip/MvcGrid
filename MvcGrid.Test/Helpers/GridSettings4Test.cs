using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcGrid.Test.Helpers
{
    public class GridSettings4Test : GridSettings
    {
        protected override string GridId
        {
            get
            {
                return "Grid";
            }
        }

        protected override string Pager
        {
            get
            {
                return "Pager";
            }
        }

        public string GridPattern
        {
            get
            {
                return base.GridSettingsPattern;
            }
        }
    }
}