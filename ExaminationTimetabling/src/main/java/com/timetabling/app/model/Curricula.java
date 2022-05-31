package com.timetabling.app.model;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonProperty;

public class Curricula {
		
		@JsonProperty("Curriculum")
		private String curriculum;
		@JsonProperty("PrimaryCourses")
		private List<String> primaryCourses;
		@JsonProperty("SecondaryCourses")
		private List<String> secondaryCourses;
		
		public Curricula() {}
		
		@JsonIgnore
		public String getCurriculum() {
			return curriculum;
		}

		@JsonIgnore
		public void setCurriculum(String curriculum) {
			this.curriculum = curriculum;
		}

		@JsonIgnore
		public List<String> getPrimaryCourses() {
			return primaryCourses;
		}

		@JsonIgnore
		public void setPrimaryCourses(List<String> primaryCourses) {
			this.primaryCourses = primaryCourses;
		}

		@JsonIgnore
		public List<String> getSecondaryCourses() {
			return secondaryCourses;
		}

		@JsonIgnore
		public void setSecondaryCourses(List<String> secondaryCourses) {
			this.secondaryCourses = secondaryCourses;
		}
		
		public Curricula(Builder builder) {
			this.curriculum = builder.curriculum;
			this.primaryCourses = builder.primaryCourses;
			this.secondaryCourses = builder.secondaryCourses;
		}
		
		public static class Builder {
			private String curriculum;
			private List<String> primaryCourses;
			private List<String> secondaryCourses;
			
			public Builder curriculum(String curriculum) {
				this.curriculum = curriculum;
				return this;
			}
			
			public Builder primaryCourses(List<String> primaryCourses) {
				this.primaryCourses = primaryCourses;
				return this;
			}
			
			public Builder secondaryCourses(List<String> secondaryCourses) {
				this.secondaryCourses = secondaryCourses;
				return this;
			}
			
			public Curricula build() {
				return new Curricula(this);
			}
		}
	
}
