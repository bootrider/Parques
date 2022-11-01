using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{
    public class Box
    {
        int indice;
        Token[] tokens;
        //Color token; the class house have this atributte

        public Box Next { get; set; }

    }
}
