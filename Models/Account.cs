using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemOckovania.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int Admin { get; set; }
        public string StoredSalt { get; set; }
    }
}
