using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcGrid
{
    public class GridFormatterColumn : GridColumnBase<GridFormatterColumn>
    {
        public GridFormatterColumn SetFormatter(string formatter)
        {
            AddProperty("formatter", formatter);
            return GetInstance();
        }

        public GridFormatterColumn AddFormatOption(string optionName, object value)
        {
            if (string.IsNullOrWhiteSpace(optionName))
                throw new ArgumentException("Option name cannot be null or empty!");

            Option formatoption = GetProperty("formatoptions") as Option;
            if (formatoption == null)
            {
                formatoption = new Option();
                AddProperty("formatoptions", formatoption);
            }

            formatoption.AddOption(optionName, value);
            return GetInstance();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override GridFormatterColumn GetInstance()
        {
            return this;
        }
    }
}