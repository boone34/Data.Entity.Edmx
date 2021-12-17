using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TComplexType
    {
		private List<TComplexTypeProperty>                _ComplexTypeProperties;
        public  IReadOnlyCollection<TComplexTypeProperty> ComplexTypeProperties => _ComplexTypeProperties ??= Items.OfType<TComplexTypeProperty>().ToList();

		private List<TValueAnnotation>                _ValueAnnotations;
        public  IReadOnlyCollection<TValueAnnotation> ValueAnnotations => _ValueAnnotations ??= Items.OfType<TValueAnnotation>().ToList();

		private List<TTypeAnnotation>                _TypeAnnotations;
        public  IReadOnlyCollection<TTypeAnnotation> TypeAnnotations => _TypeAnnotations ??= Items.OfType<TTypeAnnotation>().ToList();
    }
}
