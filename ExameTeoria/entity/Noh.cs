using System;
using System.Collections.Generic;
using System.Text;

namespace ExameTeoria.entity
{
    class Noh
    {
        public String name { get; set; }
        public Boolean isEulerian { get; set; }

        public Noh(string name, bool isEulerian)
        {
            this.name = name;
            this.isEulerian = false;
        }

        public Noh(string name)
        {
            this.name = name;
            this.isEulerian = false;
        }
    }
}
