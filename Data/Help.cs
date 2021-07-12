using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace testASPwMvc.Data
{
    public class Help
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }

    }
}
