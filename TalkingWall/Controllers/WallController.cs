using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalkingWall.Domain;

namespace TalkingWall.Controllers
{
    public class WallController : Controller
    {
        public WallController(ICollection<WallMessage> messages)
        {
            _messages = messages;
        }
        ICollection<WallMessage> _messages;


        // GET: Wall
        public ActionResult Index()
        {
            
            return   View();
        }

        // GET: Wall/Details/5
        public ActionResult Get (int id)
        {
            return View();
        }

        // GET: Wall/Create
        public ActionResult Create(WallMessage message)
        {
            return View();
        }

        // POST: Wall/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Wall/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Wall/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Wall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Wall/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
