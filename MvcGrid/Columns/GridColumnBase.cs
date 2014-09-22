using System.Collections.Generic;
using System.Linq;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public abstract class GridColumnBase<T> : GridColumn
        where T : class, new()
    {
        /// <summary>
        /// Defines the alignment of the cell in the Body layer, not in header cell
        /// </summary>
        public T SetAlign(TextAlign align)
        {
            AddProperty("align", align.ToString().ToLower());
            return GetInstance();
        }

        /// <summary>
        /// If set to true this option does not allow recalculation of the width of the column if shrinkToFit option is set to true. Also the width does not change if a setGridWidth method is used to change the grid width.
        /// </summary>
        public T SetFixed(bool isFixed)
        {
            AddProperty("fixed", isFixed);
            return GetInstance();
        }

        /// <summary>
        /// Defines if this column is hidden at initialization
        /// </summary>
        public T SetHidden(bool isHidden)
        {
            AddProperty("hidden", isHidden);
            return GetInstance();
        }

        /// <summary>
        /// Defines the heading for this column
        /// </summary>
        public T SetLabel(string label)
        {
            AddProperty("label", label);
            return GetInstance();
        }

        /// <summary>
        /// Set the unique name in the grid for the column. This property is required. As well as other words used as property/event names, the reserved words (which cannot be used for names) include subgrid, cb and rn.
        /// </summary>
        public T SetName(string name)
        {
            AddProperty("name", name);
            return GetInstance();
        }

        /// <summary>
        /// Defines if the column can be resized
        /// </summary>
        public T SetResizable(bool isResizable)
        {
            AddProperty("resizable", isResizable);
            return GetInstance();
        }

        /// <summary>
        /// When used in search modules, disables or enables searching on that column
        /// </summary>
        public T SetSearch(bool search)
        {
            AddProperty("search", search);
            return GetInstance();
        }

        /// <summary>
        /// Defines is this can be sorted
        /// </summary>
        public T SetSortable(bool isSortable)
        {
            AddProperty("sortable", isSortable);
            return GetInstance();
        }

        /// <summary>
        /// If this option is false the title is not displayed in that column when we hover a cell with the mouse
        /// </summary>
        public T ShowTitle(bool showTitle)
        {
            AddProperty("title", showTitle);
            return GetInstance();
        }

        public T SetWidth(int width)
        {
            AddProperty("width", width);
            return GetInstance();
        }

        public T WrapText(bool wrapText)
        {
            if (wrapText)
                AddProperty("wrappingTextFunction", "cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style=\"white-space: normal;\"' }");
            return GetInstance();
        }

        protected override string ResolveProperty(KeyValuePair<string, object> x)
        {
            if (x.Key == "wrappingTextFunction")
                return x.Value.ToString();

            return PropertyResolver.Resolve(x);
        }

        protected abstract T GetInstance();
    }
}