using System.Diagnostics;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Prensenter.Models;

namespace Prensenter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetPeopleListUseCase _useCasePeopleList;

        public HomeController(ILogger<HomeController> logger, IGetPeopleListUseCase useCaseListaPersonas)
        {
            _logger = logger;
            _useCasePeopleList = useCaseListaPersonas;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowOnePerson()
        {
            return View(_useCasePeopleList.GetPeopleList());
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
