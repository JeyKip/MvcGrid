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

            var name = GetProperty("name");
            if (name == null || string.IsNullOrWhiteSpace(name.ToString()))
                throw new InvalidOperationException("Column name is missing");

            return string.Format(
@"function {0}formatter(cv,o,ro){{
    {1}
    return """";
}}", name, string.Join("\n", images));
        }

        public override string ToString()
        {
            if (GetProperty("formatter") == null)
            {
                if (!string.IsNullOrWhiteSpace(GetFormatter()))
                    AddProperty("formatter", string.Format("{0}formatter", GetProperty("name")));
            }

            return string.Join(", ", GetProperties().Select(x => (x.Key == "formatter") ? string.Format("{0}: {1}", x.Key, x.Value) : PropertyResolver.Resolve(x)));
        }
    }
}