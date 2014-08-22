using System.Collections.Generic;
using System.Linq;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public abstract class GridColumnBase
    {
        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        /// <summary>
        /// Defines the alignment of the cell in the Body layer, not in header cell
        /// </summary>
        public GridColumnBase SetAlign(TextAlign align)
        {
            AddProperty("align", align.ToString().ToLower());
            return this;
        }

        /// <summary>
        /// If set to true this option does not allow recalculation of the width of the column if shrinkToFit option is set to true. Also the width does not change if a setGridWidth method is used to change the grid width.
        /// </summary>
        public GridColumnBase SetFixed(bool isFixed)
        {
            AddProperty("fixed", isFixed);
            return this;
        }

        /// <summary>
        /// Defines if this column is hidden at initialization
        /// </summary>
        public GridColumnBase SetHidden(bool isHidden)
        {
            AddProperty("hidden", isHidden);
            return this;
        }

        /// <summary>
        /// Defines the heading for this column
        /// </summary>
        public GridColumnBase SetLabel(string label)
        {
            AddProperty("label", label);
            return this;
        }

        /// <summary>
        /// Set the unique name in the grid for the column. This property is required. As well as other words used as property/event names, the reserved words (which cannot be used for names) include subgrid, cb and rn.
        /// </summary>
        public GridColumnBase SetName(string name)
        {
            AddProperty("name", name);
            return this;
        }

        /// <summary>
        /// Defines if the column can be resized
        /// </summary>
        public GridColumnBase SetResizable(bool isResizable)
        {
            AddProperty("resizable", isResizable);
            return this;
        }

        /// <summary>
        /// When used in search modules, disables or enables searching on that column
        /// </summary>
        public GridColumnBase SetSearch(bool search)
        {
            AddProperty("search", search);
            return this;
        }

        /// <summary>
        /// Defines is this can be sorted
        /// </summary>
        public GridColumnBase SetSortable(bool isSortable)
        {
            AddProperty("sortable", isSortable);
            return this;
        }

        /// <summary>
        /// If this option is false the title is not displayed in that column when we hover a cell with the mouse
        /// </summary>
        public GridColumnBase ShowTitle(bool showTitle)
        {
            AddProperty("title", showTitle);
            return this;
        }

        public GridColumnBase SetWidth(int width)
        {
            AddProperty("width", width);
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", _properties.Select(x => PropertyResolver.Resolve(x)));
        }

        protected virtual void AddProperty(string propertyName, object value)
        {
            if (!_properties.ContainsKey(propertyName))
                _properties.Add(propertyName, value);
        }

        protected object GetProperty(string name)
        {
            if (_properties.ContainsKey(name))
                return _properties.First(x=> x.Key == name).Value;

            return null;
        }

        protected Dictionary<string, object> GetProperties()
        {
            return _properties;
        }
    }
}