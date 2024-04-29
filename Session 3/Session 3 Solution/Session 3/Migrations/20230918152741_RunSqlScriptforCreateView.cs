using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session_3.Migrations
{
    public partial class RunSqlScriptforCreateView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view EmplyeeDepartment 
                                    with encryption
                                    AS 
                                    	select E.Id EmpId,E.Name EmpName,D.Id DeptId,D.Name DeptName 
                                    	from Employees E,Department D
                                    	where D.Id = E.DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Drop view EmplyeeDepartment");
        }
    }
}
