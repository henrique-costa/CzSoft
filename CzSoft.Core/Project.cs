using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CzSoft.Core
{

    public class Project
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public ProjectType Type { get; set; }

        [Display(Name = "Data de criação")]
        public string CreationDate { get; set; }

    }
}
