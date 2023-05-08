using System;
using System.Collections.Generic;
using System.Linq;
//using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
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
            else 
                choose();
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
        public bool suitcase ;
        public enum job
        {
            student , teacher
        }
        public string[] mails;

    }
    
    public class Team
    {
        public static Team teams = new Team();
        public static int team_member_numbers = 0;
        public int score;
        public enum group
        {
            slytherin , ravenclaw , gryfinndor , hufflepuff
        }
        public static group[] teamofmembers = new group[100];
        public static string[] members = new string[100];
        public string[] quideech_members;
        public static void student_group()
        {
            Console.WriteLine("Your group will assign by an spiker hat");
            Team teams = new Team();
            members[Student.ncoming] = Student.students[Student.ncoming].name + Student.students[Student.ncoming].lastname;
            Random random = new Random();
            int n = random.Next(0,100);
            teamofmembers[Student.ncoming] = (group)(n%4);
            Student.students[Student.ncoming].havegroup = true;
            team_member_numbers++;
        }
    }

    public class Student : Acceptable
    {
        public static Student[] students = new Student[100];
        public static int j = 0;
        public static int ncoming;
        public DateTime leavetrain;
        public bool inhagwartz = false;
        public bool accepted = false;
        public bool havegroup = false;
        public int passed_units;
        public int term;
        public int dormitory_number;
        public static void choosed_student()
        {
            string password;
            string username ;
            //check the username and password 
                ncoming = -1;
                bool tf = false;
                Console.WriteLine("Enter username : ");
                username = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter password : ");
                password = Convert.ToString(Console.ReadLine());
                for(int i=0; i<j; i++)
                {
                    string yn1;
                    if (students[i].password == password && students[i].username == username && students[i].suitcase == true)
                    {
                        tf = true;
                        Console.WriteLine("welcome to your pannel "+ students[i].name + " " + students[i].lastname);
                        ncoming = i;
                        break;
                    }
                    else if (students[i].password == password && students[i].username == username && students[i].suitcase == false)
                    {
                    tf = true;
                    Console.WriteLine("welcome to your pannel " + students[i].name + " " + students[i].lastname);
                    Console.WriteLine("Do you want to close your suitcase and get ready?? Y/N");
                    yn1 = Convert.ToString(Console.ReadLine());
                    if (yn1 == "y" || yn1 == "Y" || yn1 == "yes")
                    {
                        students[i].suitcase = true;
                    }
                    ncoming = i;
                    break;
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
                        students[j].leavetrain = new DateTime(2010, (12+j)%11+1, (10+5*j)%29+1);
                            while (!until)
                            {
                                Console.WriteLine(students[j].name +" "+ Human.human[i].mail + " do you want to join the hagwartz :) Y/N");
                                Console.WriteLine("the train will leave in " + students[j].leavetrain );
                                yn = Console.ReadLine();
                                if (yn == "yes" || yn == "y" || yn == "Y")
                                {
                                    students[j].accepted = true;
                                    j++;
                                    until = true;
                                    students[j].suitcase = true;
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
            while (ncoming != -1)
            {
                if (students[ncoming].inhagwartz)
                {
                    //???????? rooye in bayad kar shavad
                    Console.WriteLine("c)Determine Team \nd) \ne)exit");
                    string choo;
                    choo = Console.ReadLine();
                    if (choo == "c" && Student.students[ncoming].havegroup==false)
                    {
                        Team.student_group();
                        Console.WriteLine("your team is " + Team.teamofmembers[ncoming]);
                        Dormitory.dormitoryfunc();
                    }
                    else
                    {
                        Console.WriteLine("you are in a group right now");
                    }
                        //return to home page or not
                    if (choo == "e")
                    {   
                        Dumbeldor.choose();
                    }
                }
                else
                {
                    Console.WriteLine("b)Go to train\ne)exit");
                    //return to home page or not
                    string choo;
                    choo = Console.ReadLine();
                    if(choo == "b")
                    {
                        gototrain();
                    }
                    if (choo == "e")
                    {
                        Dumbeldor.choose();
                    }
                }
            }
            if(ncoming == -1) {
                Console.WriteLine("e)exit");
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
        public static void gototrain()
        {
            int when;
            Console.WriteLine("your train will leave in " + students[ncoming].leavetrain);
            Console.WriteLine("when do you want to move(enter the hour) ?");
            when = Convert.ToInt32(Console.ReadLine());
            if (when == (students[ncoming].leavetrain.Hour)+12)
            {
                Console.WriteLine("just in time have a safe trip");
                students[ncoming].inhagwartz = true;
            }
            else if(when < (students[ncoming].leavetrain.Hour)+12)
            {
                Console.WriteLine("you arrived soon please wait until the train come :(");
                students[ncoming].inhagwartz = true;
            }
            else
            {
                Console.WriteLine("Your late the train leave the station try another day at this time " + students[ncoming].leavetrain);
            }
        }
    }

    public class Teacher : Acceptable
    {
        public bool concurrent_teaching;
        public static void choosed_teacher()
        {
            Console.WriteLine("b)Select Unit \nc) \nd) \ne)exit");
            string choo;
            choo = Convert.ToString(Console.ReadLine());
            if(choo == "b")
            {

            }
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
        public static Dormitory[] list_of_dormitory = new Dormitory[100];
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
            Console.WriteLine("b)mailes \nc)list of dormitory \nd) \ne)exit");
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
            if(choo == "c")
            {
                string sexuality;
                for(int i=0; i<Dormitory.membersnumber; i++)
                {
                    if (list_of_dormitory[i].gender == false)
                    {
                        sexuality = "male";
                    }
                    else
                    {
                        sexuality = "female";
                    }
                    Console.WriteLine("gender : " + sexuality + "   " + "fullname : " + list_of_dormitory[i].name +"   "+ "floor : " + list_of_dormitory[i].floor +"   "+ "room : " + list_of_dormitory[i].room + "bed : " + list_of_dormitory[i].bed);
                }
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
        public DateTime[] time;
        public int numberofstudents;
        public string name ;
        public int[] presentationterm;
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
        public static int membersnumber = 0;
        //public static Dormitory[] dormitorynum = new Dormitory[100];
        public string name;
        public string group;
        public int floor;
        public int room;
        public int bed;
        public bool gender;
        public static void dormitoryfunc()
        {
            int frb1;
            if (Team.teamofmembers[Student.ncoming] == Team.group.slytherin)
            {
                frb1 = 0;
                Dumbeldor.list_of_dormitory[membersnumber] = new Dormitory(frb1,Student.ncoming);
            }
            else if (Team.teamofmembers[Student.ncoming] == Team.group.ravenclaw)
            {
                frb1 = 200;
                Dumbeldor.list_of_dormitory[membersnumber] = new Dormitory(frb1,Student.ncoming);
            }
            else if (Team.teamofmembers[Student.ncoming] == Team.group.gryfinndor)
            {
                frb1 = 400;
                Dumbeldor.list_of_dormitory[membersnumber] = new Dormitory(frb1,Student.ncoming);
            }
            else if (Team.teamofmembers[Student.ncoming] == Team.group.hufflepuff)
            {
                frb1 = 600;
                Dumbeldor.list_of_dormitory[membersnumber] = new Dormitory(frb1,Student.ncoming);
            }
            membersnumber++;
        }
        Dormitory(int frb , int number)
        {
            this.name = Student.students[number].name + Student.students[number].lastname;
            this.gender = Student.students[number].gender;
            this.name = Student.students[number].name;
            this.group = Convert.ToString(Team.teamofmembers[number]);
            frb = frb + (membersnumber / 5) * 10 + (membersnumber % 5);
            // we have 8 floor 11 room and 5 bed (from zero to i-1)
            this.floor = (frb / 100) % 8;
            this.room = ((frb / 10) % 10) % 11;
            this.bed = (frb % 5) % 5;
        }
    }
}
