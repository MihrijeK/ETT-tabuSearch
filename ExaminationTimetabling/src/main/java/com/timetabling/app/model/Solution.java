package com.timetabling.app.model;

import java.util.Collections;
import java.util.List;
import java.util.Optional;
import java.util.Random;
import java.util.stream.Collectors;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonIgnore;

public class Solution {
	private Random randomGenerator;
	@JsonProperty("Assignments")
	private List<Assignment> Assignments;
	@JsonProperty("Cost")
	private int Cost;

	@JsonIgnore
	public List<Assignment> getAssignment() {
		return Assignments;
	}

	@JsonIgnore
	public void setAssignment(List<Assignment> Assignments) {
		this.Assignments = Assignments;
	}

	@JsonIgnore
	public int getCost() {
		return Cost;
	}

	@JsonIgnore
	public void setCost(int Cost) {
		this.Cost = Cost;
	} 

	public Solution(Builder builder) {
		this.Assignments = builder.Assignments;
		this.Cost = builder.Cost;
	}
	
	public static class Builder {
		private List<Assignment> Assignments;
		private int Cost;
		
		public Builder assignments(List<Assignment> Assignments) {
			this.Assignments = Assignments;
			return this;
		}
		
		public Builder Cost(int Cost) {
			this.Cost = Cost;
			return this;
		}
		
		public Solution build() {
			return new Solution(this);
		}
	}
	
	public List<Assignment> swap() {
		randomGenerator = new Random();
		Assignment firstAssignment = this.Assignments.get(randomGenerator.nextInt(this.Assignments.size()));
		Assignment secondAssignment = this.Assignments.get(randomGenerator.nextInt(this.Assignments.size()));
		List<Event> firstEvents = firstAssignment.getEvents();
		List<Event> secondEvents = secondAssignment.getEvents();
		Event secondEvent = secondAssignment.getEvents().isEmpty() ? null : secondAssignment.getEvents().get(0);
		Event firstEvent = firstAssignment.getEvents().isEmpty() ? null : firstAssignment.getEvents().get(0);
		if(!firstEvents.isEmpty() && !secondEvents.isEmpty()) {
			String firstEventPeriod = firstEvent.getPeriod();
			String secondEventPeriod = secondEvent.getPeriod();
			secondEvent.setPeriod(firstEventPeriod);
			firstEvent.setPeriod(secondEventPeriod);
			firstEvents.set(0, firstEvent);
			secondEvents.set(0, secondEvent);
			this.setAssignment(Assignments);
		}
		return Assignments;
	}
	
	public List<Assignment> mutation(Instance inst) {
		randomGenerator = new Random();
		Assignment firstAssignment = this.Assignments.get(randomGenerator.nextInt(this.Assignments.size()));
		Event firstEvent = firstAssignment.getEvents().get(0);
		if(firstEvent != null) {
			Optional<Room> room = inst.getRooms().stream().filter(rt -> rt.getRoom().equals(firstEvent.getRoom())).findAny();
			if(room.isPresent()) {
				List<Room> rooms = inst.getRooms().stream().filter(r -> r.getType().equals(room.get().getType())).collect(Collectors.toList());
				Collections.shuffle(rooms);
				firstEvent.setRoom(rooms.get(0).getRoom());
			}
			this.setAssignment(Assignments);
		}
		return Assignments;
	}
}
