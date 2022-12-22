using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalWebApi.Migrations
{
    /// <inheritdoc />
    public partial class spGetDoctorsWithNumberOfPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                                CREATE PROCEDURE sp_GetDoctorsWithNumberOfPatients
                                AS
                                SELECT d.FullName, d.Age, COUNT(p.Id) AS NumberofPatients, dep.Name AS DepartmentName
                                FROM Doctors d
                                LEFT JOIN Patients p
                                ON d.Id = p.DoctorId
                                LEFT JOIN Departments dep
                                ON dep.Id = d.DepartmentId
                                GROUP BY d.FullName, d.Age, dep.Name
                                HAVING d.Age > 30
                                ORDER BY COUNT(p.Id) DESC
                                "); 
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_GetDoctorsWithNumberOfPatients");

        }
    }
}
