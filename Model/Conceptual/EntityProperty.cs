using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class EntityProperty : PropertyBase
    {
        public EntityType                         EntityType            { get; }
        public TStoreGeneratedPattern             StoreGeneratedPattern { get; }
        public IReadOnlyCollection<Documentation> Documentations        { get; }

        private string _ColumnName;
        public  string ColumnName
            =>
        _ColumnName
            ??=
        EntityType
        .EntitySet
        .EntitySetMapping
        .EntityTypeMappings
        .SelectMany(etm => etm.MappingFragments.SelectMany(mp => mp.ScalarProperties))
        .Single(sp => sp.Name == Name)
        .ColumnName
        ;

        private bool? _IsKey;
        public  bool  IsKey => _IsKey ??= EntityType.KeyProperties.Any(kp => kp.Name == Name);

        internal EntityProperty(EntityType entity_type, TCsdlEntityProperty t_csdl_entity_property) : base(t_csdl_entity_property)
        {
            EntityType            = entity_type ?? throw new ArgumentNullException(nameof(entity_type));
            StoreGeneratedPattern = t_csdl_entity_property.StoreGeneratedPattern;
            Documentations        = t_csdl_entity_property.Documentations.Select(td => new Documentation(td)).ToList();
        }
    }
}
