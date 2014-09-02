using NUnit.Framework;

namespace MvcGrid.Test.Columns
{
    [TestFixture]
    public class GridImageTest
    {
        [Test]
        public void ToString_Default_ImageTagWithEmptyAttributes()
        {
            GridImage gi = new GridImage();

            string expected = "<img />";
            string actual = gi.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_SetLambdaImagePath()
        {
            GridImage gi = new GridImage();
            gi.SetImagePath(x => x["ImageUrl"]);

            string expected = @"<img src='""+ro[""ImageUrl""]+""' />";
            string actual = gi.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_SetLambdaToolTip()
        {
            GridImage gi = new GridImage();
            gi.SetToolTip(x => x["Description"]);

            string expected = @"<img title='""+ro[""Description""]+""' />";
            string actual = gi.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_AllProperties_CorrectImageTag()
        {
            GridImage gi = new GridImage();
            gi.SetImagePath("/images/red.png");
            gi.SetToolTip("InActive");
            gi.SetWidth(16);
            gi.SetHeight(16);

            string expected = "<img src='/images/red.png' title='InActive' width='16' height='16' />";
            string actual = gi.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
