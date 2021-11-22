using System;
using System.Collections.Generic;
using System.Text;

namespace Design.objects
{
    class Order
    {
        public int id { get; set; }

        public virtual Client client { get; set; }

        public virtual TypeOfService typeOfServ { get; set; }

        public virtual TypeOfItem typeOfItem { get; set; }

        public DateTime? timeOfReciept { get; set; }

        public DateTime? timeFit { get; set; }

        public DateTime? timeReady { get; set; }

        public virtual Employer employer { get; set; }

        public float price { get; set; }

        public float prepaymant { get; set; }
    }
}
