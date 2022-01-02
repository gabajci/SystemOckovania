using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemOckovania.Models
{
    public class Vaccinated
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int HospitalId { get; set; }
        public string VaccineName { get; set; }
        public int VaccineNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
