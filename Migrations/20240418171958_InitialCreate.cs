using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityTuitionPayment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    TCKimlik = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TCKimlik = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    universityId = table.Column<int>(type: "int", nullable: false),
                    StudentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "University",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TuitionFee = table.Column<double>(type: "float", nullable: false),
                    CurrentTermId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_University", x => x.Id);
                    table.ForeignKey(
                        name: "FK_University_Terms_CurrentTermId",
                        column: x => x.CurrentTermId,
                        principalTable: "Terms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tuition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currentTermId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    universityId = table.Column<int>(type: "int", nullable: false),
                    TuitionTotal = table.Column<double>(type: "float", nullable: false),
                    TuitionPaid = table.Column<double>(type: "float", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tuition_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tuition_Terms_currentTermId",
                        column: x => x.currentTermId,
                        principalTable: "Terms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Tuition_University_universityId",
                        column: x => x.universityId,
                        principalTable: "University",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_AccountCode",
                table: "BankAccount",
                column: "AccountCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_TCKimlik",
                table: "BankAccount",
                column: "TCKimlik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentCode",
                table: "Student",
                column: "StudentCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_TCKimlik",
                table: "Student",
                column: "TCKimlik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_universityId",
                table: "Student",
                column: "universityId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_UniversityId",
                table: "Terms",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuition_currentTermId",
                table: "Tuition",
                column: "currentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuition_studentId",
                table: "Tuition",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuition_universityId",
                table: "Tuition",
                column: "universityId");

            migrationBuilder.CreateIndex(
                name: "IX_University_CurrentTermId",
                table: "University",
                column: "CurrentTermId");

            migrationBuilder.CreateIndex(
                name: "IX_University_UniversityCode",
                table: "University",
                column: "UniversityCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_University_universityId",
                table: "Student",
                column: "universityId",
                principalTable: "University",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Terms_University_UniversityId",
                table: "Terms",
                column: "UniversityId",
                principalTable: "University",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terms_University_UniversityId",
                table: "Terms");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Tuition");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "University");

            migrationBuilder.DropTable(
                name: "Terms");
        }
    }
}
