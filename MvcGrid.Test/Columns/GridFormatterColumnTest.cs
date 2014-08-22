using System;
using NUnit.Framework;

namespace MvcGrid.Test.Columns
{
    [TestFixture]
    public class GridFormatterColumnTest : GridColumnBaseTest<GridFormatterColumn>
    {
        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException), ExpectedMessage = "Option name cannot be null or empty!")]
        public void AddFormatOption_NameIsNull_ArgumentNullException()
        {
            GridFormatterColumn column = new GridFormatterColumn();
            column.AddFormatOption(null, null);
        }

        [Test]
        public void ToString_WithoutFormatOptions_FormatterOnly()
        {
            GridFormatterColumn column = new GridFormatterColumn();
            column.SetFormatter("date");

            string expected = "formatter: 'date'".RemoveSpaces();
            string actual = column.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual); 
        }

        [Test]
        public void ToString_FewFormatOptions_KeyValuePairsInString()
        {
            GridFormatterColumn column = new GridFormatterColumn();
            column.SetFormatter("date");
            column.AddFormatOption("baseLinkUrl", "home/getdata");
            column.AddFormatOption("id", 5);

            string expected = "formatter: 'date', formatoptions: {baseLinkUrl: 'home/getdata', id: 5}".RemoveSpaces();
            string actual = column.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}