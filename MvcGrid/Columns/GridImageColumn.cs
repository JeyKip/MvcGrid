using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public class GridImageColumn : GridColumnBase, ICustomFormatterColumn
    {
        List<GridImage> images = new List<GridImage>();

        public GridImageColumn AddImage(GridImage image)
        {
            images.Add(image);
            return this;
        }

        public string GetFormatter()
        {
            if (images.Count <= 0)
                return string.Empty;

            return string.Format(
@"function (cv,o,ro){{
    {0}
    return """";
}}", string.Join("\n", images.Select(x => string.Format("{0}return \"{1}\";", string.IsNullOrWhiteSpace(x.GetDisplayCondition()) ? string.Empty : string.Format("if ({0})", x.GetDisplayCondition()), x))));
        }

        public override string ToString()
        {
            if (GetProperty("formatter") == null)
            {
                if (!string.IsNullOrWhiteSpace(GetFormatter()))
                    AddProperty("formatter", GetFormatter());
            }

            return base.ToString();
        }

        protected override string ResolveProperty(KeyValuePair<string, object> x)
        {
            if (x.Key == "formatter")
                return string.Format("{0}: {1}", x.Key, x.Value);

            return base.ResolveProperty(x);
        }
    }
}