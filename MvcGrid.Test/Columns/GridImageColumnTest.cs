using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MvcGrid.Test.Columns
{
    [TestFixture]
    public class GridImageColumnTest : GridColumnBaseTest<GridImageColumn>
    {
        [Test]
        public void GetFormatter_WithoutImages_EmptyString()
        {
            GridImageColumn ic = new GridImageColumn();

            string expected = string.Empty;
            string actual = ic.GetFormatter();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException), ExpectedMessage = "Column name is missing")]
        public void GetFormatter_WithoutName_ThrowInvalidOperationException()
        {
            GridImageColumn ic = new GridImageColumn();
            ic.AddImage(new GridImage());
            string formatter = ic.GetFormatter();
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(InvalidOperationException), ExpectedMessage = "Column name is missing")]
        public void GetFormatter_WithEmptyName_ThrowInvalidOperationException()
        {
            GridImageColumn ic = new GridImageColumn();
            ic.SetName("");
            ic.AddImage(new GridImage());
            string formatter = ic.GetFormatter();
        }

        [Test]
        public void GetFormatter_AllConditionsAreMet_CorrectFormatterFunctionText()
        {
            GridImageColumn ic = new GridImageColumn();
            ic.SetName("Status");
            ic.AddImage((new GridImage()).SetImagePath("/images/red.png").SetToolTip("Blocked").DisplayWhen(x => x["Status"] == "0"));
            ic.AddImage((new GridImage()).SetImagePath("/images/green.png").SetToolTip("Active").DisplayWhen(x => x["Status"] == "1"));

            string expected =
@"function Statusformatter(cv,o,ro){
    if ((ro[""Status""] == ""0""))
        return ""<img src='/images/red.png' title='Blocked' />"";
    if ((ro[""Status""] == ""1""))
        return ""<img src='/images/green.png' title='Active' />"";
    return """";
}".RemoveSpaces();
            string actual = ic.GetFormatter().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_AllConditionsAreMet_CorrectFormatterFunctionName()
        {
            GridImageColumn ic = new GridImageColumn();
            ic.SetName("Status");
            ic.AddImage((new GridImage()).SetImagePath("/images/red.png").SetToolTip("Blocked").DisplayWhen(x => x["Status"] == "0"));
            ic.AddImage((new GridImage()).SetImagePath("/images/green.png").SetToolTip("Active").DisplayWhen(x => x["Status"] == "1"));

            string expected = "name: 'Status', formatter: Statusformatter";
            string actual = ic.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}