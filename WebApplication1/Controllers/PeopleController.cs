using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PeopleController : Controller
    {
        PeopleService peopleServices = new PeopleService();

        [HttpGet]
        public IActionResult Index()
        {
            return View(peopleServices.All());
        }

        [HttpPost]
        public JsonResult Create([FromBody] CreatePersonViewModel model)
        {
            peopleServices.Add(model);
            return Json(peopleServices.All());
        }

        [HttpPost]
        public IActionResult Index([FromBody] PeopleViewModel model)
        {
            return View(peopleServices.FindBy(model));
        }

        [HttpPost]
        public IActionResult Delete([FromBody] int Id)
        {
            return View(peopleServices.Remove(Id));
        }


   

    }
}
