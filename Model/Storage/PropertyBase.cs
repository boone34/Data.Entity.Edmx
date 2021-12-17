using TechNoir.Data.Entity.Edmx.Serialization;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    public class PropertyBase : AnyDocumentation
    {
        public string Name         { get; }
        public string Type         { get; }
        public bool   Nullable     { get; }
        public string DefaultValue { get; }
        public string MaxLength    { get; }
        public bool   FixedLength  { get; }
        public string Precision    { get; }
        public string Scale        { get; }
        public bool   Unicode      { get; }
        public string Collation    { get; }
        public string SRID         { get; }

        private string _CsType;
        public  string CsType => _CsType ??= SqlSimpleType.ToCsType(Type, Nullable);

        internal PropertyBase(TSsdlEntityProperty t_ssdl_entity_property) : base(t_ssdl_entity_property.Any, t_ssdl_entity_property.AnyAttr, t_ssdl_entity_property.Documentation)
        {
            Name         = t_ssdl_entity_property.Name;
            Type         = t_ssdl_entity_property.Type;
            Nullable     = t_ssdl_entity_property.Nullable;
            DefaultValue = t_ssdl_entity_property.DefaultValue;
            MaxLength    = t_ssdl_entity_property.MaxLength;
            FixedLength  = t_ssdl_entity_property.FixedLength;
            Precision    = t_ssdl_entity_property.Precision;
            Scale        = t_ssdl_entity_property.Scale;
            Unicode      = t_ssdl_entity_property.Unicode;
            Collation    = t_ssdl_entity_property.Collation;
            SRID         = t_ssdl_entity_property.SRID;
        }
    }
}
