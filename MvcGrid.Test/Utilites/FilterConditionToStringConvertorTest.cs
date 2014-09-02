using MvcGrid.Utilites;
using NUnit.Framework;

namespace MvcGrid.Test.Utilites
{
    [TestFixture]
    public class FilterConditionToStringConvertorTest
    {
        [Test]
        public void Convert_SimpleCondition()
        {
            string actual = FilterConditionToStringConvertor.Convert(x => x["Status"] == "0");
            string expected = @"(ro[""Status""] == ""0"")";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Convert_ComplexCondition()
        {
            string actual = FilterConditionToStringConvertor.Convert(x => x["Name"] == "JeyKip" && (x["Status"] == "0" || x["Status"] == "1"));
            string expected = @"((ro[""Name""] == ""JeyKip"") && ((ro[""Status""] == ""0"") || (ro[""Status""] == ""1"")))";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Convert_FilterConditionString_CorrectJavaScriptObject()
        {
            string expected = @"ro[""ImageUrl""]";
            string actual = FilterConditionToStringConvertor.Convert(x => x["ImageUrl"]);

            Assert.AreEqual(expected, actual);
        }
    }
}