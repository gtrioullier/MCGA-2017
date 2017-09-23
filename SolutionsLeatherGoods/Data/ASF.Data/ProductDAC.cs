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
    public class ProductDAC : DataAccessComponent
    {
        private static Product LoadProduct(IDataReader dr)
        {
            var product = new Product
            {
                Id = GetDataValue<int>(dr, "Id"),
                Title = GetDataValue<string>(dr, "Title"),
                Description = GetDataValue<string>(dr, "Description"),
                DealerId = GetDataValue<int>(dr, "DealerId"),
                Image = GetDataValue<string>(dr, "Image"),
                Price = GetDataValue<double>(dr, "Price"),
                QuantitySold = GetDataValue<int>(dr, "QuantitySold"),
                AvgStars = GetDataValue<double>(dr, "AvgStars"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return product;
        }

        public List<Product> Select()
        {
            const string sqlStatement = "SELECT [Id], [Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Product";

            var result = new List<Product>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var product = LoadProduct(dr); // Mapper
                        result.Add(product);
                    }
                }
            }

            return result;
        }

        public Product SelectByRowid(Guid Rowid)
        {
            const string sqlStatement = "SELECT [Id], [Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                "FROM dbo.Product WHERE [Rowid]=@Rowid "; ;

            Product product = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, Rowid);
                using (var dr = db.ExecuteReader(cmd))
                {
                        if (dr.Read()) product = LoadProduct(dr);
                }
            }

            return product;
        }

        public Product Create(Product product)
        {
            const string sqlStatement = "INSERT INTO dbo.Product ([Title], [Description], [DealerId], [Image], [Price], [QuantitySold], [AvgStars], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@Title, @Description, @DealerId, @Image, @Price, @QuantitySold, @AvgStars, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@DealerId", DbType.Int32, product.DealerId);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.Int32, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Double, product.AvgStars);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, product.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, product.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, product.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, product.ChangedBy);
                // Obtener el valor de la primary key.
                product.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return product;
        }

        public void DeleteByRowid(Guid Rowid)
        {
            const string sqlStatement = "DELETE dbo.Product WHERE [Rowid]=@Rowid ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, Rowid);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateByrowid(Product product)
        {
            const string sqlStatement = "UPDATE dbo.Product " +
                "SET [Title]=@Title, " +
                    "[Description]=@Description," +
                    "[DealerId]=@DealerId," +
                    "[Image]=@Image," +
                    "[Price]=@Price," +
                    "[QuantitySold]=@QuantitySold," +
                    "[AvgStars]=@AvgStars," +
                    "[Rowid]=@Rowid," +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Title", DbType.String, product.Title);
                db.AddInParameter(cmd, "@Description", DbType.String, product.Description);
                db.AddInParameter(cmd, "@DealerId", DbType.Int32, product.DealerId);
                db.AddInParameter(cmd, "@Image", DbType.String, product.Image);
                db.AddInParameter(cmd, "@Price", DbType.Double, product.Price);
                db.AddInParameter(cmd, "@QuantitySold", DbType.Int32, product.QuantitySold);
                db.AddInParameter(cmd, "@AvgStars", DbType.Double, product.AvgStars);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, product.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, product.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, product.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, product.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, product.ChangedBy);

                db.ExecuteNonQuery(cmd);
            }
        }

    }
}
