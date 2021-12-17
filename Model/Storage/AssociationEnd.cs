using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class AssociationEnd : AnyDocumentation
    {
        public Association                   Association  { get; }
        public string                        Type         { get; }
        public string                        Role         { get; }
        public Multiplicity                  Multiplicity { get; }
        public IReadOnlyCollection<OnAction> OnDeletes    { get; }

        internal AssociationEnd(Association association, TSsdlAssociationEnd t_ssdl_association_end) : base(t_ssdl_association_end.Any, t_ssdl_association_end.AnyAttr, t_ssdl_association_end.Documentation)
        {
            Association  = association ?? throw new ArgumentNullException(nameof(association));
            Type         = t_ssdl_association_end.Type;
            Role         = t_ssdl_association_end.Role;
            Multiplicity = t_ssdl_association_end.Multiplicity.ToMultiplicity();
            OnDeletes    = t_ssdl_association_end.OnDelete.Select(od => new OnAction(this, od)).ToList();
        }
    }
}
