using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ProductBusiness
    {
        public List<Product> All()
        {
            var productDac = new ProductDAC();
            var result = productDac.Select();
            return result;
        }

        public Product Find(Guid Rowid)
        {
            var productDac = new ProductDAC();
            var result = productDac.SelectByRowid(Rowid);
            return result;
        }

        public Product Add(Product product)
        {
            var productDac = new ProductDAC();
            return productDac.Create(product);
        }

        public void Remove(Guid Rowid)
        {
            var productDac = new ProductDAC();
            productDac.DeleteByRowid(Rowid);
        }

        public void Edit(Product product)
        {
            var productDac = new ProductDAC();
            productDac.UpdateByrowid(product);
        }
    }
}
