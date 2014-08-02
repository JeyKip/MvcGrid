using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcGrid
{
    /// <summary>
    /// You can use JsonData class for returning data
    /// </summary>
    public class JsonReader
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

        private string _page = "CurrentPage";
        /// <summary>
        /// Current page for pager. Default value - CurrentPage
        /// </summary>
        public string Page
        {
            get { return _page; }
            set { _page = value; }
        }

        private string _total = "TotalPages";
        /// <summary>
        /// Total number of pages. Default value - TotalPages
        /// </summary>
        public string Total
        {
            get { return _total; }
            set { _total = value; }
        }

        private string _records = "Records";
        /// <summary>
        /// Total number of records. Default value - Records
        /// </summary>
        public string Records
        {
            get { return _records; }
            set { _records = value; }
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

        /// <summary>
        /// Element descibes the unique id for the row
        /// </summary>
        public string Id { get; set; }

        private string _userData = "UserData";
        /// <summary>
        /// Element that contains free user data in json, i.e. "UserData" : {Total: 1200, Tax: 300. Default value - "UserData"
        /// </summary>
        public string UserData
        {
            get { return _userData; }
            set { _userData = value; }
        }

        public JsonReaderSubGrid SubGrid { get; set; }

        public override string ToString()
        {
            StringBuilder jsonReder = new StringBuilder();
            jsonReder.AppendFormat("root: '{0}', page: '{1}', total: '{2}', records: '{3}', repeatitems: {4}, cell: '{5}', id: '{6}', userdata: '{7}'", 
                Root, Page, Total, Records, RepeatItems.ToString().ToLower(), Cell, Id, UserData);
            if (SubGrid != null)
                jsonReder.AppendFormat(", subgrid: {{{0}}}", SubGrid.ToString());
            return jsonReder.ToString();
        }
    }
}