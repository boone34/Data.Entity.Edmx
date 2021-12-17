using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class ConstraintRoleElement
    {
        public Constraint                                              Constraint   { get; }
        public IReadOnlyCollection<PropertyRef<ConstraintRoleElement>> PropertyRefs { get; }
        public IReadOnlyCollection<XmlElement>                         AnyElements  { get; }
        public string                                                  Role         { get; }

        internal ConstraintRoleElement(Constraint constraint, TCsdlReferentialConstraintRoleElement t_csdl_referential_constraint_role_element)
        {
            if (t_csdl_referential_constraint_role_element == null) throw new ArgumentNullException(nameof(t_csdl_referential_constraint_role_element));

            Constraint   = constraint ?? throw new ArgumentNullException(nameof(constraint));
            PropertyRefs = t_csdl_referential_constraint_role_element.PropertyRef.Select(pr => new PropertyRef<ConstraintRoleElement>(this, pr)).ToList();
            AnyElements  = t_csdl_referential_constraint_role_element.Any;
            Role         = t_csdl_referential_constraint_role_element.Role;
        }
    }
}
