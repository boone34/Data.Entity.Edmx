using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model
{
    public class Runtime
    {
        public Edmx              Edmx             { get; }
        public Conceptual.Schema ConceptualSchema { get; }
        public Storage.Schema    StorageSchema    { get; }
        public Map.Mapping       Mapping          { get; }

        internal Runtime(Edmx edmx, TRuntime t_runtime)
        {
            Edmx             = edmx ?? throw new ArgumentNullException(nameof(edmx));
            ConceptualSchema = new Conceptual.Schema(this, t_runtime.ConceptualModels.Schema);
            StorageSchema    = new Storage.Schema(this, t_runtime.StorageModels.Schema);
            Mapping          = new Map.Mapping(this, t_runtime.Mappings.Mapping);
        }
    }
}
