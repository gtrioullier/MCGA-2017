using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    public class DealerBusiness
    {
        public List<Dealer> All()
        {
            var dealerDac = new DealerDAC();
            var result = dealerDac.Select();
            return result;
        }

        public Dealer Find(Guid Rowid)
        {
            var dealerDac = new DealerDAC();
            var result = dealerDac.SelectByRowid(Rowid);
            return result;
        }

        public Dealer Add(Dealer dealer)
        {
            var dealerDac = new DealerDAC();
            return dealerDac.Create(dealer);
        }

        public void Remove(Guid Rowid)
        {
            var dealerDac = new DealerDAC();
            dealerDac.DeleteByRowid(Rowid);
        }

        public void Edit(Dealer dealer)
        {
            var dealerDac = new DealerDAC();
            dealerDac.UpdateById(dealer);
        }

    }
}
