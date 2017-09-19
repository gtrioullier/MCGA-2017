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
    public class AspNetUserRolesDAC : DataAccessComponent
    {
        private static AspNetUserRoles LoadAspNetUserRoles(IDataReader dr)
        {
            var aspnetuserroles = new AspNetUserRoles
            {
                RoleId = GetDataValue<string>(dr, "RoleId"),
                UserId = GetDataValue<string>(dr, "UserId")
            };
            return aspnetuserroles;
        }

        public List<AspNetUserRoles> Select()
        {
            const string sqlStatement = "SELECT [UserId], [RoleId] FROM dbo.AspNetUserRoles";

            var result = new List<AspNetUserRoles>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var aspnetuserroles = LoadAspNetUserRoles(dr);
                        result.Add(aspnetuserroles);
                    }
                }
            }
            return result;
        }

        public AspNetUserRoles SelectById(AspNetUserRoles aspnetuserroles)
        {
            const string sqlStatement = "SELECT [UserId], [RoleId] FROM dbo.AspNetUserRoles" +
                "WHERE [UserId]=@UserID AND [RoleId]=@RoleId";
            
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) aspnetuserroles = LoadAspNetUserRoles(dr);
                }
            }
            return aspnetuserroles;
        }

        public AspNetUserRoles Create(AspNetUserRoles aspnetuserroles)
        {
            const string sqlStatement = "INSERT INTO dbo.AspNetUserRoles ([UserId], [RoleId])" +
                "VALUES (@UserId, @RoleId)";
            
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, "UserId");
                db.AddInParameter(cmd, "@RoleId", DbType.String, "RoleId");

                aspnetuserroles.UserId = db.ExecuteScalar(cmd).ToString();
                aspnetuserroles.RoleId = db.ExecuteScalar(cmd).ToString();
            }

            return aspnetuserroles;
        }

        public void DeleteById(AspNetUserRoles aspnetuserroles)
        {
            const string sqlStatement = "DELETE FROM dbo.AspNetUserRoles WHERE [UserId]=@UserID AND [RoleId]=@RoleId";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, "UserId");
                db.AddInParameter(cmd, "@RoleId", DbType.String, "RoleId");

                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(AspNetUserRoles aspnetuserroles)
        {
            const string sqlStatement = "UPDATE dbo.AspNetUserRoles" +
                "SET [UserId]=@UserID, [RoleId]=@RoleId" +
                "WHERE [UserId]=@UserID AND [RoleId]=@RoleId";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, "UserId");
                db.AddInParameter(cmd, "@RoleId", DbType.String, "RoleId");

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
