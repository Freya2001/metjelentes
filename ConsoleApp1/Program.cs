using System;
using System.Collections.Generic;
using System.IO;

namespace metjelentes
{
    class Program
    {
        struct adat
        {
            public adat(string ido_, string szel_, int hom_)
            {
                ido = ido_;
                szel = szel_;
                hom = hom_;
            }
            public string ido;
            public string szel;
            public int hom;
        }
        static void Main(string[] args)
        {
            #region 1.feladat
            StreamReader file = new StreamReader("tavirathu13.txt");
            bool readlinesuccesful = true;
            List<string> varos = new List<string>();
            //List<string> ido = new List<string>();
            //List<string> szel = new List<string>();
            //List<int> hom = new List<int>();
            List<adat> adatok = new List<adat>();
            Dictionary<string, adat> valogatott = new Dictionary<string, adat>();
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
                //ido.Add(tordeltsor[1]);
                //szel.Add(tordeltsor[2]);
                //hom.Add(Int32.Parse(tordeltsor[3]));
                adatok.Add(new adat(tordeltsor[1], tordeltsor[2], Int32.Parse(tordeltsor[3])));
            }

            #endregion
            #region 2.feladat
            Console.WriteLine("2.feladat:");
            Console.Write("Adja meg egy település kódját! Település:");
            string adotttelep = Console.ReadLine();
            
            string legkesobbimeres = "";
            for (int i = adatok.Count-1; i >= 0; i--)
            {
                if (adotttelep == varos[i])
                {
                    legkesobbimeres = adatok[i].ido;
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
            for (int i = 0; i < varos.Count; i++)
            {
                if (adatok[maxhomindex].hom < adatok[i].hom)
                {
                    maxhomindex = i;
                    
                }
                if (adatok[minhomindex].hom > adatok[i].hom)
                {
                    minhomindex = i;
                    
                }
            }
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {varos[minhomindex]} {adatok[minhomindex].ido.Insert(2, ":")} {adatok[minhomindex].hom}  fok.");
            Console.WriteLine($"A legmagasabb hőmérséklet: {varos[maxhomindex]} {adatok[maxhomindex].ido.Insert(2, ":")} {adatok[maxhomindex].hom} fok.");
            Console.Write('\n');
            #endregion
            #region 4.feladat
            Console.WriteLine("4.feladat:");
            bool szelcsend = false;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].szel == "00000")
                {
                    Console.WriteLine(varos[i] + " " + adatok[i].ido.Insert(2, ":"));
                    szelcsend = true;
                }
            }
            if (szelcsend == false)
            {
                Console.WriteLine("Nem volt szélcsend a mérések idején.");
            }
            Console.Write('\n');
            #endregion
            #region 5.feladat
            Console.WriteLine("5.feladat:");

            Console.Write('\n');
            #endregion
            #region 6.feladat
            Console.WriteLine("6.feladat:");

            Console.Write('\n');
            #endregion
        }
    }
}
