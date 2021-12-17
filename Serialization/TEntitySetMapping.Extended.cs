using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TEntitySetMapping
    {
        private List<TComplexProperty>                _ComplexProperties;
		public  IReadOnlyCollection<TComplexProperty> ComplexProperties => _ComplexProperties ??= Items.OfType<TComplexProperty>().ToList();

        private List<TCondition>                _Conditions;
		public  IReadOnlyCollection<TCondition> Conditions => _Conditions ??= Items.OfType<TCondition>().ToList();

        private List<TEntityTypeMapping>                _EntityTypeMappings;
		public  IReadOnlyCollection<TEntityTypeMapping> EntityTypeMappings => _EntityTypeMappings ??= Items.OfType<TEntityTypeMapping>().ToList();

        private List<TMappingFragment>                  _MappingFragments;
		public  IReadOnlyCollection<TMappingFragment>   MappingFragments => _MappingFragments ??= Items.OfType<TMappingFragment>().ToList();

        private List<TQueryView>                _QueryViews;
		public  IReadOnlyCollection<TQueryView> QueryViews => _QueryViews ??= Items.OfType<TQueryView>().ToList();

        private List<TScalarProperty>                _ScalarProperties;
		public  IReadOnlyCollection<TScalarProperty> ScalarProperties   => _ScalarProperties ??= Items.OfType<TScalarProperty>().ToList();
    }
}
