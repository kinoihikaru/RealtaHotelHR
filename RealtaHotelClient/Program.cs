using Microsoft.Extensions.Configuration;
using RealtaHotelHRWebApi;
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static IConfigurationRoot Configuration;

        static void Main(string[] args)
        {
            BuildConfig();
            IRealtaHotelHRApi _RealtaHotelHR = new RealtaHotelHRApi(Configuration.GetConnectionString("RealtaHotelDS"));

            //var workOrder = _RealtaHotelHR.RepositoryManager.WorkOrders.FindWorkOrdersById(3);
            //Console.WriteLine(workOrder);

            //var ListEmployee = _RealtaHotelHR.RepositoryManager.Employee.FindAllEmployee();

            //foreach (var item in ListEmployee)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //var findEmplyee = _RealtaHotelHR.RepositoryManager.Employee.FindEmployeeById(1);
            //Console.WriteLine(findEmplyee);

            var newEmployee = _RealtaHotelHR.RepositoryManager.Employee.CreateEmployee( new RealtaHotelHRWebApi.Model.Employee
            {
                EmpId = 13,
                EmpNationalId = "a12312312345645645000000",
                EmpBirthDate = DateTime.Now,
                EmpMaritalStatus = 'S',
                EmpGender = 'M',
                EmpHireDate = DateTime.Now,
                EmpSalariedFlag = '0',
                EmpVacationHours = 123,
                EmpSickleaveHours = 123,
                EmpCurrentFlag=  123,
                EmpPhoto = "hai",
                EmpModifiedDate = DateTime.Now,
                EmpEmpId = 1,
                EmpJoroId = 2
            });
            Console.WriteLine(newEmployee);
        }
        static void BuildConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            //Console.WriteLine(Configuration.GetConnectionString("NorthwindDS"));
        }
    }
}