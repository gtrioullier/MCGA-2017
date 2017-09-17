using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderNumberBusiness
    {
        public List<OrderNumber> All()
        {
            var ordernumberDAC = new OrderNumberDAC();
            var result = ordernumberDAC.Select();
            return result;
        }

        public OrderNumber Find(int id)
        {
            var ordernumberDAC = new OrderNumberDAC();
            var result = ordernumberDAC.SelectById(id);
            return result;
        }

        public OrderNumber Add(OrderNumber ordernumber)
        {
            var ordernumberDAC = new OrderNumberDAC();
            return ordernumberDAC.Create(ordernumber);
        }

        public void Remove(int id)
        {
            var ordernumberDAC = new OrderNumberDAC();
            ordernumberDAC.DeletedById(id);
        }

        public void Edit(OrderNumber ordernumber)
        {
            var ordernumberDAC = new OrderNumberDAC();
            ordernumberDAC.UpdateById(ordernumber);
        }

    }
}
