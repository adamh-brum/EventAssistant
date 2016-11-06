using EventAssistant.Models;
using EventAssistant.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventAssistant.Controllers
{
    public class AttendeeController : Controller
    {
        //// GET: Attendee
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Attendee/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Attendee/Create
        [HttpGet]
        public ActionResult Create(string eventName)
        {
            var viewModel = new AttendeeViewModel()
            {
                EventName = eventName
            };

            return View(viewModel);
        }

        // POST: Attendee/Create
        [HttpPost]
        public ActionResult Create(AttendeeViewModel attendeeViewModel)
        {
            try
            {
                // add attendee to the event
                Data.AddAttendee(attendeeViewModel, this.User.Identity.Name);

                // Add another
                return RedirectToAction("Create", "Attendee", new { @eventName = attendeeViewModel.EventName });
            }
            catch
            {
                return View();
            }
        }

        //// GET: Attendee/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Attendee/Edit/5
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

        //// GET: Attendee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Attendee/Delete/5
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
