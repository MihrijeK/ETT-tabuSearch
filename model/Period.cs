using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    public class Period
    {
        private string id { get; set; }
        private int day { get; set; }
        private int timeslot { get; set; }

        public Period() { }

        public Period(string id, int day, int timeslot)
        {
            this.id = id;
            this.day = day;
            this.timeslot = timeslot;
        }

        public int getDay() {
		    return day;
        }
        public void setDay(int day) {
            this.day = day;
        }

        public class Builder {
            private string id;
            private int day;
            private int timeslot;
            
            public Builder ids(string id) {
                this.id = id;
                return this;
            }
            
            public Builder days(int day) {
                this.day = day;
                return this;
            }

            public Builder timeslots(int timeslot) {
                this.timeslot = timeslot;
                return this;
            }
            
            public Period build() {
                return new Period();
            }
        }
    }
}
