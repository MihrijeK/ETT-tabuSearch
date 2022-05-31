package com.timetabling.app.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class Event {
	@JsonProperty("Period")
	public String Period;
	@JsonIgnore
	private Integer periodDay;
	@JsonIgnore
	private Integer periodTimeslot;
	@JsonProperty("Room")
	private String Room;
	
	public Event() {}
	
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
	public Integer getPeriodDay() {
		return periodDay;
	}

	@JsonIgnore
	public void setPeriodDay(Integer periodDay) {
		this.periodDay = periodDay;
	}

	@JsonIgnore
	public Integer getPeriodTimeslot() {
		return periodTimeslot;
	}

	@JsonIgnore
	public void setPeriodTimeslot(Integer periodTimeslot) {
		this.periodTimeslot = periodTimeslot;
	}

	public Event(Builder builder) {
		this.Period = builder.Period;
		this.Room = builder.Room;
		this.periodDay = builder.periodDay;
		this.periodTimeslot = builder.periodTimeslot;
	}
	
	public static class Builder {
		private String Period;
		private String Room;
		private Integer periodDay;
		private Integer periodTimeslot;
		
		public Builder Period(String Period) {
			this.Period = Period;
			return this;
		}
		
		public Builder Room(String Room) {
			this.Room = Room;
			return this;
		}
		
		public Builder periodDay(Integer periodDay) {
			this.periodDay = periodDay;
			return this;
		}
		
		public Builder periodTimeslot(Integer periodTimeslot) {
			this.periodTimeslot = periodTimeslot;
			return this;
		}
		
		public Event build() {
			return new Event(this);
		}
	}
}
