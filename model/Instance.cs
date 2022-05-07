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

       public List<Course> getCourses() {
		return courses;
	}
	public void setCourses(List<Course> courses) {
		this.courses = courses;
	}
	public List<Curricula> getCurricula() {
		return curricula;
	}
	public void setCurricula(List<Curricula> curricula) {
		this.curricula = curricula;
	}
	public int getPeriods() {
		return periods;
	}
	public void setPeriods(int periods) {
		this.periods = periods;
	}
	public decimal getPrimaryPrimaryDistance() {
		return primaryPrimaryDistance;
	}
	public void setPrimaryPrimaryDistance(decimal primaryPrimaryDistance) {
		this.primaryPrimaryDistance = primaryPrimaryDistance;
	}
	public decimal getPrimarySecondaryDistance() {
		return primarySecondaryDistance;
	}
	public void setPrimarySecondaryDistance(decimal primarySecondaryDistance) {
		this.primarySecondaryDistance = primarySecondaryDistance;
	}
	public int getSlotsPerDay() {
		return slotsPerDay;
	}
	public void setSlotsPerDay(int slotsPerDay) {
		this.slotsPerDay = slotsPerDay;
	}
	public List<String> getTeachers() {
		return teachers;
	}
	public void setTeachers(List<String> teachers) {
		this.teachers = teachers;
	}
	public List<Room> getRooms() {
		return rooms;
	}
	public void setRooms(List<Room> rooms) {
		this.rooms = rooms;
	}
	
    }
}
