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
    public class ClientDAC : DataAccessComponent
    {
        private static Client LoadClient(IDataReader dr)
        {
            var client = new Client
            {
                Id = GetDataValue<int>(dr, "Id"),
                FirstName = GetDataValue<string>(dr, "FirstName"),
                LastName = GetDataValue<string>(dr, "LastName"),
                Email = GetDataValue<string>(dr, "Email"),
                CountryId = GetDataValue<int>(dr, "CountryId"),
                AspNetUsers = GetDataValue<string>(dr, "AspNetUsers"),
                City = GetDataValue<string>(dr, "City"),
                SignupDate = GetDataValue<DateTime>(dr, "SignupDate"),
                Rowid = GetDataValue<Guid>(dr, "Rowid"),
                OrderCount = GetDataValue<int>(dr, "OrderCount"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return client;
        }

        public List<Client> Select()
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Client";

            var result = new List<Client>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var client = LoadClient(dr); // Mapper
                        result.Add(client);
                    }
                }
            }

            return result;
        }

        public Client SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [SignupDate], [Rowid], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                " FROM dbo.Client WHERE [Id]=@Id";

            Client client = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) client = LoadClient(dr);
                }
            }

            return client;
        }

        public Client Create(Client client)
        {
            const string sqlStatement = "INSERT INTO dbo.Client ([FirstName], [LastName], [Email], [CountryId], [AspNetUsers], [City], [Rowid], [SignupDate], [OrderCount], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])" +
                " VALUES(@FirstName, @LastName, @Email, @CountryId, @AspNetUsers, @City, @Rowid, @SignupDate, @OrderCount, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, client.LastName);
                db.AddInParameter(cmd, "@Email", DbType.String, client.Email);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, client.CountryId);
                db.AddInParameter(cmd, "@AspNetUsers", DbType.String, client.AspNetUsers);
                db.AddInParameter(cmd, "@City", DbType.String, client.City);
                db.AddInParameter(cmd, "@SignupDate", DbType.DateTime, client.SignupDate);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, client.Rowid);
                db.AddInParameter(cmd, "@OrderCount", DbType.Int32, client.OrderCount);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, client.FirstName);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, client.FirstName);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, client.FirstName);
                //Obtenemos el valor de la primary key.
                client.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return client;

        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Client WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(Client client)
        {
            const string sqlStatement = "UPDATE dbo.Client " +
                "SET [Id]=@Id, " +
                    "[FirstName]=@FirstName, " +
                    "[LastName]=@LastName, " +
                    "[Email]=@Email, " +
                    "[CountryId]=@CountryId, " +
                    "[AspNetUsers]=@AspNetUsers, " +
                    "[City]=@City, " +
                    "[Rowid]=@Rowid, " +
                    "[SignupDate]=@SignupDate," +
                    "[OrderCount]=@OrderCount, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[CreatedOn]=@CreatedOn, " +
                    "[ChangedOn]=@ChangedOn, " +
                    "[ChangedBy]=@ChangedBy " +
                "WHERE [Id]=@Id ";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@FirstName", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@LastName", DbType.String, client.LastName);
                db.AddInParameter(cmd, "@Email", DbType.String, client.Email);
                db.AddInParameter(cmd, "@CountryId", DbType.Int32, client.CountryId);
                db.AddInParameter(cmd, "@AspNetUsers", DbType.String, client.AspNetUsers);
                db.AddInParameter(cmd, "@City", DbType.String, client.City);
                db.AddInParameter(cmd, "@SignupDate", DbType.DateTime, client.SignupDate);
                db.AddInParameter(cmd, "@Rowid", DbType.Guid, client.Rowid);
                db.AddInParameter(cmd, "@OrderCount", DbType.Int32, client.OrderCount);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime, client.FirstName);
                db.AddInParameter(cmd, "@CreatedBy", DbType.String, client.FirstName);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime, client.FirstName);
                db.AddInParameter(cmd, "@ChangedBy", DbType.String, client.FirstName);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
