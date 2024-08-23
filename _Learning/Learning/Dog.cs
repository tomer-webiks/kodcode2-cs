using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    public class Dog
    {

        // Attributes
        private string _name;
        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            if (name == null || name == "")
            {
                Console.WriteLine("Name cannot be empty");
            } else
            {
                _name = name;
            }
        }


        private float _height;
        private float _weight;
        private string _food;

        // Default constructor
        public Dog()
        {

        }

        public Dog(string name)
        {
            _name = name;
        }

        public Dog(string name, float height, float weight, string food) 
        {
            _name = name;
            _height= height;
            _weight = weight;
            _food = food;
        }

        //public void Size()
        //{
        //    Console.WriteLine("Height: " + Height + " ; Weight: " + Weight);
        //} // Method scope

        //public void Eat()
        //{
        //    Console.WriteLine(Name + " is eating " + Food);
        //}

        //public void ChangeName(string name)
        //{
        //    Name = name;
        //}

        //public string GetValues()
        //{
        //    return Name + " ; " + Height + " ; " + Weight + " ; " + Food;
        //}

    } // Class scope
} // Namespace scope
