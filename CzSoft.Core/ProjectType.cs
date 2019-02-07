using System.ComponentModel.DataAnnotations;

namespace CzSoft.Core
{
    public enum ProjectType
    {
        [Display(Name = "Nenhum")]
        None,
        [Display(Name = "Media Social")]
        MediaDigital,
        Flyer,
        Tipo4,
        Tipo5,
        Tipo6

    }
}
