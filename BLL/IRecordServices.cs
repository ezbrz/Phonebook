using Phonebook.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Phonebook.BLL
{
    interface IRecordServices
    {
        //interface for RecordServices
            void Delete(string phoneNum);

            List<Records> ReturnData(SearchingFilter filter);
            List<Records> ReturnData();
            bool Create(FormCollection collection, NewRecord model);
    }
}
