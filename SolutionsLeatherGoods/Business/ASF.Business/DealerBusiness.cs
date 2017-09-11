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

        public Dealer Find(int id)
        {
            var dealerDac = new DealerDAC();
            var result = dealerDac.SelectById(id);
            return result;
        }

        public Dealer Add(Dealer dealer)
        {
            var dealerDac = new DealerDAC();
            return dealerDac.Create(dealer);
        }

        public void Remove(int id)
        {
            var dealerDac = new DealerDAC();
            dealerDac.DeleteById(id);
        }

        public void Edit(Dealer dealer)
        {
            var dealerDac = new DealerDAC();
            dealerDac.UpdateById(dealer);
        }

    }
}
