package com.timetabling.app.model;

import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonIgnore;

import com.timetabling.app.enums.RoomType;

public class Room {

	 @JsonProperty("Room")
	 private String Room;
	 @JsonProperty("Type")
	 private RoomType type;
	 
	 public Room() {}
	 
	 @JsonIgnore
	 @Enumerated(EnumType.STRING)
	 public String getRoom() {
		 return Room;
	 }

	 @JsonIgnore
	 public void setRoom(String Room) {
		 this.Room = Room;
	 }

	 @JsonIgnore
	 public RoomType getType() {
		 return type;
	 }

	 @JsonIgnore
	 public void setType(RoomType type) {
		 this.type = type;
	 }
	 
	 public Room(Builder builder) {
		 this.Room = builder.Room;
		 this.type = builder.type;
	 }
	 
	 public static class Builder {
		 private String Room;
		 private RoomType type;
		 
		 public Builder number(String Room) {
			 this.Room = Room;
			 return this;
		 }
		 
		 public Builder type(RoomType type) {
			 this.type = type;
			 return this;
		 }
		 
		 public Room build() {
			 return new Room(this);
		 }
	 }
}	
