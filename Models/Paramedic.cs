using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemOckovania.Models
{
    public class Paramedic
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public int Role { get; set; }
        public int YearsInPractise { get; set; }
    }
}
