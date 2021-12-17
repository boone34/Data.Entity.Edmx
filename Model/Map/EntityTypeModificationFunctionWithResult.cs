using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class EntityTypeModificationFunctionWithResult : EntityTypeModificationFunction
    {
        public IReadOnlyCollection<ResultBinding> ResultBindings { get; }

        internal EntityTypeModificationFunctionWithResult(EntityTypeModificationFunctionMapping modification_function_mapping, TEntityTypeModificationFunctionWithResult t) : base(modification_function_mapping, t)
        {
            ResultBindings = t.ResultBinding.Select(rb => new ResultBinding(this, rb)).ToList();
        }
    }
}
