using NUnit.Framework;

namespace MvcGrid.Test.Columns
{
    public class GridColumnBaseTest<T>
        where T : GridColumnBase, new()
    {
        [Test]
        public void GridColumn_BaseSettings()
        {
            T column = new T();
            column.SetAlign(TextAlign.Center)
                  .SetFixed(true)
                  .SetHidden(false)
                  .SetLabel("Test column")
                  .SetName("Test")
                  .SetResizable(true)
                  .SetSearch(true)
                  .SetSortable(true)
                  .ShowTitle(false)
                  .SetWidth(200)
                  .WrapText(true);

            string expected = @"align: 'center', fixed: true, hidden: false,
                                label: 'Test column', name: 'Test', resizable: true,
                                search: true, sortable: true, title: false, width: 200,
                                cellattr: function (rowId, tv, rawObject, cm, rdata) { return 'style=""white-space: normal;""' }"
                .RemoveSpaces();
            string actual = column.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}