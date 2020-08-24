using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
  public class DatabaseExampleController : Controller
  {
    public ApplicationDbContext dbContext;

    public DatabaseExampleController(ApplicationDbContext context)
    {
      dbContext = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<ViewResult> DatabaseOperations()
    {
      // CREATE operation
      Doctor MyDoctor = new Doctor();
      //MyDoctor.docID = 454329;
      MyDoctor.name = "Pamela Johnson";
      MyDoctor.speciality = "General";
      MyDoctor.isActive = true;

      Patient MyPatient1 = new Patient();
      //MyPatient1.patId = 9878009;
      MyPatient1.patName = "Timothy Smith";
      MyPatient1.dob = "3-12-1980";

      Patient MyPatient2 = new Patient();
      //MyPatient2.patId = 9489324;
      MyPatient2.patName = "Patricia Smith";
      MyPatient2.dob = "5-12-1981";

      Appointment MyAppointment1 = new Appointment();
      //MyAppointment1.apptID = 9878009;
      MyAppointment1.date = "6-11-2020";
      MyAppointment1.time = "3:15 pm";
      MyAppointment1.doctor = MyDoctor;
      MyAppointment1.patient = MyPatient1;

      dbContext.Doctors.Add(MyDoctor);
      dbContext.Patients.Add(MyPatient1);
      dbContext.Patients.Add(MyPatient2);
      dbContext.Appointments.Add(MyAppointment1);

      dbContext.SaveChanges();
      
      // READ operation
      //Company CompanyRead1 = dbContext.Companies
      //                        .Where(c => c.symbol == "MCOB")
      //                        .First();

      //Company CompanyRead2 = dbContext.Companies
      //                        .Include(c => c.Quotes)
      //                        .Where(c => c.symbol == "MCOB")
      //                        .First();

      //// UPDATE operation
      //CompanyRead1.iexId = "MCOB";
      //dbContext.Companies.Update(CompanyRead1);
      ////dbContext.SaveChanges();
      //await dbContext.SaveChangesAsync();
      
      //// DELETE operation
      ////dbContext.Companies.Remove(CompanyRead1);
      ////await dbContext.SaveChangesAsync();

      return View(MyAppointment1);
    }

    public ViewResult LINQOperations()
    {
            Appointment AppointmentRead1 = dbContext.Appointments
                                            .Where(c => c.apptID == 1)
                                            .First();

            Appointment AppointmentRead2 = dbContext.Appointments
                                            .Include(c => c.patient)
                                            .Where(c => c.apptID == 1)
                                            .First();

            Appointment PatientRead = dbContext.Appointments
                                    .Include(c => c.patient)
                                    .Where(c => c.apptID == 1)
                                    .FirstOrDefault();


            return View(AppointmentRead2);
    }

  }
}