using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_CRUD_DEMO.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Name can only be 50 character long")]
        public string Name { get; set; }
    }
}
