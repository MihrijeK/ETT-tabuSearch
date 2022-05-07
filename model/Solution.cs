using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETT.model
{
    class Solution
    {
        private Random randomGenerator { get; set; }
        private List<Assignment> assignments { get; set; }
        private int cost { get; set; }
        public void setAssignment(List<Assignment> assignments) {
		    this.assignments = assignments;
	    }
        public Solution(List<Assignment> assignments, int set)
        {
            this.assignments = assignments;
            this.cost = cost;
        }
        public List<Assignment> swap() {
		randomGenerator = new Random();
		Assignment firstAssignment = this.assignments[randomGenerator.Next(this.assignments.Count)];
		Assignment secondAssignment = this.assignments[randomGenerator.Next(this.assignments.Count)];
		List<Event> firstEvents = firstAssignment.getEvents();
		List<Event> secondEvents = secondAssignment.getEvents();
		Event secondEvent = secondAssignment.getEvents().Count == 0 ? null : secondAssignment.getEvents()[0];
		Event firstEvent = firstAssignment.getEvents().Count == 0 ? null : firstAssignment.getEvents()[0];
		if(firstEvents.Count != 0 && secondEvents.Count != 0) {
			String firstEventPeriod = firstEvent.getPeriod();
			String secondEventPeriod = secondEvent.getPeriod();
			secondEvent.setPeriod(firstEventPeriod);
			firstEvent.setPeriod(secondEventPeriod);
			firstEvents[0] = firstEvent;
            secondEvents[0] = secondEvent;
			this.setAssignment(assignments);
		}
		return assignments;
	}
	
	public List<Assignment> mutation(Instance inst) {
		randomGenerator = new Random();
		Assignment firstAssignment = this.assignments.get(randomGenerator.nextInt(this.assignments.size()));
		Event firstEvent = firstAssignment.getEvents().get(0);
		if(firstEvent != null) {
			Optional<Room> room = inst.getRooms().stream().filter(rt -> rt.getRoom().equals(firstEvent.getRoom())).findAny();
			if(room.isPresent()) {
				List<Room> rooms = inst.getRooms().stream().filter(r -> r.getType().equals(room.get().getType())).collect(Collectors.toList());
				Collections.shuffle(rooms);
				firstEvent.setRoom(rooms.get(0).getRoom());
			}
			this.setAssignment(assignments);
		}
		return assignments;
	}

    }
}
