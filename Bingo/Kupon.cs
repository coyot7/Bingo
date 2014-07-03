using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public class Kupon
    {
        public int tempInt;
        public int index;
        public static Random rand = new Random();
        
        public int[] Liczy15() //losowanie z zakresu od 1 - 15
        {
            int[] liczby = new int[15];    
            for (int i = 0; i < 15; i++) //wpisywanie do tablic liczb
            {
                liczby[i] = i + 1;
            }

            for (int i = 0; i < 15; i++)
            {
                tempInt = liczby[i];
                index = rand.Next(0, 14);
                liczby[i] = liczby[index];
                liczby[index] = tempInt;
            }
            return liczby;
        }

        public int[] Liczy30() //losowanie z zakresu od 16 - 30
        {
            int[] liczby = new int[15];
            for (int i = 0; i < 15; i++) //wpisywanie do tablic liczb
            {
                liczby[i] = i + 16;
            }

            for (int i = 0; i < 15; i++)
            {
                tempInt = liczby[i];
                index = rand.Next(0, 14);
                liczby[i] = liczby[index];
                liczby[index] = tempInt;
            }
            return liczby;
        }

        public int[] Liczy45() //losowanie z zakresu od 31 - 45
        {
            int[] liczby = new int[15];
            for (int i = 0; i < 15; i++) //wpisywanie do tablic liczb
            {
                liczby[i] = i + 31;
            }

            for (int i = 0; i < 15; i++)
            {
                tempInt = liczby[i];
                index = rand.Next(0, 14);
                liczby[i] = liczby[index];
                liczby[index] = tempInt;
            }
            return liczby;
        }

        public int[] Liczy60() //losowanie z zakresu od 46 - 60
        {
            int[] liczby = new int[15];
            for (int i = 0; i < 15; i++) //wpisywanie do tablic liczb
            {
                liczby[i] = i + 46;
            }

            for (int i = 0; i < 15; i++)
            {
                tempInt = liczby[i];
                index = rand.Next(0, 14);
                liczby[i] = liczby[index];
                liczby[index] = tempInt;
            }
            return liczby;
        }

        public int[] Liczy75() //losowanie z zakresu od 61-75
        {
            int[] liczby = new int[15];
            for (int i = 0; i < 15; i++) //wpisywanie do tablic liczb
            {
                liczby[i] = i + 61;
            }

            for (int i = 0; i < 15; i++)
            {
                tempInt = liczby[i];
                index = rand.Next(0, 14);
                liczby[i] = liczby[index];
                liczby[index] = tempInt;
            }
            return liczby;
        }

        public int[] GetKupon() //zwraca kupon
        {
            
            int[] liczby = new int[24];

            int[] zakres = Liczy15();
            for (int i = 0; i < 5; i++)
            {
                liczby[i] = zakres[i];
            }
            
            zakres = Liczy30();
            for (int i = 0; i < 5; i++)
            {
                liczby[i + 5] = zakres[i];
            }

            zakres = Liczy45();
            for (int i = 0; i < 4; i++)
            {
                liczby[i + 10] = zakres[i];
            }

            zakres = Liczy60();
            for (int i = 0; i < 5; i++)
            {
                liczby[i + 14] = zakres[i];
            }
            
            zakres = Liczy75();
            for (int i = 0; i < 5; i++)
            {
                liczby[i + 19] = zakres[i];
            }

            return liczby;
        }

        public bool[] ZerowanieTrafien()
        {
            bool[] trafienia = new bool[24];
            for (int i = 0; i < 24; i++)
            {
                trafienia[i] = false;
            }
            return trafienia; 
        }        
    }
}
