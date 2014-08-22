using System.Collections.Generic;
using System.Text;
using System.Linq;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public class Navigator
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        public Navigator SetEditButtonVisibility(bool isVisible)
        {
            properties.Add("edit", isVisible);
            return this;
        }

        public Navigator SetAddButtonVisibility(bool isVisible)
        {
            properties.Add("add", isVisible);
            return this;
        }

        public Navigator SetDeleteButtonVisibility(bool isVisible)
        {
            properties.Add("del", isVisible);
            return this;
        }

        public Navigator SetSearchButtonVisibility(bool isVisible)
        {
            properties.Add("search", isVisible);
            return this;
        }

        public Navigator SetRefreshButtonVisibility(bool isVisible)
        {
            properties.Add("refresh", isVisible);
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", properties.Select(x => PropertyResolver.Resolve(x)));
        }
    }
}