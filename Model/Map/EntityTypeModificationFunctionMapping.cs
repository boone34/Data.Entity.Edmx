using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class EntityTypeModificationFunctionMapping
    {
        public EntityTypeMapping                        EntityTypeMapping { get; }
        public EntityTypeModificationFunction           DeleteFunction    { get; }
        public EntityTypeModificationFunctionWithResult InsertFunction    { get; }
        public EntityTypeModificationFunctionWithResult UpdateFunction    { get; }

        internal EntityTypeModificationFunctionMapping(EntityTypeMapping entity_type_mapping, TEntityTypeModificationFunctionMapping t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            EntityTypeMapping = entity_type_mapping ?? throw new ArgumentNullException(nameof(entity_type_mapping));
            DeleteFunction    = new EntityTypeModificationFunction(this, t.DeleteFunction);
            InsertFunction    = new EntityTypeModificationFunctionWithResult(this, t.InsertFunction);
            UpdateFunction    = new EntityTypeModificationFunctionWithResult(this, t.UpdateFunction);
        }
    }
}
