using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    public class Curricula
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

        public List<String> getPrimaryCourses() {
			return primaryCourses;
		}
		public void setPrimaryCourses(List<String> primaryCourses) {
			this.primaryCourses = primaryCourses;
		}

        public List<String> getSecondaryCourses() {
			return secondaryCourses;
		}
		public void setSecondaryCourses(List<String> secondaryCourses) {
			this.secondaryCourses = secondaryCourses;
		}

        public String getCurriculum() {
            return curriculum;
        }

        public void setCurriculum(String curriculum) {
            this.curriculum = curriculum;
        }
    }
}
