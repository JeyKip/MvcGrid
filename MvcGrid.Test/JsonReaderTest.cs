using NUnit.Framework;

namespace MvcGrid.Test
{
    [TestFixture]
    public class JsonReaderTest
    {
        [Test]
        public void JsonReader_DefaultProperty()
        {
            JsonReader reader = JsonReader.Default;

            string expected = string.Format("total: 'TotalPages', page: 'CurrentPage', records: 'Records', root: 'Rows', userdata: 'UserData', repeatitems: false").RemoveSpaces();
            string actual = reader.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void JsonReader_SimpleProperties()
        {
            JsonReader reader = new JsonReader();
            reader.SetTotalElementName("total")
                  .SetCurrentPageElementName("currentPage")
                  .SetRecordsElementName("rec")
                  .SetRootElementName("rowList")
                  .SetUserDataElementName("customData")
                  .SetCell("cell")
                  .SetId("ProductId")
                  .SetRepeatItemsElementName(true);

            string expected = "total: 'total', page: 'currentPage', records: 'rec', root: 'rowList', userdata: 'customData', cell: 'cell', id: 'ProductId', repeatitems: true".RemoveSpaces();
            string actual = reader.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}