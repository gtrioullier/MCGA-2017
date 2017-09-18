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
    public class AspNetUserClaimsDAC : DataAccessComponent
    {
        private static AspNetUserClaims LoadAspNetUserClaims(IDataReader dr)
        {
            var aspnetuserclaims = new AspNetUserClaims
            {
                Id = GetDataValue<int>(dr, "Id"),
                UserId = GetDataValue<string>(dr, "UserId"),
                ClaimType = GetDataValue<string>(dr, "ClaimType"),
                ClaimValue = GetDataValue<string>(dr, "ClaimValue")
            };

            return aspnetuserclaims;
        }

        public List<AspNetUserClaims> Select()
        {
            const string sqlStatement = "SELECT [Id], [UserId], [ClaimType], [ClaimValue] FROM dbo.AspNetUserClaims";

            var result = new List<AspNetUserClaims>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var aspnetusers = LoadAspNetUserClaims(dr);
                        result.Add(aspnetusers);
                    }
                }
            }
            return result;
        }

        public AspNetUserClaims SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [UserId], [ClaimType], [ClaimValue]" + 
                "FROM dbo.AspNetUserClaims WHERE [Id]=@Id";

            AspNetUserClaims aspnetuserclaims = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, "Id");
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) aspnetuserclaims = LoadAspNetUserClaims(dr);
                }
            }

            return aspnetuserclaims;
        }

        public AspNetUserClaims Create(AspNetUserClaims aspnetusersclaims)
        {
            const string sqlStatement = "INSERT INTO dbo.AspNetUserClaims ([UserId], [ClaimType], [ClaimValue])" +
                "VALUES(@UserId, @ClaimType, @ClaimValue)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, "UserId");
                db.AddInParameter(cmd, "@ClaimType", DbType.String, "ClaimType");
                db.AddInParameter(cmd, "@ClaimValue", DbType.String, "ClaimValue");
                // Obtener el valor de la primary key.
                aspnetusersclaims.Id=Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return aspnetusersclaims;
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.AspNetUserClaims WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(AspNetUserClaims aspnetusersclaims)
        {
            const string sqlStatement = "UPDATE dbo.AspNetUserClaims" +
                "SET [UserId]=@UserId, " +
                    "[ClaimType]=@ClaimType, " +
                    "[ClaimValue]=@ClaimValue " +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, "UserId");
                db.AddInParameter(cmd, "@ClaimType", DbType.String, "ClaimType");
                db.AddInParameter(cmd, "@ClaimValue", DbType.String, "ClaimValue");

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
