using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    public class Kulka
    {
        private string _path;
        private int _nazwa;

        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }

        public Kulka(string path, int nazwa)
        {
            this.Path = path;
            this.Nazwa = nazwa;
        }

        public int Nazwa
        {
            get { return _nazwa; }
            set { _nazwa = value; }
        }
    }
}
