using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfComputerTechnology.Data
{

    public class Orders
    {
        public List<OrderArrayItems> Order { get; set; }
    }
    public class OrderArrayItems
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int IDClient;
        public string FIO { get; set; }
        public int IDStatus;
        public string Status { get; set; }

    }

    public class RepairTechnics
    {
        public List<RepairTechnicArrayItems> RepairTechnic { get; set; }
    }
    public class RepairTechnicArrayItems
    {
        public int ID;
        public int IDTechnic;
        public string Technic { get; set; }
        public int IDType;
        public string Type { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime Date { get; set; }
        public int Orders;

    }
    public class RepairWorks
    {
        public List<RepairWorkArrayItems> RepairWork { get; set; }
    }
    public class RepairWorkArrayItems
    {
        public int ID { get; set; }
        public int IDOrder;
        public string Order { get; set; }
        public int RepairTechnic;
        public DateTime Date { get; set; }
        public int IDEmployees;
        public string Employees { get; set; }
        public string Description { get; set; }
    }

    public class ListOfErrors
    {
        public List<ListOfErrorArrayItems> ListOfError { get; set; }
    }
    public class ListOfErrorArrayItems
    {
        public int ID;
        public int RepairWork;
        public DateTime DateStart { get; set; }

        public string Reason { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
    }
}
