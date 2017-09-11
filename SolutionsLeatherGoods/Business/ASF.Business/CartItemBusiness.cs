using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class CartItemBusiness
    {
        public List<CartItem> All()
        {
            var cartitemDac = new CartItemDAC();
            var result = cartitemDac.Select();
            return result;
        }

        public CartItem Find(int id)
        {
            var cartitemDac = new CartItemDAC();
            var result = cartitemDac.SelectById(id);
            return result;
        }

        public CartItem Add(CartItem cartitem)
        {
            var cartitemDac = new CartItemDAC();
            return cartitemDac.Create(cartitem);
        }

        public void Remove(int id)
        {
            var cartitemDac = new CartItemDAC();
            cartitemDac.DeleteById(id);
        }

        public void Edit(CartItem cartitem)
        {
            var cartitemDac = new CartItemDAC();
            cartitemDac.UpdateById(cartitem);
        }
    }
}
