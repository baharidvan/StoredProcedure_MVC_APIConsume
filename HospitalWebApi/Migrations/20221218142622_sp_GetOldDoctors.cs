using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalWebApi.Migrations
{
    /// <inheritdoc />
    public partial class spGetOldDoctors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                        CREATE PROCEDURE sp_GetDoctorsOldAge
                        AS
                        SELECT d.FullName, d.Age, o.Name AS DepartmentName FROM Doctors d
                        LEFT JOIN Departments o
                        ON d.DepartmentId = o.Id
                        GROUP BY d.FullName, d.Age, o.Name
                        HAVING d.Age > (SELECT AVG(Age) FROM Doctors)
                        ORDER BY d.FullName DESC
                        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP PROC sp_GetDoctorsOldAge");
        }
    }
}
