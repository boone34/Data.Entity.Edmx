using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class MappingFragment<TParent>
        where TParent: class, IHaveRuntime
    {
        public TParent                                                        Parent                { get; }
        public string                                                         StorageEntitySetName  { get; }
        public bool                                                           MakeColumnsDistinct   { get; }
        public IReadOnlyCollection<ComplexProperty<MappingFragment<TParent>>> ComplexProperties     { get; }
        public IReadOnlyCollection<Condition<MappingFragment<TParent>>>       Conditions            { get; }
        public IReadOnlyCollection<ScalarProperty<MappingFragment<TParent>>>  ScalarProperties      { get; }

        private Storage.EntitySet _StorageEntitySet;
        public  Storage.EntitySet StorageEntitySet => _StorageEntitySet ??= Parent.Runtime.StorageSchema.EntityContainer.EntitySets.SingleOrDefault(es => es.Name == StorageEntitySetName);

        internal MappingFragment(TParent parent, TMappingFragment t)
        {
            Parent                = parent ?? throw new ArgumentNullException(nameof(parent));
            StorageEntitySetName  = t.StoreEntitySet;
            MakeColumnsDistinct   = t.MakeColumnsDistinct;
            ComplexProperties     = t.ComplexProperties.Select(cp => new ComplexProperty<MappingFragment<TParent>>(this, cp)).ToList();
            Conditions            = t.Conditions.Select(c => new Condition<MappingFragment<TParent>>(this, c)).ToList();
            ScalarProperties      = t.ScalarProperties.Select(cp => new ScalarProperty<MappingFragment<TParent>>(this, cp)).ToList();
        }
    }
}
