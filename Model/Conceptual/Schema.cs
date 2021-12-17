using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class Schema : Any
    {
        public Runtime                          Runtime         { get; }
        public IReadOnlyCollection<Using>       Usings          { get; }
        public IReadOnlyCollection<Association> Associations    { get; }
        public IReadOnlyCollection<ComplexType> ComplexTypes    { get; }
        public IReadOnlyCollection<EntityType>  EntityTypes     { get; }
        public EntityContainer                  EntityContainer { get; }

        internal Schema(Runtime runtime, TCsdlSchema t_csdl_schema) : base(t_csdl_schema.Any, t_csdl_schema.AnyAttr)
        {
            if (t_csdl_schema == null) throw new ArgumentNullException(nameof(t_csdl_schema));

            Runtime         = runtime ?? throw new ArgumentNullException(nameof(runtime));
            Usings          = t_csdl_schema.Using.Select(tu => new Using(this, tu)).ToList();
            Associations    = t_csdl_schema.Association.Select(ta => new Association(this, ta)).ToList();
            ComplexTypes    = t_csdl_schema.ComplexType.Select(ct => new ComplexType(this, ct)).ToList();
            EntityTypes     = t_csdl_schema.EntityType.Select(et => new EntityType(this, et)).ToList();
            EntityContainer = t_csdl_schema.EntityContainer.Select(ec => new EntityContainer(this, ec)).Single();
        }
    }
}
