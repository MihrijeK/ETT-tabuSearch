using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Event
    {
        private string period { get; set; }
        //@JsonIgnore per mos me u gjeneru ne Json garant
        private int periodDay { get; set; }
        //@JsonIgnore
        private int periodTimeslot { get; set; }
        private string room { get; set; }

        public string getPeriod() {
		    return period;
	    }

        public void setPeriod(String period) {
		    this.period = period;
	    }

        public String getRoom() {
		    return room;
	    }

        public void setRoom(String room) {
		    this.room = room;
	    }
        public Event() { }
        public Event(string period, int periodDay, int periodTimeslot, string room)
        {
            this.period = period;
            this.room = room;
            this.periodDay = periodDay;
            this.periodTimeslot = periodTimeslot;
        }
    }
}
