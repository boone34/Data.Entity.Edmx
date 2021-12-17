using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class ModificationFunctionMappingComplexProperty<TParent>
        where TParent: class
    {
        public TParent                                                                                                              Parent            { get; }
        public string                                                                                                               Name              { get; }
        public string                                                                                                               TypeName          { get; }
        public IReadOnlyCollection<ModificationFunctionMappingComplexProperty<ModificationFunctionMappingComplexProperty<TParent>>> ComplexProperties { get; }
        public IReadOnlyCollection<ModificationFunctionMappingScalarProperty<ModificationFunctionMappingComplexProperty<TParent>>>  ScalarProperties  { get; }

        internal ModificationFunctionMappingComplexProperty(TParent parent, TModificationFunctionMappingComplexProperty t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            Parent            = parent ?? throw new ArgumentNullException(nameof(parent));
            Name              = t.Name;
            TypeName          = t.TypeName;
            ComplexProperties = t.ComplexProperties.Select(cp => new ModificationFunctionMappingComplexProperty<ModificationFunctionMappingComplexProperty<TParent>>(this, cp)).ToList();
            ScalarProperties  = t.ScalarProperties.Select(sp => new ModificationFunctionMappingScalarProperty<ModificationFunctionMappingComplexProperty<TParent>>(this, sp)).ToList();
        }
    }
}
