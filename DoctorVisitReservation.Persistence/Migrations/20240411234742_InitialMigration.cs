using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoctorVisitReservation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorDailySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorDailySchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    University = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetType = table.Column<int>(type: "int", nullable: false),
                    SubmittedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorEducations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorEducations_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSpecializations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecializations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalServices_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TreatedDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SpecializationId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatedDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreatedDiseases_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DoctorMedicalServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalServiceId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorMedicalServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorMedicalServices_MedicalServices_MedicalServiceId",
                        column: x => x.MedicalServiceId,
                        principalTable: "MedicalServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorTreatedDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatedDiseaseId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorTreatedDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorTreatedDiseases_TreatedDiseases_TreatedDiseaseId",
                        column: x => x.TreatedDiseaseId,
                        principalTable: "TreatedDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Warszawa" },
                    { 2, null, null, null, null, "Kraków" },
                    { 3, null, null, null, null, "Łódź" },
                    { 4, null, null, null, null, "Wrocław" },
                    { 5, null, null, null, null, "Poznań" },
                    { 6, null, null, null, null, "Gdańsk" },
                    { 7, null, null, null, null, "Szczecin" },
                    { 8, null, null, null, null, "Bydgoszcz" },
                    { 9, null, null, null, null, "Lublin" },
                    { 10, null, null, null, null, "Katowice" },
                    { 11, null, null, null, null, "Białystok" },
                    { 12, null, null, null, null, "Gdynia" },
                    { 13, null, null, null, null, "Częstochowa" },
                    { 14, null, null, null, null, "Radom" },
                    { 15, null, null, null, null, "Sosnowiec" },
                    { 16, null, null, null, null, "Toruń" },
                    { 17, null, null, null, null, "Kielce" },
                    { 18, null, null, null, null, "Gliwice" },
                    { 19, null, null, null, null, "Zabrze" },
                    { 20, null, null, null, null, "Bytom" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "University" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Uniwersytet Medyczny w Łodzi" },
                    { 2, null, null, null, null, "Uniwersytet Medyczny w Warszawie" },
                    { 3, null, null, null, null, "Uniwersytet Medyczny w Krakowie" },
                    { 4, null, null, null, null, "Uniwersytet Medyczny we Wrocławiu" },
                    { 5, null, null, null, null, "Gdański Uniwersytet Medyczny" },
                    { 6, null, null, null, null, "Poznański Uniwersytet Medyczny" }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Dermatologia" },
                    { 2, null, null, null, null, "Kardiologia" },
                    { 3, null, null, null, null, "Neurologia" },
                    { 4, null, null, null, null, "Pediatria" },
                    { 5, null, null, null, null, "Endokrynologia" },
                    { 6, null, null, null, null, "Ginekologia" },
                    { 7, null, null, null, null, "Psychiatria" }
                });

            migrationBuilder.InsertData(
                table: "MedicalServices",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name", "SpecializationId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Konsultacja dermatologiczna", 1 },
                    { 2, null, null, null, null, "Usuwanie znamion", 1 },
                    { 3, null, null, null, null, "Leczenie trądziku", 1 },
                    { 4, null, null, null, null, "Badanie EKG", 2 },
                    { 5, null, null, null, null, "Test wysiłkowy", 2 },
                    { 6, null, null, null, null, "Holter EKG", 2 },
                    { 7, null, null, null, null, "EEG", 3 },
                    { 8, null, null, null, null, "Badanie EMG", 3 },
                    { 9, null, null, null, null, "Konsultacje neurologiczne", 3 },
                    { 10, null, null, null, null, "Badanie pediatryczne", 4 },
                    { 11, null, null, null, null, "Szczepienia dzieci", 4 },
                    { 12, null, null, null, null, "Poradnictwo żywieniowe dla dzieci", 4 },
                    { 13, null, null, null, null, "Badanie poziomu hormonów", 5 },
                    { 14, null, null, null, null, "USG tarczycy", 5 },
                    { 15, null, null, null, null, "Konsultacja endokrynologiczna", 5 },
                    { 16, null, null, null, null, "Badanie ginekologiczne", 6 },
                    { 17, null, null, null, null, "USG ginekologiczne", 6 },
                    { 18, null, null, null, null, "Cytologia", 6 },
                    { 19, null, null, null, null, "Konsultacja psychiatryczna", 7 },
                    { 20, null, null, null, null, "Psychoterapia", 7 },
                    { 21, null, null, null, null, "Leczenie zaburzeń nastroju", 7 }
                });

            migrationBuilder.InsertData(
                table: "TreatedDiseases",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateModified", "ModifiedBy", "Name", "SpecializationId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "Trądzik", 1 },
                    { 2, null, null, null, null, "Łuszczyca", 1 },
                    { 3, null, null, null, null, "Egzema", 1 },
                    { 4, null, null, null, null, "Niewydolność serca", 2 },
                    { 5, null, null, null, null, "Choroba wieńcowa", 2 },
                    { 6, null, null, null, null, "Nadciśnienie", 2 },
                    { 7, null, null, null, null, "Stwardnienie rozsiane", 3 },
                    { 8, null, null, null, null, "Migrena", 3 },
                    { 9, null, null, null, null, "Epilepsja", 3 },
                    { 10, null, null, null, null, "Ospa wietrzna", 4 },
                    { 11, null, null, null, null, "Odra", 4 },
                    { 12, null, null, null, null, "Szkarlatyna", 4 },
                    { 13, null, null, null, null, "Cukrzyca", 5 },
                    { 14, null, null, null, null, "Choroby tarczycy", 5 },
                    { 15, null, null, null, null, "Osteoporoza", 5 },
                    { 16, null, null, null, null, "Endometrioza", 6 },
                    { 17, null, null, null, null, "Mięśniaki macicy", 6 },
                    { 18, null, null, null, null, "Zespół policystycznych jajników", 6 },
                    { 19, null, null, null, null, "Depresja", 7 },
                    { 20, null, null, null, null, "Zaburzenia lękowe", 7 },
                    { 21, null, null, null, null, "Schizofrenia", 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorEducations_EducationId",
                table: "DoctorEducations",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorMedicalServices_MedicalServiceId",
                table: "DoctorMedicalServices",
                column: "MedicalServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecializations_SpecializationId",
                table: "DoctorSpecializations",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorTreatedDiseases_TreatedDiseaseId",
                table: "DoctorTreatedDiseases",
                column: "TreatedDiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_University",
                table: "Educations",
                column: "University",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServices_Name",
                table: "MedicalServices",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalServices_SpecializationId",
                table: "MedicalServices",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Name",
                table: "Specializations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatedDiseases_Name",
                table: "TreatedDiseases",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TreatedDiseases_SpecializationId",
                table: "TreatedDiseases",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkAddresses_CityId",
                table: "WorkAddresses",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DoctorDailySchedules");

            migrationBuilder.DropTable(
                name: "DoctorEducations");

            migrationBuilder.DropTable(
                name: "DoctorMedicalServices");

            migrationBuilder.DropTable(
                name: "DoctorSpecializations");

            migrationBuilder.DropTable(
                name: "DoctorTreatedDiseases");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "WorkAddresses");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "MedicalServices");

            migrationBuilder.DropTable(
                name: "TreatedDiseases");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
