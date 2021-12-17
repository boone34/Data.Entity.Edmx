using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class OnAction : AnyDocumentation
    {
        public AssociationEnd AssociationEnd { get; }
        public TCsdlAction    Action         { get; }

        internal OnAction(AssociationEnd association_end, TCsdlOnAction t_csdl_on_action) : base(t_csdl_on_action.Any, t_csdl_on_action.AnyAttr, t_csdl_on_action.Documentation)
        {
            AssociationEnd = association_end ?? throw new ArgumentNullException(nameof(association_end));
            Action         = t_csdl_on_action.Action;
        }
    }
}
