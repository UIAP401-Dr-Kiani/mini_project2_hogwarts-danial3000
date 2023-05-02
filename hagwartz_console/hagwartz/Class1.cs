using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwartz
{
    public class Human
    {
        public string name ;
        public string lastname;
        public int birthyear;
        public bool gender;
        // man = false //  woman = true
        public string fathersname;
        public int username;
        public int password;
        public enum kind
        {
            muggle_blood , pure_blood , half_blood
        }
    }
    
    public class Team
    {
        public int score;
        public enum type
        {
            slytherin , ravenclaw , gryfinndor , hufflepuff
        }
        public string[] members;
        public string[] quideech_members;
    }

    public class Student
    {
        public int passed_units;
        public int term;
        public int dormitory_number;
    }

    public class Teacher
    {
        public bool concurrent_teaching;
    }
    /*public class Dumbeldor
    {

    }*/
    public class Lessons
    {
        public DateTime time;
        public int numberofstudents;
        public string name;
        public int presentationterm;
        public int capacity;
    }

    public class Plant
    {
        public string name;
        public int number;
    }
}
