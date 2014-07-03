using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public static class SprawdzPunkty
    {

        public static int Spradz(bool[] linie, bool[] tablica, int punkty, ref bool bingo)
        {
            if (linie[0] == false)
            {
                if (tablica[0] && tablica[1] && tablica[2] && tablica[3] && tablica[4])
                {
                    linie[0] = true;
                    punkty += 10;
                }
            }
            if (linie[1] == false)
            {
                if (tablica[5] && tablica[6] && tablica[7] && tablica[8] && tablica[9])
                {
                    linie[1] = true;
                    punkty += 10;
                }
            }
            if (linie[2] == false)
            {
                if (tablica[10] && tablica[11] && tablica[12] && tablica[13])
                {
                    linie[2] = true;
                    punkty += 10;
                }
            }
            if (linie[3] == false)
            {
                if (tablica[14] && tablica[15] && tablica[16] && tablica[17] && tablica[18])
                {
                    linie[3] = true;
                    punkty += 10;
                }
            }
            if (linie[4] == false)
            {
                if (tablica[19] && tablica[20] && tablica[21] && tablica[22] && tablica[23])
                {
                    linie[4] = true;
                    punkty += 10;
                }
            }
            if (linie[5] == false)
            {
                if (tablica[0] && tablica[5] && tablica[10] && tablica[14] && tablica[19])
                {
                    linie[5] = true;
                    punkty += 10;
                }
            }
            if (linie[6] == false)
            {
                if (tablica[1] && tablica[6] && tablica[11] && tablica[15] && tablica[20])
                {
                    linie[6] = true;
                    punkty += 10;
                }
            }
            if (linie[7] == false)
            {
                if (tablica[2] && tablica[7] && tablica[16] && tablica[21])
                {
                    linie[7] = true;
                    punkty += 10;
                }
            }
            if (linie[8] == false)
            {
                if (tablica[3] && tablica[8] && tablica[12] && tablica[17] && tablica[22])
                {
                    linie[8] = true;
                    punkty += 10;
                }
            }
            if (linie[9] == false)
            {
                if (tablica[4] && tablica[9] && tablica[13] && tablica[18] && tablica[23])
                {
                    linie[9] = true;
                    punkty += 10;
                }
            }
            if (linie[10] == false) //krzyz
            {
                if (linie[2] == true && linie[7] == true &&
                    linie[0] == false && linie[1] == false && linie[3] == false && linie[4] == false &&
                    linie[5] == false && linie[6] == false && linie[8] == false && linie[9] == false)
                {
                    linie[10] = true;
                    punkty += 30;
                }
            }
            if (linie[11] == false) //rogi
            {
                if (tablica[0] == true && tablica[4] == true && tablica[19] == true && tablica[23] == true &&
                    tablica[1] == false && tablica[5] == false && tablica[6] == false &&
                    tablica[3] == false && tablica[8] == false && tablica[9] == false &&
                    tablica[14] == false && tablica[15] == false && tablica[20] == false &&
                    tablica[17] == false && tablica[18] == false && tablica[22] == false)
                {
                    linie[11] = true;
                    punkty += 15;
                }
            }
            //bingo
            if (linie[0] == true && linie[1] == true && linie[2] == true && linie[3] && linie[4] == true)
            {
                bingo = true;
                punkty += 50;
            }

            return punkty;
        }
    }
}
