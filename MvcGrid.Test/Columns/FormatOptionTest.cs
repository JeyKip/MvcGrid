using System;
using NUnit.Framework;

namespace MvcGrid.Test.Columns
{
    [TestFixture]
    public class FormatOptionTest
    {
        [Test]
        [ExpectedException(ExpectedException=typeof(ArgumentException), ExpectedMessage="Option with name [key] already exists")]
        public void AddOption_AddingDuplicateOption_ArgumentException()
        {
            Option options = new Option();
            options.AddOption("key", 1);
            options.AddOption("key", 2);
        }

        [Test]
        public void ToString_FewOptions_KeyValuePairsInString()
        {
            Option options = new Option();
            options.AddOption("baseLinkUrl", "home/getdata");
            options.AddOption("id", 5);

            string expected = "baseLinkUrl: 'home/getdata', id: 5".RemoveSpaces();
            string actual = options.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}