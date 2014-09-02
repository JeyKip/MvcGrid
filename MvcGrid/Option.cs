using System;
using System.Collections.Generic;
using MvcGrid.Utilites;
using System.Linq;

namespace MvcGrid
{
    public class Option
    {
        private Dictionary<string, object> options = new Dictionary<string, object>();

        public void AddOption(string name, object value)
        {
            if (options.ContainsKey(name))
                throw new ArgumentException(string.Format("Option with name [{0}] already exists", name));

            options.Add(name, value);
        }

        public override string ToString()
        {
            return string.Join(", ", options.Select(x => PropertyResolver.Resolve(x)));
        }
    }
}