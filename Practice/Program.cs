using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Practice;
using Practice.DataContext;
using Practice.ExceptionClass;

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public int DepartmentID { get; set; }
    public int ProjectID { get; set; }
}
public class Department
{
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
}
public class Project
{
    public int ProjectID { get; set; }
    public string ProjectName { get; set; }
    public int ManagerID { get; set; }
}
public class Manager
{
    public int ManagerID { get; set; }
    public string ManagerName { get; set; }
}
public class Program
{
    //interface and defaault implementation
    public static void Main()
    {
        // Sample Employees
        List<Employee> Employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, FirstName = "Alice", DepartmentID = 1, ProjectID = 101 },
                new Employee { EmployeeID = 2, FirstName = "Bob", DepartmentID = 2, ProjectID = 102 },
                new Employee { EmployeeID = 3, FirstName = "Charlie", DepartmentID = 1, ProjectID = 103 },
                new Employee { EmployeeID = 4, FirstName = "Charlie"}
            };

        // Sample Departments
        List<Department> Departments = new List<Department>
            {
                new Department { DepartmentID = 1, DepartmentName = "HR" },
                new Department { DepartmentID = 2, DepartmentName = "IT" }
            };

        // Sample Projects
        List<Project> Projects = new List<Project>
            {
                new Project { ProjectID = 101, ProjectName = "HR Management System", ManagerID = 1001 },
                new Project { ProjectID = 102, ProjectName = "Cloud Migration", ManagerID = 1002 },
                new Project { ProjectID = 103, ProjectName = "Internal Tools", ManagerID = 1001 }
            };

        // Sample Managers
        List<Manager> Managers = new List<Manager>
            {
                new Manager { ManagerID = 1001, ManagerName = "John Smith" },
                new Manager { ManagerID = 1002, ManagerName = "Jane Doe" }
            };

     //   #region inner join

     //   var innerjoin1 = from e in Employees
     //                    join d in Departments on e.DepartmentID equals d.DepartmentID
     //                    join p in Projects on e.ProjectID equals p.ProjectID
     //                    join m in Managers on p.ManagerID equals m.ManagerID

     //                    select new
     //                    {
     //                        e.EmployeeID,
     //                        e.FirstName,
     //                        d.DepartmentName,
     //                        p.ProjectName,
     //                        m.ManagerName
     //                    };

     //   var innerjoin2 = Employees
     //.Join(Departments,
     //      e => e.DepartmentID,
     //      d => d.DepartmentID,
     //      (e, d) => new { e, d })
     //.Join(Projects,
     //      ed => ed.e.ProjectID,
     //      p => p.ProjectID,
     //      (ed, p) => new { ed.e, ed.d, p })
     //.Join(Managers,
     //      edp => edp.p.ManagerID,
     //      m => m.ManagerID,
     //      (edp, m) => new
     //      {
     //          edp.e.EmployeeID,
     //          edp.e.FirstName,
     //          edp.d.DepartmentName,
     //          edp.p.ProjectName,
     //          m.ManagerName
     //      });
     //   foreach (var item in innerjoin1)
     //   {
     //       Console.WriteLine($"EmployeeID: {item.EmployeeID}, Name: {item.FirstName}, " +
     //                            $"Department: {item.DepartmentName}, Project: {item.ProjectName}, " +
     //                            $"Manager: {item.ManagerName}");
     //   }
     //   foreach (var item in innerjoin2)
     //   {
     //       Console.WriteLine($"EmployeeID: {item.EmployeeID}, Name: {item.FirstName}, " +
     //                            $"Department: {item.DepartmentName}, Project: {item.ProjectName}, " +
     //                            $"Manager: {item.ManagerName}");
     //   }
     //   #endregion
     //   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
     //   Console.WriteLine("Left Join");
     //   Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");


     //   #region left join 


     //   var leftjoin1 = from e in Employees
     //                   join d in Departments on e.DepartmentID equals d.DepartmentID into deptGroup
     //                   from d in deptGroup.DefaultIfEmpty()

     //                   join p in Projects on e.ProjectID equals p.ProjectID into projGroup
     //                   from p in projGroup.DefaultIfEmpty()

     //                   join m in Managers on p?.ManagerID equals m.ManagerID into mgrGroup
     //                   from m in mgrGroup.DefaultIfEmpty()

     //                   select new
     //                   {
     //                       e.EmployeeID,
     //                       e.FirstName,
     //                       DepartmentName = d?.DepartmentName,
     //                       ProjectName = p?.ProjectName,
     //                       ManagerName = m?.ManagerName
     //                   };

     //   foreach (var item in leftjoin1)
     //   {
     //       Console.WriteLine($"EmployeeID: {item.EmployeeID}, Name: {item.FirstName}, " +
     //                            $"Department: {item.DepartmentName}, Project: {item.ProjectName}, " +
     //                            $"Manager: {item.ManagerName}");
     //   }
     //   #endregion
        var leftJoin = from e in Employees
                       join d in Departments on e.DepartmentID equals d.DepartmentID into deptGroup
                       from d in deptGroup.DefaultIfEmpty()
                       join p in Projects on e.ProjectID equals p.ProjectID into projGroup
                       from p in projGroup.DefaultIfEmpty()
                       join m in Managers on p?.ManagerID equals m.ManagerID into mgrGroup
                       from m in mgrGroup.DefaultIfEmpty()
                       select new
                       {
                           EmployeeID = (int?)e.EmployeeID,
                           FirstName = e.FirstName,
                           DepartmentName = d?.DepartmentName,
                           ProjectName = p?.ProjectName,
                           ManagerName = m?.ManagerName
                       };


        var rightJoin = from m in Managers
                        join p in Projects on m.ManagerID equals p.ManagerID into projGroup
                        from p in projGroup.DefaultIfEmpty()
                        join e in Employees on p?.ProjectID equals e.ProjectID into empGroup
                        from e in empGroup.DefaultIfEmpty()
                        join d in Departments on e?.DepartmentID equals d.DepartmentID into deptGroup
                        from d in deptGroup.DefaultIfEmpty()
                        where e == null || p == null || d == null
                        select new
                        {
                            EmployeeID = (int?)e?.EmployeeID,
                            FirstName = e?.FirstName,
                            DepartmentName = d?.DepartmentName,
                            ProjectName = p?.ProjectName,
                            ManagerName = m.ManagerName
                        };


        var result = leftJoin.Union(rightJoin);

        foreach (var item in result)
        {
            Console.WriteLine($"EmployeeID: {item.EmployeeID}, Name: {item.FirstName}, " +
                                 $"Department: {item.DepartmentName}, Project: {item.ProjectName}, " +
                                 $"Manager: {item.ManagerName}");
        }
    }
}