using System.Collections.Generic;
using System.Linq;

namespace MvcGrid
{
    public abstract class GridColumnBase
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();
        protected Dictionary<string, object> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        /// <summary>
        /// Defines the alignment of the cell in the Body layer, not in header cell
        /// </summary>
        public GridColumnBase SetAlign(TextAlign align)
        {
            Properties.Add("align", align.ToString().ToLower());
            return this;
        }

        /// <summary>
        /// If set to true this option does not allow recalculation of the width of the column if shrinkToFit option is set to true. Also the width does not change if a setGridWidth method is used to change the grid width.
        /// </summary>
        public GridColumnBase SetFixed(bool isFixed)
        {
            Properties.Add("fixed", isFixed);
            return this;
        }

        /// <summary>
        /// Defines if this column is hidden at initialization
        /// </summary>
        public GridColumnBase SetHidden(bool isHidden)
        {
            Properties.Add("hidden", isHidden);
            return this;
        }

        /// <summary>
        /// Defines the heading for this column
        /// </summary>
        public GridColumnBase SetLabel(string label)
        {
            Properties.Add("label", label);
            return this;
        }

        /// <summary>
        /// Set the unique name in the grid for the column. This property is required. As well as other words used as property/event names, the reserved words (which cannot be used for names) include subgrid, cb and rn.
        /// </summary>
        public GridColumnBase SetName(string name)
        {
            Properties.Add("name", name);
            return this;
        }

        /// <summary>
        /// Defines if the column can be resized
        /// </summary>
        public GridColumnBase SetResizable(bool isResizable)
        {
            Properties.Add("resizable", isResizable);
            return this;
        }

        /// <summary>
        /// When used in search modules, disables or enables searching on that column
        /// </summary>
        public GridColumnBase SetSearch(bool search)
        {
            Properties.Add("search", search);
            return this;
        }

        /// <summary>
        /// Defines is this can be sorted
        /// </summary>
        public GridColumnBase SetSortable(bool isSortable)
        {
            Properties.Add("sortable", isSortable);
            return this;
        }

        /// <summary>
        /// If this option is false the title is not displayed in that column when we hover a cell with the mouse
        /// </summary>
        public GridColumnBase SetTitle(string title)
        {
            Properties.Add("title", title);
            return this;
        }

        public GridColumnBase SetWidth(int width)
        {
            Properties.Add("width", width);
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", Properties.Select(x=> (x.Value is string) ? string.Format("{0}: '{1}'", x.Key, x.Value) : string.Format("{0}: {1}", x.Key, x.Value.ToString().ToLower())));
        }
    }
}