namespace HospitalWebApi.Entity
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int? DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int? NurseId { get; set; }
        public Nurse Nurse { get; set; }
    }
}
