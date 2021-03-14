using  System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hairdresserShop
{
    class Client
    {
        private string name;
        private int age;
        private decimal height;
        private string creditCardNumber;
        private string slot;


        

        public int Age { get => age; set => age = value; }
        public decimal Height { get => height; set => height = value; }
        public string CreditCardNumber { get => creditCardNumber; set => creditCardNumber = value; }
        public string Name { get => name; set => name = value; }
        public string Slot { get => slot; set => slot = value; }

        public void HairWash()
        {
            Console.WriteLine("Hair Wash");
        }

        public void HairTrim()
        {
            Console.WriteLine("Hair Trim");
        }

        public void HairDye()
        {
            Console.WriteLine("Hair Dye");
        }
        public virtual void OtherService()
        {
            Console.WriteLine("It should not be printed");
        }


        public override string ToString()
        {

            char[] cardNumber = creditCardNumber.ToCharArray();
            string card = string.Empty;
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < 16; i++) {
                 if (i >= 4 && i <= 11)
                {
                    stringBuilder.Append('X');
                }
                else {
                    stringBuilder.Append(cardNumber[i]);
                }

                if (i == 3 || i == 7 || i == 11) {
                    stringBuilder.Append(' ');
                }

            }
            
          

            return string.Format("age of client : {0}, height of client : {1}, credit card number of client : {2} ", age, height, stringBuilder);
        }
    }
}
