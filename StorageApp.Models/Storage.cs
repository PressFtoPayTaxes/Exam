using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace StorageApp
{
    public delegate void AddProduct(Storage storage, Product product, string filePath);
    [Serializable]
    public class Storage
    {
        public event AddProduct AddPressed; 

        public List<Product> products;

        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(AddProduct method)
        {
            products = new List<Product>();
            AddPressed += method;
        }

        public void RegisterDelegate(AddProduct method)
        {
            AddPressed += method;
        }

        public void Save(string filePath)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Storage));
                serializer.Serialize(stream, this);
            }
        }

        public void AddProduct(Product product, string filePath)
        {
            AddPressed(this, product, filePath);
        }

        
    }
}
