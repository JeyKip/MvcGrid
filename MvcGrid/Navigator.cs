using System.Text;

namespace MvcGrid
{
    public class Navigator
    {
        private bool _edit = true;
        public bool Edit
        {
            get { return _edit; }
            set { _edit = value; }
        }

        private bool _add = true;
        public bool Add
        {
            get { return _add; }
            set { _add = value; }
        }

        private bool _del = true;
        public bool Delete
        {
            get { return _del; }
            set { _del = value; }
        }

        private bool _search = true;
        public bool Search
        {
            get { return _search; }
            set { _search = value; }
        }

        private bool _refresh = true;
        public bool Refresh
        {
            get { return _refresh; }
            set { _refresh = value; }
        }


        public override string ToString()
        {
            StringBuilder navigator = new StringBuilder();
            navigator.AppendFormat("edit: {0},", Edit.ToString().ToLower());
            navigator.AppendFormat("add: {0},", Add.ToString().ToLower());
            navigator.AppendFormat("del: {0},", Delete.ToString().ToLower());
            navigator.AppendFormat("search: {0},", Search.ToString().ToLower());
            navigator.AppendFormat("refresh: {0}", Refresh.ToString().ToLower());
            return navigator.ToString();
        }
    }
}