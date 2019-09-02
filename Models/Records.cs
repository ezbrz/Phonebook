using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Phonebook.Models
{
    public class Records
    {
        [Required(ErrorMessage = "Error! Required")]
        [Display(Name = "firstName")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Error! Required")]
        [Display(Name = "surName")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Error! Required")]
        [Display(Name = "birthYear")]
        [Range(1900, 2019, ErrorMessage = "Must be between 1900 and 2019")]
        public int birthYear { get; set; }


        [Required(ErrorMessage = "Error! Required")]
        [Display(Name = "phoneNum")]
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "Wrong number, must contain 11 d")]
        public string phoneNum { get; set; }
    }

}