using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ClientBusiness
    {
        public List<Client> All()
        {
            var clientDac = new ClientDAC();
            var result = clientDac.Select();
            return result;
        }

        public Client Find(Guid Rowid)
        {
            var clientDac = new ClientDAC();
            var result = clientDac.SelectByRowid(Rowid);
            return result;
        }

        public Client Add(Client client)
        {
            var clientDac = new ClientDAC();
            return clientDac.Create(client);
        }

        public void Remove(Guid Rowid)
        {
            var clientDac = new ClientDAC();
            clientDac.DeleteByRowid(Rowid);
        }

        public void Edit(Client client)
        {
            var clientDac = new ClientDAC();
            clientDac.UpdateByRowid(client);
        }
    }
}
