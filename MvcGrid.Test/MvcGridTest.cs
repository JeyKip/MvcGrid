using System.Web.Mvc;
using NUnit.Framework;

namespace MvcGrid.Test
{
    [TestFixture]
    public class MvcGridTest
    {
        private class ViewDataContainer : IViewDataContainer
        {
            ViewDataDictionary dd = new ViewDataDictionary();
            public ViewDataDictionary ViewData
            {
                get
                {
                    return dd;
                }
                set
                {
                    dd = value;
                }
            }
        }

        [Test]
        public void Grid_GridSettingsIsNull_EmptyHtmlString()
        {
            var html = new HtmlHelper(new ViewContext(), new ViewDataContainer());
            MvcHtmlString grid = html.Grid(null);

            Assert.AreEqual(string.Empty, grid.ToString());
        }

        [Test]
        public void Grid_GridSettingsNotNull_GridMarkup()
        {
            var html = new HtmlHelper(new ViewContext(), new ViewDataContainer());
            var gs = new GridSettings();
            
            MvcHtmlString grid = html.Grid(gs);

            Assert.AreEqual(gs.ToString(), grid.ToString());
        }
    }
}