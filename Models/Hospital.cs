using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemOckovania.Models
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostCode { get; set; }
        public string Director { get; set; }
        public string Contact { get; set; }
        public int DailyVaccinatedCapacity { get; set; }
        public int BreathSupportCapacity { get; set; }
    }
}
