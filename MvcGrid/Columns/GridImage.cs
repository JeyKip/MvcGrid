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
        private Expression<Func<FilterCondition, string>> _imagePathColumnName = null;
        private Expression<Func<FilterCondition, string>> _toolTipColumnName = null;
        private int _height;
        private int _width;

        public GridImage SetImagePath(string imagePath)
        {
            _imagePath = imagePath;
            return this;
        }

        public GridImage SetImagePath(Expression<Func<FilterCondition, string>> imagePathColumn)
        {
            _imagePathColumnName = imagePathColumn;
            return this;
        }

        public GridImage SetToolTip(string toolTip)
        {
            _toolTip = toolTip;
            return this;
        }

        public GridImage SetToolTip(Expression<Func<FilterCondition, string>> toolTipColumn)
        {
            _toolTipColumnName = toolTipColumn;
            return this;
        }

        public GridImage DisplayWhen(Expression<Func<FilterCondition, bool>> condition)
        {
            _displayWhenCondition = condition;
            return this;
        }

        public GridImage SetWidth(int widthInPixel)
        {
            _width = widthInPixel;
            return this;
        }

        public GridImage SetHeight(int heightInPixel)
        {
            _height = heightInPixel;
            return this;
        }

        public string GetDisplayCondition()
        {
            if (_displayWhenCondition == null)
                return string.Empty;

            return FilterConditionToStringConvertor.Convert(_displayWhenCondition);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<img ");

            if (_imagePathColumnName != null)
                sb.AppendFormat("src='\"+{0}+\"' ", FilterConditionToStringConvertor.Convert(_imagePathColumnName));
            else if (!string.IsNullOrWhiteSpace(_imagePath))
                sb.AppendFormat("src='{0}' ", _imagePath);

            if (_toolTipColumnName != null)
                sb.AppendFormat("title='\"+{0}+\"' ", FilterConditionToStringConvertor.Convert(_toolTipColumnName));
            else if (!string.IsNullOrWhiteSpace(_toolTip))
                sb.AppendFormat("title='{0}' ", _toolTip);

            if (_width > 0)
                sb.AppendFormat("width='{0}' ", _width);

            if (_height > 0)
                sb.AppendFormat("height='{0}' ", _height);

            sb.Append("/>");
            return sb.ToString();
        }
    }
}