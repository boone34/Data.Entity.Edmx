using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TEntityContainerMapping
    {
        private List<TEntitySetMapping>                _EntitySetMappings;
		public  IReadOnlyCollection<TEntitySetMapping> EntitySetMappings => _EntitySetMappings ??= Items.OfType<TEntitySetMapping>().ToList();

        private List<TAssociationSetMapping>                _AssociationSetMappings;
		public  IReadOnlyCollection<TAssociationSetMapping> AssociationSetMappings => _AssociationSetMappings ??= Items.OfType<TAssociationSetMapping>().ToList();

        private List<TFunctionImportMapping>                _FunctionImportMapping;
		public  IReadOnlyCollection<TFunctionImportMapping> FunctionImportMapping => _FunctionImportMapping ??= Items.OfType<TFunctionImportMapping>().ToList();
    }
}
