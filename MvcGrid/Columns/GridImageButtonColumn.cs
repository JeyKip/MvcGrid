using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public class GridImageButtonColumn : GridColumnBase<GridImageButtonColumn>, ICustomFormatterColumn
    {
        private Expression<Func<FilterCondition, bool>> _displayCondition = null;
        private string _clickFunction = null;
        private string _toolTip = null;
        private string _iconClass = null;
        private string[] _clickHandlerParams = null;

        public GridImageButtonColumn DisplayWhen(Expression<Func<FilterCondition, bool>> displayCondition)
        {
            _displayCondition = displayCondition;
            return GetInstance();
        }

        /// <summary>
        /// Set a name of click event handler
        /// </summary>
        public GridImageButtonColumn SetClickHandler(string clickFunctionName, params string[] args)
        {
            _clickFunction = clickFunctionName;
            _clickHandlerParams = args;
            return GetInstance();
        }

        public GridImageButtonColumn SetToolTip(string toolTip)
        {
            _toolTip = toolTip;
            return GetInstance();
        }

        public GridImageButtonColumn SetIconClass(string iconClass)
        {
            _iconClass = iconClass;
            return GetInstance();
        }

        #region Overrides
        protected override GridImageButtonColumn GetInstance()
        {
            return this;
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

        public string GetFormatter()
        {
            if (string.IsNullOrWhiteSpace(_clickFunction))
                return string.Empty;

            string _clickHandler = string.Empty;
            if (_clickHandlerParams != null && _clickHandlerParams.Length > 0)
                _clickHandler = string.Format("{0}(this,{1});", _clickFunction, string.Join(",", _clickHandlerParams.Select(x => string.Format(@"'""+ro[""{0}""]+""'", x))));
            else
                _clickHandler = string.Format("{0}(this);", _clickFunction);

            return string.Format(
@"function (cv,o,ro){{
    {1}
    var cf = ""\""{0}\"""";
    var ocl = ""onclick=""+cf+"" onmouseover=jQuery(this).addClass('ui-state-hover'); onmouseout=jQuery(this).removeClass('ui-state-hover') "";
    var str = ""<div title='"" + ""{3}"" + ""' style='float:left;cursor:pointer;' class='ui-pg-div ui-inline-edit' "" + ocl + ""><span class='ui-icon {4}'></span></div>"";
    return ""<div>"" + str + ""</div>"";
    {2}
}}", _clickHandler, _displayCondition == null ? "" : string.Format("if ({0}) {{\n", FilterConditionToStringConvertor.Convert(_displayCondition)),
     _displayCondition == null ? "" : 
@"}
return """";",
     _toolTip, _iconClass);
        }
        #endregion
    }
}