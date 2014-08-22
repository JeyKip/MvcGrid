using System.Text.RegularExpressions;
namespace MvcGrid.Test
{
    public static class StringExtensions
    {
        public static string RemoveSpaces(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return (new Regex(@"\s*")).Replace(str, string.Empty); 
        }
    }
}