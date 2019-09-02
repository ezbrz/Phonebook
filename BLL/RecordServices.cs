using Phonebook.DAO;
using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Phonebook.BLL
{
    public class RecordServices : IRecordServices
    {

        private IRecordsDAO _dao;
        private IIsUnique _isUnique;

        public RecordServices()
        {
            _dao = new RecordsDAO();
            _isUnique = new IsUnique();
        }

        //delete record by phone number with DAO
        public void Delete(string phoneNum)
        {
            _dao.Delete(phoneNum);
        }

        //return records with use filter or(and) search pattern from DAO
        public List<Records> ReturnData(SearchingFilter filter)
        {
            var _dataList = from rows in _dao.ReturnData() select rows;

            if (!String.IsNullOrEmpty(filter.SearchPattern))
            {
                _dataList = _dataList.Where(s => s.lastName.Contains(filter.SearchPattern) || s.firstName.Contains(filter.SearchPattern) || s.phoneNum.Contains(filter.SearchPattern));
            }
            if (filter != null) { 
                switch (filter.Property)
                {

                    case OrderPropertyEnum.name:
                        if (filter.IsDecendig) { _dataList = _dataList.OrderByDescending(s => s.lastName);}
                        else { _dataList = _dataList.OrderBy(s => s.lastName); }
                        break;
                    case OrderPropertyEnum.year:
                        if (filter.IsDecendig) { _dataList = _dataList.OrderByDescending(s => s.birthYear); }
                        else { _dataList = _dataList.OrderBy(s => s.birthYear); }
                        break;
                    default:
                        _dataList = _dataList.OrderBy(s => s.lastName);
                    break;
                }
            }
            return _dataList.ToList();
        }

        //just return data from DAO
        public List<Records> ReturnData()
        {
            return _dao.ReturnData();
        }

        public bool Create(FormCollection collection, NewRecord model)
        {
            if (_isUnique.CheckUnique(model)) { 
                _dao.CreateRecord(collection, model);
                return(true);
            }
            else
            {
                return (false);
            }

        }
    }
}