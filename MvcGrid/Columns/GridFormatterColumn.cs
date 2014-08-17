using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcGrid
{
    public class GridFormatterColumn : GridColumnBase
    {
        private Dictionary<string, object> formatoptions = new Dictionary<string, object>();

        public GridFormatterColumn SetFormatter(string formatter)
        {
            Properties.Add("formatter", formatter);
            return this;
        }

        public GridFormatterColumn SetFormatOption(string optionName, object value)
        {
            if (formatoptions.ContainsKey(optionName))
                throw new ArgumentException(string.Format("Option with name [{0}] already setted!", optionName));

            formatoptions.Add(optionName, value);
            return this;
        }

        public override string ToString()
        {
            string result = base.ToString();
            if (formatoptions.Count > 0)
                result = string.Format("{0}, formatoptions: {{{1}}}", result, string.Join(", ", formatoptions.Select(x => x.Value is string ? string.Format("{0}: '{1}'", x.Key, x.Value) : string.Format("{0}: {1}", x.Key, x.Value))));
            return result;
        }
    }
}
