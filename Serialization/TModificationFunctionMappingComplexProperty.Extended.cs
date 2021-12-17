using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TModificationFunctionMappingComplexProperty
    {
        private List<TModificationFunctionMappingComplexProperty>                _ComplexProperties;
		public  IReadOnlyCollection<TModificationFunctionMappingComplexProperty> ComplexProperties => _ComplexProperties ??= Items.OfType<TModificationFunctionMappingComplexProperty>().ToList();

        private List<TModificationFunctionMappingScalarProperty>                _ScalarProperties;
		public  IReadOnlyCollection<TModificationFunctionMappingScalarProperty> ScalarProperties => _ScalarProperties ??= Items.OfType<TModificationFunctionMappingScalarProperty>().ToList();
    }
}
