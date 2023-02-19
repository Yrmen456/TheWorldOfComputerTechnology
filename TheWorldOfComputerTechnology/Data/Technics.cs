using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldOfComputerTechnology.Data
{

    public class Technics
    {
        public List<TechnicArrayItems> Technic { get; set; }
    }
    public class TechnicArrayItems
    {
        public int ID { get; set; }
        public string Marking { get; set; }
        public string Name { get; set; }
        public int IDType;
        public string Type { get; set; }

    }

    public class CharacteristicsOfTheEquipments
    {
        public List<CharacteristicsOfTheEquipmentArrayItems> CharacteristicsOfTheEquipment { get; set; }
    }
    public class CharacteristicsOfTheEquipmentArrayItems
    {
        public int ID;
        public int Technic;
        public string Characteristics { get; set; }
        public string Meaning { get; set; }


    }
}
