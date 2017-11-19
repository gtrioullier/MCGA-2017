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
    public class OrderDetailDAC : DataAccessComponent
    {
        private static OrderDetail LoadOrderDetail(IDataReader dr)
        {
            var orderdetail = new OrderDetail
            {
                Id = GetDataValue<int>(dr, "Id"),
                OrderId = GetDataValue<int>(dr, "OrderId"),
                ProductId = GetDataValue<int>(dr, "ProductId"),
                Price = GetDataValue<Double>(dr, "Price"),
                Quantity = GetDataValue<int>(dr, "Quantity"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return orderdetail;
        }

        public List<OrderDetail> Select()
        {
            const string sqlStatement = "SELECT [Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.OrderDetail";

            var result = new List<OrderDetail>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var orderdetail = LoadOrderDetail(dr); // Mapper
                        result.Add(orderdetail);
                    }
                }
            }

            return result;
        }

        public OrderDetail SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [OrderId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                "FROM dbo.OrderDetail WHERE [Id]=@Id ";

            OrderDetail orderdetail = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        if (dr.Read()) orderdetail = LoadOrderDetail(dr);
                    }
                }
            }

            return orderdetail;
        }

        public OrderDetail Create(OrderDetail orderdetail)
        {
            const string sqlStatement = "INSERT INTO dbo.OrderDetail ([OrderId], [ProductId], [Price], [Quantity], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]) " +
                "VALUES(@OrderId, @ProductId, @Price, @Quantity, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy); SELECT SCOPE_IDENTITY();";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@OrderId", DbType.Int32, orderdetail.OrderId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, orderdetail.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, orderdetail.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, orderdetail.Quantity);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, orderdetail.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, orderdetail.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, orderdetail.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, orderdetail.ChangedBy);
                // Obtener el valor de la primary key.
                orderdetail.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return orderdetail;
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.OrderDetail WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(OrderDetail orderdetail)
        {
            const string sqlStatement = "UPDATE dbo.OrderDetail " +
                "SET [OrderId]=@OrderId, " +
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
                db.AddInParameter(cmd, "@OrderId", DbType.Int32, orderdetail.OrderId);
                db.AddInParameter(cmd, "@ProductId", DbType.Int32, orderdetail.ProductId);
                db.AddInParameter(cmd, "@Price", DbType.Double, orderdetail.Price);
                db.AddInParameter(cmd, "@Quantity", DbType.Int32, orderdetail.Quantity);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, orderdetail.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, orderdetail.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, orderdetail.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, orderdetail.ChangedBy);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
