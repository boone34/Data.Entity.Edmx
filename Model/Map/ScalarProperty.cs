using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class ScalarProperty<TParent>
        where TParent: class
    {
        public TParent Parent { get; }
        public string  Name        { get; }
        public string  ColumnName  { get; }

        internal ScalarProperty(TParent parent, TScalarProperty t_scalar_property)
        {
            if (t_scalar_property == null) throw new ArgumentNullException(nameof(t_scalar_property));

            Parent     = parent ?? throw new ArgumentNullException(nameof(parent));
            Name       = t_scalar_property.Name;
            ColumnName = t_scalar_property.ColumnName;
        }
    }
}
