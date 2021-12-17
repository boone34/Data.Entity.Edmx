using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class AssociationSetMapping
    {
        public EntityContainerMapping                                EntityContainerMapping       { get; }
        public string                                                ConceptualAssociationSetName { get; }
        public string                                                ConceptualAssociationName    { get; }
        public string                                                StorageEntitySetName         { get; }
        public string                                                QueryView                    { get; }
        public AssociationSetModificationFunctionMapping             ModificationFunctionMapping  { get; }
        public IReadOnlyCollection<Condition<AssociationSetMapping>> Conditions                   { get; }
        public IReadOnlyCollection<EndProperty>                      EndProperties                { get; }

        private Conceptual.AssociationSet _ConceptualAssociationSet;
        public  Conceptual.AssociationSet ConceptualAssociationSet => _ConceptualAssociationSet ??= EntityContainerMapping.Mapping.Runtime.ConceptualSchema.EntityContainer.AssociationSets.Single(a_s => a_s.Name == ConceptualAssociationSetName);

        private Conceptual.Association _ConceptualAssociation;
        public  Conceptual.Association ConceptualAssociation => _ConceptualAssociation ??= EntityContainerMapping.Mapping.Runtime.ConceptualSchema.Associations.Single(a => a.Name == ConceptualAssociationName.StripNamespace());

        private Storage.EntitySet _StorageEntitySet;
        public  Storage.EntitySet StorageEntitySet => _StorageEntitySet ??= EntityContainerMapping.Mapping.Runtime.StorageSchema.EntityContainer.EntitySets.Single(es => es.Name == StorageEntitySetName);

        internal AssociationSetMapping(EntityContainerMapping entity_container_mapping, TAssociationSetMapping t_association_set_mapping)
        {
            if (t_association_set_mapping == null) throw new ArgumentNullException(nameof(t_association_set_mapping));

            EntityContainerMapping       = entity_container_mapping ?? throw new ArgumentNullException(nameof(entity_container_mapping));
            ConceptualAssociationSetName = t_association_set_mapping.Name;
            ConceptualAssociationName    = t_association_set_mapping.TypeName;
            StorageEntitySetName         = t_association_set_mapping.StoreEntitySet;
            QueryView                    = t_association_set_mapping.QueryView;
            ModificationFunctionMapping  = new AssociationSetModificationFunctionMapping(this, t_association_set_mapping.ModificationFunctionMapping);
            Conditions                   = t_association_set_mapping.Condition.Select(c => new Condition<AssociationSetMapping>(this, c)).ToList();
            EndProperties                = t_association_set_mapping.EndProperty.Select(ep => new EndProperty(this, ep)).ToList();
        }
    }
}
