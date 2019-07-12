using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoCrud.Repository.Models
{
    public class Course : BaseEntity
    {
        [Required,MaxLength(50)]
        public string Name { get; set; }

    }
}
