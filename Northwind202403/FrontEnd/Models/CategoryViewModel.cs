using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class CategoryViewModel
    {


        [DisplayName("ID")]
        public int CategoryId { get; set; }
        [DisplayName("Name")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Nombre es requerido")]
        public string CategoryName { get; set; } = null!;
    }
}
