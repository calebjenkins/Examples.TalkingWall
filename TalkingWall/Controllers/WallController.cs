using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalkingWall.Domain;

namespace TalkingWall.Controllers
{
    public class WallController : Controller
    {
        public WallController()
        {
            _messages = Global.Messages;
        }
        ICollection<WallMessage> _messages;


        // GET: Wall
        public ActionResult Index()
        {

            ViewBag.WallMessages = _messages.Reverse();

            ICollection<WallMessage> msgs = _messages;
            ICollection<WallMessage> ModelMsgs = new Collection<WallMessage>();
            foreach(var m in _messages.Reverse())
            {
                var mg = new WallMessage()
                {
                     Message = m.Message,
                     Name = m.Name,
                     TimeStamp = m.TimeStamp
                };

                ModelMsgs.Add(mg);
            }


            return View(msgs);
        }


        // GET: Wall/Create
        [ValidateAntiForgeryToken]
        [HttpPost]  
        public ActionResult Create(WallMessage message)
        {
            try
            {
                var msg = new WallMessage()
                {
                    Name = message.Name,
                    Message = message.Message,
                    TimeStamp = DateTime.Now
                };

                Global.Messages.Add(msg);

                return View("Index", _messages);

                // return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Wall/Create
        [ValidateAntiForgeryToken]
        // [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var msg = new WallMessage()
                {
                    Name = collection["message.Name"],
                    Message = collection["message.Message"],
                    TimeStamp = DateTime.Now
                };

                Global.Messages.Add(msg);

                //return View("Index", _messages);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult ClearAll()
        {
            try
            {
                Global.Messages.Clear();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
