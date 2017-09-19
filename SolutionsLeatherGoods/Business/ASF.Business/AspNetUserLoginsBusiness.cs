using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class AspNetUserLoginsBusiness
    {

        public List<AspNetUserLogins> All()
        {
            var aspnetusersloginsDac = new AspNetUserLoginsDAC();
            var result = aspnetusersloginsDac.Select();
            return result;
        }

        public AspNetUserLogins Find(AspNetUserLogins aspnetuserslogins)
        {
            var aspnetusersloginsDac = new AspNetUserLoginsDAC();
            var result = aspnetusersloginsDac.SelectById(aspnetuserslogins);
            return result;
        }

        public AspNetUserLogins Add(AspNetUserLogins aspnetuserslogins)
        {
            var aspnetusersloginsDac = new AspNetUserLoginsDAC();
            return aspnetusersloginsDac.Create(aspnetuserslogins);
        }

        public void Remove(AspNetUserLogins aspnetuserslogins)
        {
            var aspnetusersloginsDac = new AspNetUserLoginsDAC();
            aspnetusersloginsDac.DeleteById(aspnetuserslogins);
        }

        public void Edit(AspNetUserLogins aspnetuserslogins)
        {
            var aspnetusersloginsDac = new AspNetUserLoginsDAC();
            aspnetusersloginsDac.UpdateById(aspnetuserslogins);
        }
    }
}
