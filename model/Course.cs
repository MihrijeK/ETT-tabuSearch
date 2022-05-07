using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Course
    {
        private string course { get; set; }
        private RoomsRequested roomsRequested { get; set; }
        private string teacher { get; set; }

        public Course() { }
        public Course(string course, RoomsRequested roomsRequested, string teacher)
        {
            this.course = course;
            this.roomsRequested = roomsRequested;
            this.teacher = teacher;
        }
    }
}
