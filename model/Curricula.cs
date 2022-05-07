using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Curricula
    {
        private string curriculum { get; set; }
        private List<string> primaryCourses { get; set; }
        private List<string> secondaryCourses { get; set; }
        public Curricula() { }
        public Curricula(string curriculum, List<string> primaryCourses, List<string> secondaryCourses)
        {
            this.curriculum = curriculum;
            this.primaryCourses = primaryCourses;
            this.secondaryCourses = secondaryCourses;
        }

    }
}
