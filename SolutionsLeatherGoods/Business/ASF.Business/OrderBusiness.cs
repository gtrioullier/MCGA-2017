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

        public Order Find(int id)
        {
            var orderDac = new OrderDAC();
            var result = orderDac.SelectById(id);
            return result;
        }

        public Order Add(Order order)
        {
            var orderDac = new OrderDAC();
            return orderDac.Create(order);
        }

        public void Remove(int id)
        {
            var orderDac = new OrderDAC();
            orderDac.DeleteById(id);
        }

        public void Edit(Order order)
        {
            var orderDac = new OrderDAC();
            orderDac.UpdateById(order);
        }
    }
}
