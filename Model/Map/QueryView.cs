using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class QueryView
    {
        public EntitySetMapping EntitySetMapping { get; }
        public string           TypeName         { get; }
        public string           Value            { get; }

        internal QueryView(EntitySetMapping entity_set_mapping, TQueryView t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            EntitySetMapping = entity_set_mapping ?? throw new ArgumentNullException(nameof(entity_set_mapping));
            TypeName         = t.TypeName;
            Value            = t.Value;
        }
    }
}
