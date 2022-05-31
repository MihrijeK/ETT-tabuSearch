package com.timetabling.app.model;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonIgnore;

public class Teacher {

	@JsonProperty("Id")
	private String id;
	@JsonProperty("Name")
	private String name;
	
	public Teacher() {}

	@JsonIgnore
	public String getId() {
		return id;
	}

	@JsonIgnore
	public void setId(String id) {
		this.id = id;
	}

	@JsonIgnore
	public String getName() {
		return name;
	}

	@JsonIgnore
	public void setName(String name) {
		this.name = name;
	}
	
	public Teacher(Builder builder) {
		this.id = builder.id;
		this.name = builder.name;
	}
	
	public static class Builder {
		private String id;
		private String name;
		
		public Builder id(String id) {
			this.id = id;
			return this;
		}
		
		public Builder name(String name) {
			this.name = name;
			return this;
		}
		
		public Teacher build() {
			return new Teacher(this);
		}
		
	}
}
