using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfComputerTechnology.Data
{
    public class ClientArray
    {
        public List<ClientArrayItems> Clients { get; set; }
    }
    public class ClientArrayItems
    {
        public int ID { get; set; }

        public string Surname;
        public string Name;
        public string Patronymic;
        public string FIO { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth;
        public int SeriesPassport;
        public int Number_passport;
        public DateTime DateOfIssue;
        public DateTime EndDate;
        public string PlaceOfIssue;
        public int IDGender;
        public string Gender { get; set; }

        public int IDStatus;
        public string Status { get; set; }
    
    }
}
