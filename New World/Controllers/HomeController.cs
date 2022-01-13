using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using New_World.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace New_World.Controllers
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

        public IActionResult List()
        {
            //lendo valores do appsettings
            string connectStringDb = ConnectDb.ConnectString;
            string commandDb = "Select * From champions;";

            List<NewWorldDb> newWorldDbs = new List<NewWorldDb>();

            using (SqlConnection connection = new SqlConnection(connectStringDb))
            {
                SqlCommand command = new SqlCommand(commandDb, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    newWorldDbs.Add(new NewWorldDb { Id = Convert.ToInt32(reader["Id"]), Name = String.Format("{0}", reader["Name"]) });
                }
                ViewBag.Lista = newWorldDbs;

            }
            return View();
        }

        public IActionResult DeleteUser() 
        {
            
            return View();
        }
        public IActionResult EditUser() 
        {
            return View();
        }

        public IActionResult SingUp() 
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
