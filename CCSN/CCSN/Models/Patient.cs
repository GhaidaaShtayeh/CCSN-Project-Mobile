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
        public string PatientWeight { get; set; }
        public string PatientHeight { get; set; }
        public string PatientMobileNO { get; set; }
        public string PatientBirthday { get; set; }
        public string PatientGenticesDiseses { get; set; }

        public Dictionary<string, Appoitment> Appointments { get; set; }


        public Patient()
        {

        }

        public Patient(Patient instans)
        {
            ID = instans.ID;
            PatientName = instans.PatientName;
            PatientGender = instans.PatientGender;
            PatientAddress = instans.PatientAddress;
            PatientWeight = instans.PatientWeight;
            PatientHeight = instans.PatientHeight;
            PatientMobileNO = instans.PatientMobileNO;
            PatientGenticesDiseses = instans.PatientGenticesDiseses;
            Appointments = instans.Appointments;

        }
    }
    }

