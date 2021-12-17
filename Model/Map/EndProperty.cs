using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class EndProperty
    {
        public AssociationSetMapping                            AssociationSetMapping { get; }
        public string                                           Name                  { get; }
        public IReadOnlyCollection<ScalarProperty<EndProperty>> ScalarProperties      { get; }

        internal EndProperty(AssociationSetMapping association_set_mapping, TEndProperty t_end_property)
        {
            if (t_end_property == null) throw new ArgumentNullException(nameof(t_end_property));

            AssociationSetMapping = association_set_mapping ?? throw new ArgumentNullException(nameof(association_set_mapping));
            Name                  = t_end_property.Name;
            ScalarProperties      = t_end_property.ScalarProperty.Select(sp => new ScalarProperty<EndProperty>(this, sp)).ToList();
        }
    }
}
