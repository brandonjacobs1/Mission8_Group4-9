using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MIssion6_jacobs27.Models;
using Mission8_Group4_9.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group4_9.Controllers
{
    public class HomeController : Controller
    {

        private TaskContext taskContext { get; set; }

        public HomeController(TaskContext someName)
        {
            taskContext = someName;
        }

        

        public IActionResult Index()
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




        //Task forum functionality here

        [HttpGet]
        public IActionResult TaskForumNAME()
        {
            // Change Categories name to match 
            // Change categories depending on TaskContect db name
            ViewBag.Categories = taskContext.categories.ToList();

            return View();
        }

        //Change name to correct nmdoel name
        [HttpPost]
        public IActionResult TaskForumNAME(Tasks ar)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(ar);
                taskContext.SaveChanges();
                return View("Confirmation", ar);

            }
            else
            {
                //Change both categories names
                ViewBag.Categories = taskContext.categories.ToList();
                return View(ar);
            }
        }






        //View the tasks

        //May need to change ViewTasks name
        [HttpGet]
        public IActionResult ViewTasks()
        {
            //change responses to the task name in the context file and Category as well in the models
            var applications = taskContext.Tasks
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();
            return View(applications);
        }





        //These are the edit functions


        //this takforumid can be whatever name
        [HttpGet]
        public IActionResult Edit(int taskforumid)
        {
            ViewBag.Categories = taskContext.categories.ToList();

            //Change the Capital taskforumID to the right one
            var application = taskContext.Tasks.Single(x => x.MovieForumID == taskforumid);

            //Chnage TaskForum to whatever it is
            return View("TaskForum", application);
        }


        //Name should be right for task
        [HttpPost]
        public IActionResult Edit(Tasks blah)
        {


            taskContext.Update(blah);
            taskContext.SaveChanges();

            //ViewTasks may be different
            return RedirectToAction("ViewTasks");


        }








        // These are the delete functions

        [HttpGet]
        public IActionResult Delete(int taskforumid)
        {
            //Change id to the right id
            var application = taskContext.Tasks.Single(x => x.MovieForumID == taskforumid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(Tasks blah)
        {
            //FIX THIS
            taskContext.Tasks.Remove(blah);
            taskContext.SaveChanges();


            return RedirectToAction("ViewTasks");
        }

    }
}

//Making some somments
