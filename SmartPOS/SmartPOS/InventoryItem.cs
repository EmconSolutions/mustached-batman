using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPOS
{
    public class InventoryItem
    {
        public string Text { get; set; }
        public string Ean { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }
    }
}
