using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt
{
    
    public class Shelf
    {
        
        public int Size { get; set; }
        public int Aisle { get; set; }
        public List<Product> Products { get; set; }
        public Storagetype Storagetype { get; set; }
        public Shelf(Storagetype storagetype, int aisle)
        {         
            this.Size = 20;
            this.Products = new List<Product>();
            this.Storagetype = storagetype;
            this.Aisle = aisle;
        }
        public bool AddToShelf(Product product)
        {
            if(this.Products.Count <= Size)
            {
                this.Products.Add(product);
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
    
}
