using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BankAccountDetails
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string name { get; set; }

        public int amount { get; set; }
        [MaxLength(50)]
        public string Adress { get; set; }
        [ForeignKey("BankAccount")]
        public int bank_AccountsID { get; set; }
    }
}
