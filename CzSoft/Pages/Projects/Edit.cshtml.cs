using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzSoft.Core;
using CzSoft.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CzSoft.Pages.Projects
{
    public class EditModel : PageModel
    {
        //services
        private readonly IProjectData _ProjectData;
        private readonly IHtmlHelper htmlHelper;

        //prop
        [BindProperty]
        public Project Project { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; } // Usado para pegar os Enums
        
        //ctor DI
        public EditModel(IProjectData _projectData, IHtmlHelper htmlHelper)
        {
            _ProjectData = _projectData;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(int? projectId)
        {
            //busca os enums
            Types = htmlHelper.GetEnumSelectList<ProjectType>();
            if (projectId.HasValue)
            {
                Project = _ProjectData.GetById(projectId.Value);
            }
            else
            {
                Project = new Project() { CreationDate = DateTime.Now.ToShortDateString() };
            }


            if (Project == null)
            {
                return RedirectToPage("../Shared/ErrorPages/_NotFound");
            }
            return Page();
        }



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
              
                //busca os enums
                Types = htmlHelper.GetEnumSelectList<ProjectType>();
                return Page();
            }

            if (Project.Id > 0)
            {
                Project = _ProjectData.Update(Project);
            }
            else
            {
                Project.CreationDate = DateTime.Now.ToShortDateString();
                _ProjectData.Create(Project);
            }
            _ProjectData.Commit();
            TempData["Message"] = "Projeto salvo!!!";
            return RedirectToPage("./Detail", new { projectId = Project.Id });



        }
    }
}