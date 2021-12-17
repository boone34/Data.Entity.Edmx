using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TCsdlEntityContainer
    {
        private List<TCsdlAssociationSet>                _AssociationSets;
        public  IReadOnlyCollection<TCsdlAssociationSet> AssociationSets => _AssociationSets ??= Items.OfType<TCsdlAssociationSet>().ToList();

        private List<TCsdlEntitySet>                _EntitySets;
        public  IReadOnlyCollection<TCsdlEntitySet> EntitySets => _EntitySets ??= Items.OfType<TCsdlEntitySet>().ToList();

        private List<TFunctionImport>                _FunctionImports;
        public  IReadOnlyCollection<TFunctionImport> FunctionImports => _FunctionImports ??= Items.OfType<TFunctionImport>().ToList();
    }
}
