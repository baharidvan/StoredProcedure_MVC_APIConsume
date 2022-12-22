using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApi.Entity
{
    [NotMapped]
    public class DoctorDepartment
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
    }
}
