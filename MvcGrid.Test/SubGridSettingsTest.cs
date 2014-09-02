using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcGrid.Test.Helpers;
using NUnit.Framework;

namespace MvcGrid.Test
{
    [TestFixture]
    public class SubGridSettingsTest
    {
        [Test]
        public void ToString_DefaultConstructorUsing_DefaultSubGrid()
        {
            SubGridSettings4Test sg = new SubGridSettings4Test();

            string expected =
@"subGrid: true,
subGridRowExpanded: function (sid, rid) {
    $('#' + sid).html(""<table id='subGridId'></table>"");
    var rd = $(this).getRowData(rid);
    $(""#subGridId"").jqGrid({});
}".RemoveSpaces();
            string actual = sg.ToString().RemoveSpaces();

                Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToString_WithSubgridOption_SubGridWithOption()
        {
            SubGridSettings4Test sg = new SubGridSettings4Test();
            sg.SetPlusIcon("plusIconClass");
            sg.SetMinusIcon("minusIconClass");
            sg.SetOpenIcon("openIconClass");
            sg.ExpandOnLoad(false);
            sg.SelectOnExpand(true);
            sg.ReloadOnExpand(false);

            string expected =
@"subGrid: true,
subGridOptions: {
    plusicon: 'plusIconClass',
    minusicon: 'minusIconClass',
    openicon: 'openIconClass',
    expandOnLoad: false,
    selectOnExpand: true,
    reloadOnExpand: false
},
subGridRowExpanded: function (sid, rid) {
    $('#' + sid).html(""<table id='subGridId'></table>"");
    var rd = $(this).getRowData(rid);
    $(""#subGridId"").jqGrid({});
}".RemoveSpaces();
            string actual = sg.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetSubgridUrl_WithoutParams_DefaultSubGridWithUrlAddressOnly()
        {
            SubGridSettings4Test sg = new SubGridSettings4Test();
            sg.SetSubgridUrl("http://www.mysite.com/");

            string expected =
@"subGrid: true,
subGridRowExpanded: function (sid, rid) {
    $('#' + sid).html(""<table id='subGridId'></table>"");
    var rd = $(this).getRowData(rid);
    $(""#subGridId"").jqGrid({
        url: 'http://www.mysite.com/'
    });
}".RemoveSpaces();
            string actual = sg.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetSubgridUrl_SubGridUrlWithCorrectGetParams()
        {
            SubGridSettings4Test sg = new SubGridSettings4Test();
            sg.SetSubgridUrl("http://www.mysite.com/", "Code", "Name", "Status");

            string expected =
@"subGrid: true,
subGridRowExpanded: function (sid, rid) {
    $('#' + sid).html(""<table id='subGridId'></table>"");
    var rd = $(this).getRowData(rid);
    $(""#subGridId"").jqGrid({
        url: 'http://www.mysite.com/?'+'Code='+rd.Code+'&'+'Name='+rd.Name+'&'+'Status='+rd.Status
    });
}".RemoveSpaces();
            string actual = sg.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}