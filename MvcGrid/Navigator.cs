using System.Collections.Generic;
using System.Text;

namespace MvcGrid
{
    public class Navigator
    {
        private List<string> properties = new List<string>();

        public Navigator SetEditButtonVisibility(bool isVisible)
        {
            properties.Add(string.Format("edit: {0}", isVisible.ToString().ToLower()));
            return this;
        }

        public Navigator SetAddButtonVisibility(bool isVisible)
        {
            properties.Add(string.Format("add: {0}", isVisible.ToString().ToLower()));
            return this;
        }

        public Navigator SetDeleteButtonVisibility(bool isVisible)
        {
            properties.Add(string.Format("del: {0}", isVisible.ToString().ToLower()));
            return this;
        }

        public Navigator SetSearchButtonVisibility(bool isVisible)
        {
            properties.Add(string.Format("search: {0}", isVisible.ToString().ToLower()));
            return this;
        }

        public Navigator SetRefreshButtonVisibility(bool isVisible)
        {
            properties.Add(string.Format("refresh: {0}", isVisible.ToString().ToLower()));
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", properties);
        }
    }
}