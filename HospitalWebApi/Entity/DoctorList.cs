using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalWebApi.Entity
{
    [NotMapped]
    public class DoctorList
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public int numberOfPatients { get; set; }
        public string DepartmentName { get; set; }
    }
}
