using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSearchPerformanceTest
{
    public class Student
    {
        public int Jmbg { get; set; }
        public String Name { get; set; } = String.Empty;
        public String Surname { get; set; } = String.Empty;
        
        public Student(int jmbg, String name, String surname)
        {
            Jmbg = jmbg;
            Name = name;
            Surname = surname;
        }


       //Ovo zbog brze pretrage hesh vrednosti  
       //KOMPLEKSNOT SADA O(1) valjda?
       public override bool Equals(object? obj)
        {
            if (obj is Student other)
            { //nasumicne 
                return this.Jmbg == other.Jmbg;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Jmbg.GetHashCode(); // Koristi JMBG kao osnovu za generisanje hash koda
            //hesh za ime, prezime ?
        }

    }
}
