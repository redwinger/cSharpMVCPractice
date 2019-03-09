using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ultimateMVC.Models;

namespace ultimateMVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<string> _userInputList = new List<string>();

        [HttpGet]
        public IActionResult Index()
        {
            var formModel = new HomeModel()
            {
                UserInputList = new List<string>()
            };

            return View(formModel);
        }

        [HttpPost]
        public IActionResult Index(HomeModel formModel)
        {
            var userInput = formModel.UserInput;

            _userInputList.Add(userInput);
            formModel.UserInputList = _userInputList;

            return View(formModel);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
