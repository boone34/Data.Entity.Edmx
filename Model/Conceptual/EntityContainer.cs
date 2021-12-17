using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class EntityContainer
    {
        public Schema                              Schema             { get; }
        public IReadOnlyCollection<XmlAttribute>   AnyAttributes      { get; }
        public Documentation                       Documentation      { get; }
        public string                              Name               { get; }
        public string                              Extends            { get; }
        public TPublicOrInternalAccess             TypeAccess         { get; }
        public bool                                LazyLoadingEnabled { get; }
        public IReadOnlyCollection<AssociationSet> AssociationSets    { get; }
        public IReadOnlyCollection<EntitySet>      EntitySets         { get; }
        public IReadOnlyCollection<FunctionImport> FunctionImports    { get; }

        internal EntityContainer(Schema schema, TCsdlEntityContainer t_csdl_entity_container)
        {
            if (t_csdl_entity_container == null) throw new ArgumentNullException(nameof(t_csdl_entity_container));

            Schema             = schema ?? throw new ArgumentNullException(nameof(schema));
            AnyAttributes      = t_csdl_entity_container.AnyAttr;
            Documentation      = new Documentation(t_csdl_entity_container.Documentation);
            Name               = t_csdl_entity_container.Name;
            Extends            = t_csdl_entity_container.Extends;
            TypeAccess         = t_csdl_entity_container.TypeAccess;
            LazyLoadingEnabled = t_csdl_entity_container.LazyLoadingEnabled;
            AssociationSets    = t_csdl_entity_container.AssociationSets.Select(a_s => new AssociationSet(this, a_s)).ToList();
            EntitySets         = t_csdl_entity_container.EntitySets.Select(es => new EntitySet(this, es)).ToList();
            FunctionImports    = t_csdl_entity_container.FunctionImports.Select(fi => new FunctionImport(this, fi)).ToList();
        }
    }
}
