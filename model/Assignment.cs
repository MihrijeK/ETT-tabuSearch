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

        public Assignment() { }
        public Assignment(string course, List<Event> events)
        {
            this.course = course;
            this.events = events;
        }

    }
}
