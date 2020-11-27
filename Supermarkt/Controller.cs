using Supermarkt.Products;
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
                string option = ""; // damit frägt er so lange bis eingabe ein int ist
                int i = 0;
                do
                {
                    option = Console.ReadLine();
                } while (!int.TryParse(option, out i));
                MenuOptions(i);
                Console.WriteLine("continue...");
                Console.ReadLine();
            }
        }
        public void Initialize()
        {
            // shelves muss ich keine generieren, da bei meiner überprüfung der artikel automatiscch shelves erstellt werden

            string[] text = System.IO.File.ReadAllLines(@"C:\Users\DCV\Documents\DCUebungen\Supermarkt\Supermarkt\Supermarkt\TextFile1.txt");
            List<Product> allProducts = new List<Product>();
            #region textfile einlesen

            //könnte aus Products parent machen und aus types children. dann zuerst alle fruits, dann alle alcohols, dann alle vegetables usw.

            for (int i = 1; i < text.Length; i++)  //Textfile zu String array
            {
                string[] splittedValues = text[i].Split(";");
                //string storageEnum = splittedValues[5];
                //Enum.TryParse(splittedValues[5], out Storagetype storagetype); // hier kommt Enum Storagetype!!!

                //if splittedValues[4] == alcohol
                //splittedvalues mitgeben. dann if alcohol dann new alcohol { methode }
                Product newProd = AddNewProduct(splittedValues);              
                allProducts.Add(newProd);
            }
            #endregion

            // wenn produkt nicht in shelf geht dann bei supermarkt neues shelf hinzufügen
            // problem position von shelf in supermarkt liste hmmmmmm
            int aisle = 1;
            foreach (Product product in allProducts)   //problem: ich überschreibe jedes mal den shelf 
            {
                //reihenfolge zuerst alle vegies dann fruits dann alc dann sweets?
                Shelf temp = this.shelves.Find(s => s.Storagetype == product.Storagetype && s.Size > s.Products.Count); //geht in die Liste (s = aktuelles element)
                                                                                                                        //Find() = ich such in der Liste ein element!       //und schaut ob storagetype Normal ist      
                                                                                                                 
                if (temp == null)  
                {
                    temp = new Shelf(product.Storagetype, aisle);
                    aisle += 1;
                    this.shelves.Add(temp);
                }
                temp.AddToShelf(product);
            }
        }
        private Product AddNewProduct(string[] splittedValues) //return kann parent PRODUCT sein und alle Kinder auch zurückgeben!!!!!
        {
            Product newProd;  //initialisieren ohne zuweisung GEHT!!!
            string type = splittedValues[4].ToLower();
            if (type == "alcohol")
            {
                newProd = new Alcohol();
            }
            else if (type == "fruits")
            {
                newProd = new Fruits();
            }         
            else if(type == "sweets")
            {
                newProd = new Sweets();
            }
            else
            {
                newProd = new Vegetables();
            }
            newProd.ID = splittedValues[0];
            newProd.Cost = double.Parse(splittedValues[1].Replace("€", ""));
            newProd.Name = splittedValues[2];
            newProd.Usebefore = splittedValues[3];
            newProd.Type = type;            

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
            return newProd;
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
                    Console.WriteLine(s.Storagetype + " aisle: " + s.Aisle);
                }
            }
            else if (i == 3)
            {
                foreach (Shelf s in this.shelves)
                {
                    Console.WriteLine(s.Storagetype.ToString() + " " + s.Aisle);
                    foreach (Product p in s.Products)
                    {
                        Console.WriteLine("\t" + p.Name.PadRight(35, '.') + p.Type + Math.Round(p.Cost, 2) + " $");
                    }
                }
            }            
        }

    }
}
