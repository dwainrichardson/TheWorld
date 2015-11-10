using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Linq;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{

    public class AppController: Controller
    {
        private IMailService _mailService;
        private WorldContext _context;

        public AppController(IMailService service, WorldContext context)
        {
            _mailService = service;
            _context = context;
        }

        public IActionResult Index()
        {

            var trips = _context.Trips.OrderBy(t => t.TripName).ToList();
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contact)
        {

            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "email not configured");
                }

                if (_mailService.SendMail(email, email, $"Contact Page from {contact.Name}  ({contact.Email})", contact.Message))
                {
                    ModelState.Clear();

                    ViewBag.Message = "Email has been sent successfully.";

                }
            }
       
            return View();
        }
    }
}