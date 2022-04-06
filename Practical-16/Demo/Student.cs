using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string firstname { get; set; }
        [Required]
        public string lastname { get; set; }

        [Required]
        public int mobile { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}") ]
        public DateTime DOB { get; set; }

    }
}
