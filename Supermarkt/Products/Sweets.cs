using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt.Products
{
    class Sweets : Product
    {
        public Sweets(string id, double cost, string name, string usebefore, string type, Storagetype storagetype) : base(id, cost, name, usebefore, type, storagetype)
        {
        }
        public Sweets()
        {

        }
    }
}
