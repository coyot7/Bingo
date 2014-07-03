using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public static class Kulki
    {
        public static Kulka[] GetKulki()
        {
            List<Kulka> kulki = new List<Kulka>();
            //wczytywanie do tablicy stringów ze źródłami plików z obrazkami kulek
            for (int i = 1; i < 76; i++)
            {
                kulki.Add(new Kulka("kulki/" + i + ".png", i));
            }
            return kulki.ToArray();
        }

        public static Kulka[] GetKulkiWyswietl(Kulka[] tab)
        {
            List<Kulka> kulki = new List<Kulka>();
            kulki.Add(new Kulka(" ", 0));
            kulki.Add(new Kulka(" ", 0));
            for (int i = 0; i < 75; i++)
            {
                kulki.Add(new Kulka(tab[i].Path,tab[i].Nazwa));
            }
            return kulki.ToArray();
        }
    }
}