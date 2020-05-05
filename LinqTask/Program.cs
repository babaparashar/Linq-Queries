using System;
using System.Linq;
using System.Collections.Generic;
using VisioForge.Shared.MediaFoundation.OPM;
using System.Data;

// Employee details 
public class Employee
{

    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string JoiningDate { get; set; }
    public int Salary { get; set; }
    public string Department { get; set; }

}
public class Incentives
{
    public int EmployeeRefId { get; set; }
    public string IncentiveDate { get; set; }
    public int Incentive { get; set; }
}

class Program
{

    // Main method 
    static public void Main()
    {
        List<Employee> employee = new List<Employee>() {
                new Employee() { EmployeeId= 1, FirstName ="John", LastName = "Abraham", Salary= 1000000, JoiningDate ="01-JAN-13 12:00:00 AM", Department ="Banking" },
                new Employee() { EmployeeId= 2, FirstName ="Michael", LastName = "Clarke", Salary= 800000, JoiningDate = "01-JAN-13 12:00:00 AM", Department="Insurance"},
                new Employee() { EmployeeId= 3, FirstName ="Roy" ,LastName = "Thomas", Salary= 700000, JoiningDate = "01-FEB-13 12:00:00 AM", Department="Banking" },
                new Employee() { EmployeeId= 4, FirstName ="Tom" ,LastName = "Jose", Salary= 600000, JoiningDate = "01-FEB-13 12:00:00 AM", Department="Insurance" },
                new Employee() { EmployeeId= 5, FirstName ="Jerry" ,LastName = "Pinto", Salary= 650000, JoiningDate = "01-FEB-13 12:00:00 AM", Department="Insurance" },
                new Employee() { EmployeeId= 6, FirstName ="Philip" ,LastName = "Mathew", Salary= 750000, JoiningDate = "01-JAN-13 12:00:00 AM", Department="Services" },
                new Employee() { EmployeeId= 7, FirstName ="TestName1" ,LastName = "123", Salary= 650000, JoiningDate = "01-JAN-13 12:00:00 AM", Department="IT" },
                new Employee() { EmployeeId= 8, FirstName ="TestName1" ,LastName = "Lname%", Salary= 600000, JoiningDate = "01-FEB-13 12:00:00 AM", Department="Insurance" },

    };
        
        List<Incentives> incentives = new List<Incentives>()
        {
        new Incentives(){ EmployeeRefId= 1 ,IncentiveDate="01-FEB-13",Incentive=5000 },
        new Incentives(){ EmployeeRefId= 2 ,IncentiveDate="01-FEB-13",Incentive=3000 },
        new Incentives(){ EmployeeRefId= 3 ,IncentiveDate="01-FEB-13",Incentive=4000 },
        new Incentives(){ EmployeeRefId= 1 ,IncentiveDate="01-JAN-13",Incentive=4500 },
        new Incentives(){ EmployeeRefId= 2 ,IncentiveDate="01-JAN-13",Incentive=3500 }
        };




        //2.Get all employee details from the employee table

         var res = from e in employee
                   where e.EmployeeId <= 10
                   select e;

        foreach (var ed in res)
        {
            Console.WriteLine("{0}  {1}  {2}  {3}", ed.FirstName, ed.LastName, ed.Salary, ed.Department);
        }

       
        //3.Get First_Name, Last_Name from employee table

        foreach (var ed in res)
        {
            Console.WriteLine("{0}  {1}", ed.FirstName, ed.LastName) as EmployeeName;
        }

        //4.Get First_Name from employee table using alias name “Employee Name”


        foreach (var ed in res)
        {
            Console.WriteLine("{0}", ed.FirstName) as EmployeeName;
        }


        //5.Get First_Name from employee table in upper case

        foreach (var ed in res)
        {
            Console.WriteLine(ed.FirstName.ToUpper());
        }


       // 6.Get First_Name from employee table in lower case

          foreach (var ed in res)
        {
            Console.WriteLine(ed.FirstName.ToLower());
        }


        //   7.Get unique DEPARTMENT from employee table

        
            var res3 = employee.Select(p => p.Department).Distinct();
            foreach (var ed in res3)
            {

                Console.WriteLine(ed);
            }



        // 9.Get position of 'o' in name 'John' from employee table


        var res2 = from e in employee
                  where e.EmployeeId <= 10
                  select e;

        foreach (var ed in res2)
        {
            Console.WriteLine(ed.FirstName.IndexOf("o")) ;
        }


        // 10. Get FIRST_NAME from employee table after removing white spaces from right side


        foreach (var ed in res)
        {
            Console.WriteLine(ed.FirstName.RemoveRight("",""));
        }


        // 11. Get FIRST_NAME from employee table after removing white spaces from left side

        foreach (var ed in res)
        {
            Console.WriteLine(ed.FirstName.RemoveLeft("", ""));
        }

        // 12.  Get length of FIRST_NAME from employee table

        foreach (var ed in res)
        {
            Console.WriteLine(ed.FirstName.Length());
        }

        // 13. Get First_Name from employee table after replacing 'o' with '$'


        foreach (var ed in res)
        {
            Console.WriteLine(ed.FirstName.Replace("o", "$"));
        }

        // 14. Get First_Name and Last_Name as single column from employee table separated by a '_'


        // 20.Get employee details from employee table whose employee name is “John” 

        var john = employee.Where(ed => ed.FirstName == "John").FirstOrDefault();
        
        Console.WriteLine("{0} {1}  {2}  {3} {4}", john.FirstName ,john.LastName,john.Salary ,john.Department ,john.JoiningDate);
    
        //23.Get employee details from employee table whose first name starts with 'J'
        
        foreach (var ed in res)
        {
            if (ed.FirstName.IndexOf("j") == 0)
            {
                Console.WriteLine("{0} {1} {2} {3}", ed.FirstName, ed.LastName, ed.Department, ed.JoiningDate);
            }
        }


        //24.Get employee details from employee table whose first name contains 'o'
       
        foreach (var ed in res)
        {
            if (ed.FirstName.Contains("o") == true)
            {
                Console.WriteLine("{0} {1} {2} {3}", ed.FirstName, ed.LastName, ed.Department, ed.JoiningDate);
            }
        }
        

        //25.Get employee details from employee table whose first name ends with 'n'
        
            var res4 = from s in employee
                       where s.FirstName.EndsWith("n") && s.FirstName.Length == 4
                       select s;
            foreach (var std in res4)
            {
                Console.WriteLine(std.FirstName);
            }


        // 26.  Get employee details from employee table whose first name starts with 'J' and name contains 4 letters
    

            var res5 = from s in employee
                       where s.FirstName.StartsWith("J") && s.FirstName.Length == 4
                       select s;
            foreach (var std in res5)
            {
                Console.WriteLine(std.FirstName);
            }

        // 27.  Get employee details from employee table whose Salary greater than 600000

         
            var res6 = from s in employee
                       where s.Salary > 600000
                       select s;
            foreach (var std in res6)
            {
                Console.WriteLine("{0},{1}", std.FirstName, std.Salary);
            }

           // 28.  Get employee details from employee table whose Salary less than 800000

         var res7 = from s in employee
                       where s.Salary < 80000
                       select s;
            foreach (var std in res7)
            {
                Console.WriteLine("{0},{1}", std.FirstName, std.Salary);
            }


    }


}