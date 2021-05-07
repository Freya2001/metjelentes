using System;
using System.Collections.Generic;
using System.IO;

namespace metjelentes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.feladat
            StreamReader file = new StreamReader("tavirathu13.txt");
            bool readlinesuccesful = true;
            List<string> varos = new List<string>();
            List<string> ido = new List<string>();
            List<string> szel = new List<string>();
            List<int> hom = new List<int>();
            
            while (readlinesuccesful)
            {
                string line = file.ReadLine();
                if (line == null)
                {
                    readlinesuccesful = false;
                    break;
                }
                string[] tordeltsor = line.Split(' ');
                varos.Add(tordeltsor[0]);
                ido.Add(tordeltsor[1]);
                szel.Add(tordeltsor[2]);
                hom.Add(Int32.Parse(tordeltsor[3]));

            }

            #endregion
            #region 2.feladat
            Console.WriteLine("2.feladat:");
            Console.Write("Adja meg egy település kódját! Település:");
            string adotttelep = Console.ReadLine();
            
            string legkesobbimeres = "";
            for (int i = varos.Count-1; i >= 0; i--)
            {
                if (adotttelep == varos[i])
                {
                    legkesobbimeres = ido[i];
                    break;
                }
            }
            Console.WriteLine($"Az utolsó mérési adat a megadott településről {legkesobbimeres.Insert(2, ":")}-kor érkezett.");
            Console.Write('\n');
            #endregion
            #region 3.feladat
            Console.WriteLine("3.feladat:");
            int maxhomindex = 0;
            int minhomindex = 0;
            for (int i = 0; i < hom.Count; i++)
            {
                if (hom [maxhomindex] < hom[i])
                {
                    maxhomindex = i;
                    
                }
                if (hom[minhomindex] > hom[i])
                {
                    minhomindex = i;
                    
                }
            }
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {varos[minhomindex]} {ido[minhomindex].Insert(2, ":")} {hom[minhomindex]}  fok.");
            Console.WriteLine($"A legmagasabb hőmérséklet: {varos[maxhomindex]} {ido[maxhomindex].Insert(2, ":")} {hom[maxhomindex]} fok.");
            Console.Write('\n');
            #endregion
            #region 4.feladat
            Console.WriteLine("4.feladat:");

            Console.Write('\n');
            #endregion
            #region 5.feladat
            #endregion
            #region 6.feladat
            #endregion
        }
    }
}
