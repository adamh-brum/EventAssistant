using EventAssistant.Models;
using EventAssistant.Web.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventAssistant.Web.Data
{
    public static class Data
    {
        public static void AddAttendee(AttendeeViewModel collection, string userName)
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>();
            using (var db = new ApplicationDbContext(options))
            {
                var userData = db.UserData.FirstOrDefault(u => u.UserName == userName);
                var eventViewModel = userData.Events.FirstOrDefault(e => e.Name == collection.EventName);
                eventViewModel.Attendees.Add(collection);

                db.SaveChanges();
            }
        }

        public static void AddEvent(EventViewModel eventViewModel, string userName)
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>();
            using (var db = new ApplicationDbContext(options))
            {
                var userData = db.UserData.FirstOrDefault(u => u.UserName == userName);

                if (userData == null)
                {
                    userData = new UserData()
                    {
                        UserName = userName,
                        Events = new List<EventViewModel>() { eventViewModel }
                    };

                    db.UserData.Add(userData);
                }
                else
                {
                    userData.Events.Add(eventViewModel);
                }

                db.SaveChanges();
            }
        }

        private static IEnumerable<EventViewModel> GetEvents(string userName)
        {
            UserData userData = new UserData();
            var options = new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>();
            using (var db = new ApplicationDbContext(options))
            {
                userData = db.UserData.FirstOrDefault(u => u.UserName == userName);
            }

            return userData.Events;
        }
    }
}