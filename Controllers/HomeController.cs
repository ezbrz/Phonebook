using System;
using System.Web.Mvc;
using Phonebook.Models;
using Phonebook.BLL;

namespace Phonebook.Controllers
{
    public class HomeController : Controller
    {

        IRecordServices _service;
        public HomeController()
        {
            _service = new RecordServices();
        }


        public ActionResult Index(SearchingFilter filter)
        {
            //View all records with using filter and search pattern
            ViewBag.searchPattern = !String.IsNullOrEmpty(filter.SearchPattern) ? filter.SearchPattern : "";
            ViewBag.property = filter.Property;
            ViewBag.IsDecendig = !filter.IsDecendig;

            return View(_service.ReturnData(filter));
        }


        public ActionResult Delete(string phoneNum)
        {
            //Delete record by phonenum
            _service.Delete(phoneNum);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult CreateNew()
        {
            //View with empty textbox
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(FormCollection collection, NewRecord model)
        {
                TryUpdateModel(model, collection);

            //check all textboxes for valid
            if (ModelState.IsValid)
                {
                //try create new record. If phone num not unique load CreateNew view with error
                if (_service.Create(collection, model)) { return RedirectToAction("Index", "Home"); }
                else
                {
                    ViewBag.CheckMessage = "Phone number already exist. Try another";
                    return View(); }
                }
                else
                {
                //view with messages for invalid textboxes
                    return View();
                }
        }
    }
}
