using System;
using System.Collections.Generic;
using System.Linq;
//using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hagwartz
{
    public class Human
    {
        public static Human[] human = new Human[100];
        public string mail;
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
        public static void choose()
        {
            string choo;
            Console.WriteLine("a)Dumbeldor \nb)Teacher \nc)Stuendt");
            choo = Console.ReadLine();
            if (choo == "a")
                Dumbeldor.choosed_dumbeldor();
            if(choo == "b")
                Teacher.choosed_teacher();
            if (choo == "c")
                Student.choosed_student();
        }
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
        public static Student[] students = new Student[100];
        public static int j = 0;
        public bool accepted = false;
        public int passed_units;
        public int term;
        public int dormitory_number;
        public static void choosed_student()
        {
            string password;
            string username ;
            //check the username and password 
            if (j == 0 || Student.students[j].accepted == false)
            {
                bool tf = false;
                Console.WriteLine("Enter username : ");
                username = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter password : ");
                password = Convert.ToString(Console.ReadLine());
                for(int i=0; i<j; i++)
                {
                    if (students[i].password == password && students[i].username == username)
                    {
                        tf = true;
                        Console.WriteLine("welcome to your pannel "+ students[i].name + " " + students[i].lastname);
                    }  
                }
                if (!tf) {
                    for (int i = 0; i < Dumbeldor.humansnumber / 8; i++)
                    {
                        if (Human.human[i].username == username && Human.human[i].password == password)
                        {
                            string yn;
                            bool until = false;
                            students[j] = new Student();
                            students[j + 1] = new Student();
                            students[j].password = password;
                            students[j].username = username;
                            students[j].name = Human.human[i].name;
                            students[j].lastname = Human.human[i].lastname;
                            students[j].passed_units = 0;
                            students[j].term = 1;
                            while (!until)
                            {
                                Console.WriteLine(Human.human[j].name + Human.human[j].mail + " do you want to join the hagwartz :) Y/N");
                                yn = Console.ReadLine();
                                if (yn == "yes" || yn == "y" || yn == "Y")
                                {
                                    students[j].accepted = true;
                                    j++;
                                    until = true;
                                }
                                else if (yn == "no" || yn == "n" || yn == "N")
                                {
                                    students[j].accepted = false;
                                    until = true;
                                }
                            }
                        }
                    } 
                }
            }
            Console.WriteLine("b) \nc) \nd) \ne)exit");
            //return to home page or not
            string choo;
            choo = Console.ReadLine();
            if (choo == "e")
            {
                Dumbeldor.choose();
            }
            else
            {
                choosed_student();
            }
        }
    }

    public class Teacher : Acceptable
    {
        public bool concurrent_teaching;
        public static void choosed_teacher()
        {
            string choo;
            choo = Console.ReadLine();
            if (choo == "e")
            {
                Dumbeldor.choose();
            }
            else
            {
                choosed_teacher();
            }
        }
    }
    public class Dumbeldor : Acceptable
    {
        public static int humansnumber;
        Dormitory[] list_of_dormitory;
        //start of singelton
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
        //end of singeltone
        static bool sendemail = false;
        public static void choosed_dumbeldor()
        {
            string choo;
            // sending email from dumbeldor
            if (!sendemail)
            {
                Console.WriteLine("a)send email");
            }
            // access to methodes
            Console.WriteLine("b) mailes \nc) \nd) \ne)exit");
            choo = Console.ReadLine();
            //writing email as the dumbeldor
            if (choo == "a" && !sendemail) 
            {
                Console.WriteLine("Write the Email");
                string mail = "";
                mail = Convert.ToString(Console.ReadLine());
                for(int i = 0; i < humansnumber/8 ; i++)
                {
                    Human.human[i].mail = mail;
                }
                sendemail=true;
            }
            //return to home page or not
            if(choo == "e")
            {
                Dumbeldor.choose();
            }
            else
            {
                choosed_dumbeldor();
            }
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
