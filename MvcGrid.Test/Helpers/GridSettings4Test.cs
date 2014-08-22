namespace MvcGrid.Test.Helpers
{
    public class GridSettings4Test : GridSettings
    {
        public override string GridId
        {
            get
            {
                return "Grid";
            }
        }

        public override string Pager
        {
            get
            {
                return "Pager";
            }
        }

        public string GridPattern
        {
            get
            {
                return base.GridSettingsPattern;
            }
        }
    }
}