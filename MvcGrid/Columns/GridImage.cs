using System;
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
}