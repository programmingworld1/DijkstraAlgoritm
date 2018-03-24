using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nodes
            Knoop begin = new Knoop("Begin");
            Knoop eind = new Knoop("Eind");
            Knoop A = new Knoop("A");
            Knoop B = new Knoop("B");
            Knoop C = new Knoop("C");
            Knoop E = new Knoop("E");
            Knoop F = new Knoop("F");
            Knoop G = new Knoop("G");
            Knoop D = new Knoop("D");


            #region // Path 1
            // Path 1, Graph 1
            //Graph graph1 = new Graph();
            //begin.Afstand = 0;
            //begin.Buren.Add(A, 3); // naar A met afstand 3
            //begin.Buren.Add(C, 2); // naar C met afstand 2
            //begin.Buren.Add(B, 6); // naar B met afstand 6
            //A.Buren.Add(E, 2); // naar E met afstand 2
            //A.Buren.Add(eind, 6); // naar eind met afstand 6
            //B.Buren.Add(eind, 1); // naar eind met afstand 1
            //C.Buren.Add(E, 4); // naar E met afstand 4
            //E.Buren.Add(eind, 3); // Naar eind met afstand 3
            //string pad1 = graph1.Dijkstra(begin, eind);
            //Console.WriteLine();
            //Console.WriteLine(pad1);
            #endregion

            #region // path 2
            // Path 2, Graph 2
            //Graph graph2 = new Graph();
            //begin.Afstand = 0;
            //begin.Buren.Add(A, 1); // naar A met afstand 1
            //begin.Buren.Add(C, 5); // naar C met afstand 5
            //begin.Buren.Add(B, 4); // naar B met afstand 4
            //A.Buren.Add(D, 7); // naar D met afstand 7
            //D.Buren.Add(F, 3); // naar F met afstand 3
            //F.Buren.Add(G, 2); // naar G met afstand 2
            //G.Buren.Add(E, 3); // naar E met afstand 3
            //G.Buren.Add(eind, 1); // naar eind met afstand 1
            //E.Buren.Add(eind, 8); // naar eind met afstand 8
            //C.Buren.Add(E, 4); // naar E met afstand 4
            //B.Buren.Add(D, 5); // naar D met afstand 5
            //B.Buren.Add(C, 2); // naar C met afstand 2
            //string pad2 = graph2.Dijkstra(begin, eind);
            //Console.WriteLine();
            //Console.WriteLine(pad2);
            #endregion

            #region // Path 3
            // Path 3, Graph 3
            //Graph graph3 = new Graph();
            //begin.Afstand = 0;
            //begin.Buren.Add(A, 3); // naar A met afstand 3
            //begin.Buren.Add(C, 2); // naar A met afstand 3
            //begin.Buren.Add(B, 6); // naar A met afstand 3
            //A.Buren.Add(E, 4);
            //A.Buren.Add(D, 3);
            //C.Buren.Add(E, 6);
            //D.Buren.Add(F, 4);
            //D.Buren.Add(eind, 12);
            //E.Buren.Add(D, 2);
            //E.Buren.Add(G, 9);
            //F.Buren.Add(G, 4);
            //G.Buren.Add(D, 4);
            //G.Buren.Add(eind, 5);
            //string pad3 = graph3.Dijkstra(begin, eind);
            //Console.WriteLine();
            //Console.WriteLine(pad3);
            #endregion

            Console.ReadLine();
        }
    }
    public class Knoop
    {
        public Dictionary<Knoop, int> Buren { get; set; } // bijhodut wie de buren zijn, per knoop een intje bijhouden, dat is de afstand om van deze knoop naar de speciale buurknoop te komen.
        public int Afstand { get; set; } // afstand tot nu toe
        public Knoop Vorige { get; set; } // voor het pad kunnen afdrukken
        public string Naam { get; set; } // A B C D etc..
        public Knoop(string naam)
        {
            Vorige = null; // we hebben nog geen enkel pad gevonden
            Afstand = Int32.MaxValue / 2; // 
            Buren = new Dictionary<Knoop, int>(); // voor de buren
            this.Naam = naam; // naam die je meekrijgt
        }
    }
    public class Graph
    {
        // we bezoeken de knoop deze, tenzij die eind is.
        // vervolgens veranderen we deze de kortste knoop tot nu toe en dan zoeken we netzolang totdat het einde is en dan zijn we klaar.
        List<Knoop> open = new List<Knoop>();
        public string Dijkstra(Knoop begin, Knoop eind) 
        {
            Knoop deze = begin; // waar mee je begint
            while(!Bezoek(deze, eind)) // zolang we niet de eindknoop bezoeken, bezoeken we dus deze, oftewel zolang deze niet de eindknoop is en we gaan hem zoeken gaan we door. Doorgaan betekend : we veranderen deze in de kortste knoop die we tot nu toe hebben.
            {
                // pak het to nu toe kosrste pad, eerste a + tweede a, previous + derde a, previus plus vierde a, previous plus  vijfde a.
                deze = open.Aggregate((l, r) => l.Afstand < r.Afstand ? l : r); // we maken deze gelijk aan de knoop in de collectie open die de kleinste afstand heeft. Dat is precies wat we wilde, Dijkstra zij pak de knoop met de tot nu toe de kortste pad en die gaan we bezoeken. 
            }
            return MaakPad(eind); // die maakt die string waarbij die zegt we hebben de pad gevonden en dan moet je die juiste knopen in de juiste volgorde in dat stringetje zetten om op scherm te zetten.
        }

        public string MaakPad(Knoop eind)
        {
            List<string> stappenPad = new List<string>();
            Knoop vorige = eind;
            string deelPad = null;
            string volledigPad = null;
            while (vorige != null)
            {
                deelPad = vorige.Naam;
                stappenPad.Add(deelPad);
                vorige = vorige.Vorige;
            }
            stappenPad.Reverse();
            foreach (var item in stappenPad)
            {          
                volledigPad += (item + " ");
            }
            return volledigPad;
        }

        public bool Bezoek(Knoop deze, Knoop eind) // knoop deze, de noop die we willen bezoeken en de knoop eind.
        {
            Console.WriteLine("Ik bezoek knoop : " + deze.Naam);
            // checken op eind, als de knoop deze gelij kis aan de eindknoop. Als we true returnen in de whileloop dan zijn we klaar. Dan kunnen we het korste pad maken en zometeen afdrukken
            if(deze == eind)
            {
                return true;
            }
            // niet meer bezoeken
            if(open.Contains(deze)) // als we de knoop deze bezoeken moeten dan we hem uit het lijstje halen van de nog te bezoeken knopen. Als deze erin zit moeten we hem eruit halen. 
            {
                open.Remove(deze);
            }
            // Buren aflopen
            foreach(KeyValuePair<Knoop, int> x in deze.Buren) // Buren van elk knoop aflopen, in dit geval van deze. Dus die halen we eruit.
            {
                int nieuweAfstand = deze.Afstand + x.Value; // Afstand dat we tot nu toe hebben + waarde die je nodig hebt om tot die knoop te komen.
                if (nieuweAfstand < x.Key.Afstand) // Als dat korter is dan de afstand die we eventueel al hadden berekend voor x, dan moeten we hem aanpassen. Als de nieuwe afstand die we berekend hebben via de knoop deze, als dat sneller is dan de afstand die x tot nu toe(in hetb egin was die oneindig dus het was altijd zo) had dan moeten we die afstand aanpassen.
                {
                    x.Key.Afstand = nieuweAfstand; // Nieuwe afstand zetten als sneller is
                    x.Key.Vorige = deze; // Als we een nieuwe afstand moeten berekenen betekend het dat de route via deze naar zijn kind knoop x de snelste route tot nu toe is, en dat willen we onthouden. Dus op dit moment onthouden we van knoop x dat we de snelste route daarna via de knop deze was. Van de knopp x, zijn vorige wordt gelijk aan deze.
                    open.Add(x.Key); // Uiteindelijk moeten we de knoop x nog kunnen bezoeken dus voegen we het toe aan het lijstje zodat als dit tot nu de kortste pad is we die ook kunnen bezoeken.
                }
            }
            return false; // Zodat de whileloop niet eindigd. Bij true wel maar we moeten er nog doorheen.
        }
    }
}