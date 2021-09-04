using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace misV3.Models
{
    public class Emails
    {
        [Key]
        public int EmailId { get; set; }
        public string EmailName { get; set; }
        public string Emailem { get; set; }
        public string EmailPass { get; set; }
        public string Department { get; set; }
        public string Branch { get; set; }
        

    }
}
