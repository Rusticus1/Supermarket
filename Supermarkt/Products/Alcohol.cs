using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt.Products
{
    public class Alcohol : Product
    {
        public Alcohol(string id, double cost, string name, string usebefore, string type, Storagetype storagetype) : base(id, cost, name, usebefore, type, storagetype)
        {           
            
        }
        public Alcohol()
        {

        }
    }
}
