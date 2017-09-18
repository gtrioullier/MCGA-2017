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
    public class AspNetUsersDAC : DataAccessComponent
    {
        private static AspNetUsers LoadAspNetUsers(IDataReader dr)
        {
            var aspnetusers = new AspNetUsers
            {
                Id = GetDataValue<string>(dr, "Id"),
                Email = GetDataValue<string>(dr, "Email"),
                EmailConfirmed = GetDataValue<bool>(dr, "EmailConfirmed"),
                PasswordHash = GetDataValue<string>(dr, "PasswordHash"),
                SecurityStamp = GetDataValue<string>(dr, "SecurityStamp"),
                PhoneNumber = GetDataValue<string>(dr, "PhoneNumber"),
                PhoneNumberConfirmed = GetDataValue<bool>(dr, "PhoneNumberConfirmed"),
                TwoFactorEnabled = GetDataValue<bool>(dr, "TwoFactorEnabled"),
                LockoutEndDateUtc = GetDataValue<DateTime>(dr, "LocoutEndDateUtc"),
                LockoutEnabled = GetDataValue<bool>(dr, "LockoutEnabled"),
                AccessFailedCount = GetDataValue<int>(dr, "AccessFailedCount"),
                UserName = GetDataValue<string>(dr, "UserName")
            };
            return aspnetusers;
        }

        public List<AspNetUsers> Select()
        {
            const string sqlStatement = "SELECT [Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName] FROM dbo.AspNetUsers";

            var result = new List<AspNetUsers>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var aspnetusers = LoadAspNetUsers(dr); // Mapper
                        result.Add(aspnetusers);
                    }
                }
            }
            return result;
        }

        public AspNetUsers SelectById(string id)
        {
            const string sqlStatement = "SELECT [Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]" + 
                "FROM dbo.AspNetUsers WHERE [Id]=@Id";

            AspNetUsers aspnetusers = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, "Id");
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) aspnetusers = LoadAspNetUsers(dr);
                }
            }
            return aspnetusers;
        }

        public AspNetUsers Create(AspNetUsers aspnetusers)
        {
            const string sqlStatement = "INSERT INTO dbo.AspNetUsers([Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName])" +
                "VALUES(@Email, @EmailConfirmed, @PasswordHash, @SecurityStamp, @PhoneNumber, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEndDateUtc, @LockoutEnabled, @AccessFailedCount, @UserName)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);

            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Email", DbType.String, "Email");
                db.AddInParameter(cmd, "@EmailConfirmed", DbType.Boolean, "EmailConfirmed");
                db.AddInParameter(cmd, "@PasswordHash", DbType.String, "PasswordHash");
                db.AddInParameter(cmd, "@SecurityStamp", DbType.String, "SecurityStamp");
                db.AddInParameter(cmd, "@PhoneNumber", DbType.String, "PhoneNumber");
                db.AddInParameter(cmd, "@PhoneNumberConfirmed", DbType.Boolean, "PhoneNumberConfirmed");
                db.AddInParameter(cmd, "@TwoFactorEnabled", DbType.Boolean, "TwoFactorEnabled");
                db.AddInParameter(cmd, "@LockoutEndDateUtc", DbType.DateTime, "LockoutEndDateUtc");
                db.AddInParameter(cmd, "@LockoutEnabled", DbType.Boolean, "LockoutEnabled");
                db.AddInParameter(cmd, "@AccessFailedCount", DbType.Int32, "AccessFailedCount");
                db.AddInParameter(cmd, "@UserName", DbType.String, "UserName");
                // Obtener el valor de la primary key.
                aspnetusers.Id = db.ExecuteScalar(cmd).ToString();
            }
            return aspnetusers;
        }

        public void DeleteById(string id)
        {
            const string sqlStatement = "DELETE dbo.AspNetUsers WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.String, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(AspNetUsers aspnetuser)
        {
            const string sqlStatement = "UPDATE dbo.AspNetUsers" + 
                "SET [Email]=@Email, " + 
                    "[EmailConfirmed]=@EmailConfirmed, " +
                    "[PasswordHash]=@PasswordHash, " +
                    "[SecurityStamp]=@SecurityStamp, " +
                    "[PhoneNumber]=@PhoneNumber, " +
                    "[PhoneNumberConfirmed]=@PhoneNumberConfirmed, " +
                    "[TwoFactorEnabled]=@TwoFactorEnabled, " +
                    "[LockoutEndDateUtc]=@LockoutEndDateUtc, " +
                    "[LockoutEnabled]=@LockoutEnabled, " +
                    "[AccessFailedCount]=@AccessFailedCount, " +
                    "[UserName]=@UserName, " +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Email", DbType.String, "Email");
                db.AddInParameter(cmd, "@EmailConfirmed", DbType.Boolean, "EmailConfirmed");
                db.AddInParameter(cmd, "@PasswordHash", DbType.String, "PasswordHash");
                db.AddInParameter(cmd, "@SecurityStamp", DbType.String, "SecurityStamp");
                db.AddInParameter(cmd, "@PhoneNumber", DbType.String, "PhoneNumber");
                db.AddInParameter(cmd, "@PhoneNumberConfirmed", DbType.Boolean, "PhoneNumberConfirmed");
                db.AddInParameter(cmd, "@TwoFactorEnabled", DbType.Boolean, "TwoFactorEnabled");
                db.AddInParameter(cmd, "@LockoutEndDateUtc", DbType.DateTime, "LockoutEndDateUtc");
                db.AddInParameter(cmd, "@LockoutEnabled", DbType.Boolean, "LockoutEnabled");
                db.AddInParameter(cmd, "@AccessFailedCount", DbType.Int32, "AccessFailedCount");
                db.AddInParameter(cmd, "@UserName", DbType.String, "UserName");

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
