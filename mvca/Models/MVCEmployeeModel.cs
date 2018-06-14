using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvca.Models
{
    public class MVCEmployeeModel
    {
        [Required(ErrorMessage = "This Field is Required")]
        public int EmployeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}