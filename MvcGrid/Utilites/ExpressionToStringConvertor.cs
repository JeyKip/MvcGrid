using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace MvcGrid.Utilites
{
    public static class FilterConditionToStringConvertor
    {
        public static string Convert(Expression<Func<FilterCondition, bool>> expression)
        {
            string expBody = ((LambdaExpression)expression).Body.ToString();
            foreach (var parameter in expression.Parameters)
                expBody = expBody.Replace(string.Format("{0}.", parameter.Name), string.Empty);

            Regex regex = new Regex(@"get_Item(\(""\w*""\))");
            var matches = regex.Matches(expBody);
            foreach(Match match in matches)
            {
                if (expBody.IndexOf(match.Value) < 0)
                    continue;

                string columnName = (new Regex(@"(""\w*"")")).Split(match.Value)[1];
                expBody = expBody.Replace(match.Value, string.Format("ro[{0}]", columnName));
            }

            return expBody.Replace("AndAlso", "&&")
                          .Replace("OrElse", "||");
        }
    }
}