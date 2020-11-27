using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt
{
    public enum ProductType
    {
        FRUITS,
        ALCOHOL,
        VEGETABLES,
        SWEETS,

    }
    public class Product
    {
        public string ID { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public string Usebefore { get; set; }
        public string Type { get; set; }
        public Storagetype Storagetype { get; set; }
        public Product(string id, double cost, string name, string usebefore, string type, Storagetype storagetype)
        {
            this.ID = id;
            this.Cost = cost;
            this.Name = name;
            this.Usebefore = usebefore;
            this.Type = type;
            this.Storagetype = storagetype;
        }
        public Product()
        {

        }
    }
}
