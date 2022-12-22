using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HospitalWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Nurses_NurseId",
                        column: x => x.NurseId,
                        principalTable: "Nurses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dahiliye" },
                    { 2, "KBB" },
                    { 3, "Ortopedi" },
                    { 4, "Cildiye" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "DepartmentId", "FullName" },
                values: new object[,]
                {
                    { 1, 32, 1, "Ahmet Büyük" },
                    { 2, 28, 2, "Mehmet Sancak" },
                    { 3, 36, 2, "Semih Boyer" },
                    { 4, 41, 3, "Ayşe Yalın" },
                    { 5, 35, 4, "Betül Kırmızı" },
                    { 6, 29, 2, "Fatma Yeşil" },
                    { 7, 51, 4, "Mehmet Sarac" }
                });

            migrationBuilder.InsertData(
                table: "Nurses",
                columns: new[] { "Id", "Age", "DepartmentId", "FullName" },
                values: new object[,]
                {
                    { 1, 23, 2, "Ayşe Sarı" },
                    { 2, 43, 1, "Zehra Kurt" },
                    { 3, 31, 1, "Emine Sancak" },
                    { 4, 25, 4, "Ali Mert" },
                    { 5, 29, 4, "Ece Berk" },
                    { 6, 36, 3, "Hatice Canoglu" },
                    { 7, 45, 2, "Ahmet Kiraz" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Age", "DoctorId", "FullName", "NurseId" },
                values: new object[,]
                {
                    { 1, 23, 1, "Hasan Akçay", 3 },
                    { 2, 30, 1, "Şeyma Kural", 2 },
                    { 3, 16, 2, "Şamil Kaya", 1 },
                    { 4, 20, 3, "Ali Osman Kara", 4 },
                    { 5, 30, 4, "Filiz Köseoğlu", 2 },
                    { 6, 52, 7, "Feyza Duru", 2 },
                    { 7, 56, 5, "Ahsen Kırmızı", 5 },
                    { 8, 45, 6, "Büşra Aktay", 6 },
                    { 9, 33, 4, "Kemal Dinçer", 5 },
                    { 10, 54, 7, "Fatma Yara", 3 },
                    { 11, 19, 1, "Mehmet Efe Can", 5 },
                    { 12, 34, 2, "Sümeyra Damla", 6 },
                    { 13, 38, 5, "Halil Merkez", 1 },
                    { 14, 14, 3, "Hasan Saran", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_DepartmentId",
                table: "Nurses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_NurseId",
                table: "Patients",
                column: "NurseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Nurses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
