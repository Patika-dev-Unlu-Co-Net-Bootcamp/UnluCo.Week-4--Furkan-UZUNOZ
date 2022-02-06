using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BankAccount
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankAccountID { get; set; }

        [MaxLength(50)]
        public string tcNumber { get; set; }

        [MaxLength(50)]
        public string Pass { get; set; }
    }
}
