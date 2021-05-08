using System;
using System.Collections.Generic;
using System.IO;

namespace metjelentes
{
    class Program
    {
        class adat
        {
            public adat(string varos_,string ido_, string szel_, int hom_)
            {
                ido = ido_;
                szel = szel_;
                hom = hom_;
                varos = varos_;
            }
            public string varos;
            public string ido;
            public string szel;
            public int hom;
        }
        
        class HomeStat
        {
            public HomeStat(adat ad)
            {
                min = ad.hom;
                max = ad.hom;
                count = 0;
                sum = 0;
                ProcessAtlag(ad);
            }
            public int min;
            public int max;
            public int sum;
            public int count;
            public void Process(adat ad)
            {
                if (max < ad.hom)
                {
                    max = ad.hom;
                }
                if (min > ad.hom)
                {
                    min = ad.hom;
                }
                ProcessAtlag(ad);
            }
            static bool IdoJo(string ido)
            {
                ido = ido.Substring(0, 2);
                if (ido == "01" || ido == "07" || ido == "13" || ido == "19")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public string GetKozepMsg()
            {
                if (count >= 8)
                {
                    return $"Középhőmérséklet: {(sum+count/2) / count}";
                }
                else
                {
                    return "NA";
                }
            }
            void ProcessAtlag(adat ad)
            {
                if (IdoJo(ad.ido))
                {
                    sum += ad.hom;
                    count++;
                }
            }
        }
        
        static void Main(string[] args)
        {
            #region 1.feladat
            StreamReader file = new StreamReader("tavirathu13.txt");
            bool readlinesuccesful = true;
            //List<string> varos = new List<string>();
            //List<string> ido = new List<string>();
            //List<string> szel = new List<string>();
            //List<int> hom = new List<int>();
            List<adat> adatok = new List<adat>();
            Dictionary<string, HomeStat> valogatott = new Dictionary<string, HomeStat>();
            while (readlinesuccesful)
            {
                string line = file.ReadLine();
                if (line == null)
                {
                    readlinesuccesful = false;
                    break;
                }
                string[] tordeltsor = line.Split(' ');
                //varos.Add(tordeltsor[0]);
                //ido.Add(tordeltsor[1]);
                //szel.Add(tordeltsor[2]);
                //hom.Add(Int32.Parse(tordeltsor[3]));
                adatok.Add(new adat(tordeltsor[0],tordeltsor[1], tordeltsor[2], Int32.Parse(tordeltsor[3])));
            }

            #endregion
            #region 2.feladat
            Console.WriteLine("2.feladat:");
            Console.Write("Adja meg egy település kódját! Település:");
            string adotttelep = Console.ReadLine();
            
            string legkesobbimeres = "0000";
            for (int i = adatok.Count-1; i >= 0; i--)
            {
                if (adotttelep == adatok[i].varos)
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
            for (int i = 0; i < adatok.Count; i++)
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
            Console.WriteLine($"A legalacsonyabb hőmérséklet: {adatok[minhomindex].varos} {adatok[minhomindex].ido.Insert(2, ":")} {adatok[minhomindex].hom}  fok.");
            Console.WriteLine($"A legmagasabb hőmérséklet: {adatok[maxhomindex].varos} {adatok[maxhomindex].ido.Insert(2, ":")} {adatok[maxhomindex].hom} fok.");
            Console.Write('\n');
            #endregion
            #region 4.feladat
            Console.WriteLine("4.feladat:");
            bool szelcsend = false;
            for (int i = 0; i < adatok.Count; i++)
            {
                if (adatok[i].szel == "00000")
                {
                    Console.WriteLine(adatok[i].varos + " " + adatok[i].ido.Insert(2, ":"));
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
            foreach (var ad in adatok)
            {
                if (valogatott.ContainsKey(ad.varos))
                {
                    valogatott[ad.varos].Process(ad);
                }
                else
                {
                    valogatott.Add(ad.varos, new HomeStat(ad));
                }
            }
            foreach (var kv in valogatott)
            {
                
                Console.WriteLine($"{kv.Key} {kv.Value.GetKozepMsg()}; Hőmérséklet-ingadozás: {kv.Value.max - kv.Value.min}");
            }
            Console.Write('\n');
            #endregion
            #region 6.feladat
            Console.WriteLine("6.feladat:");

            Console.Write('\n');
            #endregion
        }
    }
}
