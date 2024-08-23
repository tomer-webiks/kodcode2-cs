using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning
{
    public class Student
    {
        public int Id;
        public string FirstName;
        public string LastName;

        /// <summary>
        ///  Incorrect
        /// </summary>
        public string Name
        {
            get { return Name; }
            set { Name = value; }
        }

        /// <summary>
        ///  Correct
        /// </summary>
        private int _age;
        public int Age
        {
            get { return _age; }
            set {
                // Validate 'value' - Check for errors
                if (value < 0 || value > 120)
                {
                    Console.WriteLine("Error: Age must be between 0 and 120. " + value);
                } else
                {
                    _age = value;
                }
            }
        }

        public void printArray()
        {
            int[] steps = { 1, 2, 3, 4, 5 };

            Array.Sort(steps);

            // Lambda expression
            int result = Array.Find(steps, step => step == 3);

            
        }

        private int findStep(int[] steps, int stepToFind)
        {
            foreach (int step in steps)
            {
                if (step == 3)
                {
                    return step;
                }
            }

            return -1;
        }

    }
}
