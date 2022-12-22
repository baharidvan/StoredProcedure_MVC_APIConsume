using HospitalWebApi.Data;
using HospitalWebApi.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class HomeController : ControllerBase
    {
        private readonly DataContext _context;
        public HomeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public ActionResult Index()
        {
            //var doctorList = context.Doctors.FromSqlRaw<Doctor>("spGetDoctors").ToList();
            var doctorsOldAge = _context.DoctorDepartments.FromSql($"EXEC sp_GetDoctorsOldAge").ToList();
            //Console.WriteLine();
            return Ok(doctorsOldAge);
        }
        [HttpGet("[action]")]
        public IActionResult GetDoctors()
        {
            var doctorList = _context.DoctorLists.FromSql($"EXEC sp_GetDoctorsWithNumberOfPatients").ToList();
            return Ok(doctorList);
        }
    }
}
