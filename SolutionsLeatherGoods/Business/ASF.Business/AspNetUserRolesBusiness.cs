using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    public class AspNetUserRolesBusiness
    {
        public List<AspNetUserRoles> All()
        {
            var aspnetusersrolesDac = new AspNetUserRolesDAC();
            var result = aspnetusersrolesDac.Select();
            return result;
        }

        public AspNetUserRoles Find(AspNetUserRoles aspnetuserroles)
        {
            var aspnetusersrolesDac = new AspNetUserRolesDAC();
            var result = aspnetusersrolesDac.SelectById(aspnetuserroles);
            return result;
        }

        public AspNetUserRoles Add(AspNetUserRoles aspnetusersroles)
        {
            var aspnetusersrolesDac = new AspNetUserRolesDAC();
            return aspnetusersrolesDac.Create(aspnetusersroles);
        }

        public void Remove(AspNetUserRoles aspnetusersroles)
        {
            var aspnetusersrolesDac = new AspNetUserRolesDAC();
            aspnetusersrolesDac.DeleteById(aspnetusersroles);
        }

        public void Edit(AspNetUserRoles aspnetusersroles)
        {
            var aspnetusersrolesDac = new AspNetUserRolesDAC();
            aspnetusersrolesDac.UpdateById(aspnetusersroles);
        }
    }
}
