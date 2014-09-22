using System.Collections.Generic;
using System.Linq;
using MvcGrid.Utilites;

namespace MvcGrid
{
    public abstract class GridColumn
    {
        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        public override string ToString()
        {
            return string.Join(", ", _properties.Select(x => ResolveProperty(x)));
        }

        protected virtual void AddProperty(string propertyName, object value)
        {
            if (!_properties.ContainsKey(propertyName))
                _properties.Add(propertyName, value);
        }

        protected object GetProperty(string name)
        {
            if (_properties.ContainsKey(name))
                return _properties.First(x => x.Key == name).Value;

            return null;
        }

        protected virtual string ResolveProperty(KeyValuePair<string, object> x)
        {
            return PropertyResolver.Resolve(x);
        }
    }
}