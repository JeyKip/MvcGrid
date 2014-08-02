using System.Web.Mvc;

namespace MvcGrid
{
    public static class MvcGrid
    {
        public static MvcHtmlString Grid(this HtmlHelper htmlHelper, GridSettings settings)
        {
            if (settings == null)
                return new MvcHtmlString("");

            return new MvcHtmlString(settings.ToString());
        }
    }
}