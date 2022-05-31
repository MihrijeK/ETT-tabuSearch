package com.timetabling.app.model;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.List;

public class Assignment {

	@JsonProperty("Course")
	private String Course;
	
	//@JsonProperty("Events")
	@JsonIgnore
	private List<Event> Events;
	@JsonProperty("Period")
	public String Period;
	@JsonProperty("Room")
	private String Room;

	public Assignment() {}

	@JsonIgnore
	public String getPeriod() {
		return Period;
	}

	@JsonIgnore
	public void setPeriod(String Period) {
		this.Period = Period;
	}

	@JsonIgnore
	public String getRoom() {
		return Room;
	}

	@JsonIgnore
	public void setRoom(String Room) {
		this.Room = Room;
	}
	@JsonIgnore
	public String getCourse() {
		return Course;
	}

	@JsonIgnore
	public void setCourse(String Course) {
		this.Course = Course;
	}

	@JsonIgnore
	public List<Event> getEvents() {
		return Events;
	}
	
	@JsonIgnore
	public void setEvents(List<Event> Events) {
		this.Events = Events;
	}
	
	public Assignment(Builder builder) {
		this.Course = builder.Course;
		this.Events = builder.Events;
		this.Period = builder.Period;
		this.Room = builder.Room;
	}
	
	public static class Builder {
		private String Course;
		private List<Event> Events;
		private String Period;
		private String Room;
		
		public Builder Course(String Course) {
			this.Course = Course;
			return this;
		}
		
		public Builder Period(String Period) {
			this.Period = Period;
			return this;
		}
		
		public Builder Room(String Room) {
			this.Room = Room;
			return this;
		}

		public Builder Events(List<Event> Events) {
			this.Events = Events;
			
			this.Period = Events.get(0).Period;
			this.Room = Events.get(0).getRoom();
			//System.out.println("Hii"+this.Room);
			return this;
		}
		
		public Assignment build() {
			return new Assignment(this);
		}
	}
}
