using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МВВМ.Model
{
    public class Herman
    {
        public Herman(string carname, string mark, string age)
        {
            Carname = carname;
            Mark = mark;
            Age = age;
        }
        public string Carname { get; set; }
        public string Mark { get; set; }
        public string Age { get; set; }
    }
}
