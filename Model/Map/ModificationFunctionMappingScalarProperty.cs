using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class ModificationFunctionMappingScalarProperty<TParent>
        where TParent: class
    {
        public TParent  Parent        { get; }
        public string   Name          { get; }
        public string   ParameterName { get; }
        public TVersion Version       { get; }

        internal ModificationFunctionMappingScalarProperty(TParent parent, TModificationFunctionMappingScalarProperty t_modification_function_mapping_scalar_property)
        {
            if (t_modification_function_mapping_scalar_property == null) throw new ArgumentNullException(nameof(t_modification_function_mapping_scalar_property));

            Parent        = parent ?? throw new ArgumentNullException(nameof(parent));
            Name          = t_modification_function_mapping_scalar_property.Name;
            ParameterName = t_modification_function_mapping_scalar_property.ParameterName;
            Version       = t_modification_function_mapping_scalar_property.Version;
        }
    }
}
