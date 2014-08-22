using MvcGrid.Test.Helpers;
using NUnit.Framework;

namespace MvcGrid.Test
{
    [TestFixture]
    public class GridSettingsTest
    {
        [Test]
        public void DefaultSettings_OnlyTableAndCallingOfGridInitFunction()
        {
            GridSettings4Test grid = new GridSettings4Test();
            
            string expected = string.Format(
@"<table id=""{0}""></table>
<script type=""text/javascript"">
    $(function(){{
        $('#{0}').jqGrid({{
        }});
    }});
</script>", grid.GridId).RemoveSpaces();
            string actual = grid.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GridSettings_SimpleProperties()
        {
            GridSettings4Test grid = new GridSettings4Test();
            JsonReader reader = new JsonReader();
            reader.SetCurrentPageElementName("CurrentPage")
                  .SetRootElementName("Rows");

            var formatterColumn = (new GridFormatterColumn()).SetFormatter("date").SetName("Created");
            var imageColumn = (new GridImageColumn());
            imageColumn.AddImage((new GridImage()).SetImagePath("/images/red.png").DisplayWhen(x => x["Status"] == "0"))
                       .AddImage((new GridImage()).SetImagePath("/images/green.png").DisplayWhen(x => x["Status"] == "1"))
                       .SetName("Status");

            grid.SetUrl("/Home/GetData")
                .SetDataType(GridDataType.JsonString)
                .SetRowNumber(25)
                .SetRowList(10, 25, 50)
                .SetViewRecords(true)
                .SetEmptyRecords("No records")
                .SetSortName("Id")
                .SetSortOrder(SortOrder.Desc)
                .SetCaption("Caption")
                .SetHideGrid(false)
                .SetHeight("100%")
                .AddJsonReader(reader)
                .AddColumn(formatterColumn)
                .AddColumn(imageColumn);

            string expected = string.Format(
@"<table id=""{0}""></table>
<script type=""text/javascript"">
    $(function(){{
        $('#{0}').jqGrid({{
            url: '/Home/GetData',
            datatype: 'jsonstring',
            rowNum: 25,
            rowList: [10, 25, 50],
            viewrecords: true,
            emptyrecords: 'No records',
            sortname: 'Id',
            sortorder: 'desc',
            caption: 'Caption',
            hidegrid: false,
            height: '100%',
            jsonReader: {{
                {1}
            }},
            colModel: [
                {{{2}}},
                {{{3}}}
            ]
        }});
    }});
    {4}
</script>", grid.GridId, reader, formatterColumn, imageColumn, imageColumn.GetFormatter()).RemoveSpaces();
            string actual = grid.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShowPager_SetToTrue_TableForGridDivForPagingPropertyWithPagerId()
        {
            GridSettings4Test grid = new GridSettings4Test();
            grid.ShowPager(true);

            string expected = string.Format(
@"<table id=""{0}""></table>
<div id=""{1}""></div>
<script type=""text/javascript"">
    $(function(){{
        $('#{0}').jqGrid({{
            pager: '#{1}'
        }});
    }});
</script>", grid.GridId, grid.Pager).RemoveSpaces();
            string actual = grid.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetNavigator_WithDefaultShowPager_DefaultGrid()
        {
            GridSettings4Test grid = new GridSettings4Test();
            grid.SetNavigator(new Navigator());
            
            string expected = string.Format(
@"<table id=""{0}""></table>
<script type=""text/javascript"">
    $(function(){{
        $('#Grid').jqGrid({{}});
    }});
</script>", grid.GridId).RemoveSpaces();
            string actual = grid.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetNavigator_DefaultInputWithPager_GridWithPager()
        {
            GridSettings4Test grid = new GridSettings4Test();
            grid.ShowPager(true);
            grid.SetNavigator(new Navigator());

            string expected = string.Format(
@"<table id=""{0}""></table>
<div id=""{1}""></div>
<script type=""text/javascript"">
    $(function(){{
        $('#Grid').jqGrid({{
            pager: '#{1}'
        }});
    }});
</script>", grid.GridId, grid.Pager).RemoveSpaces();
            string actual = grid.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetNavigator_CustomInput_GridWithPagerAndNavigatorOverriding()
        {
            GridSettings4Test grid = new GridSettings4Test();
            grid.ShowPager(true);
            grid.SetNavigator((new Navigator())
                            .SetAddButtonVisibility(false)
                            .SetEditButtonVisibility(true)
                            .SetDeleteButtonVisibility(false)
                            .SetRefreshButtonVisibility(true)
                            .SetSearchButtonVisibility(true));

            string expected = string.Format(
@"<table id=""{0}""></table>
<div id=""{1}""></div>
<script type=""text/javascript"">
    $(function(){{
        $('#Grid').jqGrid({{
            pager: '#{1}'
        }});
        $('#{0}').navGrid('#{1}', {{
            add: false,
            edit: true,
            del: false,
            refresh: true,
            search: true
        }});
    }});
</script>", grid.GridId, grid.Pager).RemoveSpaces();
            string actual = grid.ToString().RemoveSpaces();

            Assert.AreEqual(expected, actual);
        }
    }
}