using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ASF.Entities;
using ASF.Data;

namespace ASF.Business
{
    public class ErrorBusiness
    {
        public List<Error> All()
        {
            var errorDAC = new ErrorDAC();
            var result = errorDAC.Select();
            return result;
        }

        public Error Find(int id)
        {
            var errorDAC = new ErrorDAC();
            var result = errorDAC.SelectById(id);
            return result;
        }

        public Error Add(Error error)
        {
            var errorDAC = new ErrorDAC();
            return errorDAC.Create(error);
        }

        public void Remove(int id)
        {
            var errorDAC = new ErrorDAC();
            errorDAC.Delete(id);
        }

        public void Edit(Error error)
        {
            var errorDAC = new ErrorDAC();
            errorDAC.Edit(error);
        }

    }
}
