using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TCsdlEntityProperty
    {
        private List<TCsdlDocumentation>                _Documentations;
        public  IReadOnlyCollection<TCsdlDocumentation> Documentations => _Documentations ??= Items.OfType<TCsdlDocumentation>().ToList();

        private List<TValueAnnotation>                _ValueAnnotations;
        public  IReadOnlyCollection<TValueAnnotation> ValueAnnotations => _ValueAnnotations ??= Items.OfType<TValueAnnotation>().ToList();

        private List<TTypeAnnotation>                _TypeAnnotations;
        public  IReadOnlyCollection<TTypeAnnotation> TypeAnnotations => _TypeAnnotations ??= Items.OfType<TTypeAnnotation>().ToList();
    }
}
