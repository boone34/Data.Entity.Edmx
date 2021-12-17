using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class Using : AnyDocumentation
    {
        public Schema Schema        { get; }
        public string Namespace     { get; }
        public string NamespaceUri  { get; }
        public string Alias         { get; }

        internal Using(Schema schema, TUsing t_using) : base(t_using.Any, t_using.AnyAttr, t_using.Documentation)
        {
            if (t_using == null) throw new ArgumentNullException(nameof(t_using));

            Schema        = schema ?? throw new ArgumentNullException(nameof(schema));
            Namespace     = t_using.Namespace;
            NamespaceUri  = t_using.NamespaceUri;
            Alias         = t_using.Alias;
        }
    }
}
