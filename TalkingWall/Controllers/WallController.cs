using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalkingWall.Domain;
using TalkingWall.Domain.Services;

namespace TalkingWall.Controllers
{
    public class WallController : Controller
    {
        IWallMessageRepository msgRepo;

        public WallController(IWallMessageRepository messagesRepository)
        {
            msgRepo = messagesRepository;
        }
        


        // GET: Wall
        public ActionResult Index()
        {

            Collection<WallMessage> msgs = msgRepo.Messages;

            Collection<WallMessage> ModelMsgs = new Collection<WallMessage>();
            foreach(var m in msgs.Reverse())
            {
                var mg = new WallMessage()
                {
                     Message = m.Message,
                     Name = m.Name,
                     TimeStamp = m.TimeStamp
                };

                ModelMsgs.Add(mg);
            }


            return View(ModelMsgs);
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

               msgRepo.Messages.Add(msg);

                return View("Index", msgRepo.Messages);
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

                msgRepo.Messages.Add(msg);

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
                msgRepo.Messages.Clear();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
