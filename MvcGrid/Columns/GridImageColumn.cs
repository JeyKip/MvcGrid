using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public class GridImage
    {
        private string _imagePath = null;
        private string _toolTip = null;
        private Expression<Func<FilterCondition, bool>> _displayWhenCondition = null;

        public GridImage SetImagePath(string imagePath)
        {
            _imagePath = imagePath;
            return this;
        }

        public GridImage SetToolTip(string toolTip)
        {
            _toolTip = toolTip;
            return this;
        }

        public GridImage DisplayWhen(Expression<Func<FilterCondition, bool>> condition)
        {
            _displayWhenCondition = condition;
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_displayWhenCondition != null)
                sb.AppendFormat("if ({0}) ", FilterConditionToStringConvertor.Convert(_displayWhenCondition));

            sb.AppendFormat("return \"<img src='{0}' title='{1}' />\";", _imagePath, _toolTip);
            return sb.ToString();
        }
    }

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
            if (!Properties.ContainsKey("name"))
                throw new InvalidOperationException("Column name is missing");

            var name = Properties.First(x => x.Key == "name");
            if (name.Value == null || string.IsNullOrWhiteSpace(name.Value.ToString()))
                throw new InvalidOperationException("Column name is missing");

            return string.Format(
@"function {0}Formatter(cv,o,ro){{
    {1}
    return """";
}}", name.Value, string.Join("\n", images));
        }

        public override string ToString()
        {
            if (!Properties.ContainsKey("name"))
                throw new InvalidOperationException("Column name is missing");

            var name = Properties.First(x => x.Key == "name");
            if (name.Value == null || string.IsNullOrWhiteSpace(name.Value.ToString()))
                throw new InvalidOperationException("Column name is missing");

            return string.Format("{0},{1}", 
                string.Join(", ", Properties.Select(x => (x.Value is string) ? string.Format("{0}: '{1}'", x.Key, x.Value) : string.Format("{0}: {1}", x.Key, x.Value.ToString().ToLower()))), 
                string.Format("formatter: {0}Formatter", name.Value));
        }
    }
}