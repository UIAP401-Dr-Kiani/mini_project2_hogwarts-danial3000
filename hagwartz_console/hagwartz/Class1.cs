using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hagwartz
{
    public class Human
    {
        public string name= "";
        public string lastname = "";
        public int birthyear = -1 ;
        public bool gender = false ;
        // man = false //  woman = true
        public string fathersname = "";
        public string username = "";
        public string password = "";
        public enum kind
        {
            muggle_blood, pure_blood, half_blood
        }
        public kind kindof = kind.muggle_blood ;

    }

    public class Acceptable : Human
    {
        public string schedule ;
        public enum pet
        {
            rat , cat , owl
        }
        public string group ;
        bool suitcase ;
        public enum job
        {
            student , teacher
        }
        public string[] mails;

    }
    
    public class Team
    {
        public int score;
        public enum group
        {
            slytherin , ravenclaw , gryfinndor , hufflepuff
        }
        public string[] members;
        public string[] quideech_members;
    }

    public class Student : Acceptable
    {
        public int passed_units;
        public int term;
        public int dormitory_number;
    }

    public class Teacher : Acceptable
    {
        public bool concurrent_teaching;
    }
    public class Dumbeldor : Acceptable
    {
        Dormitory[] list_of_dormitory;
        static private Dumbeldor dum;
        private Dumbeldor()
        {
        }
        public static Dumbeldor geter()
        {
            if( dum == null )
            {
                dum = new Dumbeldor();
            }
            return dum;
        }
    }
    public class Lessons
    {
        public DateTime time;
        public int numberofstudents;
        public string name ;
        public int presentationterm;
        public int capacity;
    }

    public class Plant
    {
        public string name ;
        public int number;
    }
    public class Chemistary : Lessons
    {
        public string[] name_of_materials;
    }
    public class Magic : Lessons
    {
        public string[] Charms;
    }
    public class Sport : Lessons
    {
        public string sport_kind ;
    }
    public class Botany : Lessons
    {
        public string[] listofplant1;
        public string[] listofplant2;
        public string[] listofplant3;
        public string[] listofplant4;
    }
    public class Dormitory
    {
        public string group;
        public int floor;
        public int room;
        public int bed;
        public bool gender;
        Dormitory(int frb)
        {
            this.floor = (frb / 100) % 5;
            this.room = (frb / 10) % 10;
            this.bed = (frb % 10);
        }
    }
}
