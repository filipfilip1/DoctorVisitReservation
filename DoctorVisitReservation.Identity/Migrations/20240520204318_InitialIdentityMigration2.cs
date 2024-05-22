using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorVisitReservation.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentityMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d0b470e-bb1d-4eaf-94c4-4e6fe36b9e06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78f78557-f02a-487f-a9bd-919a4bf01076", "AQAAAAIAAYagAAAAELPdKh5FxLVWIYVZU5fRX/rZ2EkDG575dvNsFw31Seh91L6RrBmrahHtYscEARE9Lw==", "41ddac1b-32fb-4c6d-b999-16bd69b964a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34a0fc6e-e693-4fce-bce4-21b1a3a5b6a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74542c04-ed51-47e1-b7ab-18d37e66a72d", "AQAAAAIAAYagAAAAEHHLRNKT8sH3hksYBFNvOPLapcmLIC+fjGuIBRC4yfb8DCyfyVox35gPIx7EUjJu/w==", "5964b9c7-048e-472c-a31f-e19d9dc61a37" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d49d1860-e92d-4384-b77c-7254ef3105e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cca8163-cd3b-46f5-9bff-c6de901a395c", "AQAAAAIAAYagAAAAEEROwmgGTj1Ygyq6v56rVus1lTqTYQJ6xiFBY3pWnUmZR+kz+1Tr8lWpBpJQom6ZfQ==", "324d6386-3d11-4a37-a8ea-5a65b5c35357" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d0b470e-bb1d-4eaf-94c4-4e6fe36b9e06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77dd21fb-4597-4a94-9eb4-90f5f0e6500a", "AQAAAAIAAYagAAAAEGha23gSSU8tVlQfLUW80t5QeqOcrQ0s9Be1MXo346u0zAUdCZGMhHm0dbmGaqjexw==", "99f90515-a330-4103-b606-fba3d7f8dd3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34a0fc6e-e693-4fce-bce4-21b1a3a5b6a0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb72b716-4583-4a24-8a00-7f9761e8e1a3", "AQAAAAIAAYagAAAAEFPJaSiycm6giIaTXSSw4GifxLcwP2xIF4zIpHql51mSPEKs+8IzXtxL5gqknK9RwA==", "351268ca-6452-4542-a325-ea8919b61826" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d49d1860-e92d-4384-b77c-7254ef3105e8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "feb85f74-34e3-4ad0-ad63-e41a6eecb16c", "AQAAAAIAAYagAAAAELwoRI6jtrtud8NsCMbUVUmWjUfSyYH9aQVSROx++4hceyOu9WacduzFEeaLEVluLQ==", "38396af1-aaf8-4a3d-abc1-b9899bb7abe7" });
        }
    }
}
