using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Model.Conceptual;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class ConstraintRoleElement : AnyDocumentation
    {
        public Constraint                                                         Constraint   { get; }
        public string                                                             Role         { get; }
        public IReadOnlyCollection<PropertyRef<ConstraintRoleElement>> PropertyRefs { get; }

        internal ConstraintRoleElement(Constraint constraint, TSsdlReferentialConstraintRoleElement t_ssdl_referential_constraint_role_element)
            :
        base(t_ssdl_referential_constraint_role_element.Any, t_ssdl_referential_constraint_role_element.AnyAttr, t_ssdl_referential_constraint_role_element.Documentation)
        {
            Constraint   = constraint ?? throw new ArgumentNullException(nameof(constraint));
            Role         = t_ssdl_referential_constraint_role_element.Role;
            PropertyRefs = t_ssdl_referential_constraint_role_element.PropertyRef.Select(pr => new PropertyRef<ConstraintRoleElement>(this, pr)).ToList();
        }
    }
}
