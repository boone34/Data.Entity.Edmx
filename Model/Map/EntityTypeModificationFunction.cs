using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class EntityTypeModificationFunction
    {
        public EntityTypeModificationFunctionMapping                                                           ModificationFunctionMapping { get; }
        public string                                                                                          FunctionName                { get; }
        public string                                                                                          RowsAffectedParameter       { get; }
        public IReadOnlyCollection<ModificationFunctionMappingAssociationEnd>                                  AssociationEnds             { get; }
        public IReadOnlyCollection<ModificationFunctionMappingComplexProperty<EntityTypeModificationFunction>> ComplexProperties           { get; }
        public IReadOnlyCollection<ModificationFunctionMappingScalarProperty<EntityTypeModificationFunction>>  ScalarProperties            { get; }

        internal EntityTypeModificationFunction(EntityTypeModificationFunctionMapping modification_function_mapping, TEntityTypeModificationFunction t)
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            ModificationFunctionMapping = modification_function_mapping ?? throw new ArgumentNullException(nameof(modification_function_mapping));
            FunctionName                = t.FunctionName;
            RowsAffectedParameter       = t.RowsAffectedParameter;
            AssociationEnds             = t.AssociationEnds.Select(ae => new ModificationFunctionMappingAssociationEnd(this, ae)).ToList();
            ComplexProperties           = t.ComplexProperties.Select(cp => new ModificationFunctionMappingComplexProperty<EntityTypeModificationFunction>(this, cp)).ToList();
            ScalarProperties            = t.ScalarProperties.Select(sp => new ModificationFunctionMappingScalarProperty<EntityTypeModificationFunction>(this, sp)).ToList();
        }
    }
}
