using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfComputerTechnology.Data
{
    public class ComboBoxItemsRoles
    {
        public ComboBoxItemsArray[] Roles { get; set; }
    }
    public class ComboBoxItemsGenders
    {
        public ComboBoxItemsArray[] Genders { get; set; }
    }
    public class ComboBoxItemsClientStatus
    {
        public ComboBoxItemsArray[] ClientStatus { get; set; }
    }
    public class ComboBoxItemsOrderStatus
    {
        public ComboBoxItemsArray[] OrderStatus { get; set; }
    }
    public class ComboBoxItemsType
    {
        public ComboBoxItemsArray[] Type { get; set; }
    }
    public class ComboBoxItemsArray
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
