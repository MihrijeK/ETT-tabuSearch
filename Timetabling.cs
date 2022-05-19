using System;
using System.Linq;
using System.Collections.Generic;
using ETT.model;
namespace ETT
{
    class Timetabling {
	
        private static Dictionary<Period, List<Room>> periodRoomRelation = new Dictionary<Period, List<Room>>();
        private static int cost = 0;
        private static Solution best = null;
        static void Main(string[] args){

            Instance inst = JSONUtils.Convert(JSONUtils.getFileData("src/main/java/com/timetabling/app/D1-2-16.json"), new Instance(){});

            List<Course> courses = inst.getCourses();
            List<Room> rooms = inst.getRooms();
            List<Curricula> curriculas = inst.getCurricula();
            List<Solution> tabuList = new List<Solution>();
            int numberOfTweak = 5;
            
            Solution solution = generateSolution(inst, courses, rooms, curriculas);
            calculateCost(solution, inst);
            best = solution;
            int tabuListLength = 10;
            tabuList.Add(solution);
            int repeat = 0;
            while(repeat < 50) {
                Solution R;
                if(tabuList.Count > tabuListLength) {
                    tabuList.RemoveAt(0);
                }
                cost = 0;
                R = new Solution.Builder().assignmentss(applyTweaks(solution, inst)).costs(cost).build();
                calculateCost(R, inst);
                Console.WriteLine(R.getCost());
                for (int i = 0; i < numberOfTweak; i++) {
                    cost = 0;
                    Solution W = new Solution.Builder().assignmentss(applyTweaks(solution, inst)).costs(cost).build();
                    calculateCost(W, inst);
                    Console.WriteLine(W.getCost());
                    if(!tabuList.Contains(W) && (W.getCost() > R.getCost() || tabuList.Contains(R))) {
                        R = W;
                    }
                    cost = 0;
                }
                if(!tabuList.Contains(R)) {
                    solution = R;
                    tabuList.Add(R);
                }
                if(solution.getCost() >= best.getCost()) {
                    best = solution;
                }
                repeat++;
            }
            JSONUtils.saveFile(JSONUtils.convert(best), "Assignments.json");
        }

        private static Solution generateSolution(Instance inst, List<Course> courses, List<Room> rooms, List<Curricula> curriculas) {
            List<Assignment> assignments = new List<Assignment>();
            List<Exam> exams = new List<Exam>();
            periodRoomRelation = getPeriods(inst.getPeriods(), inst.getSlotsPerDay(), rooms);
            curriculas.ForEach(curricula => {
                checkingConstraints(inst, courses, exams, curricula, curricula.getPrimaryCourses(), assignments, inst.getPrimaryPrimaryDistance());
                checkingConstraints(inst, courses, exams, curricula, curricula.getSecondaryCourses(), assignments, inst.getPrimarySecondaryDistance());
		    });
            return new Solution.Builder().assignmentss(assignments).costs(cost).build();
        }
        
        private static List<Assignment> applyTweaks(Solution solution, Instance inst) {
            solution.swap();
            return solution.mutation(inst);
        }

        static List<Assignment> checkingConstraints(Instance inst, List<Course> courses, List<Exam> exams, Curricula curricula,
            List<String> curricumCourses, List<Assignment> assignments, decimal distance) {
            Random randomGenerator = new Random();
            var shuffleCurriculumCourses = curricumCourses.OrderBy(a => randomGenerator.Next()).ToList();
            foreach (String prCourse in shuffleCurriculumCourses) {
                Course course = courses.Where(cr => cr.getCourse().Equals(prCourse, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                Dictionary<Period, List<Room>> periodAndCourseRoom = getRequestedCourseRooms(course, exams, inst, curricula, distance ,curricumCourses);
                if(periodAndCourseRoom != null) {
                      List<Room> selectedPeriod = periodAndCourseRoom.Where(r => r.Equals(course.getRoomsRequested().getType())).Take(course.getRoomsRequested().getNumber()).ToList();
                        Exam exam = new Exam.Builder().courses(course).roomss(selectedPeriod)
                                .periods(periodAndCourseRoom.getKey()).curriculum(curricula.getCurriculum()).build();
                        exams.Add(exam);
                        List<Event> events = new List<Event>();
                        if(selectedPeriod.Count == 0) {
                            Event e = new Event.Builder().periodss(periodAndCourseRoom.getKey().getId()).periodDays(periodAndCourseRoom.getKey().getDay()).
                                    periodTimeslots(periodAndCourseRoom.getKey().getTimeslot()).rooms("").build();
                            events.Add(e);
                        } 
                        else {
                            selectedPeriod.ForEach(period => {
                                Event e = new Event.Builder().periodss(periodAndCourseRoom.getKey().getId()).periodDays(periodAndCourseRoom.getKey().getDay()).
                                        periodTimeslots(periodAndCourseRoom.getKey().getTimeslot()).rooms(period.getRoom()).build();
                                events.Add(e);
                            });
                        }
                        Assignment assignment = new Assignment.Builder().courses(exam.getCourse().getCourse())
                                .eventss(events).build();
                        assignments.Add(assignment);
                        periodRoomRelation.Remove(periodAndCourseRoom.getKey());
                }
            
            }
   
            return assignments;

        }
        
        static Dictionary<Period, List<Room>> getPeriods(int day, int timeslots, List<Room> rooms) {
            Dictionary<Period, List<Room>> periodRooms = new Dictionary<Period, List<Room>>();
            int id = 0;
            for (int i = 1; i <= day/timeslots; i++) {
                for (int j = 1; j <= timeslots; j++) {
                    Period period = new Period.Builder().ids(Convert.ToString(id)).days(i).timeslots(j).build();
                    periodRooms.Add(period, rooms);
                    id++;
                }
            }
            return periodRooms;
        }
        
        static Dictionary<Period, List<Room>> getRequestedCourseRooms(Course course, List<Exam> exams, Instance inst, Curricula curricula, decimal distance, List<String> courses) {
            List<Room> rooms = inst.getRooms().Where(room => room.getType().Equals(course.getRoomsRequested().getType()))
                    .Take(course.getRoomsRequested().getNumber()).ToList();
            Dictionary<Period, List<Room>> periodOfRooms = periodRoomRelation.AsParallel().Where(e => e.Equals(rooms))
                    .ToDictionary(e => e.Key, e => e.Value);
            if(exams.Count == 0) {
                return periodOfRooms.Count == 0 ? periodRoomRelation.Value : periodOfRooms.AsParallel().iterator().next();
            } else {
                Dictionary<Period, List<Room>> availablePeriodOfRooms = periodOfRooms.Count == 0 ? periodRoomRelation : periodOfRooms;
                Dictionary<Period, List<Room>> softConstraintRoomPeriod = checkPeriodSoftConstraint(availablePeriodOfRooms, exams, curricula, course, courses, distance);
                if(softConstraintRoomPeriod != null) {
                    return softConstraintRoomPeriod;
                }
                Dictionary<Period, List<Room>> periodOfRoomSelected = periodOfRooms.Where(
                        e => exams.Any(ex => !ex.getCourse().getTeacher().Equals(course.getTeacher()) && !ex.getPeriod().Equals(e.Key)))
                        .SingleOrDefault();
                return periodOfRoomSelected != null ? periodOfRoomSelected : null;
            }
        }
        
        static Dictionary<Period, List<Room>> checkPeriodSoftConstraint(Dictionary<Period, List<Room>> periodOfRooms, List<Exam> exams, Curricula curricula, 
                Course course, List<String> courses, decimal distance) {
            List<String> allCurriculumCourses = new List<String>(curricula.getPrimaryCourses());
            allCurriculumCourses.AddRange(curricula.getSecondaryCourses());
            List<Exam> addedCurriculumCourses = exams.Where(exam => allCurriculumCourses.Contains(exam.getCourse().getCourse())).ToList();
            Dictionary<Period, List<Room>> availablePeriodOfRooms = periodOfRooms.AsParallel().Where(
                    e => addedCurriculumCourses.Any(ex => !ex.getCourse().getTeacher().Equals(course.getTeacher()) && !ex.getPeriod().Equals(e.Key))).ToDictionary(ex => ex.Key, ex => ex.Value);
            Dictionary<Period, List<Room>> periodOfRoom = checkCourseDistanceSoftConstraint(availablePeriodOfRooms, exams, courses, course, distance);
            if(periodOfRoom != null) {
                return periodOfRoom;
            }
            Dictionary<Period, List<Room>> periodOfRoomSelected = periodOfRooms.AsParallel().Where(
                    e => addedCurriculumCourses.Any(ex => !ex.getCourse().getTeacher().Equals(course.getTeacher()) && !ex.getPeriod().Equals(e.Key)))
                    .FirstOrDefault();
            if(periodOfRoomSelected != null) {
                return periodOfRoomSelected;
            }
            return null;
        }
        
        static Dictionary<Period, List<Room>> checkCourseDistanceSoftConstraint(Dictionary<Period, List<Room>> periodOfRooms, List<Exam> exams, List<String> courses, Course course, decimal distance) {
            List<Exam> addedCourses = exams.Where(exam => courses.Contains(exam.getCourse().getCourse())).ToList();
            addedCourses.Sort(addedCourses.CompareTo(new Exam.getPeriod().getDay()).reversed());
            if(addedCourses.Count == 0) {
                return null;
            }
            decimal lastAddedExamDayPeriod = addedCourses[0].getPeriod().getDay();
            Dictionary<Period, List<Room>> periodOfRoomSelected = periodOfRooms.AsParallel().Where(e => e.Key.getDay().CompareTo(lastAddedExamDayPeriod+distance) > 1 ).FindFirst();
            return periodOfRoomSelected != null ? periodOfRoomSelected : null;
        }
        
        static void calculateCost(Solution solution, Instance inst) {
            Dictionary<String, List<String>> periodOfCourses = new Dictionary<String, List<String>>();
            solution.getAssignment().ForEach(assignment => {
			List<Event> assignmentEvents = assignment.getEvents();
			assignmentEvents.ForEach(e => {
				if(periodOfCourses.ContainsKey(e.getPeriod())) {
					List<String> courses = periodOfCourses[e.getPeriod()];
					if(!courses.Contains(assignment.getCourse())) {
						courses.Add(assignment.getCourse());
					}
				} else {
					periodOfCourses.Add(e.getPeriod(), new List<String>(assignment.getCourse().ToList()));
				}
			});
		});
		
		inst.getCurricula().ForEach(curricula => {
			List<String> curriculaCourses = curricula.getPrimaryCourses();
			//Check second soft constraint 
			checkSecondConstraintCost(solution, inst, curriculaCourses);
			checkSecondConstraintCost(solution, inst, curricula.getSecondaryCourses());
			curriculaCourses.AddRange(curricula.getSecondaryCourses());
			periodOfCourses.AsParallel().ForAll(courses => {
				if(!curriculaCourses.Contains(courses.Key)) {  ////////////////////////////////////////
					cost = cost + courses.Value.Count;
				}
			});
		});
		solution.setCost(cost);
		
	}

	static void checkSecondConstraintCost(Solution solution, Instance inst, List<String> curriculaCourses) {
		List<Assignment> filteredAssignments = new List<Assignment>();
        filteredAssignments = solution.getAssignment().Where(a => curriculaCourses.Contains(a.getCourse())).ToList();
        // filteredAssignments.Sort(filteredAssignments.CompareTo((new Assignment.getEvents()[0].getPeriodDay())).reversed());
		for (int i = 0; i < filteredAssignments.Count-1; i++) {
			if(filteredAssignments[i].getEvents()[0].getPeriodDay() + ((int)inst.getPrimaryPrimaryDistance())
			>=  filteredAssignments[i+1].getEvents()[0].getPeriodDay()) {
				cost = cost + 1;
			}
		}
	}

    }
}
