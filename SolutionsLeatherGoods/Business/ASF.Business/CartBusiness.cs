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

        public Cart Find(int id)
        {
            var cartDac = new CartDAC();
            var result = cartDac.SelectById(id);
            return result;
        }

        public Cart Add(Cart cart)
        {
            var cartDac = new CartDAC();
            return cartDac.Create(cart);
        }

        public void Remove(int id)
        {
            var cartDac = new CartDAC();
            cartDac.DeleteById(id);
        }

        public void Edit(Cart cart)
        {
            var cartDac = new CartDAC();
            cartDac.UpdateById(cart);
        }
    }
}
