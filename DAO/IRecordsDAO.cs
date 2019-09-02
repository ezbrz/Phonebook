using System.Collections.Generic;
using System.Web.Mvc;
using Phonebook.Models;

namespace Phonebook.DAO
{
    interface IRecordsDAO
    {
        //Interface for RecordsDAO class
        void Delete(string phoneNum);
        List<Records> ReturnData();
        void CreateRecord(FormCollection collection, NewRecord model);
    }
}
