using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcGrid
{
    public class JsonReader
    {
        private List<string> properties = new List<string>();

        /// <summary>
        /// Returns JsonReader instance with default settings:
        /// <para>total: TotalPages</para>
        /// <para>page: CurrentPage</para>
        /// <para>records: Records</para>
        /// <para>root: Rows</para>
        /// <para>userdata: UserData</para>
        /// <para>repeatitems: false</para>
        /// You can use MvcGrid.DataFormat.JsonData for packing returning values
        /// </summary>
        public static JsonReader Default
        {
            get 
            {
                return (new JsonReader())
                        .SetTotalElementName("TotalPages")
                        .SetCurrentPageElementName("CurrentPage")
                        .SetRecordsElementName("Records")
                        .SetRootElementName("Rows")
                        .SetUserDataElementName("UserData")
                        .SetRepeatItemsElementName(false);
            }
        }

        /// <summary>
        /// This element describes where our data begins. In other words, this points to the array that contains the data
        /// </summary>
        public JsonReader SetRootElementName(string root)
        {
            properties.Add(string.Format("root: '{0}'", root));
            return this;
        }

        /// <summary>
        /// Current page for pager
        /// </summary>
        public JsonReader SetCurrentPageElementName(string page)
        {
            properties.Add(string.Format("page: '{0}'", page));
            return this;
        }

        /// <summary>
        /// Total number of pages
        /// </summary>
        public JsonReader SetTotalElementName(string total)
        {
            properties.Add(string.Format("total: '{0}'", total));
            return this;
        }

        /// <summary>
        /// Total number of records
        /// </summary>
        public JsonReader SetRecordsElementName(string records)
        {
            properties.Add(string.Format("records: '{0}'", records));
            return this;
        }

        /// <summary>
        /// Tells jqGrid that the information for the data in the row is repeatable - i.e. the elements have the same tag cell described in cell element. Setting this option to false instructs jqGrid to search elements in the json data by name. Default value is false
        /// </summary>
        public JsonReader SetRepeatItemsElementName(bool repeatitems)
        {
            properties.Add(string.Format("repeatitems: {0}", repeatitems.ToString().ToLower()));
            return this;
        }

        /// <summary>
        /// An array that contains the data for a row
        /// </summary>
        public JsonReader SetCell(string cell)
        {
            properties.Add(string.Format("cell: '{0}'", cell));
            return this;
        }

        /// <summary>
        /// Element descibes the unique id for the row
        /// </summary>
        public JsonReader SetId(string id)
        {
            properties.Add(string.Format("id: '{0}'", id));
            return this;
        }

        /// <summary>
        /// Element that contains free user data in json, i.e. "UserData" : {Total: 1200, Tax: 300}
        /// </summary>
        public JsonReader SetUserDataElementName(string userData)
        {
            properties.Add(string.Format("userdata: '{0}'", userData));
            return this;
        }

        public JsonReader SetSubGridInfo(JsonReaderSubGrid subGridInfo)
        {
            if (subGridInfo != null)
                properties.Add(string.Format("subgrid: {{{0}}}", subGridInfo));
            
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", properties);
        }
    }
}