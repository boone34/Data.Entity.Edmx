using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TCsdlEntityType
    {
        private List<TCsdlEntityProperty>                _Properties;
        public  IReadOnlyCollection<TCsdlEntityProperty> Properties => _Properties ??= Items.OfType<TCsdlEntityProperty>().ToList();

        private List<TNavigationProperty>                _NavigationProperties;
		public  IReadOnlyCollection<TNavigationProperty> NavigationProperties => _NavigationProperties ??= Items.OfType<TNavigationProperty>().ToList();

        private List<TValueAnnotation>                 _ValueAnnotations;
		public  IReadOnlyCollection<TValueAnnotation>  ValueAnnotations => _ValueAnnotations ??= Items.OfType<TValueAnnotation>().ToList();

        private List<TTypeAnnotation>                _TypeAnnotations;
		public  IReadOnlyCollection<TTypeAnnotation> TypeAnnotations => _TypeAnnotations ??= Items.OfType<TTypeAnnotation>().ToList();
    }
}
