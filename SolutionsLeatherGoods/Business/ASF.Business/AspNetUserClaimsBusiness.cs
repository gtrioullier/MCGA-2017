using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class AspNetUserClaimsBusiness
    {
        public List<AspNetUserClaims> All()
        {
            var aspnetusersclaimsDac = new AspNetUserClaimsDAC();
            var result = aspnetusersclaimsDac.Select();
            return result;
        }

        public AspNetUserClaims Find(int id)
        {
            var aspnetusersclaimsDac = new AspNetUserClaimsDAC();
            var result = aspnetusersclaimsDac.SelectById(id);
            return result;
        }

        public AspNetUserClaims Add(AspNetUserClaims aspnetusersclaims)
        {
            var aspnetusersclaimsDac = new AspNetUserClaimsDAC();
            return aspnetusersclaimsDac.Create(aspnetusersclaims);
        }

        public void Remove(int id)
        {
            var aspnetusersclaimsDac = new AspNetUserClaimsDAC();
            aspnetusersclaimsDac.DeleteById(id);
        }

        public void Edit(AspNetUserClaims aspnetusersclaims)
        {
            var aspnetusersclaimsDac = new AspNetUserClaimsDAC();
            aspnetusersclaimsDac.UpdateById(aspnetusersclaims);
        }
    }
}
