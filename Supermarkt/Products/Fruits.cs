using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt.Products
{
    class Fruits : Product
    {
        public Fruits(string id, double cost, string name, string usebefore, string type, Storagetype storagetype) : base(id, cost, name, usebefore, type, storagetype)
        {
            
        }
        public Fruits()
        {

        }
    }
}
