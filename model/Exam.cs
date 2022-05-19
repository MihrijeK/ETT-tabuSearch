using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    public class Exam
    {
        private Course course { get; set; }
        private List<Room> rooms { get; set; }
        private Period period { get; set; }
        private string curriculum { get; set; }
        public Exam() { }
        public Exam(Course course,List<Room> rooms ,Period period, string curriculum)
        {
            this.course = course;
            this.rooms = rooms;
            this.period = period;
            this.curriculum = curriculum;
        }

        public List<Room> getRooms() {
		    return rooms;
	    }
	    public void setRooms(List<Room> rooms) {
		    this.rooms = rooms;
	    }
        public Period getPeriod() {
            return period;
        }


        public Course getCourse() {
		    return course;
        }
        public void setCourse(Course course) {
            this.course = course;
        }

        public String getCurriculum() {
		    return curriculum;
        }

        public void setCurriculum(String curriculum) {
            this.curriculum = curriculum;
        }

        public void setPeriod(Period period) {
            this.period = period;
        }
    
    public class Builder {
            private int cost;

            private Course course;
            private List<Room> rooms;
            private Period period;
            private string curriculum;
            
            public Builder courses(Course course) {
                this.course = course;
                return this;
            }
            
            public Builder roomss(List<Room> rooms) {
                this.rooms = rooms;
                return this;
            }
            
            public Builder periods(Period period) {
                this.period = period;
                return this;

            }

            public Builder currilculums(string curriculum) {
                this.curriculum = curriculum;
                return this;
            }
            public Exam build() {
                return new Exam();
            }
        }
    }
}
