using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using c_sharpPortfolio.Models;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;


namespace c_sharpPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contactViewModel)
        {
        if (ModelState.IsValid)
        {
            try
                {
                //instantiate a new MimeMessage
                var message = new MimeMessage();
                //Setting the To e-mail address
                message.To.Add(new MailboxAddress("E-mail Recipient Name", "randocommando2345@gmail.com"));
                //Setting the From e-mail address
                message.From.Add(new MailboxAddress("E-mail From Name", "from@domain.com"));
                //E-mail subject 
                message.Subject = contactViewModel.typeof_app;
                //E-mail message body
                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = "Here is what they need" + contactViewModel.Comment + " Message was sent by: " + contactViewModel.first_name + contactViewModel.last_name + " E-mail: " + contactViewModel.email
                };

                //Configure the e-mail
                using (var emailClient = new SmtpClient())
                {
                    emailClient.Connect("smtp.gmail.com", 587, false);
                    emailClient.Authenticate("randocommando2345@gmail.com", "Rnuggins##23");
                    emailClient.Send(message);
                    emailClient.Disconnect(true);
                }
                }
                catch (Exception ex)
                {
                ModelState.Clear();
                ViewBag.Message = $" Oops! We have a problem here {ex.Message}";
                }
            }
            return View();
        }


    }
}
