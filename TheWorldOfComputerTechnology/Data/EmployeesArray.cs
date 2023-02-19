using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfComputerTechnology.Data
{
    public class EmployeesArray
    {
        public  List<EmployeesArrayItems> Employees { get; set; }
    }
    public class EmployeesArrayItems
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public string Surname;
        public string Name;
        public string Patronymic;
        public DateTime DateOfBirth { get; set; }
        public int IDGender;
        public string Gender { get; set; }
        public int IDRole;
        public string Role { get; set; }
        public string Photo;
    }
}
