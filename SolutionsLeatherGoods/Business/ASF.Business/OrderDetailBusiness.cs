using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class OrderDetailBusiness
    {
        public List<OrderDetail> All()
        {
            var orderdetailDac = new OrderDetailDAC();
            var result = orderdetailDac.Select();
            return result;
        }

        public OrderDetail Find(int id)
        {
            var orderdetailDac = new OrderDetailDAC();
            var result = orderdetailDac.SelectById(id);
            return result;
        }

        public OrderDetail Add(OrderDetail orderdetail)
        {
            var orderdetailDac = new OrderDetailDAC();
            return orderdetailDac.Create(orderdetail);
        }

        public void Remove(int id)
        {
            var orderdetailDac = new OrderDetailDAC();
            orderdetailDac.DeleteById(id);
        }

        public void Edit(OrderDetail orderdetail)
        {
            var orderdetailDac = new OrderDetailDAC();
            orderdetailDac.UpdateById(orderdetail);
        }
    }
}
