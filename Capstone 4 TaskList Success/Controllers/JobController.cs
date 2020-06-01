using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone_4_TaskList_Success.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone_4_TaskList_Success.Controllers
{
    public class JobController : Controller
    {
        private readonly JobDBContext _context;

        public JobController(JobDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Job> jobs = _context.Job.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ListJobs()
        {
            List<Job> jobs = _context.Job.ToList();
            return View(jobs);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }

        public IActionResult TickComplete(int Id)
        {
            Job oldJob = _context.Job.Find(d);

            if (ModelState.IsValid)
            {
                oldJob.Complete = !oldJob.Complete;

                _context.Entry(oldJob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(oldJob);
                _context.SaveChanges();
            }
            return RedirectToAction("ListJobs");
        }

        public IActionResult AddJob(Job newJob)
        {
            if(ModelState.IsValid)
            {
                _context.Job.Add(newJob);
                _context.SaveChanges();
            }
            return RedirectToAction("ListJobs");
        }

        public IActionResult UpdateJob(int id)
        {
            Job job = _context.Job.Find(id);
                return View(job);
        }

        [HttpPost]
        public IActionResult UpdateJob(Job newJob)
        {
            Job oldJob = _context.Job.Find(newJob.Id);

            if (ModelState.IsValid)
            {
                oldJob.Description = newJob.Description;
                oldJob.DueDate = newJob.DueDate;
                oldJob.Complete = newJob.Complete;
            

                _context.Entry(oldJob).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(oldJob);
                _context.SaveChanges();
            }

            return RedirectToAction("ListJobs");
        }

        public IActionResult DeleteJob(int id)
        {
            Job job = _context.Job.Find(id);
            if (job != null)
            {
                _context.Job.Remove(job);
                _context.SaveChanges();
            }

            return RedirectToAction("ListJobs");
        }

        public IActionResult Search()
        {

        }

    }
}