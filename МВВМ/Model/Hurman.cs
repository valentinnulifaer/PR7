using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace МВВМ.Model
{
    internal class Hurman
    {
        public Hurman(string tonirovka, string shina, int benzin, string cvet, int speed, int razgon)
        {
            Tonirovka = tonirovka;
            Shina = shina;
            Benzin = benzin;
            Cvet = cvet;
            Speed = speed;
            Razgon = razgon;
        }
        public string Tonirovka { get; set; }
        public string Shina { get; set; }
        public int Benzin { get; set; }
        public string Cvet { get; set; }
        public int Speed { get; set; }
        public int Razgon { get; set; }
        public Hurman(int group, string glid)
        {
            Group = group;
            Glid = glid;
        }
        public int Group { get; set; }
        public string Glid { get; set; }
    }
}
