using System.Collections.Generic;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Serialization
{
    public partial class TCsdlFunction
    {
		private List<TFunctionParameter>                _FunctionParameters;
        public  IReadOnlyCollection<TFunctionParameter> FunctionParameters => _FunctionParameters ??= Items.OfType<TFunctionParameter>().ToList();
    }
}
