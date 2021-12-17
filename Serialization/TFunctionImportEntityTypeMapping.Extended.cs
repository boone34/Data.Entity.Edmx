using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TFunctionImportEntityTypeMapping
    {
        private List<TFunctionImportCondition>                _Conditions;
		public  IReadOnlyCollection<TFunctionImportCondition> Conditions => _Conditions ??= Items.OfType<TFunctionImportCondition>().ToList();

        private List<TScalarProperty>                _ScalarProperties;
		public  IReadOnlyCollection<TScalarProperty> ScalarProperties => _ScalarProperties ??= Items.OfType<TScalarProperty>().ToList();
    }
}
