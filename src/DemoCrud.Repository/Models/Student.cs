using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoCrud.Repository.Models
{
    public class Student : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public int RollNo { get; set; }
    }
}
