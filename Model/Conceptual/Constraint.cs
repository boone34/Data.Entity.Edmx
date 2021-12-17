using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class Constraint : AnyDocumentation
    {
        public Association           Association { get; }
        public ConstraintRoleElement Principle   { get; }
        public ConstraintRoleElement Dependent   { get; }

        internal Constraint(Association association, TCsdlConstraint t_csdl_constraint) : base(t_csdl_constraint.Any, t_csdl_constraint.AnyAttr, t_csdl_constraint.Documentation)
        {
            Association = association ?? throw new ArgumentNullException(nameof(association));
            Principle   = new ConstraintRoleElement(this, t_csdl_constraint.Principal);
            Dependent   = new ConstraintRoleElement(this, t_csdl_constraint.Dependent);
        }
    }
}
