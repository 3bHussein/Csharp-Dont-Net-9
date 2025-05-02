using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class App
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("hello");
            
            sum(1);

            //Console.ReadLine();

            // how to delcar variable
            int StudentNumber;
            string Student_Name;
            int Student_Age;
            StudentNumber = 1;
            Console.WriteLine(StudentNumber);
            Student_Name = Console.ReadLine();
            int n1 = 5;
            float f1 = 6.5f;
            string name1 = "name ";
            bool b1 = true;
            Console.WriteLine("hello we try to check the vairable"+":"+n1+" "
                + " "+f1 + " "+name1 + " "+b1
                );


            int mark = 0;

            Console.WriteLine("enter your mar");
           
            string s = Console.ReadLine();
            mark = int (s);

            //if statement
            if (mark >50)
            {
                Console.WriteLine("your mark is wow "+mark);

            }
        }



        static int sum(int numb1 =0)
        {
            //numb1 = 0;
            numb1 += numb1;
            Console.WriteLine(numb1);
            return numb1;
        }

        
    }
}