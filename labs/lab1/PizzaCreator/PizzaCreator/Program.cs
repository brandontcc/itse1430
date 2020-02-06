/*
 * ITSE
 * Brandon Houston
*/
using System;

namespace Pizza
{
    class Program
    {
        static double fullPrice=0;
        static double pizzaSizePrice;
        static string pizzaSize;
        static double price = 0;
        static double meatPrice = .75;
        static int bacon;
        static int ham;
        static int pepperoni;
        static int sausage;
        static double vegPrice = .50;
        static int blackOlives;
        static int mushrooms;
        static int onions;
        static int peppers;
        static string sauceType;
        static double saucePrice;
        static string cheese;
        static double extraCheese;
        static string deliveryOrPickup;
        static double deliveryCost;

        static void Main ( string[] args )
        {
            pizzaSizePrice = 0;
            Console.WriteLine("Welcome to Pizza INC");
            var confirm = false;
            do
            {
                var done = false;
                do
                {
                    if (pizzaSizePrice==0&&done!=true)
                    {
                        switch (DisplayMenu())
                        {
                            case 1: AddPizza(); break;
                            case 2: ModifyPizza(); break;
                            case 0: done=true; break;
                        }
                    };
                    if (pizzaSizePrice>0&&done!=true)
                    {
                        switch (DisplayMenu())
                        {
                            case 1: DisplayOrder();break;
                            case 2: ModifyPizza(); break;
                            case 0: done=true; break;
                        }
                    };
                } while (done==false);

                bool test = false;
                do
                {
                    Console.WriteLine("Are you sure you wish to exit (Y/N) ");
                    var sure = Console.ReadLine();

                    switch (sure.ToLower())
                    {
                        case "y": confirm=true; test=true; break;
                        case "n": test=true; break;
                        default: Console.WriteLine("Invalid Option"); break;
                    }

                } while (test==false);
            } while (confirm==false);
        }

        private static void AddPizza ()
        {
            DisplaySizes();
            DisplayMeats();
            DisplayVegetables();
            DisplaySauce();
            DisplayCheese();
            DisplayDelivery();
        }

        private static void DisplayOrder ()
        {
            Console.Clear();
            double tempMeat = 0;
            double tempVeg = 0;
            Console.WriteLine(pizzaSize.PadRight(20)+"$"+String.Format("{0:0.00}", pizzaSizePrice));
            if (bacon+ham+pepperoni+sausage>0)
            {
                Console.WriteLine("Meats");
                if (bacon>0)
                {
                    price=bacon*meatPrice;
                    Console.WriteLine("     Bacon".PadRight(20)+"$"+ String.Format("{0:0.00}", price));
                }
                if (ham>0)
                {
                    price=ham*meatPrice;
                    Console.WriteLine("     Ham".PadRight(20)+"$"+ String.Format("{0:0.00}", price));
                }
                if (pepperoni>0)
                {
                    price=pepperoni*meatPrice;
                    Console.WriteLine("     Pepperoni".PadRight(20)+"$"+ String.Format("{0:0.00}", price));
                }
                if (sausage>0)
                {
                    price=sausage*meatPrice;
                    Console.WriteLine("     Sausage".PadRight(20)+"$"+ String.Format("{0:0.00}", price));
                }
                tempMeat=bacon+ham+pepperoni+sausage;
            }
            if (blackOlives+mushrooms+onions+peppers>0)
            {
                Console.WriteLine("Vegetables");
                if (blackOlives>0)
                {
                    price=blackOlives*vegPrice;
                    Console.WriteLine("     Black Olives".PadRight(20)+"$"+String.Format("{0:0.00}", price));
                }
                if (mushrooms>0)
                {
                    price=mushrooms*vegPrice;
                    Console.WriteLine("     Mushrooms".PadRight(20)+"$"+String.Format("{0:0.00}", price));
                }
                if (onions>0)
                {
                    price=onions*vegPrice;
                    Console.WriteLine("     Onions".PadRight(20)+"$"+String.Format("{0:0.00}", price));
                }
                if (peppers>0)
                {
                    price=peppers*vegPrice;
                    Console.WriteLine("     Peppers".PadRight(20)+"$"+String.Format("{0:0.00}", price));
                }
                tempVeg=blackOlives+mushrooms+onions+peppers;
            }
            Console.WriteLine("Sauce");
            Console.WriteLine("     "+sauceType.PadRight(15)+"$"+String.Format("{0:0.00}", saucePrice));
            Console.WriteLine("Cheese");
            Console.WriteLine("     "+ cheese.PadRight(15)+"$"+String.Format("{0:0.00}", extraCheese));
            Console.WriteLine(deliveryOrPickup.PadRight(20)+"$"+String.Format("{0:0.00}", +deliveryCost));
            fullPrice= tempMeat+tempVeg+saucePrice+extraCheese+deliveryCost;
            Console.WriteLine("".PadLeft(20), '-');
            Console.WriteLine("Total".PadRight(20)+"$"+fullPrice);
        }

        private static void DisplayDelivery ()
        {
            Console.WriteLine("Will your order be for pickup or delivery");
            Console.WriteLine("1 Pickup");
            Console.WriteLine("2 Delivery");
            var delivery = RealOrderNumber("Please select one):", 1, 2);
            if (delivery==1)
                deliveryOrPickup="Pickup"; deliveryCost=0;
            if (delivery==2)
            {
                deliveryOrPickup="Delivery"; deliveryCost=2.50;
            }
        }

        private static void DisplayCheese ()
        { 
            Console.WriteLine("Please select your cheese");
            Console.WriteLine("1 Regular    ($0)");
            Console.WriteLine("2 Extra   ($1.25)");
            var cheesyGoodness = RealOrderNumber("Please select one):", 1, 2);
            if (cheesyGoodness==1)
                cheese="Normal"; extraCheese=0;
            if (cheesyGoodness==2)
                cheese="extra"; extraCheese=1.25;
        }

        private static void DisplaySauce ()
        {   
            Console.WriteLine("Sauce Choices");
            Console.WriteLine("1 Traditional ($0)");
            Console.WriteLine("2 Garlic      ($1)");
            Console.WriteLine("3 Oregano     ($1)");
            var sauce= RealOrderNumber("Please select your sauce):", 1, 3);
            if (sauce==1)
                sauceType="Traditional  "; saucePrice=0;
            if (sauce==2)
                sauceType="Garlic  ";saucePrice=1;
            if (sauce==3)
                sauceType="Oregano  "; saucePrice=1;
        }

        private static void DisplayVegetables ()
        {
            Console.WriteLine("What Vegetables would you like to have, each selection is .50$.Choose between 0-3 of each topping");
            blackOlives = RealOrderNumber("Black Olives):", 0, 3);
            mushrooms= RealOrderNumber("Mushrooms):", 0, 3);
            onions= RealOrderNumber("Onions):", 0, 3);
            peppers= RealOrderNumber("Peppers):", 0, 3);
        }

        private static void DisplayMeats ()
        {
            Console.WriteLine("What meats would you like to have each selection is .75$ each. 0 or more");
            bacon= RealOrderNumber("Bacon):", 0, 3);
            ham= RealOrderNumber("Ham):", 0, 3);
            pepperoni= RealOrderNumber("Pepperoni):", 0, 3);
            sausage= RealOrderNumber("Sausage):", 0, 3);
        }

        private static int RealOrderNumber (string message, int minValue, int MaxValue)
        {
            Console.WriteLine(message);
            do
            {
                var temp = Console.ReadLine();
                if (Int32.TryParse(temp, out var value))
                {
                    if (value>=minValue && value <=MaxValue)
                        return value;
                }
                Console.WriteLine("Invalid option selection must be between "+minValue+" - "+ MaxValue);
            }while(true);
        }

        private static void DisplaySizes ()
        {
            
            var breakPoint = false;
            do
            {
                Console.WriteLine("What size pizza would you like");
                Console.WriteLine("S)mall ($5)");
                Console.WriteLine("M)edium ($6.25)");
                Console.WriteLine("L)arge ($8.75)");
                var pizza= Console.ReadLine();
                switch (pizza.ToUpper())
                {
                    case "L": pizzaSizePrice =pizzaSizePrice+ 8.75; pizzaSize="Large Pizza "; breakPoint = true; break;
                    case "M": pizzaSizePrice =pizzaSizePrice+ 6.25; pizzaSize="Medium Pizza "; breakPoint = true; break;
                    case "S": pizzaSizePrice =pizzaSizePrice+ 5; pizzaSize="Small Pizza "; breakPoint = true; break;

                    default: Console.WriteLine("Invalid Option"); break;
                }
            } while (breakPoint == false);
            return;
        }

        private static void ModifyPizza ()
        {
            if (fullPrice>0)
            {
                AddPizza();
            };
            if (fullPrice==0)
            {
                Console.WriteLine("No pizza to modify please start over");
            };
        }

        private static int DisplayMenu ()
        {
            do
            {
                if (pizzaSizePrice==0)
                {
                    Console.WriteLine("(1) Add Pizza");
                    Console.WriteLine("(2) Modify Pizza");
                    Console.WriteLine("(0) Quit");
                    var input = Console.ReadLine();
                    if (Int32.TryParse(input, out int value))
                        switch (value)
                        {
                            case 1: return 1;
                            case 2: return 2;
                            case 0: return 0;

                            default: Console.WriteLine("Invalid Option"); break;
                        }
                } 
                if (pizzaSizePrice>0)
                {
                    Console.WriteLine("(1) View Order");
                    Console.WriteLine("(2) Modify Pizza");
                    Console.WriteLine("(0) Quit");
                    var input = Console.ReadLine();
                    if (Int32.TryParse(input, out int value))
                        switch (value)
                        {
                            case 1: return 1;
                            case 2: return 2;
                            case 0: return 0;

                            default: Console.WriteLine("Invalid Option"); break;
                        }
                }
            } while (true);
        }
    }
}
