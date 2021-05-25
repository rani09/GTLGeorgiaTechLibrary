using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTLCore
{
    public class Member
    {
        public int ssn { get; set; }
        public bool is_professor { get; set; }
        public string campus_address { get; set; }
        public int person { get; set; }
    }
}
