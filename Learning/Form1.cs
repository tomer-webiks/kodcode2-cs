using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Learning
{
    public partial class Form1 : Form
    {
        private string[] names = new string[10];

        public Dog[] Dogs = new Dog[10];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 2 options to initialize an array
            // 1. Define the length of the array
            int[] ages = new int[10];

            ages[0] = 23; // 1st element
            ages[1] = 45; // 2nd element

            Console.WriteLine(ages[0]);

            // 2. Define an array with values
            int[] grades = { 100, 100, 99 };


            // Loops
            // 1. 'For'
            //  - (1) initialization
            //  - (2) Condition
            //  - (3) Change values
            Console.WriteLine("-- for ()");
            for (int i = 0 ; i < grades.Length ; i++)
            {
                //Console.WriteLine("Grade " + i + ": " + grades[i]);
                Console.WriteLine($"Grade {i}: {grades[i]}");
            }

            // 2. 'foreach'
            Console.WriteLine("-- foreach");
            foreach (int oneAge in ages)
            {
                Console.WriteLine(oneAge);
            }

            names[0] = "Tomer Sagi";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student[] studentArr = new Student[25];

            studentArr[0] = new Student();
            studentArr[0].FirstName = "Test";
            studentArr[0].LastName = "Bergman";

            //studentArr[0] = new Student();
            //studentArr[0].FirstName = "Shalom";
            //studentArr[0].LastName = "Bergman";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // תרגיל
            // להגדיר 3 משתנים
            // int, double, string
            // Perform '+' operation for all combinations (8 combinations)
            // Print the result of each operation to Console or label.Text
            // Understand the LOGIC behind it
            // Bonus: Print the 'type' of the result using .GetType() method
            int a = 6;
            float b = 7.5f;
            string c = "Hello";

            Console.WriteLine(a + c);
            Console.WriteLine((a + c).GetType());

            Console.WriteLine(a + b);
            Console.WriteLine((a + b).GetType());

            Console.WriteLine(b + c);
            Console.WriteLine((b + c).GetType());

            Console.WriteLine(a + a);
            Console.WriteLine((a + a).GetType());


            Console.WriteLine(a + b + c);
            Console.WriteLine((a + b + c).GetType());


            char d = 'a';
            int h = d;

            Console.WriteLine(d);
            Console.WriteLine(h);
            Console.WriteLine(d + h);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Console.WriteLine(d3.Name);
            //Console.WriteLine(d4.Food);
            //Console.WriteLine(d4);

            //// 'Size()'
            //d3.Size();
            //d4.Size();

            //// 'Eat()' 
            //d3.Eat();
            //d4.Eat();

            //// 'changeName()'
            //d3.ChangeName("My Lovely Dog");
            //Console.WriteLine(d3.Name);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Dog d1 = new Dog();
            //Dog d2 = new Dog("Chuppy");
            //Dog d3 = new Dog("Doggy", 24.4f, 44.2f, "Super Food");
            //Dog d4 = new Dog();
            //d4.Name = "Pitzi";
            //d4.Height = 4.5f;

            //Dogs[0] = d3;
            //Dogs[1] = d4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (Dog d in Dogs)
            {
                if (d != null)
                {
                    Console.WriteLine(d);
                } else
                {
                    break;
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dog dog = new Dog();

            // Classical setter and getter
            dog.SetName("George");
            Console.WriteLine(dog.GetName());


            Student student = new Student();
            student.Name = "Tomer"; // logic 'set'
            //student.Age = 45;


        }
    }
}
