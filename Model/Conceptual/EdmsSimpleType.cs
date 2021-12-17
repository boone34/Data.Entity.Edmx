using System;

namespace TechNoir.Data.Entity.Edmx.Model.Conceptual
{
    public class EdmsSimpleType
    {
        public enum Types
        {
            Binary,
            Boolean,
            Byte,
            DateTime,
            DateTimeOffset,
            Time,
            Decimal,
            Double,
            Single,
            Geography,
            Point,
            LineString,
            Polygon,
            MultiPoint,
            MultiLineString,
            MultiPolygon,
            GeographyCollection,
            Geometry,
            GeometricPoint,
            GeometricLineString,
            GeometricPolygon,
            GeometricMultiPoint,
            GeometricMultiLineString,
            GeometricMultiPolygon,
            GeometryCollection,
            Guid,
            Int16,
            Int32,
            Int64,
            String,
            SByte
        }

        public static string ToCsType(Types type, bool nullable)
        {
            var cs_type
                =
            type switch
            {
                Types.Binary         => "byte []",
                Types.Boolean        => "bool",
                Types.Byte           => "byte",
                Types.DateTime       => "DateTime",
                Types.DateTimeOffset => "DateTimeOffset",
                Types.Time           => "TimeSpan",
                Types.Decimal        => "decimal",
                Types.Double         => "double",
                Types.Single         => "float",
                Types.Geography      => "Geometry",
                Types.Point          => "Geometry",
                //case Types.LineString:
                //    break;
                //case Types.Polygon:
                //    break;
                //case Types.MultiPoint:
                //    break;
                //case Types.MultiLineString:
                //    break;
                //case Types.MultiPolygon:
                //    break;
                //case Types.GeographyCollection:
                //    break;
                //case Types.Geometry:
                //    break;
                //case Types.GeometricPoint:
                //    break;
                //case Types.GeometricLineString:
                //    break;
                //case Types.GeometricPolygon:
                //    break;
                //case Types.GeometricMultiPoint:
                //    break;
                //case Types.GeometricMultiLineString:
                //    break;
                //case Types.GeometricMultiPolygon:
                //    break;
                //case Types.GeometryCollection:
                //    break;
                Types.Guid           => "Guid",
                Types.Int16          => "short",
                Types.Int32          => "int",
                Types.Int64          => "long",
                Types.String         => "string",
                Types.SByte          => "sbyte",
                _                    => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            }
            ;

            return type is Types.String or Types.Binary or Types.Geography ? cs_type : nullable ? $"{cs_type}?" : cs_type;
        }

        public static string ToCsType(string edms_type, bool nullable) => ToCsType((Types)Enum.Parse(typeof(Types), edms_type), nullable);
    }
}
