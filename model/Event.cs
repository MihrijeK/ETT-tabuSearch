using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    public class Event
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

        public int getPeriodDay() {
		    return periodDay;
        }

        public void setPeriodDay(int periodDay) {
            this.periodDay = periodDay;
        }
        public Event() { }
        public Event(string period, int periodDay, int periodTimeslot, string room)
        {
            this.period = period;
            this.room = room;
            this.periodDay = periodDay;
            this.periodTimeslot = periodTimeslot;
        }
    public class Builder {
            private string period;
            //@JsonIgnore per mos me u gjeneru ne Json garant
            private int periodDay;
            //@JsonIgnore
            private int periodTimeslot;
            private string room;
            
            public Builder periodss(string period) {
                this.period = period;
                return this;
            }
            
            public Builder periodDays(int periodDay) {
                this.periodDay = periodDay;
                return this;
            }

            public Builder perTimeslots(int periodTimeslot) {
                this.periodTimeslot = periodTimeslot;
                return this;
            }

            public Builder rooms(string room) {
                this.room = room;
                return this;
            }
            
            
            public Event build() {
                return new Event();
            }
        }
        
    }
}
