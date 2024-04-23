using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class MegtakaritasSzamla : Szamla
    {
        private int kamatLab = 3;

        public MegtakaritasSzamla(string tulajdonos, string szamlaszam, int egyenleg, int kamatLab) : base(tulajdonos, szamlaszam, egyenleg)
        {
            this.kamatLab = kamatLab;
        }
        public void kamatozas()
        {
            egyenleg += egyenleg*kamatLab/100;
        }
    }
}
