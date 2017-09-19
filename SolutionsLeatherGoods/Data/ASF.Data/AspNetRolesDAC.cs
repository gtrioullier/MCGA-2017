using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;


namespace ASF.Data
{
    public class AspNetRolesDAC : DataAccessComponent
    {
        private static AspNetRoles LoadAspNetRoles(IDataReader dr)
        {
            var aspnetroles = new AspNetRoles
            {
                Id = GetDataValue<string>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name")
            };

            return aspnetroles;
        }

        public List<AspNetRoles> Select()
        {
            const string sqlStatement = "SELECT [Id], [Name] FROM dbo.AspNetRoles";

            var result = new List<AspNetRoles>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var aspnetroles = LoadAspNetRoles(dr);
                        result.Add(aspnetroles);
                    }
                }
            }

            return result;
        }

        public AspNetRoles SelectById(string id)
        {
            const string sqlStatement = "SELECT [Id], [Name] FROM dbo.AspNetRoles" +
                "WHERE [Id]=@Id";

            AspNetRoles aspnetroles = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    db.AddInParameter(cmd, "@Id", DbType.String, "Id");
                    if (dr.Read()) aspnetroles = LoadAspNetRoles(dr);
                }
            }
            return aspnetroles;
        }

        public AspNetRoles Create(AspNetRoles aspnetroles)
        {
            const string sqlStatement = "INSERT INTO dbo.AspNetRoles ([Name])" +
                "VALUES(@Name)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, "Name");

                aspnetroles.Id = db.ExecuteScalar(cmd).ToString();
            }

            return aspnetroles;
        }

        public void DeleteById(string id)
        {
            const string sqlStatement = "DELETE FROM dbo.AspNetRoles WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    db.AddInParameter(cmd, "@Id", DbType.String, "Id");
                    db.ExecuteNonQuery(cmd);
                }
            }
        }

        public void UpdateById(AspNetRoles aspnetroles)
        {
            const string sqlStatement = "UPDATE dbo.AspNetRoles" +
                "SET[Name]=@Name" +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, "Name");

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
