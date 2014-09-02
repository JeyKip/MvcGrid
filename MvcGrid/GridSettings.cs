using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public class GridSettings
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();
        private Navigator _navigator = null;
        private bool _showPager = false;

        /// <summary>
        /// The url of the file that returns the data needed to populate the grid
        /// </summary>
        public GridSettings SetUrl(string url)
        {
            properties.Add("url", url);
            return this;
        }

        /// <summary>
        /// Defines in what format to expect the data that fills the grid
        /// </summary>
        public GridSettings SetDataType(GridDataType dataType)
        {
            properties.Add("datatype", dataType.ToString().ToLower());
            return this;
        }

        /// <summary>
        /// Sets how many records we want to view in the grid. Default value is 20
        /// </summary>
        public GridSettings SetRowNumber(int rowNumber)
        {
            properties.Add("rowNum", rowNumber);
            return this;
        }

        /// <summary>
        /// An array to construct a select box element in the pager in which we can change the number of the visible rows
        /// </summary>
        public GridSettings SetRowList(params int[] rowList)
        {
            properties.Add("rowList", rowList);
            return this;
        }

        /// <summary>
        /// If true, jqGrid displays the beginning and ending record number in the grid, out of the total number of records in the query. This information is shown in the pager bar (bottom right by default)in this format: “View X to Y out of Z”. Default value is false
        /// </summary>
        public GridSettings SetViewRecords(bool viewRecords)
        {
            properties.Add("viewrecords", viewRecords);
            return this;
        }

        /// <summary>
        /// The string to display when the returned (or the current) number of records in the grid is zero. This option is valid only if ViewRecords option is set to true
        /// </summary>
        public GridSettings SetEmptyRecords(string emptyRecordsText)
        {
            properties.Add("emptyrecords", emptyRecordsText);
            return this;
        }

        /// <summary>
        /// The column according to which the data is to be sorted when it is initially loaded from the server
        /// </summary>
        public GridSettings SetSortName(string sortName)
        {
            properties.Add("sortname", sortName);
            return this;
        }

        /// <summary>
        /// The initial sorting order (ascending or descending) when we fetch data from the server using datatypes xml or json
        /// </summary>
        public GridSettings SetSortOrder(SortOrder sortOrder)
        {
            properties.Add("sortorder", sortOrder.ToString().ToLower());
            return this;
        }

        /// <summary>
        /// Defines the caption for the grid. This caption appears in the caption layer, which is above the header layer. If the string is empty the caption does not appear
        /// </summary>
        public GridSettings SetCaption(string caption)
        {
            properties.Add("caption", caption);
            return this;
        }

        /// <summary>
        /// Enables or disables the show/hide grid button, which appears on the right side of the caption layer. Takes effect only if the caption property is not an empty string
        /// </summary>
        public GridSettings SetHideGrid(bool hideGrid)
        {
            properties.Add("hidegrid", hideGrid);
            return this;
        }

        /// <summary>
        /// The height of the grid. Can be set as number (in this case we mean pixels) or as percentage (only 100% is acceped) or value of auto is acceptable
        /// </summary>
        public GridSettings SetHeight(string height)
        {
            properties.Add("height", height);
            return this;
        }

        public GridSettings AddJsonReader(JsonReader jsonReader)
        {
            properties.Add("jsonReader", jsonReader);
            return this;
        }

        /// <summary>
        /// Add new column information
        /// </summary>
        public GridSettings AddColumn(GridColumnBase column)
        {
            if (!properties.ContainsKey("colModel"))
                properties.Add("colModel", new List<GridColumnBase>());
            var colModel = properties.FirstOrDefault(x => x.Key == "colModel").Value as List<GridColumnBase>;
            colModel.Add(column);
            return this;
        }

        public GridSettings SetNavigator(Navigator navigator)
        {
            _navigator = navigator;
            return this;
        }

        public GridSettings ShowPager(bool showPager)
        {
            _showPager = showPager;
            return this;
        }

        public GridSettings SetSubGrid(SubGridSettings sg)
        {
            properties.Add("subGridProperty", sg);
            return this;
        }

        protected string GridSettingsPattern
        {
            get
            {
                return
@"@GridTable
@PagerDiv
<script type=""text/javascript"">
    $(function(){
        @InitFunction
    });
</script>";
            }
        }

        public override string ToString()
        {
            if (_showPager && !properties.ContainsKey("pager"))
                properties.Add("pager", string.Format("#{0}", PagerId));

            return GridSettingsPattern.Replace("@GridTable", GetGridTable())
                                      .Replace("@PagerDiv", GetPager())
                                      .Replace("@InitFunction", GetInitFunction());

        }

        #region Protected
        protected string GetGridTable()
        {
            return string.Format(@"<table id='{0}'></table>", GridId);
        }

        protected string GetPager()
        {
            if (_showPager)
                return string.Format("<div id='{0}'></div>", PagerId);
            return string.Empty;
        }

        protected string GetInitFunction()
        {
            string function =
@"$(""#@gridId"").jqGrid({
        @Properties
    });
@NavigatorSettings";

            string navigatorFormat = string.Empty;
            if (_showPager && _navigator != null && !string.IsNullOrWhiteSpace(_navigator.ToString()))
                navigatorFormat = string.Format(@"$('#{0}').navGrid('#{1}', {{{2}}});", GridId, PagerId, _navigator);

            string propertiesFormat = string.Empty;
            if (properties.Count > 0)
                propertiesFormat = string.Join(",\n", properties.Select(x => ResolveParameter(x)));

            return function.Replace("@NavigatorSettings", navigatorFormat)
                           .Replace("@Properties", propertiesFormat)
                           .Replace("@gridId", GridId);
        }

        protected virtual string ResolveParameter(KeyValuePair<string, object> x)
        {
            if (x.Key == "subGridProperty")
                return x.Value.ToString();

            return PropertyResolver.Resolve(x);
        }
        #endregion

        #region Public Members
        private string _gridId = string.Empty;

        [ExcludeFromCodeCoverage]
        public virtual string GridId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_gridId))
                    _gridId = string.Format("Grid{0}", Guid.NewGuid());
                return _gridId;
            }
        }

        [ExcludeFromCodeCoverage]
        public virtual string PagerId
        {
            get
            {
                return string.Format("Pager{0}", GridId);
            }
        }
        #endregion
    }
}