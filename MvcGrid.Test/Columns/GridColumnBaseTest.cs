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
                  .SetWidth(200);

            string expected = @"align: 'center', fixed: true, hidden: false,
                                label: 'Test column', name: 'Test', resizable: true,
                                search: true, sortable: true, title: false, width: 200"
                .RemoveSpaces();
            string actual = column.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}