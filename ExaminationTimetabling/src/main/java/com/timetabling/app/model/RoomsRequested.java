package com.timetabling.app.model;

import com.timetabling.app.enums.RoomType;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonIgnore;

public class RoomsRequested {

	@JsonProperty("Number")
	private Integer number;
	@JsonProperty("Type")
	private RoomType type;
	
	public RoomsRequested() {}

	@JsonIgnore
	public Integer getNumber() {
		return number;
	}

	@JsonIgnore
	public void setNumber(Integer number) {
		this.number = number;
	}

	@JsonIgnore
	public RoomType getType() {
		return type;
	}

	@JsonIgnore
	public void setType(RoomType type) {
		this.type = type;
	}
	
	public RoomsRequested(Builder builder) {
		this.number = builder.number;
		this.type = builder.type;
	}
	
	public static class Builder {
		private Integer number;
		private RoomType type;
		
		public Builder number(Integer number) {
			this.number = number;
			return this;
		}
		
		public Builder type(RoomType type) {
			this.type = type;
			return this;
		}
		
		public RoomsRequested build() {
			return new RoomsRequested(this);
		}
	}
	
}
