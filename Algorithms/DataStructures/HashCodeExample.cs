using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class HashCodeExample
    {
        static void Main(string[] args)
        {
            var number1 = new PhoneNumber() { AreaCode = "141804", Exchange = "27", Number = "90319334" };
            var number2 = new PhoneNumber() { AreaCode = "141804", Exchange = "27", Number = "90319334" };

            Console.WriteLine(number1.GetHashCode());
            Console.WriteLine(number2.GetHashCode());
            Console.WriteLine(value: number1 == number2);
            Console.WriteLine(number1.Equals(number2));

            var customers = new Dictionary<PhoneNumber, Person>();
            customers.Add(number1, new Person());
            customers.Add(number2, new Person());

            Console.WriteLine(value: "After adding phone numbers.");

            Console.Read();
        } 
    }
}
