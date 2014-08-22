using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            string expected = @"return ""<img src='' title='' />"";";
            string actual = gi.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_WithPropertiesWithoutCondition_ImageTagWithFilledAttributes()
        {
            GridImage gi = new GridImage();
            gi.SetImagePath("/images/image.gif");
            gi.SetToolTip("Image tooltip");

            string expected = @"return ""<img src='/images/image.gif' title='Image tooltip' />"";";
            string actual = gi.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_WithPropertiesAndCondition_ImageTagWithFilledAttributesAndIfStatement()
        {
            GridImage gi = new GridImage();
            gi.DisplayWhen(x => x["Status"] == "1")
              .SetImagePath("/images/image.gif")
              .SetToolTip("Image tooltip");

            string expected = @"if ((ro[""Status""] == ""1"")) return ""<img src='/images/image.gif' title='Image tooltip' />"";".RemoveSpaces();
            string actual = gi.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}
