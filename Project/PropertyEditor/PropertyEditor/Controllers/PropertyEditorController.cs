using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PropertyEditor.Models;
using PerpetuumSoft.Knockout;

namespace PropertyEditor.Controllers
{
    public class PropertyEditorController : Controller
    {
        private PropertyDBContext db = new PropertyDBContext();

        // 
        // GET: /PropertyEditor/
        public ActionResult Index()
        {
            var properties = db.Properties.ToList();
            return View(properties);
        }

        // 
        // GET: /PropertyEditor/AddPanel
        public ActionResult AddPanel()
        {
            return View();
        }

        // 
        // POST: /PropertyEditor/Add
        [HttpPost]
        public ActionResult Add(Property property)
        {
            Status status = Status.add_success;
            try {
                db.Properties.Add(property);
                db.SaveChanges();
            } catch(Exception e) {
                status = Status.add_error;
            }

            return View(status);
        }

        // Статус прошлого события для Index
        public enum Status {
            add_success,
            add_error,
            edit_success,
            edit_error,
            delete_success
        }
    }
}
