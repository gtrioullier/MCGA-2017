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
    public class CartItemDAC : DataAccessComponent
    {
        private static CartItem LoadCartItem(IDataReader dr)
        {
            var cartitem = new CartItem
            {
                Id = GetDataValue<int>(dr, "Id"),
                CartId = GetDataValue<int>(dr, "CartId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Price = GetDataValue<Single>(dr, "Price"),
                Quantity = GetDataValue<int>(dr, "Quantity"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return cartitem;
        }

        public List<CartItem> Select()
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [OrderDate], [TotalPrice], [State], [OrderNumber], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.CartItem";

            var result = new List<CartItem>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var cartitem = LoadCartItem(dr); // Mapper
                        result.Add(cartitem);
                    }
                }
            }

            return result;
        }

        public CartItem SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [CartId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                "FROM dbo.CartItem WHERE [Id]=@Id ";

            CartItem cartitem = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        if (dr.Read()) cartitem = LoadCartItem(dr);
                    }
                }
            }

            return cartitem;
        }

        public CartItem Create(CartItem cartitem)
        {
            const string sqlStatement = "INSERT INTO dbo.CartItem ([CartId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])" +
               "VALUES (@CartId, @ProductId, @Price, @Quantity, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy], @CartId, @ProductId, @Price, @Quantity, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Single, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, cartitem.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cartitem.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cartitem.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cartitem.ChangedBy);
                // Obtener el valor de la primary key.
                cartitem.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return cartitem;
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.CartItem WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(CartItem cartitem)
        {
            const string sqlStatement = "UPDATE dbo.CartItem" +
                "SET [CartId]=@CartId, " +
                    "[ProductId]=@ProductId, " +
                    "[Price]=@Price, " +
                    "[Quantity]=@Quantity, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedBy]=@CreatedBy, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@CartId", DbType.Int32, cartitem.CartId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, cartitem.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Single, cartitem.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, cartitem.Quantity);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, cartitem.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, cartitem.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, cartitem.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, cartitem.ChangedBy);

                db.ExecuteNonQuery(cmd);
            }
        } 
    }
}