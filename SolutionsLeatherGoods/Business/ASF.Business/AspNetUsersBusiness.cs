using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;


namespace ASF.Business
{
    public class AspNetUsersBusiness
    {
        public List<AspNetUsers> All()
        {
            var aspnetusersDac = new AspNetUsersDAC();
            var result = aspnetusersDac.Select();
            return result;
        }

        public AspNetUsers Find(string id)
        {
            var aspnetusersDac = new AspNetUsersDAC();
            var result = aspnetusersDac.SelectById(id);
            return result;
        }

        public AspNetUsers Add(AspNetUsers aspnetusers)
        {
            var aspnetusersDac = new AspNetUsersDAC();
            return aspnetusersDac.Create(aspnetusers);
        }

        public void Remove(string id)
        {
            var aspnetusersDac = new AspNetUsersDAC();
            aspnetusersDac.DeleteById(id);
        }

        public void Edit(AspNetUsers aspnetusers)
        {
            var aspnetusersDac = new AspNetUsersDAC();
            aspnetusersDac.UpdateById(aspnetusers);
        }
    }
}
