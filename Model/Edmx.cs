using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model
{
    public class Edmx
    {
        public string  Version { get; }
        public Runtime Runtime { get; }

        public Edmx(TEdmx edmx)
        {
            if (edmx == null) throw new ArgumentNullException(nameof(edmx));

            Version = edmx.Version;
            Runtime = new Runtime(this, edmx.Runtime);
        }

        public Edmx(string path) : this(TEdmx.LoadFromFile(path)) { }
    }
}
