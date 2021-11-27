using System;

namespace SystemOckovania.Models
{
    public class Vaccinated
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string VaccineName { get; set; }
        public int VaccineNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
