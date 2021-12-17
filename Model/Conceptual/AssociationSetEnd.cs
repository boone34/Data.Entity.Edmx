using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class AssociationSetEnd
    {
        public AssociationSet                  AssociationSet { get; }
        public IReadOnlyCollection<XmlElement> AnyElements    { get; }
        public Documentation                   Documentation  { get; }
        public string                          Role           { get; }
        public string                          EntitySetName  { get; }

        private EntitySet _EntitySet;
        public  EntitySet EntitySet => _EntitySet ??= AssociationSet.EntityContainer.EntitySets.Single(es => es.Name == EntitySetName);

        internal AssociationSetEnd(AssociationSet association_set, TCsdlAssociationSetEnd t_csdl_association_set_end)
        {
            if (t_csdl_association_set_end == null) throw new ArgumentNullException(nameof(t_csdl_association_set_end));

            AssociationSet = association_set ?? throw new ArgumentNullException(nameof(association_set));
            AnyElements    = t_csdl_association_set_end.Any;
            Documentation  = new Documentation(t_csdl_association_set_end.Documentation);
            Role           = t_csdl_association_set_end.Role;
            EntitySetName  = t_csdl_association_set_end.EntitySet;
        }
    }
}
