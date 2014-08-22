using System.Collections.Generic;
using System.Linq;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public class JsonReader
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

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
            properties.Add("root", root);
            return this;
        }

        /// <summary>
        /// Current page for pager
        /// </summary>
        public JsonReader SetCurrentPageElementName(string page)
        {
            properties.Add("page", page);
            return this;
        }

        /// <summary>
        /// Total number of pages
        /// </summary>
        public JsonReader SetTotalElementName(string total)
        {
            properties.Add("total", total);
            return this;
        }

        /// <summary>
        /// Total number of records
        /// </summary>
        public JsonReader SetRecordsElementName(string records)
        {
            properties.Add("records", records);
            return this;
        }

        /// <summary>
        /// Tells jqGrid that the information for the data in the row is repeatable - i.e. the elements have the same tag cell described in cell element. Setting this option to false instructs jqGrid to search elements in the json data by name. Default value is false
        /// </summary>
        public JsonReader SetRepeatItemsElementName(bool repeatitems)
        {
            properties.Add("repeatitems", repeatitems);
            return this;
        }

        /// <summary>
        /// An array that contains the data for a row
        /// </summary>
        public JsonReader SetCell(string cell)
        {
            properties.Add("cell", cell);
            return this;
        }

        /// <summary>
        /// Element descibes the unique id for the row
        /// </summary>
        public JsonReader SetId(string id)
        {
            properties.Add("id", id);
            return this;
        }

        /// <summary>
        /// Element that contains free user data in json, i.e. "UserData" : {Total: 1200, Tax: 300}
        /// </summary>
        public JsonReader SetUserDataElementName(string userData)
        {
            properties.Add("userdata", userData);
            return this;
        }

        public override string ToString()
        {
            return string.Join(", ", properties.Select(x => PropertyResolver.Resolve(x)));
        }
    }
}