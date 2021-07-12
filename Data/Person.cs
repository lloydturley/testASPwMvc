using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testASPwMvc.Data
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Help> Helps { get; set; }
    }
}
