﻿using System;
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
    public class DealerDAC : DataAccessComponent
    {
        
        private static Dealer LoadDealer(IDataReader dr)
        {
            var dealer = new Dealer
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                CategoryId = GetDataValue<int>(dr, "CategoryId"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                Description = GetDataValue<string>(dr, "Description"),
                TotalProducts = GetDataValue<int>(dr, "TotalProducts"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<String>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<String>(dr, "ChangedBy")
            };

            return dealer;
        }

        public List<Dealer> Select()
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Dealer";

            var result = new List<Dealer>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var dealer = LoadDealer(dr); // Mapper
                        result.Add(dealer);
                    }
                }
            }

            return result;
        }

        public Dealer SelectByRowid(Guid Rowid)
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                "FROM dbo.Dealer WHERE [Rowid]=@Rowid ";

            Dealer dealer = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, Rowid);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) dealer = LoadDealer(dr);
                }
            }

            return dealer;
        }



        public Dealer Create(Dealer dealer)
        {
            const string sqlStatement = "INSERT INTO dbo.Dealer ([FirstName], [LastName], [CategoryId], [CountryId], [Description], [TotalProducts], [Rowid], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@FirstName, @LastName, @CategoryId, @CountryId, @Description, @TotalProducts, @Rowid, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, dealer.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, dealer.LastName);
                db.AddInParameter(cmd, "@CategoryId", DbType.Int32, dealer.CategoryId);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, dealer.CountryId);
                db.AddInParameter(cmd, "@Description", DbType.String, dealer.Description);
                db.AddInParameter(cmd, "@TotalProducts", DbType.Int32, dealer.TotalProducts);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, dealer.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, dealer.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, dealer.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, dealer.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, dealer.ChangedBy);
                // Obtener el valor de la primary key.
                dealer.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return dealer;
        }

        public void DeleteByRowid(Guid Rowid)
        {
            const string sqlStatement = "DELETE dbo.Dealer WHERE [Rowid]=@Rowid ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, Rowid);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(Dealer dealer)
        {
            const string sqlStatement = "UPDATE dbo.Dealer " +
                "SET [FirstName]=@FirstName, " +
                    "[LastName]=@LastName," +
                    "[CategoryId]=@CategoryId," +
                    "[CountryId]=@CountryId," +
                    "[Description]=@Description," +
                    "[TotalProducts]=@TotalProducts," +
                    "[Rowid]=@Rowid," +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Rowid]=@Rowid ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, dealer.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, dealer.LastName);
                db.AddInParameter(cmd, "@CategoryId", DbType.Int32, dealer.CategoryId);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, dealer.CountryId);
                db.AddInParameter(cmd, "@Description", DbType.String, dealer.Description);
                db.AddInParameter(cmd, "@TotalProducts", DbType.Int32, dealer.TotalProducts);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, dealer.Rowid);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, dealer.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, dealer.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, dealer.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, dealer.ChangedBy);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
