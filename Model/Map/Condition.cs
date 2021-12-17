using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class Condition<TParent>
        where TParent : class
    {
        public TParent Parent     { get; }
        public string  Name       { get; }
        public string  ColumnName { get; }
        public string  Value      { get; }
        public bool    IsNull     { get; }

        internal Condition(TParent parent, TCondition t_condition)
        {
            Parent     = parent ?? throw new ArgumentNullException(nameof(parent));
            Name       = t_condition.Name;
            ColumnName = t_condition.ColumnName;
            Value      = t_condition.Value;
            IsNull     = t_condition.IsNull;
        }
    }
}
