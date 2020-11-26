using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt
{
    
    public class Shelf
    {
        
        public int Size { get; set; }
        public List<Product> Products { get; set; }
        public Storagetype Storagetype { get; set; }
        public Shelf(Storagetype storagetype)
        {         
            this.Size = 20;
            this.Products = new List<Product>();
            this.Storagetype = storagetype;
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
