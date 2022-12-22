using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApi.Entity
{
    [NotMapped]
    public class PatientList
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
        public string DoctorName { get; set; }
        public string NurseName { get; set; }
    }
}
