using System;
using System.Collections.Generic;
using System.Text;

namespace ExameTeoria.entity
{
    class Noh
    {
        public Boolean isEulerian { get; set; }

        public Noh(bool isEulerian)
        {
            this.isEulerian = false;
        }

        public Noh()
        {
            this.isEulerian = false;
        }
    }
}
