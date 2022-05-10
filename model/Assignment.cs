using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Assignment
    {
        private string course { get; set; }
        private List<Event> events { get; set; }

        public List<Event> getEvents() {
		    return events;
	    }
        public void setEvents(List<Event> events) {
		    this.events = events;
	    }

        public String getCourse() {
            return course;
        }
        public void setCourse(String course) {
            this.course = course;
        }
        public Assignment() { }
        public Assignment(string course, List<Event> events)
        {
            this.course = course;
            this.events = events;
        }

    }
}
