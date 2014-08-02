using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcGrid
{
    public class GridSettings
    {
        public string GridId { get; set; }
        /// <summary>
        /// The url of the file that returns the data needed to populate the grid
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Defines in what format to expect the data that fills the grid
        /// </summary>
        public GridDataType DataType { get; set; }

        private int rowNum = 20;
        /// <summary>
        /// Sets how many records we want to view in the grid
        /// </summary>
        public int RowNumber
        {
            get { return rowNum; }
            set { rowNum = value; }
        }

        /// <summary>
        /// An array to construct a select box element in the pager in which we can change the number of the visible rows
        /// </summary>
        public int[] RowList { get; set; }

        /// <summary>
        /// If true, jqGrid displays the beginning and ending record number in the grid, out of the total number of records in the query. This information is shown in the pager bar (bottom right by default)in this format: “View X to Y out of Z”
        /// </summary>
        public bool ViewRecords { get; set; }

        /// <summary>
        /// The string to display when the returned (or the current) number of records in the grid is zero. This option is valid only if ViewRecords option is set to true
        /// </summary>
        public string EmptyRecords { get; set; }

        /// <summary>
        /// ID of html div-element
        /// </summary>
        public string Pager { get; set; }

        /// <summary>
        /// The column according to which the data is to be sorted when it is initially loaded from the server
        /// </summary>
        public string Sortname { get; set; }

        /// <summary>
        /// The initial sorting order (ascending or descending) when we fetch data from the server using datatypes xml or json
        /// </summary>
        public SortOrder Sortorder { get; set; }

        /// <summary>
        /// Defines the caption for the grid. This caption appears in the caption layer, which is above the header layer. If the string is empty the caption does not appear
        /// </summary>
        public string Caption { get; set; }

        private bool _hidegrid = true;
        /// <summary>
        /// Enables or disables the show/hide grid button, which appears on the right side of the caption layer. Takes effect only if the caption property is not an empty string
        /// </summary>
        public bool Hidegrid
        {
            get { return _hidegrid; }
            set { _hidegrid = value; }
        }

        private string _height = "150";
        /// <summary>
        /// The height of the grid. Can be set as number (in this case we mean pixels) or as percentage (only 100% is acceped) or value of auto is acceptable
        /// </summary>
        public string Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private Navigator _navigator = new Navigator();
        public Navigator Navigator
        {
            get { return _navigator; }
            set { _navigator = value; }
        }

        private JsonReader _jsonReader = new JsonReader();
        public JsonReader JsonReader
        {
            get { return _jsonReader; }
            set { _jsonReader = value; }
        }

        /// <summary>
        /// Array which describes the parameters of the columns
        /// </summary>
        public GridColumn[] Columns { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(GridId))
                throw new InvalidOperationException("GridId must be setted");

            StringBuilder grid = new StringBuilder();
            grid.AppendFormat("$(function(){{$('#{0}').jqGrid({{", GridId);
            grid.AppendFormat("url: '{0}',", string.IsNullOrWhiteSpace(URL) ? "null" : URL);
            grid.AppendFormat("datatype: '{0}',", DataType.ToString().ToLower());
            grid.AppendFormat("rowNum: {0},", RowNumber);
            grid.AppendFormat("rowList: [{0}],", string.Join(", ", RowList));
            grid.AppendFormat("viewrecords: {0},", ViewRecords.ToString().ToLower());
            grid.AppendFormat("emptyrecords: '{0}',", EmptyRecords);
            grid.AppendFormat("colModel: [{0}],", string.Join(", ", Columns.Select(x => string.Format("{{{0}}}", x.ToString()))));
            grid.AppendFormat("pager: '#{0}',", Pager);
            grid.AppendFormat("sortname: '{0}',", Sortname);
            grid.AppendFormat("sortorder: '{0}',", Sortorder.ToString().ToLower());
            grid.AppendFormat("caption: '{0}',", Caption);
            grid.AppendFormat("hidegrid: {0},", Hidegrid.ToString().ToLower());
            grid.AppendFormat("height: '{0}',", Height);

            if (DataType == GridDataType.Json || DataType == GridDataType.Jsonp || DataType == GridDataType.JsonString)
                grid.AppendFormat("jsonReader: {{{0}}}", JsonReader.ToString());

            grid.Append("});");

            grid.AppendFormat("$('#{0}').navGrid('#{1}', {{{2}}});", GridId, Pager, Navigator.ToString());
            grid.Append("});");
            return grid.ToString();
        }
    }
}