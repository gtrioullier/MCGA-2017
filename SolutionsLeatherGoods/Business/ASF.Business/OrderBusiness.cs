using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderBusiness
    {
        public List<Order> All()
        {
            var orderDac = new OrderDAC();
            var result = orderDac.Select();
            return result;
        }

        public Order Find(Guid Rowid)
        {
            var orderDac = new OrderDAC();
            var result = orderDac.SelectById(Rowid);
            return result;
        }

        public Order Add(Order order)
        {
            var orderDac = new OrderDAC();
            return orderDac.Create(order);
        }

        public void Remove(Guid Rowid)
        {
            var orderDac = new OrderDAC();
            orderDac.DeleteById(Rowid);
        }

        public void Edit(Order order)
        {
            var orderDac = new OrderDAC();
            orderDac.UpdateById(order);
        }
    }
}
