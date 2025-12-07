using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Manager employee = new SafetyManager();
            employee.Id = 7;
            employee.FirstName = "khan";
            employee.LastName = "Lala";
            employee.AnnualSalary = 6000;
            employee.JobTitle = "Security Manager";
            employee.officeId = 90;
            employee.SecurityId = 100;
            employee.Joindate = new DateTime(2019, 4, 11);

            Console.WriteLine(employee.GetInformation());
            Console.WriteLine($"Number of years Worked: {employee.GetFullYearsWorked()}");

            Console.ReadKey();
        }

        public abstract class Employee : IEmployee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string JobTitle { get; set; }
            public decimal AnnualSalary { get; set; }
            public string Qualification { get; set; }
            public char Gender { get; set; }
            public DateTime Joindate { get; set; }

            public virtual string GetInformation()
            {
                return $"Id: {Id}{Environment.NewLine}JobTitle: {JobTitle}{Environment.NewLine}FirstName: {FirstName}{Environment.NewLine}LastName: {LastName}{Environment.NewLine}AnnualSalary: {AnnualSalary}{Environment.NewLine}";
            }

            public int GetFullYearsWorked()
            {
                DateTime zeroTime = new DateTime(1, 1, 1);

                TimeSpan span = DateTime.Now.Subtract(Joindate);

                int years = zeroTime.Add(span).Year - 1;

                return years;
            }
        }

        public interface IEmployee
        {
            int Id { get; set; }
            string FirstName { get; set; }
            string LastName { get; set; }
            string JobTitle { get; set; }
            decimal AnnualSalary { get; set; }
            string Qualification { get; set; }
            char Gender { get; set; }
            DateTime Joindate { get; set; }
            string GetInformation();

            int GetFullYearsWorked();
           
        }

        public class Electrian : Employee
        {
           
        }

        public class CraneOperator : Employee
        {
           
        }

        public class Sweeper: Employee
        {

        }

        public interface IManager
        {
            public int officeId { get; set; }
            public int SecurityId { get; set; }
        }

        public abstract class Manager : Employee,IManager
        {
            public int officeId { get; set; }
            public int SecurityId { get; set; }

            public override string GetInformation()
            {
                return base.GetInformation() + $"{Environment.NewLine}OfficeID: {officeId}{Environment.NewLine}SecurityId: {SecurityId}";
            }
        }

        public class ProjectManager: Manager
        {
           
        }

        public class SafetyManager: Manager
        {
         
        }
    }
}