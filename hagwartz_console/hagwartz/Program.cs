// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;

namespace hagwartz
{
    class program
    {
        static void Main(String[] args)
        {
            int sefr = 0;
            string[] human1 = new string[100];

            using (StreamReader file = new StreamReader(@"D:\file.txt"))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    human1 = ln.Split("\t").ToArray<string>();
                }
                file.Close();
            }
            //Human[] human = new Human[100];
            // instace of Human class
            for (int i = 0; i < human1.Length; i++)
                Human.human[i] = new Human();
            // complete instances of Human class
            for (int i = 0; i < human1.Length; i++)
            {
                if (i % 8 == 0)
                    Human.human[i / 8].name = human1[i];
                else if (i % 8 == 1)
                    Human.human[i / 8].lastname = human1[i];
                else if (i % 8 == 2)
                    Human.human[i / 8].birthyear = Convert.ToInt32(human1[i]);
                else if (i % 8 == 3)
                {
                    if (human1[i % 8] == "man")
                        Human.human[i / 8].gender = false;
                    else if (human1[i % 8] == "woman")
                        Human.human[i / 8].gender = true;
                }
                else if (i % 8 == 4)
                    Human.human[i / 8].fathersname = human1[i];
                else if (i % 8 == 5)
                    Human.human[i / 9].username = human1[i];
                else if (i % 8 == 6)
                    Human.human[i / 8].password = human1[i];
                else if (i % 8 == 7)
                {
                    if (human1[i % 8] == "muggle_blood")
                        Human.human[i / 8].kindof = Human.kind.muggle_blood;
                    else if (human1[i % 8] == "pure_blood")
                        Human.human[i / 8].kindof = Human.kind.pure_blood;
                    else if (human1[i % 8] == "half_blood")
                        Human.human[i / 8].kindof = Human.kind.half_blood;
                }
            }
            for (int i = 0; i < 11; i++)
            {
                Teacher.teacher[i] = new Teacher();
            }
            Lessons.lessons[0] = "magic"; Lessons.lessons[1] = "history"; Lessons.lessons[2] = "plant"; Lessons.lessons[3] = "chemistary";
            Lessons.lessons[4] = "sport"; Lessons.lessons[5] = "botany"; Lessons.lessons[6] = "human in eslam"; Lessons.lessons[7] = "math";
            Lessons.lessons[8] = "physique"; Lessons.lessons[9] = "discrete"; Lessons.lessons[10] = "voldemort logic";
            for(int i=0; i<10; i++)
            {
                Teacher.teacher[i] = new Teacher();
            }
            Teacher.teacher[0].name = "hossein"; Teacher.teacher[0].name = "rafiee"; Teacher.teacher[0].username = "hossein rafiee"; Teacher.teacher[0].password = "100";
            Teacher.teacher[1].name = "snape"; Teacher.teacher[1].name = "kazemi"; Teacher.teacher[1].username = "snape kazemi"; Teacher.teacher[1].password = "101";
            Teacher.teacher[2].name = "behnam"; Teacher.teacher[2].name = "safavie"; Teacher.teacher[2].username = "behnam safavie"; Teacher.teacher[2].password = "102";
            Teacher.teacher[3].name = "ali"; Teacher.teacher[3].lastname = "safavi"; Teacher.teacher[3].username = "ali safavi"; Teacher.teacher[3].password = "103";
            Teacher.teacher[4].name = "moosa"; Teacher.teacher[4].lastname = "jamshidi"; Teacher.teacher[4].username = "moosa jamshidi"; Teacher.teacher[4].password = "104";
            Teacher.teacher[5].name = "daniel"; Teacher.teacher[5].lastname = "olson"; Teacher.teacher[5].username = "daniel olson"; Teacher.teacher[5].password = "105";
            Teacher.teacher[6].name = "harry"; Teacher.teacher[6].lastname = "amooshahi"; Teacher.teacher[6].username = "hary amooshahi."; Teacher.teacher[6].password = "106";
            Teacher.teacher[7].name = "yalda"; Teacher.teacher[7].name = "moosavi"; Teacher.teacher[7].username = "yalda moosavi"; Teacher.teacher[7].password = "107";
            Teacher.teacher[8].name = "ziba"; Teacher.teacher[8].name = "jafari"; Teacher.teacher[8].username = "ziba jafari"; Teacher.teacher[8].password = "108";
            Teacher.teacher[9].name = "aram"; Teacher.teacher[9].name = "mokhtari"; Teacher.teacher[9].username = "aram mokhtari"; Teacher.teacher[9].password = "109";
            Dumbeldor.humansnumber = human1.Length;
            Human.choose();
            




            


        }
    }
}
