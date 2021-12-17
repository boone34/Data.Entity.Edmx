using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TSsdlEntityContainer
    {
        private List<TSsdlAssociationSet>                _AssociationSets;
        public  IReadOnlyCollection<TSsdlAssociationSet> AssociationSets => _AssociationSets ??= Items.OfType<TSsdlAssociationSet>().ToList();

        private List<TSsdlEntitySet>                _EntitySets;
        public  IReadOnlyCollection<TSsdlEntitySet> EntitySets => _EntitySets ??= Items.OfType<TSsdlEntitySet>().ToList();
    }
}
