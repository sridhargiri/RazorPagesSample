using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [Required(ErrorMessage = "Value required")]
        public string JobTitle { get; set; }
        public string ProfileData { get; set; }
        [Required(ErrorMessage = "Value required")]
        public string CompanyInfo { get; set; }
        [Required(ErrorMessage = "Value required")]
        public string JobTask { get; set; }
        [Required(ErrorMessage = "Value required")]
        public string CandidateProfile { get; set; }
        [Required(ErrorMessage = "Value required")]
        public string ApplicationInfo { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string id)
        {

            if (id != null)
            {
                using (var context = new JobDataContext())
                {
                    var found = context.Job.Where(x => x.Id.ToString() == id).FirstOrDefault();
                    if (found != null)
                    {
                        Id = Id;
                        JobTitle = found.JobTitle;
                        ProfileData = found.ProfileData;
                        CompanyInfo = found.CompanyInfo;
                        ApplicationInfo = found.ApplicationInfo;
                        CandidateProfile = found.CandidateProfile;
                        JobTask = found.JobTask;
                    }
                }
            }
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                using (var context = new JobDataContext())
                {
                    var updatefound = context.Job.Where(x => x.Id.ToString() == Id).FirstOrDefault();
                    if (updatefound != null)
                    {
                        updatefound.JobTitle = JobTitle;
                        updatefound.ProfileData = ProfileData;
                        updatefound.CompanyInfo = CompanyInfo;
                        updatefound.CandidateProfile = CandidateProfile;
                        updatefound.ApplicationInfo = ApplicationInfo;
                        updatefound.JobTitle = JobTitle;
                        context.SaveChanges();
                        ViewData["msd"] = $"Data updated";
                    }
                    else
                    {
                        var job = new Job()
                        {
                            JobTitle = JobTitle,
                            ProfileData = ProfileData,
                            CompanyInfo = CompanyInfo,
                            ApplicationInfo = ApplicationInfo,
                            CandidateProfile = CandidateProfile,
                            JobTask = JobTask
                        };
                        context.Job.Add(job);
                        context.SaveChanges();

                        ViewData["msd"] = $"Data saved. id = {job.Id}";
                    }
                    ViewData["css"] = "alert-success";
                }
            }
            else
            {
                ViewData["msd"] = $"One or more input files are empty";
                ViewData["css"] = "alert-danger";
                ModelState.AddModelError("error", "Validation errors occured");
            }
        }
    }
}
