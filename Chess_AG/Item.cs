using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Item
    {
        public int[] estado { get; set; }
        public int h { get; set; }
        public double porcentagem { get; set; }

        public Item()
        {
            this.estado = new int[8];
            this.h = 0;
            this.porcentagem = 0;
        }
    }
}
