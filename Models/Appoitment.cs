﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CCSN.Models
{
    public class Appoitment
    {

        public string AppointmentPatientName { get; set; }
        public DateTime AppointmentDate { get; set; } //date picker
        public DateTime AppointmentTime { get; set; } //time picker 
        public string FollowUpDate { get; set; }
        public string FollowUpTools { get; set; }
        public string FollowUpGoals { get; set; }
        public string FollowUpAddNote { get; set; }

        public Appoitment()
        {
        }
        /*  public Appoitment(Appoitment instans)
          {
              AppointmentPatientName = instans.AppointmentPatientName;
              AppointmentDate = instans.AppointmentDate;
              AppointmentTime = instans.AppointmentTime;
              FollowUpDate = instans.FollowUpDate;
              FollowUpTools = instans.FollowUpTools;
              FollowUpGoals = instans.FollowUpGoals;
              FollowUpAddNote = instans.FollowUpAddNote;

          }*/
    }
}