using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcGrid
{
    public class GridColumn
    {
        /// <summary>
        /// Defines the alignment of the cell in the Body layer, not in header cell
        /// </summary>
        public TextAlign Align { get; set; }

        /// <summary>
        /// If set to true this option does not allow recalculation of the width of the column if shrinkToFit option is set to true. Also the width does not change if a setGridWidth method is used to change the grid width.
        /// </summary>
        public bool Fixed { get; set; }

        /// <summary>
        /// Defines if this column is hidden at initialization
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Defines the heading for this column
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Set the unique name in the grid for the column. This property is required. As well as other words used as property/event names, the reserved words (which cannot be used for names) include subgrid, cb and rn.
        /// </summary>
        public string Name { get; set; }

        public bool _resizable = true;
        /// <summary>
        /// Defines if the column can be re sized
        /// </summary>
        public bool Resizable
        {
            get { return _resizable; }
            set { _resizable = value; }
        }

        private bool _search = true;
        /// <summary>
        /// When used in search modules, disables or enables searching on that column
        /// </summary>
        public bool Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private bool _sortable = true;
        /// <summary>
        /// Defines is this can be sorted
        /// </summary>
        public bool Sortable
        {
            get { return _sortable; }
            set { _sortable = value; }
        }

        private bool _title = true;
        /// <summary>
        /// If this option is false the title is not displayed in that column when we hover a cell with the mouse
        /// </summary>
        public bool Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Set the initial width of the column, in pixels. This value currently can not be set as percentage
        /// </summary>
        public int Width { get; set; }

        public override string ToString()
        {
            StringBuilder column = new StringBuilder();
            column.AppendFormat("align: '{0}',", Align.ToString().ToLower());
            column.AppendFormat("fixed: {0},", Fixed.ToString().ToLower());
            column.AppendFormat("hidden: {0}, ", Hidden.ToString().ToLower());
            column.AppendFormat("label: '{0}',", Label);
            column.AppendFormat("name: '{0}',", Name);
            column.AppendFormat("resizable: {0},", Resizable.ToString().ToLower());
            column.AppendFormat("search: {0},", Search.ToString().ToLower());
            column.AppendFormat("sortable: {0},", Sortable.ToString().ToLower());
            column.AppendFormat("title: {0}", Title.ToString().ToLower());
            return column.ToString();
        }
    }
}