using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarkt.Products
{
    class Vegetables : Product
    {
        public Vegetables(string id, double cost, string name, string usebefore, string type, Storagetype storagetype) : base(id, cost, name, usebefore, type, storagetype)
        {
        }
        public Vegetables()
        {

        }
    }
}
