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
        public IActionResult AddTask()
        {
            // Change Categories name to match 
            ViewBag.Categories = taskContext.Categories.ToList();

            return View();
        }

        //Change name to correct model name
        [HttpPost]
        public IActionResult AddTask(Tasks ar)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(ar);
                taskContext.SaveChanges();

                //Change where the view goes to
                return View("Confirmation",ar);
            }
            else
            {
                ViewBag.Categories = taskContext.Categories.ToList();
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
                .ToList();
            return View(applications);
        }





        //These are the edit functions


        [HttpGet]
        public IActionResult Edit(int taskforumid)
        {
            ViewBag.Categories = taskContext.Categories.ToList();

            var application = taskContext.Tasks.Single(x => x.TaskID == taskforumid);

            //Chnage TaskForum to whatever it is
            return View("AddTask", application);
        }


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
            var application = taskContext.Tasks.Single(x => x.TaskID == taskforumid);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(Tasks blah)
        {
            taskContext.Tasks.Remove(blah);
            taskContext.SaveChanges();

            //Change to the right action
            return RedirectToAction("ViewTasks");
        }

    }
}

//Making some somments
