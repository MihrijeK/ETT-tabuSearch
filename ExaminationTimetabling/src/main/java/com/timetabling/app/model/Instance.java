package com.timetabling.app.model;

import java.math.BigDecimal;
import java.util.List;
import com.fasterxml.jackson.annotation.JsonProperty;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonIgnore;

@JsonIgnoreProperties(ignoreUnknown = true)
public class Instance {
	@JsonProperty("Courses")
	private List<Course> Courses;
	@JsonProperty("Curricula")
	private List<Curricula> Curricula;
	@JsonProperty("Periods")
	private Integer Periods;
	@JsonProperty("PrimaryPrimaryDistance")
	private BigDecimal PrimaryPrimaryDistance;
	@JsonProperty("PrimarySecondaryDistance")
	private BigDecimal PrimarySecondaryDistance;
	@JsonProperty("SlotsPerDay")
	private Integer SlotsPerDay;
	@JsonProperty("Teachers")
	private List<String> Teachers;
	@JsonProperty("Rooms")
	private List<Room> Rooms;
	
	public Instance() {}
	
	@JsonIgnore
	public List<Course> getCourses() {
		return Courses;
	}

	@JsonIgnore
	public void setCourses(List<Course> Courses) {
		this.Courses = Courses;
	}

	@JsonIgnore
	public List<Curricula> getCurricula() {
		return Curricula;
	}
	
	@JsonIgnore
	public void setCurricula(List<Curricula> Curricula) {
		this.Curricula = Curricula;
	}

	@JsonIgnore
	public Integer getPeriods() {
		return Periods;
	}

	@JsonIgnore
	public void setPeriods(Integer Periods) {
		this.Periods = Periods;
	}

	@JsonIgnore
	public BigDecimal getPrimaryPrimaryDistance() {
		return PrimaryPrimaryDistance;
	}

	@JsonIgnore
	public void setPrimaryPrimaryDistance(BigDecimal primaryPrimaryDistance) {
		this.PrimaryPrimaryDistance = primaryPrimaryDistance;
	}

	@JsonIgnore
	public BigDecimal getPrimarySecondaryDistance() {
		return PrimarySecondaryDistance;
	}

	@JsonIgnore
	public void setPrimarySecondaryDistance(BigDecimal primarySecondaryDistance) {
		this.PrimarySecondaryDistance = primarySecondaryDistance;
	}

	@JsonIgnore
	public Integer getSlotsPerDay() {
		return SlotsPerDay;
	}

	@JsonIgnore
	public void setSlotsPerDay(Integer slotsPerDay) {
		this.SlotsPerDay = slotsPerDay;
	}

	@JsonIgnore
	public List<String> getTeachers() {
		return Teachers;
	}

	@JsonIgnore
	public void setTeachers(List<String> Teachers) {
		this.Teachers = Teachers;
	}

	@JsonIgnore
	public List<Room> getRooms() {
		return Rooms;
	}

	@JsonIgnore
	public void setRooms(List<Room> Rooms) {
		this.Rooms = Rooms;
	}
	
	public Instance(Builder builder) {
		 this.Courses = builder.Courses;
		 this.Curricula = builder.curricula;
		 this.Periods = builder.Periods;
		 this.PrimaryPrimaryDistance = builder.primaryPrimaryDistance;
		 this.PrimarySecondaryDistance =  builder.primarySecondaryDistance;
		 this.SlotsPerDay = builder.slotsPerDay;
		 this.Teachers = builder.Teachers;
		 this.Rooms = builder.Rooms;
	}
	
	public static class Builder {
		private List<Course> Courses;
		private List<Curricula> curricula;
		private Integer Periods;
		private BigDecimal primaryPrimaryDistance;
		private BigDecimal primarySecondaryDistance;
		private Integer slotsPerDay;
		private List<String> Teachers;
		private List<Room> Rooms;
		
		public Builder Courses(List<Course> Courses) {
			this.Courses = Courses;
			return this;
		}
		public Builder curricula(List<Curricula> curricula) {
			this.curricula = curricula;
			return this;
		}
		public Builder Periods(Integer Periods) {
			this.Periods = Periods;
			return this;
		}
		public Builder primaryPrimaryDistance(BigDecimal primaryPrimaryDistance) {
			this.primaryPrimaryDistance = primaryPrimaryDistance;
			return this;
		}
		public Builder primarySecondaryDistance(BigDecimal primarySecondaryDistance) {
			this.primarySecondaryDistance = primarySecondaryDistance;
			return this;
		}
		public Builder slotsPerDay(Integer slotsPerDay) {
			this.slotsPerDay = slotsPerDay;
			return this;
		}
		public Builder Teachers(List<String> Teachers) {
			this.Teachers = Teachers;
			return this;
		}
		public Builder Rooms(List<Room> Rooms) {
			this.Rooms = Rooms;
			return this;
		}
		
		public Instance build() {
			return new Instance(this);
		}
	}
} 
