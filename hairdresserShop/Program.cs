using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairdresserShop
{
    public enum Customer
    {
        Gentlemen = 1,
        Ladies=2,
        Children=3
    }
    class Program
    {
        List<string> appointmentList = new List<string>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
            Console.ReadKey();
        }


        public void Run()
        {
            List<Client> myList = new List<Client>();

            appointmentList.Add("9AM to 10AM ");
            appointmentList.Add("10AM to 11AM ");
            appointmentList.Add("11AM to 12PM ");
            appointmentList.Add("12PM to 01PM ");
            appointmentList.Add("01PM to 02PM ");
            appointmentList.Add("02PM to 03PM ");
            appointmentList.Add("03PM to 04PM ");
            appointmentList.Add("04PM to 05PM ");
            appointmentList.Add ("05PM to 06PM ");

            string input = string.Empty;
            do
            {
                string name = string.Empty;

                bool invalidInput = true;

                do
                {
                    Console.Write("Enter name: ");
                    name = Console.ReadLine();
                    if (name.Length > 0)
                    {
                        invalidInput = false;
                    }
                    else {
                        Console.WriteLine("Name length should be greater than 0");
                    }
                    

                } while (invalidInput);

              

                int age = 0;
                string ageString = string.Empty;

                invalidInput = true;

                do
                {
                    Console.Write("Enter age[1-99]: ");
                    ageString = Console.ReadLine();
                    if (int.TryParse(ageString, out age) && age > 0 && age <= 99)
                    {
                        invalidInput = false;
                    }
                    else {
                        Console.WriteLine("Invalid input");
                    }

                } while (invalidInput);

                int height = 0;
                string heightString = string.Empty;
                do
                {
                    Console.Write("Enter height in inches[10-96]: ");
                    heightString = Console.ReadLine();
                } while (!(int.TryParse(heightString, out height) && height >= 10 && height <= 96));

                string creditCard = string.Empty;
                creditCard = addCreditCard();

                int customerType = 0;
                string stringClient = string.Empty;

                do
                {
                    Console.Write("Enter Customer type (1) for Gentlemen, (2) for Ladies, (3)for Children : ");
                    stringClient = Console.ReadLine();
                } while (!(int.TryParse(stringClient, out customerType) && customerType >= (int)Customer.Gentlemen
                                && customerType <= (int)Customer.Children));

                Client client = null;
                switch (customerType)
                {
                    case (int)Customer.Gentlemen:
                        client = new Gentlemen() { Name= name, Height = height, Age = age,CreditCardNumber=creditCard };
                        string Trimming = string.Empty;

                        do
                        {
                            Console.Write("Does Gentleman need Trimming?[Y/N]");
                            Trimming = Console.ReadLine();
                        } while (Trimming.Length != 1 || (Trimming != "Y" && Trimming != "N"));

                        ((Gentlemen)client).IsTrimmingNeeded = (Trimming == "Y") ? true : false;



                        string moustaches = string.Empty;
                        do
                        {
                            Console.Write("Does Gentleman need to do moustaches?[Y/N]");
                            moustaches = Console.ReadLine();
                        } while (moustaches.Length != 1 || (moustaches != "Y" && moustaches != "N"));
                        ((Gentlemen)client).Moustaches = (moustaches == "Y") ? true : false;
                        client.Slot = selectAppoinmentSlot();
                        break;

                    case (int)Customer.Ladies:
                        client = new Ladies() { Name = name,  Height = height, Age = age, CreditCardNumber = creditCard };

                        string hairStyle = string.Empty;
                        do
                        {
                            Console.Write("Need hairstyle?[Y/N]");
                            hairStyle = Console.ReadLine();
                        } while (hairStyle.Length != 1 || (hairStyle != "Y" && hairStyle != "N"));
                        ((Ladies)client).HairStyle = (hairStyle == "Y") ? true : false;
                        client.Slot = selectAppoinmentSlot();
                        break;
                        
                    case (int)Customer.Children:
                        client = new Children() { Name = name, Height = height, Age = age, CreditCardNumber = creditCard };
                       
                        string sensitiveTrimmers = string.Empty;
                        do
                        {
                            Console.Write("Sensitive Trimmer? [Y/N]");
                            sensitiveTrimmers = Console.ReadLine();
                        } while (sensitiveTrimmers.Length != 1 || (sensitiveTrimmers != "Y" && sensitiveTrimmers != "N"));
                        ((Children)client).SensitiveTrimmers = (sensitiveTrimmers == "Y") ? true : false;
                        string adjustableSeats  = string.Empty;
                        do
                        {
                            Console.Write("Does child require adjustale seat? [Y/N]");
                            adjustableSeats = Console.ReadLine();
                        } while (adjustableSeats.Length != 1 || (adjustableSeats != "Y" && adjustableSeats != "N"));
                        ((Children)client).AdjustableSeats = (adjustableSeats == "Y") ? true : false;
                        client.Slot = selectAppoinmentSlot();
                        break;
                } 

                myList.Add(client);

                Console.Write("Do you want to enter more? [Y/N] ");
                input = Console.ReadLine();
            } while (input.Length == 0 || input.Length > 1 || input.ToUpper() == "Y");

            foreach (Client v in myList)
            {
                Console.WriteLine(v);
                v.HairWash();
                v.HairTrim();
                v.HairDye();
                v.OtherService();
            }

        }
         private  string selectAppoinmentSlot()
        {
            int slotNumber = 0;
            string slotString = string.Empty;
            string slot = string.Empty;
            do
            {
                Console.WriteLine("Select available slot[1-{0}] ", appointmentList.Count);
                for(int i=0; i<appointmentList.Count; i++)
                {
                    Console.WriteLine("{0} => {1}", i + 1, appointmentList[i]);
                }
                
                slotString = Console.ReadLine();

            } while (!(int.TryParse(slotString, out slotNumber) && slotNumber >= 1 && slotNumber <= appointmentList.Count));

            //slot selected
            slot = appointmentList[slotNumber - 1];

            //booked appointment remove from available slots
            appointmentList.Remove(slot);

            return slot;


        }
           private string addCreditCard()
        {
            string creditCard = string.Empty;
            bool isInCorrect = true;
            do
            {
                Console.Write("Enter creditcard number : ");
                

                creditCard = Console.ReadLine();
                if (creditCard != string.Empty && creditCard != null && creditCard.Length == 16)
                {
                    
                    char[] cardArray = creditCard.ToCharArray();

                    foreach (char c in cardArray)
                    {
                        if (!char.IsDigit(c))
                        {
                            isInCorrect = true;

                            break;
                        }
                    }
                    isInCorrect = false;


                }
                
                if (isInCorrect) {
                    Console.WriteLine("Invalid credit card!");
                }
               
               
            } while (isInCorrect);
            return creditCard;

        }

    }
}
