using System.Globalization;
using System;
using System.Collections.Generic;
using System.IO;

namespace TerkepAdatok
{
    public class Adatok
    {
        double minX, minY, maxX, maxY;
        public List<Koords> Koordinatak {  get; set; }
        public Adatok()
        {
            Meretezes();
        }
        private List<Koords> Beolvas()
        {
            
            List<Koords> koordinataLista = new List<Koords>();
            TextReader textReader = new StreamReader(@"C:\demo\stops.txt");
            string sor = textReader.ReadLine();
            while ((sor = textReader.ReadLine()) != null)
            {
                Koords egyKord = new Koords();
                string[] vs = sor.Split(',');
                if (sor.Contains('"'))
                {

                    egyKord.X = Convert.ToDouble(vs[4], CultureInfo.InvariantCulture);
                    egyKord.Y = Convert.ToDouble(vs[3], CultureInfo.InvariantCulture);


                }
                else
                {

                    egyKord.X = Convert.ToDouble(vs[3], CultureInfo.InvariantCulture);
                    egyKord.Y = Convert.ToDouble(vs[2], CultureInfo.InvariantCulture);


                }

                koordinataLista.Add(egyKord);
            }
            minX = koordinataLista.Min(a=> a.X);
            minY = koordinataLista.Min(a => a.Y);
            maxX = koordinataLista.Max(a => a.X);
            maxY = koordinataLista.Max(a => a.Y);
            return koordinataLista;
        }

        private void Meretezes()
        {
            Koordinatak = new List<Koords>();
            foreach(Koords kord in Beolvas())
            {
                Koords ujkord;
                ujkord.X = (kord.X - minX) * 1000;
                ujkord.Y = 499 -(kord.Y - minY) * 1000;
                Koordinatak.Add(ujkord);

            }

          

        }
    }
}
