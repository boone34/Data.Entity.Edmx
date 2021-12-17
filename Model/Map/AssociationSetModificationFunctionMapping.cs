using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class AssociationSetModificationFunctionMapping
    {
        public AssociationSetMapping              AssociationSetMapping { get; }
        public AssociationSetModificationFunction DeleteFunction { get; }
        public AssociationSetModificationFunction InsertFunction { get; }

        internal AssociationSetModificationFunctionMapping(AssociationSetMapping association_set_mapping, TAssociationSetModificationFunctionMapping t_association_set_modification_function_mapping)
        {
            if (t_association_set_modification_function_mapping == null) throw new ArgumentNullException(nameof(t_association_set_modification_function_mapping));

            AssociationSetMapping = association_set_mapping ?? throw new ArgumentNullException(nameof(association_set_mapping));
            DeleteFunction        = new AssociationSetModificationFunction(this, t_association_set_modification_function_mapping.DeleteFunction);
            InsertFunction        = new AssociationSetModificationFunction(this, t_association_set_modification_function_mapping.InsertFunction);
        }
    }
}
