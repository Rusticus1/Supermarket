using System;

namespace Supermarkt
{
    public class Program
    {
        static void Main(string[] args)
        {
            //interface und vererbung nicht unbedingt nötig, kann aber
            //UML Klassendiagramm  zeichnen

            Controller supermarket = new Controller();
            supermarket.Start();


        }
    }
}
