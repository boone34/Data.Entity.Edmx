using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class AssociationSetEnd
    {
        public AssociationSet                  AssociationSet { get; }
        public string                          Role           { get; }
        public string                          EntitySetName  { get; }
        public Documentation                   Documentation  { get; }
        public IReadOnlyCollection<XmlElement> AnyElements    { get; }

        private EntitySet _EntitySet;
        public  EntitySet EntitySet => _EntitySet ??= AssociationSet.EntityContainer.EntitySets.Single(es => es.Name == EntitySetName);

        public AssociationSetEnd(AssociationSet association_set, TSsdlAssociationSetEnd t_ssdl_association_set_end)
        {
            if (t_ssdl_association_set_end == null) throw new ArgumentNullException(nameof(t_ssdl_association_set_end));

            AssociationSet = association_set ?? throw new ArgumentNullException(nameof(association_set));
            Role           = t_ssdl_association_set_end.Role;
            EntitySetName  = t_ssdl_association_set_end.EntitySet;
            Documentation  = new Documentation(t_ssdl_association_set_end.Documentation);
            AnyElements    = t_ssdl_association_set_end.Any;
        }
    }
}
