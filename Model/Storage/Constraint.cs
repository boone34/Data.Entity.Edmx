using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class Constraint : AnyDocumentation
    {
        public Association           Association { get; }
        public ConstraintRoleElement Principal   { get; }
        public ConstraintRoleElement Dependent   { get; }

        internal Constraint(Association association, TSsdlConstraint t_ssdl_constraint) : base(t_ssdl_constraint.Any, t_ssdl_constraint.AnyAttr, t_ssdl_constraint.Documentation)
        {
            Association = association ?? throw new ArgumentNullException(nameof(association));
            Principal   = new ConstraintRoleElement(this, t_ssdl_constraint.Principal);
            Dependent   = new ConstraintRoleElement(this, t_ssdl_constraint.Dependent);
        }
    }
}
