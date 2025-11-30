using System.Diagnostics;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Prensenter.Models;

namespace Prensenter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
