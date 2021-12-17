using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class FunctionImportCondition
    {
        public FunctionImportEntityTypeMapping EntityTypeMapping { get; }
        public string                          ColumnName        { get; }
        public bool                            IsNull            { get; }
        public string                          Value             { get; }

        internal FunctionImportCondition(FunctionImportEntityTypeMapping entity_type_mapping, TFunctionImportCondition t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            EntityTypeMapping = entity_type_mapping ?? throw new ArgumentNullException(nameof(entity_type_mapping));
            ColumnName        = t.ColumnName;
            IsNull            = t.IsNull;
            Value             = t.Value;
        }
    }
}
