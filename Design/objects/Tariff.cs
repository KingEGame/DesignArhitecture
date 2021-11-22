using System;
using System.Collections.Generic;
using System.Text;

namespace Design.objects
{
    class Tariff
    {
        public int id { get; set; }

        public virtual TypeOfItem typeOfItem { get; set; }

        public virtual TypeOfService typeOfService { get; set; }

        public float price { get; set; }
    }
}
