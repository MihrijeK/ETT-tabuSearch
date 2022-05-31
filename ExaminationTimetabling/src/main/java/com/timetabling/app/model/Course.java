package com.timetabling.app.model;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonIgnore;

public class Course {

	@JsonProperty("Course")
	private String Course;
	@JsonProperty("RoomsRequested")
	private RoomsRequested roomsRequested;
	@JsonProperty("Teacher")
	private String Teacher;
	
	public Course() {}

	@JsonIgnore
	public String getCourse() {
		return Course;
	}

	@JsonIgnore
	public void setCourse(String Course) {
		this.Course = Course;
	}

	@JsonIgnore
	public RoomsRequested getRoomsRequested() {
		return roomsRequested;
	}

	@JsonIgnore
	public void setRoomsRequested(RoomsRequested roomsRequested) {
		this.roomsRequested = roomsRequested;
	}

	@JsonIgnore
	public String getTeacher() {
		return Teacher;
	}

	@JsonIgnore
	public void setTeacher(String Teacher) {
		this.Teacher = Teacher;
	}
	
	public Course(Builder builder) {
		this.Course = builder.Course;
		this.roomsRequested = builder.roomsRequested;
		this.Teacher = builder.Teacher;
	}
	
	public static class Builder {
		private String Course;
		private RoomsRequested roomsRequested;
		private String Teacher;
		
		public Builder course(String Course) {
			this.Course = Course;
			return this;
		}
		
		public Builder roomsRequested(RoomsRequested roomsRequested) {
			this.roomsRequested = roomsRequested;
			return this;
		}
		
		public Builder teacher(String Teacher) {
			this.Teacher = Teacher;
			return this;
		}
		
		public Course build() {
			return new Course(this);
		}
	}
}
