using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
  public class Doctor
  {
    [Key]
    public int docID { get; set; }
    public string name { get; set; }
    public string speciality { get; set; }
    public bool isActive { get; set; }
    public List<Appointment> appointments { get; set; }
  }

  public class Patient
  {
    [Key]
    public int patId { get; set; }
    public string patName { get; set; }
    public string dob { get; set; }
    List<Appointment> appointments { get; set; }
      }

    public class Appointment
    {
        [Key]
        public int apptID { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }

    }
    public class ChartRoot
  {
    //public Quote[] chart { get; set; }
  }
}