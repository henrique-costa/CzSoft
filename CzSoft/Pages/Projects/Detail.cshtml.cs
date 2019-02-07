using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzSoft.Core;
using CzSoft.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CzSoft.Pages.Projects
{
    public class DetailModel : PageModel
    {
        private readonly IProjectData projectData;
        public Project Project { get; set; }
        [TempData]
        public string Message { get; set; }


        public DetailModel(IProjectData projectData)
        {
            this.projectData = projectData;
        }

        
        public IActionResult OnGet(int projectId)
        {
            Project = projectData.GetById(projectId);
            if (Project == null)
            {
                //D:\Users\henri\Desktop\Projects\CzSoft\CzSoft\Pages\Shared\ErrorPages\_NotFound.cshtml
                return RedirectToPage("../Shared/ErrorPages/_NotFound");
            }
            return Page();
        }
    }
}