using System;

namespace SampleLib
{
    public class AccessModifierBase
    {
        
        public string Name { get; set; }
        protected string Address { get; set; }
        private int Age { get; set; }
        internal string Zip { get; set; }

        //Simple methods (used instead of properties) for getting name, address etc. 
        public string GetName() => this.Name;
        protected string GetAddress() => this.Address;
        private string GetZipCode() => this.Zip;
        internal int GetAge() => this.Age;
        
    }

    public class DerivedAccessModifier : AccessModifierBase
    {
        public DerivedAccessModifier(string name, string address, int age, string zip)
        {
            base.Address = address;
            base.Name = name;
            //base.Age = age;   //can't access base class private property
            base.Zip = zip;
        }
        
        public string GetPersonInfo()
        {
            string name = base.GetName(); //can access public method
            string address = base.GetAddress(); //can access protected method
            //string zip = base.GetZipCode(); // can't access base class private method
            int age = base.GetAge(); //can access internal method just like public (within same assembly)

            return $"From public DerivedAccessModifier Class: Name {name}, Address {address}, Age {age.ToString()}";
        }
    }

    //Can't call internal class from the Main Program.cs as this is a different assembly
    internal class DerivedAnotherExample : AccessModifierBase
    {
        public DerivedAnotherExample(string name, string address, int age, string zip)
        {
            base.Address = address;
            base.Name = name;
            //base.Age = age;   //can't access base class private property
            base.Zip = zip;
        }

        public string GetPersonInfo()
        {
            string name = base.GetName(); //can access public method in base class
            string address = base.GetAddress(); //can access protected method in base class
            //string zip = base.GetZipCode(); // can't access base class private method
            int age = base.GetAge(); //can access internal method in base class (in same assembly)

            return $"From Internal DerivedAnotherExample Class: Name {name}, Address {address}, Age {age.ToString()}";
        }
    }
}
