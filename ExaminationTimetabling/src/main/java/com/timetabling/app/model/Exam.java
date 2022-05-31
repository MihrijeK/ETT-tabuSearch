package com.timetabling.app.model;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonIgnore;

import java.util.List;

public class Exam {
	@JsonProperty("Course")
	private Course Course;
	@JsonProperty("Rooms")
	private List<Room> Rooms;
	@JsonProperty("Period")
	public Period Period;
	@JsonProperty("Curriculum")
	private String curriculum;
	
	public Exam() {}
	
	@JsonIgnore
	public Course getCourse() {
		return Course;
	}

	@JsonIgnore
	public void setCourse(Course Course) {
		this.Course = Course;
	}

	@JsonIgnore
	public List<Room> getRooms() {
		return Rooms;
	}

	@JsonIgnore
	public void setRooms(List<Room> Rooms) {
		this.Rooms = Rooms;
	}

	@JsonIgnore
	public Period getPeriod() {
		return Period;
	}

	@JsonIgnore
	public void setPeriod(Period Period) {
		this.Period = Period;
	}
	
	@JsonIgnore
	public String getCurriculum() {
		return curriculum;
	}

	@JsonIgnore
	public void setCurriculum(String curriculum) {
		this.curriculum = curriculum;
	}

	public Exam(Builder builder) {
		this.Course = builder.Course;
		this.Rooms = builder.Rooms;
		this.Period = builder.Period;
		this.curriculum = builder.curriculum;
	}
	
	public static class Builder {
		private Course Course;
		private List<Room> Rooms;
		private Period Period;
		private String curriculum;
		
		public Builder course(Course Course) {
			this.Course = Course;
			return this;
		}
		
		public Builder rooms(List<Room> Rooms) {
			this.Rooms = Rooms;
			return this;
		}
		
		public Builder period(Period Period) {
			this.Period = Period;
			return this;
		}
		
		public Builder curriculum(String curriculum) {
			this.curriculum = curriculum;
			return this;
		}
		public Exam build() {
			return new Exam(this);
		}
	}
	
}
