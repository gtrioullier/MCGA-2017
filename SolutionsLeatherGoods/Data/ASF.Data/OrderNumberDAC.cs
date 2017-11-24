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
    public class OrderNumberDAC : DataAccessComponent
    {
        private static OrderNumber LoadOrderNumber(IDataReader dr)
        {
            var ordernumber = new OrderNumber
            {
                Id = GetDataValue<int>(dr, "Id"),
                Number = GetDataValue<int>(dr, "Number")
            };

            return ordernumber;
        }

        public List<OrderNumber> Select() 
        {
            const string sqlStatement = "SELECT [Id], [Number] FROM dbo.OrderNumber";

            var result = new List<OrderNumber>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var ordernumberdetail = LoadOrderNumber(dr); // Mapper
                        result.Add(ordernumberdetail);
                    }
                }
            }

            return result;
        }

        public OrderNumber SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Number] " + 
                "FROM dbo.OrderNumber WHERE [Id]=@Id";

            OrderNumber ordernumber = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        if (dr.Read()) ordernumber = LoadOrderNumber(dr);
                    }
                }
            }

            return ordernumber;
        }

        public OrderNumber Create(OrderNumber ordernumber)
        {
            const string sqlStatement = "INSERT INTO dbo.OrderNumber ([Number]) " + 
                "VALUES(@Number)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Number", DbType.Int32, ordernumber.Number);
               
                ordernumber.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return ordernumber;
        }

        public void DeletedById(int id)
        {
            const string sqlStatement = "DELETE FROM db.OrderNumber WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(OrderNumber ordernumber)
        {
            const string sqlStatement = "UPDATE dbo.OrderNumber " +
                "SET [Number]=@Number ," +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Number", DbType.Int32, ordernumber.Number);

                ordernumber.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
        }
    }
}
