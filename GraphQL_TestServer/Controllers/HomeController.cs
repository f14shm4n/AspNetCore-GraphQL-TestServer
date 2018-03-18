using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL_TestServer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello, this is home page.");
        }
    }
}