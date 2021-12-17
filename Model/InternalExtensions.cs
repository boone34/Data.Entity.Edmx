using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model
{
    internal static class InternalExtensions
    {
        public static Multiplicity ToMultiplicity(this TMultiplicity t_multiplicity)
        {
            switch (t_multiplicity)
            {
                case TMultiplicity.Item01:
                    return Multiplicity.ZeroOrOne;
                case TMultiplicity.Item1:
                    return Multiplicity.One;
                case TMultiplicity.Item:
                    return Multiplicity.ZeroOrMore;
                default:
                    throw new ArgumentOutOfRangeException(nameof(t_multiplicity), t_multiplicity, null);
            }
        }

	    public static string StripNamespace(this string name)
	    {
		    var parts = name.Split(new [] {'.'}, StringSplitOptions.RemoveEmptyEntries);
		    
		    return parts[parts.Length - 1];
	    }
    }
}
