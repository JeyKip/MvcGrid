using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcGrid
{
    public class GridSettings
    {
        public string Name { get; set; }
        /// <summary>
        /// The url of the file that returns the data needed to populate the grid
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Defines in what format to expect the data that fills the grid
        /// </summary>
        public GridDataType DataType { get; set; }

        // rowNum
        /// <summary>
        /// Sets how many records we want to view in the grid
        /// </summary>
        public int RowNumber { get; set; }

        //rowList
        /// <summary>
        /// An array to construct a select box element in the pager in which we can change the number of the visible rows
        /// </summary>
        public int[] RowList { get; set; }

        /// <summary>
        /// If true, jqGrid displays the beginning and ending record number in the grid, out of the total number of records in the query. This information is shown in the pager bar (bottom right by default)in this format: “View X to Y out of Z”
        /// </summary>
        public bool ViewRecords { get; set; }

        /// <summary>
        /// Array which describes the parameters of the columns
        /// </summary>
        public GridColumn[] Columns { get; set; }
    }
}