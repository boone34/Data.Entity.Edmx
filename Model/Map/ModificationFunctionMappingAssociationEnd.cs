using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class ModificationFunctionMappingAssociationEnd
    {
        public EntityTypeModificationFunction                                                                            EntityTypeModificationFunction { get; }
        public string                                                                                                    AssociationSetName             { get; }
        public string                                                                                                    FromRole                       { get; }
        public string                                                                                                    ToRole                         { get; }
        public IReadOnlyCollection<ModificationFunctionMappingScalarProperty<ModificationFunctionMappingAssociationEnd>> ScalarProperties               { get; }

        internal ModificationFunctionMappingAssociationEnd(EntityTypeModificationFunction entity_type_modification_function, TModificationFunctionMappingAssociationEnd t_modification_function_mapping_association_end)
        {
            EntityTypeModificationFunction = entity_type_modification_function ?? throw new ArgumentNullException(nameof(entity_type_modification_function));
            AssociationSetName             = t_modification_function_mapping_association_end.AssociationSet;
            FromRole                       = t_modification_function_mapping_association_end.From;
            ToRole                         = t_modification_function_mapping_association_end.To;
            ScalarProperties               = t_modification_function_mapping_association_end.ScalarProperty.Select(sp => new ModificationFunctionMappingScalarProperty<ModificationFunctionMappingAssociationEnd>(this, sp)).ToList();
        }
    }
}
