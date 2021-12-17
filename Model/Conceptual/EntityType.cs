using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class EntityType : AnyDocumentation
    {
        public Schema                                  Schema               { get; }
        public string                                  Name                 { get; }
        public string                                  BaseType             { get; }
        public bool                                    Abstract             { get; }
        public bool                                    OpenType             { get; }
        public IReadOnlyCollection<EntityProperty>     Properties           { get; }
        public IReadOnlyCollection<EntityProperty>     KeyProperties        { get; }
        public IReadOnlyCollection<NavigationProperty> NavigationProperties { get; }

        private IReadOnlyCollection<NavigationProperty> _ParentProperties;
        public  IReadOnlyCollection<NavigationProperty> ParentProperties
            =>
        _ParentProperties
            ??=
        NavigationProperties
        .Where(np => !np.IsPrinciple && np.ToEnd.Multiplicity != Multiplicity.ZeroOrMore)
        .ToList()
        ;

        private IReadOnlyCollection<NavigationProperty> _ChildProperties;
        public  IReadOnlyCollection<NavigationProperty> ChildProperties
            =>
        _ChildProperties
            ??=
        NavigationProperties
        .Where(np => np.IsPrinciple && np.ToEnd.Multiplicity != Multiplicity.ZeroOrMore)
        .ToList()
        ;

        private IReadOnlyCollection<NavigationProperty> _ChildCollections;
        public  IReadOnlyCollection<NavigationProperty> ChildCollections
            =>
        _ChildCollections
            ??=
        NavigationProperties
        .Where(np => np.IsPrinciple && np.ToEnd.Multiplicity == Multiplicity.ZeroOrMore)
        .ToList()
        ;

        private IReadOnlyCollection<NavigationProperty> _ManyToManyCollections;
        public  IReadOnlyCollection<NavigationProperty> ManyToManyCollections
            =>
        _ManyToManyCollections
            ??=
        NavigationProperties
        .Where(np => !np.IsPrinciple && np.FromEnd.Multiplicity == Multiplicity.ZeroOrMore && np.ToEnd.Multiplicity == Multiplicity.ZeroOrMore)
        .ToList()
        ;

        private EntitySet _EntitySet;
        public  EntitySet EntitySet => _EntitySet ??= Schema.EntityContainer.EntitySets.Single(es => es.EntityTypeName.StripNamespace() == Name);

        internal EntityType(Schema schema, TCsdlEntityType t_entity_type) : base(t_entity_type.Any, t_entity_type.AnyAttr, t_entity_type.Documentation)
        {
            if (t_entity_type == null) throw new ArgumentNullException(nameof(t_entity_type));

            Schema               = schema ?? throw new ArgumentNullException(nameof(schema));
            Name                 = t_entity_type.Name;
            BaseType             = t_entity_type.BaseType;
            Abstract             = t_entity_type.Abstract;
            OpenType             = t_entity_type.OpenType;
            Properties           = t_entity_type.Properties.Select(p => new EntityProperty(this, p)).ToList();
            KeyProperties        = Properties.Where(p => t_entity_type.Key.PropertyRef.Any(pr => pr.Name == p.Name)).ToList();
            NavigationProperties = t_entity_type.NavigationProperties.Select(np => new NavigationProperty(this, np)).ToList();
        }
    }
}
