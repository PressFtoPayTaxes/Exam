using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp
{
    public class Product
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Count { get; set; }
        public bool IsImported { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
