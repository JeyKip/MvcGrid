using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcGrid
{
    public class JsonReaderSubGrid
    {
        private List<string> properties = new List<string>();
        
        /// <summary>
        /// This element describes where our data begins. In other words, this points to the array that contains the data. Default value - "Rows"
        /// </summary>
        public JsonReaderSubGrid SetRootElementName(string root)
        {
            properties.Add(string.Format("root: '{0}'", root));
            return this;
        }

        /// <summary>
        /// Tells jqGrid that the information for the data in the row is repeatable - i.e. the elements have the same tag cell described in cell element. Setting this option to false instructs jqGrid to search elements in the json data by name. Default value is false
        /// </summary>
        public JsonReaderSubGrid SetRepeatItemsElementName(bool repeatitems)
        {
            properties.Add(string.Format("repeatitems: '{0}'", repeatitems.ToString().ToLower()));
            return this;
        }

        /// <summary>
        /// An array that contains the data for a row
        /// </summary>
        public JsonReaderSubGrid SetCell(string cell)
        {
            properties.Add(string.Format("cell: '{0}'", cell));
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", properties);
        }
    }
}