using HospitalWebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace HospitalWebApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(new Doctor[]
            {
                new(){Id=1, FullName= "Ahmet Büyük", DepartmentId=1, Age=32},
                new(){Id=2, FullName= "Mehmet Sancak", DepartmentId=2, Age=28},
                new(){Id=3, FullName= "Semih Boyer", DepartmentId=2, Age=36},
                new(){Id=4, FullName= "Ayşe Yalın", DepartmentId=3, Age=41},
                new(){Id=5, FullName= "Betül Kırmızı", DepartmentId=4, Age=35},
                new(){Id=6, FullName= "Fatma Yeşil", DepartmentId=2, Age=29},
                new(){Id=7, FullName= "Mehmet Sarac", DepartmentId=4, Age=51}
            });
            modelBuilder.Entity<Nurse>().HasData(new Nurse[]
            {
                new(){Id=1, FullName="Ayşe Sarı", DepartmentId=2, Age=23},
                new(){Id=2, FullName="Zehra Kurt", DepartmentId=1, Age=43},
                new(){Id=3, FullName="Emine Sancak", DepartmentId=1, Age=31},
                new(){Id=4, FullName="Ali Mert", DepartmentId=4, Age=25},
                new(){Id=5, FullName="Ece Berk", DepartmentId=4, Age=29},
                new(){Id=6, FullName="Hatice Canoglu", DepartmentId=3, Age=36},
                new(){Id=7, FullName="Ahmet Kiraz", DepartmentId=2, Age=45}
            });
            modelBuilder.Entity<Department>().HasData(new Department[]
            {
                new(){Id=1, Name="Dahiliye"},
                new(){Id=2, Name="KBB"},
                new(){Id=3, Name="Ortopedi"},
                new(){Id=4, Name="Cildiye"}
            });
            modelBuilder.Entity<Patient>().HasData(new Patient[]
            {
                new(){Id=1, FullName="Hasan Akçay", Age=23, DoctorId=1, NurseId=3},
                new(){Id=2, FullName="Şeyma Kural", Age=30, DoctorId=1,NurseId=2},
                new(){Id=3, FullName="Şamil Kaya", Age=16, DoctorId=2,NurseId=1},
                new(){Id=4, FullName="Ali Osman Kara", Age=20, DoctorId=3,NurseId=4},
                new(){Id=5, FullName="Filiz Köseoğlu", Age=30, DoctorId=4,NurseId=2},
                new(){Id=6, FullName="Feyza Duru", Age=52, DoctorId=7, NurseId=2},
                new(){Id=7, FullName="Ahsen Kırmızı", Age=56, DoctorId=5, NurseId=5},
                new(){Id=8, FullName="Büşra Aktay", Age=45, DoctorId=6, NurseId=6 },
                new(){Id=9, FullName="Kemal Dinçer", Age=33, DoctorId=4, NurseId=5},
                new(){Id=10, FullName="Fatma Yara", Age=54, DoctorId=7, NurseId=3},
                new(){Id=11, FullName="Mehmet Efe Can", Age=19, DoctorId=1, NurseId=5},
                new(){Id=12, FullName="Sümeyra Damla", Age=34, DoctorId=2, NurseId=6},
                new(){Id=13, FullName="Halil Merkez", Age=38, DoctorId=5, NurseId=1},
                new(){Id=14, FullName="Hasan Saran", Age=14, DoctorId=3, NurseId=4}
            });

            modelBuilder.Entity<DoctorDepartment>().HasNoKey();
            modelBuilder.Entity<PatientList>().HasNoKey();
            modelBuilder.Entity<DoctorList>().HasNoKey();
            //modelBuilder.Ignore<DoctorDepartment>();
            //modelBuilder.Ignore<PatientList>();

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DoctorDepartment> DoctorDepartments { get; set; }
        public DbSet<PatientList> PatientLists { get; set; }
        public DbSet<DoctorList> DoctorLists { get; set; }

    }
}
