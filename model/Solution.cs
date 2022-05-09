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
        public List<Assignment> getAssignment() {
		return assignments;
	}

        public void setAssignment(List<Assignment> assignments) {
            this.assignments = assignments;
        }
        public Solution(List<Assignment> assignments, int set)
        {
            this.assignments = assignments;
            this.cost = cost;
        }

        public int getCost() {
		    return cost;
        }
        public void setCost(int cost) {
            this.cost = cost;
        } 

        // public List<Assignment> assignmentss(List<Assignment> assignments) {
		// 	this.assignments = assignments;
		// 	return this.assignments;
		// }
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
	
	public List<Assignment> mutation(Instance inst)
		{
			randomGenerator = new Random();

			Assignment firstAssignment = this.assignments[randomGenerator.Next(assignments.Count())];
			Event firstEvent = firstAssignment.getEvents()[0];
			if (firstEvent != null)
			{
				Room room = inst.getRooms().Where(rt => rt.getRoom().Equals(firstEvent.getRoom())).FirstOrDefault();
				if (room !=null)
				{
					List<Room> rooms = inst.getRooms().Where(r => r.getType().Equals(room.getType())).ToList();
					var shuffledrooms = rooms.OrderBy(a => randomGenerator.Next()).ToList();
					firstEvent.setRoom(shuffledrooms[0].getRoom());
				}
				this.setAssignment(assignments);
			}
			return assignments;
		}
    }
}
