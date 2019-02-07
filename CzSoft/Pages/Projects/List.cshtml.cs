using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CzSoft.Core;
using CzSoft.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CzSoft.Pages.Projects
{
    public class ListModel : PageModel
    {
        //Interface used to push a msg or data from appsettings
        private readonly IConfiguration configuration;

        private readonly IProjectData projectData;

        public string Message { get; set; }

        public IEnumerable<Project> Projects;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }              
       
        //DI
        public ListModel(IConfiguration configuration, IProjectData projectData)
        {
            this.configuration = configuration;
            this.projectData = projectData;
        }

        public void OnGet(string searchTerm)
        {
            //Push a msg or data from appsettings
            Message = configuration["Message"];

            Projects = projectData.GetProjectByName(SearchTerm);
        }
    }
}