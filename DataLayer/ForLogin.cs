using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnluCo.Bank.DataLayer
{
    public class ForLogin
    {
        [Required(ErrorMessage = "Required Space")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required Space")]
        public string Pass { get; set; }
    }
}
