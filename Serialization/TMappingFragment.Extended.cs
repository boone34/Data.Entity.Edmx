using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TMappingFragment
    {
        private List<TComplexProperty>                _ComplexProperties;
		public  IReadOnlyCollection<TComplexProperty> ComplexProperties => _ComplexProperties ??= Items.OfType<TComplexProperty>().ToList();

        private List<TCondition>                _Conditions;
		public  IReadOnlyCollection<TCondition> Conditions => _Conditions ??= Items.OfType<TCondition>().ToList();

        private List<TScalarProperty>                _ScalarProperties;
		public  IReadOnlyCollection<TScalarProperty> ScalarProperties  => _ScalarProperties ??= Items.OfType<TScalarProperty>().ToList();
    }
}
