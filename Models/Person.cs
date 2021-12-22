using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemOckovania.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
    }
}
