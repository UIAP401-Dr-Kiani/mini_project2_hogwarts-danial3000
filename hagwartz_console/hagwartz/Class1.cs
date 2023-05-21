using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public string[,,] jadval = new string[6, 5,1];
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
        public static string whichday(int a)
        {
            if (a == 0) return "saturday";
            else if (a == 1) return "sunday";
            else if (a == 2) return "monday";
            else if (a == 3) return "tuseday";
            else if (a == 4) return "wednesday";
            else if (a == 5) return "thurseday";
            else return "out of range";
        }
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
                    for (int i = 0; i < (Dumbeldor.humansnumber / 9)-Teacher.noteacher; i++)
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
                    Console.WriteLine("c)Determine Team \nd)select units \ne)exit");
                    string choo;
                    choo = Console.ReadLine();
                    if (choo == "d")
                    {
                        //start of writting the lessons and times
                        for(int i=0; i<Teacher.noteacher ; i++)
                        {
                            if (Teacher.teacher[i].select_unit == true)
                            {
                                for (int f = 0; f < 10; f++)
                                {
                                    for (int j = 0; j < 6; j++)
                                    {
                                        for (int k = 0; k < 5; k++)
                                        {
                                            for (int d = 0; d < 2; d++)
                                            {
                                                if (Lessons.lessons[f] == Teacher.teacher[i].jadval[j,k,d])
                                                {
                                                    Console.WriteLine(Lessons.lessons[f]+" "+ Teacher.teacher[i].username+" "+$"{8+2*k}:{10+2*k} day of week : {whichday(j)} number : {Lessons.code_of_class_teachers[i,f,0]}");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //end of writting the lessons and times
                        int number_of_lessons, th_of_lessons;
                        Console.WriteLine("enter the number of lessons :)");
                        number_of_lessons = Convert.ToInt32(Console.ReadLine());
                        for(int i=0; i<number_of_lessons ; i++)
                        {
                            th_of_lessons = Convert.ToInt32(Console.ReadLine());
                            for(int t=0; t<30/*tedad teacher ha*/ ; t++)
                            {
                                for(int h=0; h<10 ; h++)
                                {
                                    if (Lessons.code_of_class_teachers[t,h,0] == Convert.ToString(th_of_lessons))
                                    {
                                        for (int r1 = 0; r1 < 6; r1++) {
                                            for (int r2 = 0; r2 < 5; r2++) {
                                                for (int d = 0; d < 2; d++) {
                                                    if (students[ncoming].jadval[r1, r2, 0] != null && d==0)
                                                    {
                                                        Console.WriteLine("Impossible");
                                                    }
                                                    else if (Teacher.teacher[t].jadval[r1,r2,d] == Lessons.lessons[h] && students[ncoming].jadval[r1, r2, 0] == null)
                                                    {
                                                        students[ncoming].jadval[r1,r2,0] = Lessons.lessons[h];
                                                    }                                                   
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (choo == "c" && Student.students[ncoming].havegroup==false)
                    {
                        Team.student_group();
                        Console.WriteLine("your team is " + Team.teamofmembers[ncoming]);
                        Dormitory.dormitoryfunc();
                    }
                    else if(choo == "c" && Student.students[ncoming].havegroup == true)
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
        public static int noteacher = 0;
        public bool select_unit = false;
        public static string[] nameofclasses = new string[30];
        public string[, ,] jadval = new string[6,5,2];
        public bool asked_concurrent_teaching = false;
        public static int teacher_ncoming = -1;
        public static Teacher[] teacher = new Teacher[100];
        public bool concurrent_teaching = false;
        public static void choosed_teacher()
        {
            bool tf = false;
            string username;
            string password;
            while (!tf)
            {
                Console.WriteLine("enter your username : ");
                username = Console.ReadLine();
                Console.WriteLine("enter your password : ");
                password = Console.ReadLine();
                for (int i = 0; i <= Teacher.noteacher; i++)
                {
                    if (teacher[i].username == username && teacher[i].password == password)
                    {
                        teacher_ncoming = i;
                        tf = true;
                        break;
                    }
                }
                if (!tf)
                {
                    string chose;
                    Console.WriteLine("a)try again \ne)exit");
                    chose = Console.ReadLine();
                    if(chose == "e" || chose == "E")
                    {
                        Dumbeldor.choose();
                    }
                    else
                    {
                        choosed_teacher();
                    }
                }
            }
            while (tf) { 
            Console.WriteLine("b)Select Unit \nc) \nd) \ne)exit");
            string choo;
            choo = Convert.ToString(Console.ReadLine());
            bool btf = true;
                if (choo == "b")
                {

                    if (tf && !teacher[teacher_ncoming].select_unit)
                    {
                        int i = 0, j = 0, k = 0, d = 0;
                        string answer = "";
                        if (teacher[teacher_ncoming].asked_concurrent_teaching == false)
                        {
                            Console.WriteLine("hello miss/mr " + teacher[teacher_ncoming].username + " can you be in two place at the same time (Y/N)?");
                            answer = Console.ReadLine();
                            if (answer == "y" || answer == "Y" || answer == "yes")
                            {
                                teacher[teacher_ncoming].concurrent_teaching = true;
                                teacher[teacher_ncoming].asked_concurrent_teaching = true;
                            }
                            else if (answer == "n" || answer == "N" || answer == "no")
                            {
                                teacher[teacher_ncoming].concurrent_teaching = false;
                                teacher[teacher_ncoming].asked_concurrent_teaching = true;
                            }
                        }
                        if (!teacher[teacher_ncoming].asked_concurrent_teaching)
                        {
                            Console.WriteLine("you have selected your units and times of it");
                        }
                        else if (teacher[teacher_ncoming].asked_concurrent_teaching)
                        {
                            Console.WriteLine("how many lesson do you can teach?");
                            i = Convert.ToInt32(Console.ReadLine());
                            for (int i1 = 0; i1 < i; i1++)
                            {
                                Console.WriteLine("Enter the name of lesson : ");
                                nameofclasses[i1] = Convert.ToString(Console.ReadLine());
                                for (int h = 0; h < 11; h++)
                                {
                                    if (Lessons.lessons[h] == nameofclasses[i1])
                                    {
                                        Lessons.code_of_class_teachers[teacher_ncoming,h, 0] = Convert.ToString(Lessons.code_select_unit);
                                        Lessons.code_select_unit++;
                                        break;
                                    }
                                }
                                Console.WriteLine("how many seisson in week do you have?");
                                j = Convert.ToInt32(Console.ReadLine());
                                for (int j1 = 0; j1 < j; j1++)
                                {
                                    bool possible = true;
                                    while (possible)
                                    {
                                        Console.WriteLine("Enter the number of day (saturday=0 ; sunday=1 ; ...)");
                                        k = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("enter the hour of start of your class (all classes will long 2 hours)");
                                        d = Convert.ToInt32(Console.ReadLine());
                                        if (teacher[teacher_ncoming].jadval[k, (d - 8) / 2, 0] == null)
                                        {
                                            teacher[teacher_ncoming].jadval[k, (d - 8) / 2, 0] = nameofclasses[i1];
                                            possible = false;
                                        }
                                        else if (teacher[teacher_ncoming].jadval[k, (d - 8) / 2, 1] == null && teacher[teacher_ncoming].concurrent_teaching == true && teacher[teacher_ncoming].jadval[k, (d - 8) / 2, 0] != nameofclasses[i1])
                                        {
                                            teacher[teacher_ncoming].jadval[k, (d - 8) / 2, 1] = nameofclasses[i1];
                                            possible = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Impossible");
                                            possible = true;
                                        }
                                    }
                                }
                            }
                        }
                        teacher[teacher_ncoming].select_unit = true;
                    }
                }
                else if (choo == "e")
                {
                    Dumbeldor.choose();
                }
                /*else
                {
                    choosed_teacher();
                }*/
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
        public static int code_select_unit = 0 ;
        public static string[,,] code_of_class_teachers = new string[100,11,1];                                                                                               
        public static string[] lessons = new string[15];
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
