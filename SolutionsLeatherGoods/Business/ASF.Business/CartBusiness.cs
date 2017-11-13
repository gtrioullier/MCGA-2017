using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    public class CartBusiness
    {
        public List<Cart> All()
        {
            var cartDac = new CartDAC();
            var result = cartDac.Select();
            return result;
        }

        public Cart Find(Guid Rowid)
        {
            var cartDac = new CartDAC();
            var result = cartDac.SelectById(Rowid);
            return result;
        }

        public Cart Add(Cart cart)
        {
            var cartDac = new CartDAC();
            return cartDac.Create(cart);
        }

        public void Remove(Guid Rowid)
        {
            var cartDac = new CartDAC();
            cartDac.DeleteById(Rowid);
        }

        public void Edit(Cart cart)
        {
            var cartDac = new CartDAC();
            cartDac.UpdateById(cart);
        }
    }
}
