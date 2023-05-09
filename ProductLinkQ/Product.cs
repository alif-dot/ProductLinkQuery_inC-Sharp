using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLinkQ
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Quentity { get; set; }
        public string ProductName { get; set; }
        public int ProductNumber { get; set; }
        public string Color { get; set; }
        public double FixedPrice { get; set; }
        public int CategoryID { get; set; }
        public int ModelID { get; set; }

        public virtual Category Category { get; set; }
        public virtual ProductModel Model { get; set; }

        public Product()
        {

        }
        
        public Product(int productID, string name, double price, int quentity, int productNumber, int categoryID, int modelID, string color) : this()
        {
            ProductId = productID;
            Quentity = quentity;
            ProductName = name;
            FixedPrice = price;
            CategoryID = categoryID;
            ModelID = modelID;
            Color = color;
        }
    }
}
