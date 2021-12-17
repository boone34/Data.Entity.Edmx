using System;

namespace TechNoir.Data.Entity.Edmx.Model.Storage
{
    internal class SqlSimpleType
    {
        public static string ToCsType(string sql_type, bool nullable)
        {
            if (sql_type == null) throw new ArgumentNullException(nameof(sql_type));

            string cs_type = null;

            switch (sql_type.ToLower())
            {
                case "bigint":
                    cs_type = "long";
                    break;
				case "binary":
				case "varbinary":
				case "image":
					cs_type = "byte []";
					break;
				case "bit":
					cs_type = "bool";
					break;
				case "char":
				case "nchar":
				case "ntext":
				case "nvarchar":
				case "text":
				case "varchar":
				case "xml":
					cs_type = "string";
					break;
				case "cursor":
					break;
				case "date":
				case "datetime":
				case "datetime2":
				case "smalldatetime":
					cs_type = "DateTime";
					break;
				case "datetimeoffset":
					cs_type = "DateTimeOffset";
					break;
				case "decimal":
				case "money":
				case "numeric":
				case "smallmoney":
					cs_type = "decimal";
					break;
				case "float":
					cs_type = "double";
					break;
				//case "geography":
				//	break;
				//case "geometry":
				//	break;
				//case "hierarchyid":
				//	break;
				case "int":
                    cs_type = "int";
					break;
				case "real":
					cs_type = "float";
					break;
				//case "rowversion":
				//	break;
				case "smallint":
                    cs_type = "short";
					break;
				case "sql_variant":
                    cs_type = "object";
					break;
				//case "table":
				//	break;
				case "time":
                    cs_type = "TimeSpan";
					break;
				case "tinyint":
					cs_type = "sbyte";
					break;
				case "uniqueidentifier":
					cs_type = "Guid";
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(sql_type), sql_type, null);
            }

			return cs_type == "string" ? cs_type : nullable ? $"{cs_type}?" : cs_type;
        }
    }
}
