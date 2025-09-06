using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class InialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HumanResources");

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "HumanResources",
                columns: table => new
                {
                    DepartmentID = table.Column<short>(type: "smallint", nullable: false, comment: "Primary key for Department records.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the department."),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the group to which the department belongs."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated."),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_DepartmentID", x => x.DepartmentID);
                },
                comment: "Lookup table containing the departments within the Adventure Works Cycles company.");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for Employee records.  Foreign key to BusinessEntity.BusinessEntityID."),
                    NationalIDNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Unique national identification number such as a social security number."),
                    LoginID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false, comment: "Network login."),
                    OrganizationLevel = table.Column<short>(type: "smallint", nullable: true, computedColumnSql: "([OrganizationNode].[GetLevel]())", stored: false, comment: "The depth of the employee in the corporate hierarchy."),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Work title such as Buyer or Sales Representative."),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "Date of birth."),
                    MaritalStatus = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false, comment: "M = Married, S = Single"),
                    Gender = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false, comment: "M = Male, F = Female"),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "Employee hired on this date."),
                    SalariedFlag = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "Job classification. 0 = Hourly, not exempt from collective bargaining. 1 = Salaried, exempt from collective bargaining."),
                    VacationHours = table.Column<short>(type: "smallint", nullable: false, comment: "Number of available vacation hours."),
                    SickLeaveHours = table.Column<short>(type: "smallint", nullable: false, comment: "Number of available sick leave hours."),
                    CurrentFlag = table.Column<bool>(type: "bit", nullable: false, defaultValue: true, comment: "0 = Inactive, 1 = Active"),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())", comment: "ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_BusinessEntityID", x => x.BusinessEntityID);
                },
                comment: "Employee information such as salary, department, and title.");

            migrationBuilder.CreateTable(
                name: "Shift",
                schema: "HumanResources",
                columns: table => new
                {
                    ShiftID = table.Column<byte>(type: "tinyint", nullable: false, comment: "Primary key for Shift records.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Shift description."),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false, comment: "Shift start time."),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false, comment: "Shift end time."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift_ShiftID", x => x.ShiftID);
                },
                comment: "Work shift lookup table.");

            migrationBuilder.CreateTable(
                name: "EmployeePayHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false, comment: "Employee identification number. Foreign key to Employee.BusinessEntityID."),
                    RateChangeDate = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Date the change in pay is effective"),
                    Rate = table.Column<decimal>(type: "money", nullable: false, comment: "Salary hourly rate."),
                    PayFrequency = table.Column<byte>(type: "tinyint", nullable: false, comment: "1 = Salary received monthly, 2 = Salary received biweekly"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHistory_BusinessEntityID_RateChangeDate", x => new { x.BusinessEntityID, x.RateChangeDate });
                    table.ForeignKey(
                        name: "FK_EmployeePayHistory_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID");
                },
                comment: "Employee pay history.");

            migrationBuilder.CreateTable(
                name: "JobCandidate",
                schema: "HumanResources",
                columns: table => new
                {
                    JobCandidateID = table.Column<int>(type: "int", nullable: false, comment: "Primary key for JobCandidate records.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessEntityID = table.Column<int>(type: "int", nullable: true, comment: "Employee identification number if applicant was hired. Foreign key to Employee.BusinessEntityID."),
                    Resume = table.Column<string>(type: "xml", nullable: true, comment: "Résumé in XML format."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCandidate_JobCandidateID", x => x.JobCandidateID);
                    table.ForeignKey(
                        name: "FK_JobCandidate_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID");
                },
                comment: "Résumés submitted to Human Resources by job applicants.");

            migrationBuilder.CreateTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false, comment: "Employee identification number. Foreign key to Employee.BusinessEntityID."),
                    DepartmentID = table.Column<short>(type: "smallint", nullable: false, comment: "Department in which the employee worked including currently. Foreign key to Department.DepartmentID."),
                    ShiftID = table.Column<byte>(type: "tinyint", nullable: false, comment: "Identifies which 8-hour shift the employee works. Foreign key to Shift.Shift.ID."),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "Date the employee started work in the department."),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "Date the employee left the department. NULL = Current department."),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())", comment: "Date and time the record was last updated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartmentHistory_BusinessEntityID_StartDate_DepartmentID", x => new { x.BusinessEntityID, x.StartDate, x.DepartmentID, x.ShiftID });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "HumanResources",
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalSchema: "HumanResources",
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID");
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Shift_ShiftID",
                        column: x => x.ShiftID,
                        principalSchema: "HumanResources",
                        principalTable: "Shift",
                        principalColumn: "ShiftID");
                },
                comment: "Employee department transfers.");

            migrationBuilder.CreateIndex(
                name: "AK_Department_Name",
                schema: "HumanResources",
                table: "Department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_LoginID",
                schema: "HumanResources",
                table: "Employee",
                column: "LoginID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_NationalIDNumber",
                schema: "HumanResources",
                table: "Employee",
                column: "NationalIDNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Employee_rowguid",
                schema: "HumanResources",
                table: "Employee",
                column: "rowguid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_DepartmentID",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_ShiftID",
                schema: "HumanResources",
                table: "EmployeeDepartmentHistory",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_JobCandidate_BusinessEntityID",
                schema: "HumanResources",
                table: "JobCandidate",
                column: "BusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "AK_Shift_Name",
                schema: "HumanResources",
                table: "Shift",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Shift_StartTime_EndTime",
                schema: "HumanResources",
                table: "Shift",
                columns: new[] { "StartTime", "EndTime" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartmentHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "EmployeePayHistory",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "JobCandidate",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Shift",
                schema: "HumanResources");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "HumanResources");
        }
    }
}
