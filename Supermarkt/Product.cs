using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt
{
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
            //d473ef07-8ab4-48fd-bd73-a81ca0c76b1c;€12,05;Sausage - Breakfast;6/8/2020;Fruits;freezer
        }
        public Product()
        {

        }
    }
}
