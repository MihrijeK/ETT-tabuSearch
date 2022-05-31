package com.timetabling.app.model;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonIgnore;

public class Period {
	
	@JsonProperty("Id")
	private String id;
	@JsonProperty("Day")
	private Integer day;
	private Integer timeslot;
	
	@JsonIgnore
	public String getId() {
		return id;
	}

	@JsonIgnore
	public void setId(String id) {
		this.id = id;
	}
	public Integer getDay() {
		return day;
	}

	@JsonIgnore
	public void setDay(Integer day) {
		this.day = day;
	}

	@JsonIgnore
	public Integer getTimeslot() {
		return timeslot;
	}

	@JsonIgnore
	public void setTimeslot(Integer timeslot) {
		this.timeslot = timeslot;
	}
	
	public Period(Builder builder) {
		this.id = builder.id;
		this.day = builder.day;
		this.timeslot = builder.timeslot;
	}
	
	public static class Builder {
		private String id;
		private Integer day;
		private Integer timeslot;
		
		public Builder id(String id) {
			this.id = id;
			return this;
		}
		
		public Builder day(Integer day) {
			this.day = day;
			return this;
		}
		
		public Builder timeslot(Integer timeslot) {
			this.timeslot = timeslot;
			return this;
		}
		
		public Period build() {
			return new Period(this);
		}
	}
}
