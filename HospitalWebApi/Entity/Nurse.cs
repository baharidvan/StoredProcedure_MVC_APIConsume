namespace HospitalWebApi.Entity
{
    public class Nurse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }  
        public int Age { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
