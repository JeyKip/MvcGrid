using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MvcGrid.Utilites
{
    public static class PropertyResolver
    {
        public static string Resolve(KeyValuePair<string, object> x)
        {
            if (x.Value is string || !(x.Value is IEnumerable))
                return string.Format("{0}: {1}", x.Key, Resolve(x.Value));

            List<string> properties = new List<string>();
            foreach (var value in (x.Value as IEnumerable))
                properties.Add(Resolve(value));

            return string.Format("{0}: [{1}]", x.Key, string.Join(", ", properties));
        }

        public static string Resolve(object value)
        {
            if (value is string || value is char)
                return string.Format("'{0}'", value);

            if (value.GetType().IsEnum)
                return string.Format("'{0}'", value.ToString().ToLower());

            if (value.GetType().IsClass)
                return string.Format("{{{0}}}", value);

            return value.ToString().ToLower();
        }
    }
}