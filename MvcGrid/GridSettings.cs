using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcGrid
{
    public class GridSettings
    {
        private List<string> properties = new List<string>();
        private List<GridColumnBase> columns = new List<GridColumnBase>();
        private Navigator navigator = new Navigator();

        /// <summary>
        /// The url of the file that returns the data needed to populate the grid
        /// </summary>
        public GridSettings SetUrl(string url)
        {
            properties.Add(string.Format("url: '{0}'", url));
            return this;
        }

        /// <summary>
        /// Defines in what format to expect the data that fills the grid
        /// </summary>
        public GridSettings SetDataType(GridDataType dataType)
        {
            properties.Add(string.Format("datatype: '{0}'", dataType));
            return this;
        }

        /// <summary>
        /// Sets how many records we want to view in the grid. Default value is 20
        /// </summary>
        public GridSettings SetRowNumber(int rowNumber)
        {
            properties.Add(string.Format("rowNum: {0}", rowNumber));
            return this;
        }

        /// <summary>
        /// An array to construct a select box element in the pager in which we can change the number of the visible rows
        /// </summary>
        public GridSettings SetRowList(params int[] rowList)
        {
            properties.Add(string.Format("rowList: [{0}]", string.Join(", ", rowList)));
            return this;
        }

        /// <summary>
        /// If true, jqGrid displays the beginning and ending record number in the grid, out of the total number of records in the query. This information is shown in the pager bar (bottom right by default)in this format: “View X to Y out of Z”. Default value is false
        /// </summary>
        public GridSettings SetViewRecords(bool viewRecords)
        {
            properties.Add(string.Format("viewrecords: {0}", viewRecords.ToString().ToLower()));
            return this;
        }

        /// <summary>
        /// The string to display when the returned (or the current) number of records in the grid is zero. This option is valid only if ViewRecords option is set to true
        /// </summary>
        public GridSettings SetEmptyRecords(string emptyRecordsText)
        {
            properties.Add(string.Format("emptyrecords: '{0}'", emptyRecordsText));
            return this;
        }

        /// <summary>
        /// The column according to which the data is to be sorted when it is initially loaded from the server
        /// </summary>
        public GridSettings SetSortName(string sortName)
        {
            properties.Add(string.Format("sortname: '{0}'", sortName));
            return this;
        }

        /// <summary>
        /// The initial sorting order (ascending or descending) when we fetch data from the server using datatypes xml or json
        /// </summary>
        public GridSettings SetSortOrder(SortOrder sortOrder)
        {
            properties.Add(string.Format("sortorder: '{0}'", sortOrder.ToString().ToLower()));
            return this;
        }

        /// <summary>
        /// Defines the caption for the grid. This caption appears in the caption layer, which is above the header layer. If the string is empty the caption does not appear
        /// </summary>
        public GridSettings SetCaption(string caption)
        {
            properties.Add(string.Format("caption: '{0}'", caption));
            return this;
        }

        /// <summary>
        /// Enables or disables the show/hide grid button, which appears on the right side of the caption layer. Takes effect only if the caption property is not an empty string
        /// </summary>
        public GridSettings SetHideGrid(bool hideGrid)
        {
            properties.Add(string.Format("hidegrid: {0}", hideGrid.ToString().ToLower()));
            return this;
        }

        /// <summary>
        /// The height of the grid. Can be set as number (in this case we mean pixels) or as percentage (only 100% is acceped) or value of auto is acceptable
        /// </summary>
        public GridSettings SetHeight(string height)
        {
            properties.Add(string.Format("height: '{0}'", height));
            return this;
        }

        /// <summary>
        /// Add new column information
        /// </summary>
        public GridSettings AddColumn(GridColumnBase column)
        {
            columns.Add(column);
            return this;
        }

        public GridSettings AddNavigator(Navigator _navigator)
        {
            navigator = _navigator;
            return this;
        }

        public GridSettings AddJsonReader(JsonReader jsonReader)
        {
            if (jsonReader != null)
                properties.Add(string.Format("jsonReader: {{{0}}}", jsonReader));

            return this;
        }

        protected string GridSettingsPattern
        {
            get
            {
                return
@"<table id=""@gridId""></table>
<div id=""@navigatorId""></div>
<script type=""text/javascript"">
    $(function(){
        $('#@gridId').jqGrid({
            @Properties,
            colModel: [@ColModel],
            pager: '#@navigatorId'
        });
        $('#@gridId').navGrid('#@navigatorId', {
            @Navigator
        });
    });
@CustomFormatters
</script>";
            }
        }

        public override string ToString()
        {
            return GridSettingsPattern
                .Replace("@gridId", GridId)
                .Replace("@navigatorId", Pager)
                .Replace("@ColModel", string.Join(", ", columns.Select(x => string.Format("{{{0}}}", x.ToString()))))
                .Replace("@Navigator", navigator == null ? string.Empty : navigator.ToString())
                .Replace("@Properties", string.Join(",\n", properties))
                .Replace("@CustomFormatters", string.Join("\n",
                columns.Where(x => x is ICustomFormatterColumn)
                       .Select(x => (x as ICustomFormatterColumn).GetFormatter())));
        }

        #region Protected Members
        private string _gridId = string.Empty;
        protected virtual string GridId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_gridId))
                    _gridId = string.Format("Grid{0}", Guid.NewGuid());
                return _gridId;
            }
        }

        protected virtual string Pager
        {
            get
            {
                return string.Format("Pager{0}", GridId);
            }
        }
        #endregion
    }
}