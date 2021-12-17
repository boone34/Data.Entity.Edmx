using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class FunctionImport : AnyDocumentation
    {
        public EntityContainer EntityContainer { get; }
        public string          Name            { get; }
        public bool            IsComposable    { get; }
        public bool            IsSideEffecting { get; }
        public bool            IsBindable      { get; }
        public TAccess         MethodAccess    { get; }

        internal FunctionImport(EntityContainer entity_container, TFunctionImport t_function_import) : base(t_function_import.Any, t_function_import.AnyAttr, t_function_import.Documentation)
        {
            EntityContainer = entity_container ?? throw new ArgumentNullException(nameof(entity_container));
            Name            = t_function_import.Name;
            IsComposable    = t_function_import.IsComposable;
            IsSideEffecting = t_function_import.IsSideEffecting;
            IsBindable      = t_function_import.IsBindable;
            MethodAccess    = t_function_import.MethodAccess;
        }
    }
}
