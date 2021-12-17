using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class OnAction : AnyDocumentation
    {
        public AssociationEnd AssociationEnd { get; }
        public TSsdlAction    Action         { get; }

        internal OnAction(AssociationEnd association_end, TSsdlOnAction t_ssdl_on_action) : base(t_ssdl_on_action.Any, t_ssdl_on_action.AnyAttr, t_ssdl_on_action.Documentation)
        {
            AssociationEnd = association_end ?? throw new ArgumentNullException(nameof(association_end));
            Action         = t_ssdl_on_action.Action;
        }
    }
}
