using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcGrid
{
    public class JsonReaderSubGrid
    {
        private string _root = "Rows";
        /// <summary>
        /// This element describes where our data begins. In other words, this points to the array that contains the data. Default value - "Rows"
        /// </summary>
        public string Root
        {
            get { return _root; }
            set { _root = value; }
        }

        private bool _repeatitems = true;
        /// <summary>
        /// Tells jqGrid that the information for the data in the row is repeatable - i.e. the elements have the same tag cell described in cell element. Setting this option to false instructs jqGrid to search elements in the json data by name
        /// </summary>
        public bool RepeatItems
        {
            get { return _repeatitems; }
            set { _repeatitems = value; }
        }

        /// <summary>
        /// An array that contains the data for a row
        /// </summary>
        public string Cell { get; set; }

        public override string ToString()
        {
            return string.Format("root: '{0}', repeatitems: {1}, cell: '{2}'", Root, RepeatItems.ToString().ToLower(), Cell);
        }
    }
}