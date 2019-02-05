using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace CzSoft.Pages.Projects
{
    public class ListModel : PageModel
    {
        //Interface used to push a msg or data from appsettings
        private readonly IConfiguration configuration;

        public string Message { get; set; }

        //teste

        //DI
        public ListModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            //Push a msg or data from appsettings
            Message = configuration["Message"];
        }
    }
}