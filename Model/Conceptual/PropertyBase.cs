using System;
using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class PropertyBase
    {
        public string           Name            { get; }
        public string           Type            { get; }
        public bool             Nullable        { get; }
        public string           DefaultValue    { get; }
        public string           MaxLength       { get; }
        public bool             FixedLength     { get; }
        public string           Precision       { get; }
        public string           Scale           { get; }
        public bool             Unicode         { get; }
        public string           Collation       { get; }
        public string           SRID            { get; }
        public TConcurrencyMode ConcurrencyMode { get; }
        public TAccess          SetterAccess    { get; }
        public TAccess          GetterAccess    { get; }

        private string _CsType;
        public  string CsType => _CsType ??= EdmsSimpleType.ToCsType(Type, Nullable);

        internal PropertyBase(TComplexTypeProperty t_complex_type_property)
        {
            if (t_complex_type_property == null) throw new ArgumentNullException(nameof(t_complex_type_property));

            Name            = t_complex_type_property.Name;
            Type            = t_complex_type_property.Type;
            Nullable        = t_complex_type_property.Nullable;
            DefaultValue    = t_complex_type_property.DefaultValue;
            MaxLength       = t_complex_type_property.MaxLength;
            FixedLength     = t_complex_type_property.FixedLength;
            Precision       = t_complex_type_property.Precision;
            Scale           = t_complex_type_property.Scale;
            Unicode         = t_complex_type_property.Unicode;
            Collation       = t_complex_type_property.Collation;
            SRID            = t_complex_type_property.SRID;
            ConcurrencyMode = t_complex_type_property.ConcurrencyMode;
            SetterAccess    = t_complex_type_property.SetterAccess;
            GetterAccess    = t_complex_type_property.GetterAccess;
        }

        internal PropertyBase(TCsdlEntityProperty t_entity_property)
        {
            if (t_entity_property == null) throw new ArgumentNullException(nameof(t_entity_property));

            Name            = t_entity_property.Name;
            Type            = t_entity_property.Type;
            Nullable        = t_entity_property.Nullable;
            DefaultValue    = t_entity_property.DefaultValue;
            MaxLength       = t_entity_property.MaxLength;
            FixedLength     = t_entity_property.FixedLength;
            Precision       = t_entity_property.Precision;
            Scale           = t_entity_property.Scale;
            Unicode         = t_entity_property.Unicode;
            Collation       = t_entity_property.Collation;
            SRID            = t_entity_property.SRID;
            ConcurrencyMode = t_entity_property.ConcurrencyMode;
            SetterAccess    = t_entity_property.SetterAccess;
            GetterAccess    = t_entity_property.GetterAccess;
        }
    }
}
