using EventAssistant.Models;
using EventAssistant.Web.Data;
using Microsoft.Extensions.Configuration;
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
            // Get an instance of the DB
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
            string connectionString = GetConnectionString();
            using (var context = EventContextFactory.Create(connectionString))
            {
                context.Add(eventViewModel);
                context.SaveChanges();
            }

            //var options = new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>();
            //using (var db = new ApplicationDbContext(options))
            //{
            //    var userData = db.UserData.FirstOrDefault(u => u.UserName == userName);

            //    if (userData == null)
            //    {
            //        userData = new UserData()
            //        {
            //            UserName = userName,
            //            Events = new List<EventViewModel>() { eventViewModel }
            //        };

            //        db.UserData.Add(userData);
            //    }
            //    else
            //    {
            //        userData.Events.Add(eventViewModel);
            //    }

            //    db.SaveChanges();
            //}
        }

        private static string GetConnectionString()
        {
            return "server=localhost;userid=root;pwd=;port=3305;database=sakila;sslmode=none;";

        //    var builder = new ConfigurationBuilder()
        //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            //    var configuration = builder.Build();

            //    return configuration.GetConnectionString("DefaultConnection");
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