using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class Schema : Any
    {
        public Runtime                          Runtime               { get; }
        public string                           Namespace             { get; }
        public string                           Alias                 { get; }
        public string                           Provider              { get; }
        public string                           ProviderManifestToken { get; }
        public EntityContainer                  EntityContainer       { get; }
        public IReadOnlyCollection<Association> Associations          { get; }
        public IReadOnlyCollection<EntityType>  EntityTypes           { get; }

        internal Schema(Runtime runtime, TSsdlSchema t_ssdl_schema) : base(t_ssdl_schema.Any, t_ssdl_schema.AnyAttr)
        {
            Runtime               = runtime ?? throw new ArgumentNullException(nameof(runtime));
            Namespace             = t_ssdl_schema.Namespace;
            Alias                 = t_ssdl_schema.Alias;
            Provider              = t_ssdl_schema.Provider;
            ProviderManifestToken = t_ssdl_schema.ProviderManifestToken;
            EntityContainer       = t_ssdl_schema.EntityContainer.Select(ec => new EntityContainer(this, ec)).Single();
            Associations          = t_ssdl_schema.Association.Select(a => new Association(this, a)).ToList();
            EntityTypes           = t_ssdl_schema.EntityType.Select(et => new EntityType(this, et)).ToList();
        }
    }
}
