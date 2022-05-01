using System;
using System.Collections.Generic;
using System.Text;
using CCSN.Models;

namespace CCSN.Models
{
    public class Specalist
    {

        public string Name { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public List<Patient> Patients { get; set; }

    }
}
