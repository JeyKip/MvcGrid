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
        public void ToString_ImageWithoutCondition()
        {
            GridImageColumn ic = new GridImageColumn();
            ic.AddImage(new GridImage().SetImagePath("/images/red.png"));

            string expected =
@"formatter: function (cv,o,ro){
    return ""<img src='/images/red.png' />"";
    return """";
}".RemoveSpaces();
            string actual = ic.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_AllConditionsAreMet_FormatterPropertyCorrectFunctionText()
        {
            GridImageColumn ic = new GridImageColumn();
            ic.AddImage((new GridImage()).SetImagePath("/images/red.png").SetToolTip("Blocked").DisplayWhen(x => x["Status"] == "0"));
            ic.AddImage((new GridImage()).SetImagePath("/images/green.png").SetToolTip("Active").DisplayWhen(x => x["Status"] == "1"));

            string expected =
@"formatter: function (cv,o,ro){
    if ((ro[""Status""] == ""0""))
        return ""<img src='/images/red.png' title='Blocked' />"";
    if ((ro[""Status""] == ""1""))
        return ""<img src='/images/green.png' title='Active' />"";
    return """";
}".RemoveSpaces();
            string actual = ic.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}