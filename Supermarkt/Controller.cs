using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Supermarkt
{
    public enum Storagetype
    {
        NORMAL,
        FRIDGE,
        FREEZER,
    }
    public class Controller  //mein Controller ist mein Supermarkt deshalb die Liste hier
    {                        //oft schwer zu verstehen welches objekt verwendet werden muss und wo was rein gehört
        public List<Shelf> shelves = new List<Shelf>();
        public void Start()
        {
            Initialize();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("please select option");
                Console.WriteLine("1 - List all products");
                Console.WriteLine("2 - List all shelves");
                Console.WriteLine("3 - List all shelves with products");
                string opt = ""; // damit frägt er so lange bis eingabe ein int ist
                int i = 0;
                do
                {
                    opt = Console.ReadLine();
                } while (!int.TryParse(opt, out i));
                MenuOptions(i);
                Console.ReadLine();
            }
        }
        public void Initialize()
        {
            // shelves muss ich keine generieren, da bei meiner überprüfung der artikel automatiscch shelves erstellt werden
            //Shelf normal = new Shelf(Storagetype.NORMAL);
            //Shelf fridge = new Shelf(Storagetype.FRIDGE);
            //Shelf freezer = new Shelf(Storagetype.FREEZER);

            string[] text = System.IO.File.ReadAllLines(@"C:\Users\DCV\Documents\DCUebungen\Supermarkt\Supermarkt\Supermarkt\TextFile1.txt");
            List<Product> allProducts = new List<Product>();
            #region textfile einlesen
            for (int i = 1; i < text.Length; i++)  //Textfile zu String array
            {
                string[] splittedValues = text[i].Split(";");
                //string storageEnum = splittedValues[5];
                //Enum.TryParse(splittedValues[5], out Storagetype storagetype); // hier kommt Enum Storagetype!!!
                // try parse STRING to ENUM
                Product newProd = new Product() //schauen ob produkte richtig eingelesen werden!!
                {
                    ID = splittedValues[0],
                    Cost = double.Parse(splittedValues[1].Replace("€", "")),
                    Name = splittedValues[2],
                    Usebefore = splittedValues[3],
                    Type = splittedValues[4]
                };
                if (splittedValues[5] == "normal")
                {
                    newProd.Storagetype = Storagetype.NORMAL;
                }
                else if (splittedValues[5] == "fridge")
                {
                    newProd.Storagetype = Storagetype.FRIDGE;
                }
                else if (splittedValues[5] == "freezer")
                {
                    newProd.Storagetype = Storagetype.FREEZER;
                }
                allProducts.Add(newProd);
            }
            #endregion

            // wenn produkt nicht in shelf geht dann bei supermarkt neues shelf hinzufügen
            // problem position von shelf in supermarkt liste hmmmmmm

            foreach (Product product in allProducts)   //problem: ich überschreibe jedes mal den shelf 
            {
                Shelf temp = this.shelves.Find(s => s.Storagetype == product.Storagetype && s.Size > s.Products.Count); //geht in die Liste (s = aktuelles element)
                                                                                                                        //Find() = ich such in der Liste ein element!       //und schaut ob storagetype Normal ist                
                                                                                                                        //hier prüfung
                if (temp == null)
                {
                    temp = new Shelf(product.Storagetype);
                    this.shelves.Add(temp);
                }
                temp.AddToShelf(product);
            }
        }
        public void MenuOptions(int i)
        {
            if (i == 1)
            {
                foreach (Shelf s in shelves)
                {
                    foreach (Product p in s.Products)
                    {
                        Console.WriteLine(p.Name.PadRight(35, '.') + "" + p.Cost + " $");
                    }
                }
            }
            else if (i == 2)
            {
                foreach (Shelf s in shelves)
                {
                    Console.WriteLine(s.Storagetype);
                }
            }
            else if (i == 3)
            {
                foreach (Shelf s in this.shelves)
                {
                    Console.WriteLine(s.Storagetype.ToString());
                    foreach (Product p in s.Products)
                    {
                        Console.WriteLine("\t" + p.Name.PadRight(35, '.') + Math.Round(p.Cost, 2) + " $");
                    }
                }
            }
        }
    }
}
