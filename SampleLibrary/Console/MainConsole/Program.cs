using SampleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DerivedAccessModifier dam = new DerivedAccessModifier("John", "123 Main St", 25, "08656");
            Console.WriteLine(dam.GetPersonInfo());
            Console.WriteLine(dam.GetName());
            //Console.WriteLine(dam.GetAddress()); //can't access protected method from outside
            //Console.WriteLine(dam.GetZipCode()); //can't access private method  from outside
            //Console.WriteLine(dam.GetAge()); //can't access internal method in a separate assembly

            //Internal class in different assembly (dll). can't access
            //DerivedAnotherExample dae = new DerivedAnotherExample("Ben", "100 New St", 25, "08323");

            //internal class in same assembly. can access from Main()
            InternalTest it = new InternalTest(21, "111 Water Street");
            Console.WriteLine($"Address {it.GetAddress()}, Age {it.GetAge().ToString()}");

            //Question 4.. replacing Names with XXXX
            //calling the name masking class here
            string searchIn = "John, Lisa, Bob and Bobby went for lunch. It was Lisa's Birthday, so John, Bobby and Bob paid for the lunch.";
            Console.WriteLine($"original text: {searchIn}");

            List<string> searchNames = new List<string> { "John", "Bobby","Bob", "Lisa" };
            string[] arrNames = new string[] { "John", "Bobby", "Bob", "Lisa" };
            string strNames = "John, Bobby, Bob, Lisa";

            MaskName mn = new MaskName(searchIn);
            //Passing List<string> of names
            Console.WriteLine($"result using List<string>: {mn.ReplaceNamesWithX('X', searchNames)}");

            //Passing string[] array
            Console.WriteLine($"Result using string[]: {mn.ReplaceNamesWithX('X', arrNames)}");

            //passing string with comman separated names
            Console.WriteLine($"Result using string: {mn.ReplaceNamesWithX('X', strNames)}");
            
            
            Console.ReadLine();
        }

        internal class InternalTest
        {
            public int internalAge { get; set; }
            protected string _address;

            public InternalTest(int age, string address)
            {
                this.internalAge = age;
                this._address = address;
            }
            public int GetAge() => this.internalAge;
            public string GetAddress() => this._address;
        }
            

    }
}
