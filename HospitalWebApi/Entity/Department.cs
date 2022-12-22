namespace HospitalWebApi.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Nurse> Nurses { get; set; }

    }
}
