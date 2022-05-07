using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Period
    {
        private string id { get; set; }
        private int day { get; set; }
        private int timeslot { get; set; }
        public Period(string id, int day, int timeslot)
        {
            this.id = id;
            this.day = day;
            this.timeslot = timeslot;
        }
    }
}
