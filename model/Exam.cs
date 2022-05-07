using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Exam
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

    }
}
