using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class ModificationFunctionMappingEndProperty
    {
        public AssociationSetModificationFunction                                                                     ModificationFunction { get; }
        public string                                                                                                 Name                 { get; }
        public IReadOnlyCollection<ModificationFunctionMappingScalarProperty<ModificationFunctionMappingEndProperty>> ScalarProperties     { get; }

        internal ModificationFunctionMappingEndProperty(AssociationSetModificationFunction modification_function, TModificationFunctionMappingEndProperty t_modification_function_mapping_end_property)
        {
            if (t_modification_function_mapping_end_property == null) throw new ArgumentNullException(nameof(t_modification_function_mapping_end_property));

            ModificationFunction = modification_function ?? throw new ArgumentNullException(nameof(modification_function));
            Name                 = t_modification_function_mapping_end_property.Name;
            ScalarProperties     = t_modification_function_mapping_end_property.ScalarProperty.Select(sp => new ModificationFunctionMappingScalarProperty<ModificationFunctionMappingEndProperty>(this, sp)).ToList();
        }
    }
}
