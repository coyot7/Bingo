using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;

namespace Bingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DispatcherTimer aTimer;
        private static int licznik = 0;
        private static int malaIndeks = 0;
        private static int sredniaIndeks = 1;
        private static int duzaIndeks = 2;
        private Kulka[] wyswietlKulki;
        private int[] tablicaKupon1; //liczby na kuponie gracza1
        private int[] tablicaKupon2; //gracz 2
        protected static int punktyPlayer1 = 0;
        protected static int punktyPlayer2 = 0;
        private bool[] trafieniaPlayer1; //do dodawania punktow
        private bool[] trafieniaPlayer2; 
        private bool[] liniePlayer1;
        private bool[] liniePlayer2;
        private bool bingoPlayer1 = false; //czy ma bingo
        private bool bingoPlayer2 = false;

        public MainWindow()
        {
            InitializeComponent();

            LosowanieKulek();
        }

        private void LosowanieKulek()
        {
            Kulka[] tabelaKulkiZrodlo = Kulki.GetKulki();
            MaszynaLosujaca.Losowanie(tabelaKulkiZrodlo);
            wyswietlKulki = Kulki.GetKulkiWyswietl(tabelaKulkiZrodlo);

            Kupon pierwszy = new Kupon(); 
            trafieniaPlayer1 = pierwszy.ZerowanieTrafien();
            liniePlayer1 = new bool[12];
            for (int i = 0; i < 12; i++)
            {
                liniePlayer1[i] = false;
            }

            Kupon drugi = new Kupon();
            trafieniaPlayer2 = drugi.ZerowanieTrafien();
            liniePlayer2 = new bool[12];
            for (int i = 0; i < 12; i++)
            {
                liniePlayer2[i] = false;
            }
        }

        private void OnTimedEvent(Object sender, EventArgs e)
        {
            DisplayKulki();
            SprawdzKupon();
            SprawdzKupon2();
            punktyPlayer1 = SprawdzPunkty.Spradz(liniePlayer1 ,trafieniaPlayer1, punktyPlayer1,ref bingoPlayer1);
            punktyPlayer2 = SprawdzPunkty.Spradz(liniePlayer2, trafieniaPlayer2, punktyPlayer2, ref bingoPlayer2);

            //przesuwanie indeksow kulek
            malaIndeks++;
            sredniaIndeks++;
            duzaIndeks++;
            licznik++;
        }

        private void LosowanieKuponPierwszy()
        {
            Kupon nowy = new Kupon();
            tablicaKupon1 = nowy.GetKupon();
            A1.Text = tablicaKupon1[0].ToString();
            A2.Text = tablicaKupon1[1].ToString();
            A3.Text = tablicaKupon1[2].ToString();
            A4.Text = tablicaKupon1[3].ToString();
            A5.Text = tablicaKupon1[4].ToString();
            A6.Text = tablicaKupon1[5].ToString();
            A7.Text = tablicaKupon1[6].ToString();
            A8.Text = tablicaKupon1[7].ToString();
            A9.Text = tablicaKupon1[8].ToString();
            A10.Text = tablicaKupon1[9].ToString();
            A11.Text = tablicaKupon1[10].ToString();
            A12.Text = tablicaKupon1[11].ToString();
            A13.Text = tablicaKupon1[12].ToString();
            A14.Text = tablicaKupon1[13].ToString();
            A15.Text = tablicaKupon1[14].ToString();
            A16.Text = tablicaKupon1[15].ToString();
            A17.Text = tablicaKupon1[16].ToString();
            A18.Text = tablicaKupon1[17].ToString();
            A19.Text = tablicaKupon1[18].ToString();
            A20.Text = tablicaKupon1[19].ToString();
            A21.Text = tablicaKupon1[20].ToString();
            A22.Text = tablicaKupon1[21].ToString();
            A23.Text = tablicaKupon1[22].ToString();
            A24.Text = tablicaKupon1[23].ToString();
        }

        private void LosowanieKuponDrugi()
        {
            Kupon nowy = new Kupon();
            tablicaKupon2 = nowy.GetKupon();
            B1.Text = tablicaKupon2[0].ToString();
            B2.Text = tablicaKupon2[1].ToString();
            B3.Text = tablicaKupon2[2].ToString();
            B4.Text = tablicaKupon2[3].ToString();
            B5.Text = tablicaKupon2[4].ToString();
            B6.Text = tablicaKupon2[5].ToString();
            B7.Text = tablicaKupon2[6].ToString();
            B8.Text = tablicaKupon2[7].ToString();
            B9.Text = tablicaKupon2[8].ToString();
            B10.Text = tablicaKupon2[9].ToString();
            B11.Text = tablicaKupon2[10].ToString();
            B12.Text = tablicaKupon2[11].ToString();
            B13.Text = tablicaKupon2[12].ToString();
            B14.Text = tablicaKupon2[13].ToString();
            B15.Text = tablicaKupon2[14].ToString();
            B16.Text = tablicaKupon2[15].ToString();
            B17.Text = tablicaKupon2[16].ToString();
            B18.Text = tablicaKupon2[17].ToString();
            B19.Text = tablicaKupon2[18].ToString();
            B20.Text = tablicaKupon2[19].ToString();
            B21.Text = tablicaKupon2[20].ToString();
            B22.Text = tablicaKupon2[21].ToString();
            B23.Text = tablicaKupon2[22].ToString();
            B24.Text = tablicaKupon2[23].ToString();

        }

        private void OnHover(Object sender, EventArgs e)
        {
            LosowanieKuponPierwszy(); //automatyczne generowanie kuponu
            KuponTylkoDlaPlayera1();
        }

        private void OnHover2(Object sender, EventArgs e)
        {
            LosowanieKuponPierwszy();
            LosowanieKuponDrugi();
        }

        private void SprawdzKupon()
        {
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A1.Text)
            {
                Binding bindingA1 = new Binding();
                bindingA1.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A1Picture.SetBinding(Image.SourceProperty, bindingA1);
                trafieniaPlayer1[0] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A2.Text)
            {
                Binding bindingA2 = new Binding();
                bindingA2.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A2Picture.SetBinding(Image.SourceProperty, bindingA2);
                trafieniaPlayer1[1] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A3.Text)
            {
                Binding bindingA3 = new Binding();
                bindingA3.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A3Picture.SetBinding(Image.SourceProperty, bindingA3);
                trafieniaPlayer1[2] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A4.Text)
            {
                Binding bindingA4 = new Binding();
                bindingA4.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A4Picture.SetBinding(Image.SourceProperty, bindingA4);
                trafieniaPlayer1[3] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A5.Text)
            {
                Binding bindingA5 = new Binding();
                bindingA5.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A5Picture.SetBinding(Image.SourceProperty, bindingA5);
                trafieniaPlayer1[4] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A6.Text)
            {
                Binding bindingA6 = new Binding();
                bindingA6.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A6Picture.SetBinding(Image.SourceProperty, bindingA6);
                trafieniaPlayer1[5] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A7.Text)
            {
                Binding bindingA7 = new Binding();
                bindingA7.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A7Picture.SetBinding(Image.SourceProperty, bindingA7);
                trafieniaPlayer1[6] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A8.Text)
            {
                Binding bindingA8 = new Binding();
                bindingA8.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A8Picture.SetBinding(Image.SourceProperty, bindingA8);
                trafieniaPlayer1[7] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A9.Text)
            {
                Binding bindingA9 = new Binding();
                bindingA9.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A9Picture.SetBinding(Image.SourceProperty, bindingA9);
                trafieniaPlayer1[8] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A10.Text)
            {
                Binding bindingA10 = new Binding();
                bindingA10.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A10Picture.SetBinding(Image.SourceProperty, bindingA10);
                trafieniaPlayer1[9] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A11.Text)
            {
                Binding bindingA11 = new Binding();
                bindingA11.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A11Picture.SetBinding(Image.SourceProperty, bindingA11);
                trafieniaPlayer1[10] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A12.Text)
            {
                Binding bindingA12 = new Binding();
                bindingA12.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A12Picture.SetBinding(Image.SourceProperty, bindingA12);
                trafieniaPlayer1[11] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A13.Text)
            {
                Binding bindingA13 = new Binding();
                bindingA13.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A13Picture.SetBinding(Image.SourceProperty, bindingA13);
                trafieniaPlayer1[12] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A14.Text)
            {
                Binding bindingA14 = new Binding();
                bindingA14.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A14Picture.SetBinding(Image.SourceProperty, bindingA14);
                trafieniaPlayer1[13] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A15.Text)
            {
                Binding bindingA15 = new Binding();
                bindingA15.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A15Picture.SetBinding(Image.SourceProperty, bindingA15);
                trafieniaPlayer1[14] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A16.Text)
            {
                Binding bindingA16 = new Binding();
                bindingA16.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A16Picture.SetBinding(Image.SourceProperty, bindingA16);
                trafieniaPlayer1[15] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A17.Text)
            {
                Binding bindingA17 = new Binding();
                bindingA17.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A17Picture.SetBinding(Image.SourceProperty, bindingA17);
                trafieniaPlayer1[16] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A18.Text)
            {
                Binding bindingA18 = new Binding();
                bindingA18.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A18Picture.SetBinding(Image.SourceProperty, bindingA18);
                trafieniaPlayer1[17] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A19.Text)
            {
                Binding bindingA19 = new Binding();
                bindingA19.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A19Picture.SetBinding(Image.SourceProperty, bindingA19);
                trafieniaPlayer1[18] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A20.Text)
            {
                Binding bindingA20 = new Binding();
                bindingA20.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A20Picture.SetBinding(Image.SourceProperty, bindingA20);
                trafieniaPlayer1[19] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A21.Text)
            {
                Binding bindingA21 = new Binding();
                bindingA21.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A21Picture.SetBinding(Image.SourceProperty, bindingA21);
                trafieniaPlayer1[20] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A22.Text)
            {
                Binding bindingA22 = new Binding();
                bindingA22.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A22Picture.SetBinding(Image.SourceProperty, bindingA22);
                trafieniaPlayer1[21] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A23.Text)
            {
                Binding bindingA23 = new Binding();
                bindingA23.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A23Picture.SetBinding(Image.SourceProperty, bindingA23);
                trafieniaPlayer1[22] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == A24.Text)
            {
                Binding bindingA24 = new Binding();
                bindingA24.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                A24Picture.SetBinding(Image.SourceProperty, bindingA24);
                trafieniaPlayer1[23] = true;
            }
        }

        private void SprawdzKupon2()
        {
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B1.Text)
            {
                Binding bindingB1 = new Binding();
                bindingB1.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B1Picture.SetBinding(Image.SourceProperty, bindingB1);
                trafieniaPlayer2[0] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B2.Text)
            {
                Binding bindingB2 = new Binding();
                bindingB2.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B2Picture.SetBinding(Image.SourceProperty, bindingB2);
                trafieniaPlayer2[1] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B3.Text)
            {
                Binding bindingB3 = new Binding();
                bindingB3.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B3Picture.SetBinding(Image.SourceProperty, bindingB3);
                trafieniaPlayer2[2] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B4.Text)
            {
                Binding bindingB4 = new Binding();
                bindingB4.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B4Picture.SetBinding(Image.SourceProperty, bindingB4);
                trafieniaPlayer2[3] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B5.Text)
            {
                Binding bindingB5 = new Binding();
                bindingB5.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B5Picture.SetBinding(Image.SourceProperty, bindingB5);
                trafieniaPlayer2[4] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B6.Text)
            {
                Binding bindingB6 = new Binding();
                bindingB6.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B6Picture.SetBinding(Image.SourceProperty, bindingB6);
                trafieniaPlayer2[5] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B7.Text)
            {
                Binding bindingB7 = new Binding();
                bindingB7.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B7Picture.SetBinding(Image.SourceProperty, bindingB7);
                trafieniaPlayer2[6] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B8.Text)
            {
                Binding bindingB8 = new Binding();
                bindingB8.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B8Picture.SetBinding(Image.SourceProperty, bindingB8);
                trafieniaPlayer2[7] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B9.Text)
            {
                Binding bindingB9 = new Binding();
                bindingB9.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B9Picture.SetBinding(Image.SourceProperty, bindingB9);
                trafieniaPlayer2[8] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B10.Text)
            {
                Binding bindingB10 = new Binding();
                bindingB10.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B10Picture.SetBinding(Image.SourceProperty, bindingB10);
                trafieniaPlayer2[9] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B11.Text)
            {
                Binding bindingB11 = new Binding();
                bindingB11.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                
                B11Picture.SetBinding(Image.SourceProperty, bindingB11);
                trafieniaPlayer2[10] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B12.Text)
            {
                Binding bindingB12 = new Binding();
                bindingB12.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B12Picture.SetBinding(Image.SourceProperty, bindingB12);
                trafieniaPlayer2[11] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B13.Text)
            {
                Binding bindingB13 = new Binding();
                bindingB13.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B13Picture.SetBinding(Image.SourceProperty, bindingB13);
                trafieniaPlayer2[12] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B14.Text)
            {
                Binding bindingB14 = new Binding();
                bindingB14.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B14Picture.SetBinding(Image.SourceProperty, bindingB14);
                trafieniaPlayer2[13] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B15.Text)
            {
                Binding bindingB15 = new Binding();
                bindingB15.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B15Picture.SetBinding(Image.SourceProperty, bindingB15);
                trafieniaPlayer2[14] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B16.Text)
            {
                Binding bindingB16 = new Binding();
                bindingB16.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B16Picture.SetBinding(Image.SourceProperty, bindingB16);
                trafieniaPlayer2[15] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B17.Text)
            {
                Binding bindingB17 = new Binding();
                bindingB17.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B17Picture.SetBinding(Image.SourceProperty, bindingB17);
                trafieniaPlayer2[16] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B18.Text)
            {
                Binding bindingB18 = new Binding();
                bindingB18.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B18Picture.SetBinding(Image.SourceProperty, bindingB18);
                trafieniaPlayer2[17] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B19.Text)
            {
                Binding bindingB19 = new Binding();
                bindingB19.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B19Picture.SetBinding(Image.SourceProperty, bindingB19);
                trafieniaPlayer2[18] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B20.Text)
            {
                Binding bindingB20 = new Binding();
                bindingB20.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B20Picture.SetBinding(Image.SourceProperty, bindingB20);
                trafieniaPlayer2[19] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B21.Text)
            {
                Binding bindingB21 = new Binding();
                bindingB21.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B21Picture.SetBinding(Image.SourceProperty, bindingB21);
                trafieniaPlayer2[20] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B22.Text)
            {
                Binding bindingB22 = new Binding();
                bindingB22.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B22Picture.SetBinding(Image.SourceProperty, bindingB22);
                trafieniaPlayer2[21] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B23.Text)
            {
                Binding bindingB23 = new Binding();
                bindingB23.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B23Picture.SetBinding(Image.SourceProperty, bindingB23);
                trafieniaPlayer2[22] = true;
            }
            if (wyswietlKulki[duzaIndeks].Nazwa.ToString() == B24.Text)
            {
                Binding bindingB24 = new Binding();
                bindingB24.Source = wyswietlKulki[duzaIndeks].Path.ToString();
                B24Picture.SetBinding(Image.SourceProperty, bindingB24);
                trafieniaPlayer2[23] = true;
            }
        }

        private void CzyszczenieKuponu() //czyszczenie planszy z kulek
        {

            Binding bindingA1 = new Binding();
            bindingA1.Source = "";
            A1Picture.SetBinding(Image.SourceProperty, bindingA1);

            Binding bindingA2 = new Binding();
            bindingA2.Source = "";
            A2Picture.SetBinding(Image.SourceProperty, bindingA2);

            Binding bindingA3 = new Binding();
            bindingA3.Source = "";
            A3Picture.SetBinding(Image.SourceProperty, bindingA3);

            Binding bindingA4 = new Binding();
            bindingA4.Source = "";
            A4Picture.SetBinding(Image.SourceProperty, bindingA4);

            Binding bindingA5 = new Binding();
            bindingA5.Source = "";
            A5Picture.SetBinding(Image.SourceProperty, bindingA5);

            Binding bindingA6 = new Binding();
            bindingA6.Source = "";
            A6Picture.SetBinding(Image.SourceProperty, bindingA6);

            Binding bindingA7 = new Binding();
            bindingA7.Source = "";
            A7Picture.SetBinding(Image.SourceProperty, bindingA7);

            Binding bindingA8 = new Binding();
            bindingA8.Source = "";
            A8Picture.SetBinding(Image.SourceProperty, bindingA8);

            Binding bindingA9 = new Binding();
            bindingA9.Source = "";
            A9Picture.SetBinding(Image.SourceProperty, bindingA9);

            Binding bindingA10 = new Binding();
            bindingA10.Source = "";
            A10Picture.SetBinding(Image.SourceProperty, bindingA10);

            Binding bindingA11 = new Binding();
            bindingA11.Source = "";
            A11Picture.SetBinding(Image.SourceProperty, bindingA11);

            Binding bindingA12 = new Binding();
            bindingA12.Source = "";
            A12Picture.SetBinding(Image.SourceProperty, bindingA12);

            Binding bindingA13 = new Binding();
            bindingA13.Source = "";
            A13Picture.SetBinding(Image.SourceProperty, bindingA13);

            Binding bindingA14 = new Binding();
            bindingA14.Source = "";
            A14Picture.SetBinding(Image.SourceProperty, bindingA14);

            Binding bindingA15 = new Binding();
            bindingA15.Source = "";
            A15Picture.SetBinding(Image.SourceProperty, bindingA15);

            Binding bindingA16 = new Binding();
            bindingA16.Source = "";
            A16Picture.SetBinding(Image.SourceProperty, bindingA16);

            Binding bindingA17 = new Binding();
            bindingA17.Source = "";
            A17Picture.SetBinding(Image.SourceProperty, bindingA17);

            Binding bindingA18 = new Binding();
            bindingA18.Source = "";
            A18Picture.SetBinding(Image.SourceProperty, bindingA18);

            Binding bindingA19 = new Binding();
            bindingA19.Source = "";
            A19Picture.SetBinding(Image.SourceProperty, bindingA19);

            Binding bindingA20 = new Binding();
            bindingA20.Source = "";
            A20Picture.SetBinding(Image.SourceProperty, bindingA20);

            Binding bindingA21 = new Binding();
            bindingA21.Source = "";
            A21Picture.SetBinding(Image.SourceProperty, bindingA21);

            Binding bindingA22 = new Binding();
            bindingA22.Source = "";
            A22Picture.SetBinding(Image.SourceProperty, bindingA22);

            Binding bindingA23 = new Binding();
            bindingA23.Source = "";
            A23Picture.SetBinding(Image.SourceProperty, bindingA23);

            Binding bindingA24 = new Binding();
            bindingA24.Source = "";
            A24Picture.SetBinding(Image.SourceProperty, bindingA24);

        }

        private void CzyszczenieKuponu2() //czyszcze planszy Playera2 z kulek
        {

            Binding bindingB1 = new Binding();
            bindingB1.Source = "";
            B1Picture.SetBinding(Image.SourceProperty, bindingB1);

            Binding bindingB2 = new Binding();
            bindingB2.Source = "";
            B2Picture.SetBinding(Image.SourceProperty, bindingB2);

            Binding bindingB3 = new Binding();
            bindingB3.Source = "";
            B3Picture.SetBinding(Image.SourceProperty, bindingB3);

            Binding bindingB4 = new Binding();
            bindingB4.Source = "";
            B4Picture.SetBinding(Image.SourceProperty, bindingB4);

            Binding bindingB5 = new Binding();
            bindingB5.Source = "";
            B5Picture.SetBinding(Image.SourceProperty, bindingB5);

            Binding bindingB6 = new Binding();
            bindingB6.Source = "";
            B6Picture.SetBinding(Image.SourceProperty, bindingB6);

            Binding bindingB7 = new Binding();
            bindingB7.Source = "";
            B7Picture.SetBinding(Image.SourceProperty, bindingB7);

            Binding bindingB8 = new Binding();
            bindingB8.Source = "";
            B8Picture.SetBinding(Image.SourceProperty, bindingB8);

            Binding bindingB9 = new Binding();
            bindingB9.Source = "";
            B9Picture.SetBinding(Image.SourceProperty, bindingB9);

            Binding bindingB10 = new Binding();
            bindingB10.Source = "";
            B10Picture.SetBinding(Image.SourceProperty, bindingB10);

            Binding bindingB11 = new Binding();
            bindingB11.Source = "";
            B11Picture.SetBinding(Image.SourceProperty, bindingB11);

            Binding bindingB12 = new Binding();
            bindingB12.Source = "";
            B12Picture.SetBinding(Image.SourceProperty, bindingB12);

            Binding bindingB13 = new Binding();
            bindingB13.Source = "";
            B13Picture.SetBinding(Image.SourceProperty, bindingB13);

            Binding bindingB14 = new Binding();
            bindingB14.Source = "";
            B14Picture.SetBinding(Image.SourceProperty, bindingB14);

            Binding bindingB15 = new Binding();
            bindingB15.Source = "";
            B15Picture.SetBinding(Image.SourceProperty, bindingB15);

            Binding bindingB16 = new Binding();
            bindingB16.Source = "";
            B16Picture.SetBinding(Image.SourceProperty, bindingB16);

            Binding bindingB17 = new Binding();
            bindingB17.Source = "";
            B17Picture.SetBinding(Image.SourceProperty, bindingB17);

            Binding bindingB18 = new Binding();
            bindingB18.Source = "";
            B18Picture.SetBinding(Image.SourceProperty, bindingB18);

            Binding bindingB19 = new Binding();
            bindingB19.Source = "";
            B19Picture.SetBinding(Image.SourceProperty, bindingB19);

            Binding bindingB20 = new Binding();
            bindingB20.Source = "";
            B20Picture.SetBinding(Image.SourceProperty, bindingB20);

            Binding bindingB21 = new Binding();
            bindingB21.Source = "";
            B21Picture.SetBinding(Image.SourceProperty, bindingB21);

            Binding bindingB22 = new Binding();
            bindingB22.Source = "";
            B22Picture.SetBinding(Image.SourceProperty, bindingB22);

            Binding bindingB23 = new Binding();
            bindingB23.Source = "";
            B23Picture.SetBinding(Image.SourceProperty, bindingB23);

            Binding bindingB24 = new Binding();
            bindingB24.Source = "";
            B24Picture.SetBinding(Image.SourceProperty, bindingB24);

        }

        private void KuponTylkoDlaPlayera1()
        {
            B1.Text = "B";
            B2.Text = "B";
            B3.Text = "B";
            B4.Text = "B";
            B5.Text = "B";

            B6.Text = "I";
            B7.Text = "I";
            B8.Text = "I";
            B9.Text = "I";
            B10.Text = "I";

            B11.Text = "N";
            B12.Text = "N";
            B13.Text = "N";
            B14.Text = "N";

            B15.Text = "G";
            B16.Text = "G";
            B17.Text = "G";
            B18.Text = "G";
            B19.Text = "G";

            B20.Text = "O";
            B21.Text = "O";
            B22.Text = "O";
            B23.Text = "O";
            B24.Text = "O";
        }

        private void DisplayKulki()
        {
            //ustawianie kulik duzej
            Binding bindingDuza = new Binding();
            bindingDuza.Source = wyswietlKulki[duzaIndeks].Path.ToString();
            Duza.SetBinding(Image.SourceProperty, bindingDuza);

            //ustawianie kulik sredniej
            Binding bindingSrednia = new Binding();
            bindingSrednia.Source = wyswietlKulki[sredniaIndeks].Path.ToString();
            Srednia.SetBinding(Image.SourceProperty, bindingSrednia);

            //ustawianie kulik malej
            Binding bindingMala = new Binding();
            bindingMala.Source = wyswietlKulki[malaIndeks].Path.ToString();
            Mala.SetBinding(Image.SourceProperty, bindingMala);

            //dopisywanie punktow
            PKT1.Text = punktyPlayer1.ToString();
            PKT2.Text = punktyPlayer2.ToString();

            //sprawdzanie binga remis
            if (bingoPlayer1 == true && bingoPlayer2 == true)
            {
                aTimer.Stop();
                MessageBox.Show("B I N G O !!!\n\nRemis");
                IloscGraczy.IsEnabled = true;
                licznik = -1;
                malaIndeks = -1;
                sredniaIndeks = 0;
                duzaIndeks = 1;
                CzyszczenieKuponu();
                CzyszczenieKuponu2();
                bingoPlayer1 = false;
                bingoPlayer2 = false;
                LosowanieKulek();
            }

            //sprawdzanie binga player1
            if (bingoPlayer1 == true)
            {
                aTimer.Stop();
                MessageBox.Show("B I N G O !!!\n\nWygrywa Player 1");
                IloscGraczy.IsEnabled = true;
                licznik = -1;
                malaIndeks = -1;
                sredniaIndeks = 0;
                duzaIndeks = 1;
                CzyszczenieKuponu();
                CzyszczenieKuponu2();
                bingoPlayer1 = false;
                bingoPlayer2 = false;
                LosowanieKulek();
            }

            //sprawdzanie binga player2
            if (bingoPlayer2 == true)
            {
                aTimer.Stop();
                MessageBox.Show("B I N G O !!!\n\nWygrywa Player 2");
                IloscGraczy.IsEnabled = true;
                licznik = -1;
                malaIndeks = -1;
                sredniaIndeks = 0;
                duzaIndeks = 1;
                CzyszczenieKuponu();
                CzyszczenieKuponu2();
                bingoPlayer1 = false;
                bingoPlayer2 = false;
                LosowanieKulek();
            }

            //koniec gry bez binga
            if (licznik == 74)
            {
                aTimer.Stop();
                MessageBox.Show("KONIEC GRY");
                IloscGraczy.IsEnabled = true;
                licznik = -1;
                malaIndeks = -1;
                sredniaIndeks = 0;
                duzaIndeks = 1;
                CzyszczenieKuponu();
                CzyszczenieKuponu2();
                LosowanieKulek();
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e) //przycisk start
        {
            IloscGraczy.IsEnabled = false;
            aTimer = new DispatcherTimer();
            aTimer.Interval = TimeSpan.FromSeconds(0.5);  //czas losowanaia kolejnej kuli
            aTimer.Tick += OnTimedEvent;
            aTimer.IsEnabled = true;
        }
    }
}
