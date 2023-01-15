/*using System;
using System.Collections.Generic;*/
using DogApiMVCProject.Models;
/*using DogApiMVCProject.OracleDataProvider;*/
using DogApiMVCProject.OracleDataProvider.OracleDBContext;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
/*using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;*/

namespace DogApiMVCProject.Controllers
{
    public class RegFormController : Controller
    {
        private readonly OracleDBContext _context;

        public RegFormController(OracleDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            List<RegForm> data = new();

            using (OracleConnection connection = _context.GetConnection())
            {
                _context.OpenConnection(connection);
                using (OracleCommand command = _context.GetCommand("SELECT * FROM DogRegistrationForm", connection))
                {
                    using OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        data.Add(new RegForm
                        {
                            Registrationid = reader.GetInt64(0),
                            DogName = reader.GetString(1),
                            DogBreed = reader.GetString(2),
                            DogAge = reader.GetString(3),
                            DogHeight = reader.GetDouble(4),
                            DogLength = reader.GetDouble(5),
                            DogWeight = reader.GetInt32(6)
                        });
                    }
                }
                _context.CloseConnection(connection);
            }

            return Ok(data);
        }

    }

}