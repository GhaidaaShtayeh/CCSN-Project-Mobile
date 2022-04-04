using System;
using System.Collections.Generic;
using System.Text;
using CCSN.Models;

namespace CCSN.Models
{
    public class Patient
    {
        public string ID { get; set; }
        public string PatientName { get; set; }
        public string PatientGender { get; set; }
        public string PatientAddress { get; set; }
        public int PatientWeight { get; set; }
        public int PatientHeight { get; set; }
        public string PatientMobileNO { get; set; }
        public string PatientBirthday { get; set; }
        public string PatientGenticesDiseses { get; set; }

        public List<Appoitment> Appointments { get; set; }
    }
}
