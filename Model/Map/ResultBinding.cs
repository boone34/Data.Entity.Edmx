using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class ResultBinding
    {
        public EntityTypeModificationFunctionWithResult FunctionWithResult { get; }
        public string                                   Name               { get; }
        public string                                   ColumnName         { get; }

        internal ResultBinding(EntityTypeModificationFunctionWithResult function_with_result, TResultBinding t)
        {
            FunctionWithResult = function_with_result ?? throw new ArgumentNullException(nameof(function_with_result));
            Name               = t.Name;
            ColumnName         = t.ColumnName;
        }
    }
}
