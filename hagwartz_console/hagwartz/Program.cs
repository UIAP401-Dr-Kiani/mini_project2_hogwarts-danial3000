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
            Dumbeldor.humansnumber = human1.Length;
            Human.choose();
            




            


        }
    }
}
