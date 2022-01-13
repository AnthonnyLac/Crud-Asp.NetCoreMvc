using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using New_World.Models;

namespace New_World.Controllers
{
    public class SingUp : Controller
    {

        [HttpPost]
        public IActionResult SaveSingUp(string user)
        {
            string connectStringDb = ConnectDb.ConnectString;
            string commandDb = $"insert into champions (Name) values ('{user}');";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectStringDb;
                SqlCommand command = new SqlCommand(commandDb, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
            }
            ViewData["user"] = user;
            return View();
        }

        public IActionResult DeleteUser(int id)
        {
            string connectStringDb = ConnectDb.ConnectString;
            string commandDb = $"Delete from champions where Id = {id};";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectStringDb;
                SqlCommand command = new SqlCommand(commandDb, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
            }
            return View();
        }

        public IActionResult UpdateUser(string newName, int id)
        {
            string connectionStringDb = ConnectDb.ConnectString;
            string commandDb = $"Update Champions Set Name = '{newName}' Where Id = '{id}'";

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionStringDb;
                SqlCommand command = new SqlCommand(commandDb, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
            }
            return View();
        }
    }
}
