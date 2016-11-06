using EventAssistant.Models;
using EventAssistant.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace EventAssistant.Controllers
{
    public class EventController : Controller
    {
        //// GET: CreateEvent
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: CreateEvent/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: CreateEvent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateEvent/Create
        [HttpPost]
        public ActionResult Create(EventViewModel eventViewModel)
        {
            try
            {
                Data.AddEvent(eventViewModel, this.User.Identity.Name);

                return RedirectToAction("Create", "Attendee", new { @eventName = eventViewModel.Name });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //// GET: CreateEvent/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CreateEvent/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CreateEvent/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CreateEvent/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
