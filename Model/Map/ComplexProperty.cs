using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class ComplexProperty<TParent>
        where TParent: class
    {
        public TParent                                                        Parent            { get; }
        public string                                                         Name              { get; }
        public string                                                         TypeName          { get; }
        public bool                                                           IsPartial         { get; }
        public IReadOnlyCollection<ComplexProperty<ComplexProperty<TParent>>> ComplexProperties { get; }
        public IReadOnlyCollection<Condition<ComplexProperty<TParent>>>       Conditions        { get; }
        public IReadOnlyCollection<ScalarProperty<ComplexProperty<TParent>>>  ScalarProperties  { get; }

        internal ComplexProperty(TParent parent, TComplexProperty t_complex_property)
        {
            if (t_complex_property == null) throw new ArgumentNullException(nameof(t_complex_property));

            Parent            = parent ?? throw new ArgumentNullException(nameof(parent));
            Name              = t_complex_property.Name;
            TypeName          = t_complex_property.TypeName;
            IsPartial         = t_complex_property.IsPartial;
            ComplexProperties = t_complex_property.ComplexProperties.Select(cp => new ComplexProperty<ComplexProperty<TParent>>(this, cp)).ToList();
            Conditions        = t_complex_property.Conditions.Select(c => new Condition<ComplexProperty<TParent>>(this, c)).ToList();
            ScalarProperties  = t_complex_property.ScalarProperties.Select(sp => new ScalarProperty<ComplexProperty<TParent>>(this, sp)).ToList();
        }
    }
}
