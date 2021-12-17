using System;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class NavigationProperty : AnyDocumentation
    {
        public EntityType EntityType { get; }
        public string     Name;
        public string     Relationship;
        public string     FromRole;
        public string     ToRole;
        public TAccess    GetterAccess;
        public TAccess    SetterAccess;

        private Association _Association;
        public  Association Association => _Association ??= EntityType.Schema.Associations.Single(a => a.Name == Relationship.StripNamespace());

        private AssociationEnd _FromEnd;
        public  AssociationEnd FromEnd => _FromEnd ??= Association.Ends.Single(e => e.Role == FromRole);

        private AssociationEnd _ToEnd;
        public  AssociationEnd ToEnd => _ToEnd ??= Association.Ends.Single(e => e.Role == ToRole);

        private bool? _IsPrinciple;
        public  bool  IsPrinciple => _IsPrinciple ??= Association.Constraint.Principle.Role == FromRole;

        internal NavigationProperty(EntityType entity_type, TNavigationProperty t_navigation_property) : base(t_navigation_property.Any, t_navigation_property.AnyAttr, t_navigation_property.Documentation)
        {
            EntityType   = entity_type ?? throw new ArgumentNullException(nameof(entity_type));
            Name         = t_navigation_property.Name;
            Relationship = t_navigation_property.Relationship;
            FromRole     = t_navigation_property.FromRole;
            ToRole       = t_navigation_property.ToRole;
            GetterAccess = t_navigation_property.GetterAccess;
            SetterAccess = t_navigation_property.SetterAccess;
        }
    }
}
