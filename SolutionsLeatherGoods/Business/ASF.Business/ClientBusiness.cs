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

        public Client Find(int id)
        {
            var clientDac = new ClientDAC();
            var result = clientDac.SelectById(id);
            return result;
        }

        public Client Add(Client client)
        {
            var clientDac = new ClientDAC();
            return clientDac.Create(client);
        }

        public void Remove(int id)
        {
            var clientDac = new ClientDAC();
            clientDac.DeleteById(id);
        }

        public void Edit(Client client)
        {
            var clientDac = new ClientDAC();
            clientDac.UpdateById(client);
        }
    }
}
