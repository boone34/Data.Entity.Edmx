using System;
using System.Collections.Generic;
using System.Linq;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Map
{
    public class Mapping
    {
        public Runtime                    Runtime                { get; }
        public TSpace                     Space                  { get; }
        public Dictionary<string, string> Aliases                { get; }
        public EntityContainerMapping     EntityContainerMapping { get; }

        internal Mapping(Runtime runtime, TMapping t_mapping)
        {
            if (t_mapping == null) throw new ArgumentNullException(nameof(t_mapping));

            Runtime                = runtime ?? throw new ArgumentNullException(nameof(runtime));
            Space                  = t_mapping.Space;
            Aliases                = t_mapping.Alias.ToDictionary(a => a.Key, a => a.Value);
            EntityContainerMapping = new EntityContainerMapping(this, t_mapping.EntityContainerMapping);
        }
    }
}
