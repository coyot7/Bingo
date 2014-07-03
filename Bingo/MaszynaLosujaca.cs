using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public static class MaszynaLosujaca
    {
        private static Kulka temp;
        private static int index;
        
        public static Kulka[] Losowanie(Kulka[] tablica) //dostajemy tablice ze źródłami obrazków
        {
            Random rand = new Random();

            for (int i = 0; i < 75; i++) //mieszamy liczby w tablicy
            {
                temp = tablica[i];
                index = rand.Next(0, 74);
                tablica[i] = tablica[index];
                tablica[index] = temp;
            }
            return tablica;
        }
    }
}
