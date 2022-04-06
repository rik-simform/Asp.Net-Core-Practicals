using Microsoft.EntityFrameworkCore.Migrations;

namespace Practical_16.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "mobile",
                table: "Students",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e7214b3-23c6-4171-98ce-0910174f0482", "b3c6ed92-8cda-44f6-9787-77d31d37b3c4", "Admin", "ADMIN" },
                    { "d60900d1-4f53-4f00-9f3e-530a7b5772ac", "0f0937b5-032a-4570-a4aa-cbab3ad93d5c", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "firstname", "lastname" },
                values: new object[,]
                {
                    { "ea4283d3-e8ec-4f23-ad9f-8629f31bd79e", 0, "4be1333a-867c-4882-8cc3-11db1a8bb2e7", "Admin@email.com", false, false, null, "ADMIN@EMAIL.COM", null, "AQAAAAEAACcQAAAAEPcBiVMIentVDIbq5fCCfU31Y8nM4Vx6Tx8PKDVunZL8MCOSM463HVTuDwESH+BOkA==", null, false, "ab519f79-060d-4068-8a52-b42e01043a69", false, null, "system", "admin" },
                    { "6d44dff0-acdf-444a-b255-6c3565f89c3a", 0, "a673b616-7d32-45e0-a50c-40b6a8daac9b", "Admin@email.com", false, false, null, "ADMIN@EMAIL.COM", null, "AQAAAAEAACcQAAAAEAKzs2+l8Q2rKa0+piR3Usa8An6BT8CrSYqh1v+uKxMHUfpCZDBJccMp6vnJKsxU6A==", null, false, "b24694c7-9293-4ce5-97eb-2715f99e2d0e", false, null, "system", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e7214b3-23c6-4171-98ce-0910174f0482", "ea4283d3-e8ec-4f23-ad9f-8629f31bd79e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d60900d1-4f53-4f00-9f3e-530a7b5772ac", "6d44dff0-acdf-444a-b255-6c3565f89c3a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d60900d1-4f53-4f00-9f3e-530a7b5772ac", "6d44dff0-acdf-444a-b255-6c3565f89c3a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e7214b3-23c6-4171-98ce-0910174f0482", "ea4283d3-e8ec-4f23-ad9f-8629f31bd79e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e7214b3-23c6-4171-98ce-0910174f0482");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d60900d1-4f53-4f00-9f3e-530a7b5772ac");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d44dff0-acdf-444a-b255-6c3565f89c3a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea4283d3-e8ec-4f23-ad9f-8629f31bd79e");

            migrationBuilder.AlterColumn<int>(
                name: "mobile",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "phone",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
