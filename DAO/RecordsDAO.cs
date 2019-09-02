using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Phonebook.Models;
using System.Xml;
using System.Web.Hosting;

namespace Phonebook.DAO
{
    public class RecordsDAO : IRecordsDAO
    {
        //delete record with phoneNum from XML
        public void Delete(string phoneNum)
        {
            XmlDocument doc = new XmlDocument();
            string XMLData = HostingEnvironment.MapPath("~/App_Data/PhonebookData.xml");
            doc.Load(XMLData);
            XmlNode root = doc.DocumentElement;
            XmlNode node = root.SelectSingleNode(String.Format("Record[phoneNum='{0}']", phoneNum));
            XmlNode outer = node.ParentNode;
            outer.RemoveChild(node);
            doc.Save(XMLData);
        }

        //Get data from XML file
        public List<Records> ReturnData()
        {
            var _recordList = new List<Records>();
            string XMLData = HostingEnvironment.MapPath("~/App_Data/PhonebookData.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(XMLData);
            if (ds.Tables.Count > 0) { 
            _recordList = (from rows in ds.Tables[0].AsEnumerable()
                          select new Records
                          {
                              //ID = Convert.ToInt32(rows[0].ToString()),
                              firstName = rows[0].ToString(),
                              lastName = rows[1].ToString(),
                              birthYear = Convert.ToInt32(rows[2].ToString()),
                              phoneNum = rows[3].ToString()
                          }).ToList();
            }
            return _recordList;
        }

        //Create new record for XML file after all validation in BLL
        public void CreateRecord(FormCollection collection, NewRecord model)
        {
            XmlDocument doc = new XmlDocument();
            string XMLData = HostingEnvironment.MapPath("~/App_Data/PhonebookData.xml");
            doc.Load(XMLData);
            XmlNode xRoot = doc.DocumentElement;
            XmlNode newRecord = doc.CreateElement("Record");
            XmlNode firstNameElem = doc.CreateElement("firstName");
            XmlNode lastNameElem = doc.CreateElement("lastName");
            XmlNode birthYearElem = doc.CreateElement("birthYear");
            XmlNode phoneNumElem = doc.CreateElement("phoneNum");

            XmlText firstNameNew = doc.CreateTextNode(model.firstName);
            XmlText lastNameNew = doc.CreateTextNode(model.lastName);
            XmlText birthYearNew = doc.CreateTextNode(model.birthYear.ToString());
            XmlText phoneNumNew = doc.CreateTextNode(model.phoneNum);

            firstNameElem.AppendChild(firstNameNew);
            lastNameElem.AppendChild(lastNameNew);
            birthYearElem.AppendChild(birthYearNew);
            phoneNumElem.AppendChild(phoneNumNew);

            newRecord.AppendChild(firstNameElem);
            newRecord.AppendChild(lastNameElem);
            newRecord.AppendChild(birthYearElem);
            newRecord.AppendChild(phoneNumElem);

            xRoot.AppendChild(newRecord);
            doc.Save(XMLData);
        }

    }
}