namespace MvcGrid
{
    public abstract class FilterCondition
    {
        public abstract string this[string columnName] { get; }
    }
}