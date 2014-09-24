using NUnit.Framework;

namespace MvcGrid.Test.Columns
{
    [TestFixture]
    public class GridImageButtonColumnTest : GridColumnBaseTest<GridImageButtonColumn>
    {
        [Test]
        public void ToString_EmptyFunctionName_EmptyString()
        {
            GridImageButtonColumn ibc = new GridImageButtonColumn();

            string expected = string.Empty;
            string actual = ibc.ToString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_FunctionNameIsSetted_CorrectFormatter()
        {
            GridImageButtonColumn column = new GridImageButtonColumn();
            column.SetClickHandler("clickHandler");
            column.SetIconClass("ui-icon-pencil");
            column.SetToolTip("Some title");

            string expected =
@"formatter: function (cv,o,ro){
    var cf = ""\""clickHandler(this);\"""";
    var ocl = ""onclick=""+cf+"" onmouseover=jQuery(this).addClass('ui-state-hover'); onmouseout=jQuery(this).removeClass('ui-state-hover') "";
    var str = ""<div title='"" + ""Some title"" + ""' style='float:left;cursor:pointer;' class='ui-pg-div ui-inline-edit' "" + ocl + ""><span class='ui-icon ui-icon-pencil'></span></div>"";
    return ""<div>"" + str + ""</div>"";
}".RemoveSpaces();

            string actual = column.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_FunctionNameWithParams_CorrectFormatter()
        {
            GridImageButtonColumn column = new GridImageButtonColumn();
            column.SetClickHandler("clickHandler", "ID", "Description", "Status");
            column.SetIconClass("ui-icon-pencil");
            column.SetToolTip("Some title");

            string expected =
@"formatter: function (cv,o,ro){
    var cf = ""\""clickHandler(this, '""+ro[""ID""]+""', '""+ro[""Description""]+""', '""+ro[""Status""]+""');\"""";
    var ocl = ""onclick=""+cf+"" onmouseover=jQuery(this).addClass('ui-state-hover'); onmouseout=jQuery(this).removeClass('ui-state-hover') "";
    var str = ""<div title='"" + ""Some title"" + ""' style='float:left;cursor:pointer;' class='ui-pg-div ui-inline-edit' "" + ocl + ""><span class='ui-icon ui-icon-pencil'></span></div>"";
    return ""<div>"" + str + ""</div>"";
}".RemoveSpaces();

            string actual = column.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_FunctionNameWithDisplayCondition_CorrectFormatter()
        {
            GridImageButtonColumn column = new GridImageButtonColumn();
            column.SetClickHandler("clickHandler", "ID", "Description", "Status");
            column.SetIconClass("ui-icon-pencil");
            column.SetToolTip("Some title");
            column.DisplayWhen(x => x["Status"] == "1");

            string expected =
@"formatter: function (cv,o,ro){
    if ((ro[""Status""] == ""1"")){
        var cf = ""\""clickHandler(this, '""+ro[""ID""]+""', '""+ro[""Description""]+""', '""+ro[""Status""]+""');\"""";
        var ocl = ""onclick=""+cf+"" onmouseover=jQuery(this).addClass('ui-state-hover'); onmouseout=jQuery(this).removeClass('ui-state-hover') "";
        var str = ""<div title='"" + ""Some title"" + ""' style='float:left;cursor:pointer;' class='ui-pg-div ui-inline-edit' "" + ocl + ""><span class='ui-icon ui-icon-pencil'></span></div>"";
        return ""<div>"" + str + ""</div>"";
    }
    return """";
}".RemoveSpaces();

            string actual = column.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}