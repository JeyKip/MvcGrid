using System.Collections.Generic;
using System.Linq;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public class SubGridSettings : GridSettings
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>() 
        {
            { "subGrid", true }
        };
        /// <summary>
        /// Defines the icon when the grid is collapsed. A valid name of icon from Theme Roller should be set. 
        /// </summary>
        /// <param name="plusIconClass">CssClass that describes image</param>
        /// <returns></returns>
        public SubGridSettings SetPlusIcon(string plusIconClass)
        {
            AddOption("plusicon", plusIconClass);
            return this;
        }

        /// <summary>
        /// Defines the icon when the grid is expanded. A valid name of icon from Theme Roller should be set. 
        /// </summary>
        /// <param name="minusIconClass">CssClass that describes image</param>
        /// <returns></returns>
        public SubGridSettings SetMinusIcon(string minusIconClass)
        {
            AddOption("minusicon", minusIconClass);
            return this;
        }

        /// <summary>
        /// The icon bellow the minusicon when the subgrid row is expanded
        /// </summary>
        /// <param name="openIconClass">CssClass that describes image</param>
        /// <returns></returns>
        public SubGridSettings SetOpenIcon(string openIconClass)
        {
            AddOption("openicon", openIconClass);
            return this;
        }

        /// <summary>
        /// When set to true make it so that all rows will be expanded automatically when a new set of data is loaded. Default is false
        /// </summary>
        /// <returns></returns>
        public SubGridSettings ExpandOnLoad(bool expandOnLoad)
        {
            AddOption("expandOnLoad", expandOnLoad);
            return this;
        }

        /// <summary>
        /// When set to true the row is selected when a plusicon is clicked with the mouse. Default is false
        /// </summary>
        /// <returns></returns>
        public SubGridSettings SelectOnExpand(bool selectOnExpand)
        {
            AddOption("selectOnExpand", selectOnExpand);
            return this;
        }

        /// <summary>
        /// If set to false the data in the subgrid is loaded only once and all other subsequent clicks just hide or show the data and no more ajax calls are made. Default is true
        /// </summary>
        /// <returns></returns>
        public SubGridSettings ReloadOnExpand(bool reloadOnExpand)
        {
            AddOption("reloadOnExpand", reloadOnExpand);
            return this;
        }

        /// <summary>
        /// Set url for getting data for grid
        /// </summary>
        /// <param name="url">The url that returns the data needed to populate the grid</param>
        /// <param name="urlParamsList">Field names for using them as get-parameters for subgrid url. Order is important</param>
        /// <returns></returns>
        public SubGridSettings SetSubgridUrl(string url, params string[] urlParamsList)
        {
            if (urlParamsList.Length <= 0)
            {
                SetUrl(url);
                return this;
            }

            url = string.Format("'{0}?'+{1}", url, string.Join("+'&'+", urlParamsList.Select(x => string.Format("'{0}='+rd.{0}", x))));
            SetUrl(url);
            return this;
        }

        protected override string ResolveParameter(KeyValuePair<string, object> x)
        {
            if (x.Key == "url" && x.Value.ToString().Contains('?'))
                return string.Format("{0}: {1}", x.Key, x.Value);

            return base.ResolveParameter(x);
        }

        public override string ToString()
        {
            return string.Format(
@"{3},
subGridRowExpanded: function (sid, rid) {{
    $('#' + sid).html(""{0}{1}"");
    var rd = $(this).getRowData(rid);
    {2}
}}", GetGridTable(), GetPager(), GetInitFunction(),
   string.Join(", ", properties.Select(x => ResolveParameter(x))));
        }

        private void AddOption(string optionName, object value)
        {
            if (!properties.ContainsKey("subGridOptions"))
                properties.Add("subGridOptions", new Option());

            Option option = properties.FirstOrDefault(x => x.Key == "subGridOptions").Value as Option;
            option.AddOption(optionName, value);
        }

        public override string GridId
        {
            get
            {
                return string.Format("{0}\"+sid+\"", base.GridId);
            }
        }
    }
}