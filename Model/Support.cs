using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TechNoir.Data.Entity.Edmx.Model
{
    public static class Support
    {
        public static string NullIfNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str) ? null : str;

        public static Dictionary<string, string> GetConfig(string path)
            =>
        File
        .ReadAllLines(path)
        .Select(l => l.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries))
        .Select(p => new { Name = p.Length > 0 ? p[0].Trim().NullIfNullOrWhiteSpace() : null, Value = p.Length > 1 ? p[1].Trim().NullIfNullOrWhiteSpace() : null })
        .Where(x => x.Name != null)
        .ToDictionary(x => x.Name, x => x.Value)
        ;
    }
}
