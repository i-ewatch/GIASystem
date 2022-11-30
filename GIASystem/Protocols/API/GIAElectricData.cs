using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIASystem.Protocols.API
{
    public abstract class GIAElectricData : AbsProtocol
    {
        public decimal PriceRate { get; set; }
        public decimal Hour_Total_kWh { get; set; }
        public decimal Month_Total_kWh { get; set; }
        public decimal Day_Total_kWh { get; set; }
        public List<GroupkWh> GroupkWhs { get; set; } = new List<GroupkWh>();
    }
    public class GroupkWh
    {
        public string Name { get; set; }
        public decimal Hour_Total_kWh { get; set; }
        public decimal Month_Total_kWh { get; set; }
        public decimal Day_Total_kWh { get; set; }
        public List<ItemkWh> ItemkWhs { get; set; } = new List<ItemkWh>();
    }
    public class ItemkWh
    {
        public string Name { get; set; }
        public decimal Hour_Total_kWh { get; set; }
        public decimal Month_Total_kWh { get; set; }
        public decimal Day_Total_kWh { get; set; }
    }
}
