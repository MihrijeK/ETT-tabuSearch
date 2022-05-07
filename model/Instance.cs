using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETT.model
{
    class Instance
    {
        private List<Course> courses { get; set; }
        private List<Curricula> curricula { get; set; }
        private int periods { get; set; }
        private decimal primaryPrimaryDistance { get; set; }
        private decimal primarySecondaryDistance { get; set; }
        private int slotsPerDay { get; set; }
        private List<string> teachers { get; set; }
        private List<Room> rooms { get; set; }

        public Instance() { }
        public Instance(List<Course> courses, List<Curricula> curricula, int periods, decimal primaryPrimaryDistance, decimal primarySecondaryDistance, int slotsPerDay, List<string> teachers, List<Room> rooms)
        {
            this.courses = courses;
            this.curricula = curricula;
            this.periods = periods;
            this.primaryPrimaryDistance = primaryPrimaryDistance;
            this.primarySecondaryDistance = primarySecondaryDistance;
            this.slotsPerDay = slotsPerDay;
            this.teachers = teachers;
            this.rooms = rooms;
        }

        public List<Room> getRooms() {
		    return rooms;
	    }
	    public void setRooms(List<Room> rooms) {
		    this.rooms = rooms;
	    }

    }
}
