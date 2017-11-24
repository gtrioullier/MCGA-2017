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
    public class RatingDAC : DataAccessComponent
    {
        private static Rating LoadRating(IDataReader dr)
        {
            var rating = new Rating
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Stars = GetDataValue<int>(dr, "Stars"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<String>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<String>(dr, "ChangedBy")
            };

            return rating;
        }

        public List<Rating> Select()
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Rating";

            var result = new List<Rating>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var rating = LoadRating(dr); // Mapper
                        result.Add(rating);
                    }
                }
            }

            return result;
        }

        public Rating SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] " +
                "FROM dbo.Rating WHERE [Id]=@Id "; 

            Rating rating = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        if (dr.Read()) rating = LoadRating(dr);
                    }
                }
            }

            return rating;
        }

        public Rating Create(Rating rating)
        {
            const string sqlStatement = "INSERT INTO dbo.Rating ([ClientId], [ProductId], [Stars], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@ClientId, @ProductId, @Stars, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, rating.ClientId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, rating.ProductId);
                db.AddInParameter(cmd, "@Stars", DbType.Int32, rating.Stars);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, rating.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, rating.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, rating.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, rating.ChangedBy);
                // Obtener el valor de la primary key.
                rating.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return rating;
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Rating WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(Rating rating)
        {
            const string sqlStatement = "UPDATE dbo.Rating " +
                "SET [ClientId]=@ClientId, " +
                    "[ProductId]=@ProductId," +
                    "[Stars]=@Stars, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, rating.ClientId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, rating.ProductId);
                db.AddInParameter(cmd, "@Stars", DbType.Int32, rating.Stars);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, rating.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, rating.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, rating.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, rating.ChangedBy);

                db.ExecuteNonQuery(cmd);
            }
        }

    }
}
