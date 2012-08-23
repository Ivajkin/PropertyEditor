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

        // Статус прошлого события для Index
        public enum Status
        {
            add_success,
            add_error,
            edit_success,
            edit_error,
            delete_success
        }

        // 
        // GET: /PropertyEditor/
        public ActionResult Index()
        {
            var properties = db.Properties.ToList();
            return View(properties);
        }

        #region add
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
        #endregion

        #region delete
        // 
        // POST: /PropertyEditor/Delete
        [HttpPost]
        public ActionResult Delete(string Name)
        {
            db.Properties.Remove(db.Properties.First(m => m.Name == Name));
            db.SaveChanges();
            
            Status status = Status.delete_success;
            return View(status);
        }
        #endregion
    }
}
