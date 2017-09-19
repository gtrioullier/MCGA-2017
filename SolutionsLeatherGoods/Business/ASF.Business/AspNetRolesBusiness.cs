using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class AspNetRolesBusiness
    {
        public List<AspNetRoles> All()
        {
            var aspnetusersclaimsDac = new AspNetRolesDAC();
            var result = aspnetusersclaimsDac.Select();
            return result;
        }

        public AspNetRoles Find(string id)
        {
            var aspnetusersclaimsDac = new AspNetRolesDAC();
            var result = aspnetusersclaimsDac.SelectById(id);
            return result;
        }

        public AspNetRoles Add(AspNetRoles aspnetusersclaims)
        {
            var aspnetusersclaimsDac = new AspNetRolesDAC();
            return aspnetusersclaimsDac.Create(aspnetusersclaims);
        }

        public void Remove(string id)
        {
            var aspnetusersclaimsDac = new AspNetRolesDAC();
            aspnetusersclaimsDac.DeleteById(id);
        }

        public void Edit(AspNetRoles aspnetusersclaims)
        {
            var aspnetusersclaimsDac = new AspNetRolesDAC();
            aspnetusersclaimsDac.UpdateById(aspnetusersclaims);
        }
    }
}
