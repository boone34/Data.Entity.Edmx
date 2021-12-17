using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class AssociationSetModificationFunction
    {
        public AssociationSetModificationFunctionMapping                   ModificationFunctionMapping { get; }
        public string                                                      FunctionName                { get; }
        public string                                                      RowsAffectedParameter       { get; }
        public IReadOnlyCollection<ModificationFunctionMappingEndProperty> EndProperties               { get; }

        internal AssociationSetModificationFunction(AssociationSetModificationFunctionMapping modification_function_mapping, TAssociationSetModificationFunction t_association_set_modification_function)
        {
            if (t_association_set_modification_function == null) throw new ArgumentNullException(nameof(t_association_set_modification_function));

            ModificationFunctionMapping = modification_function_mapping;
            FunctionName                = t_association_set_modification_function.FunctionName;
            RowsAffectedParameter       = t_association_set_modification_function.RowsAffectedParameter;
            EndProperties               = t_association_set_modification_function.Items.Select(ep => new ModificationFunctionMappingEndProperty(this, ep)).ToList();
        }
    }
}
