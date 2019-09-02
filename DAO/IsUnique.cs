using System.Linq;
using Phonebook.Models;

namespace Phonebook.DAO
{
    public class IsUnique : IIsUnique
    {

        private IRecordsDAO _dao;

        public IsUnique()
        {
            _dao = new RecordsDAO();
        }

        //Check new record for unique, if notunique return false
        public bool CheckUnique(NewRecord model)
        {
            var _dataList = from rows in _dao.ReturnData() select rows;
            bool validationResult;
            validationResult = (_dataList.FirstOrDefault(d => d.phoneNum == model.phoneNum)==null) ? true : false;
            return validationResult;
        }
    }
}