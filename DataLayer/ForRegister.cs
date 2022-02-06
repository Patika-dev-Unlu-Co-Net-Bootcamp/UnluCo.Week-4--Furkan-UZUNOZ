using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnluCo.Bank.DataLayer
{
    public class ForRegister
    {
        [Required(ErrorMessage ="Required Space")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required Space")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required Space")]
        public string Pass { get; set; }
        [Required(ErrorMessage = "Required Space")]
        public string Name { get; set; }
        [Required]
        public string MotherOldLastname { get; set; }
     

    }
}
