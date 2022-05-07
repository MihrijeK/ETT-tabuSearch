using System;
using System.Linq;
using System.Collections.Generic;
using ETT.model;
namespace ETT
{
    class Timetabling {
	
        private static IDictionary<Period, List<Room>> periodRoomRelation = new Dictionary<Period, List<Room>>();
        private static int cost = 0;
        private static Solution best = null;
        static void Main(string[] args){

            Instance inst = JSONUtils.convert(JSONUtils.getFileData("src/main/java/com/timetabling/app/D1-2-16.json"), new TypeReference<Instance>(){});

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
                R = new Solution.Builder().assignments(applyTweaks(solution, inst)).cost(cost).build();
                calculateCost(R, inst);
                Console.WriteLine(R.getCost());
                for (int i = 0; i < numberOfTweak; i++) {
                    cost = 0;
                    Solution W = new Solution.Builder().assignments(applyTweaks(solution, inst)).cost(cost).build();
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
            return new Solution.Builder().assignments(assignments).cost(cost).build();
        }
        
        private static List<Assignment> applyTweaks(Solution solution, Instance inst) {
            solution.swap();
            return solution.mutation(inst);
        }

        static List<Assignment> checkingConstraints(Instance inst, List<Course> courses, List<Exam> exams, Curricula curricula,
                List<String> curricumCourses, List<Assignment> assignments, decimal distance) {
            // // Collections.shuffle(curricumCourses);
            Random randomGenerator = new Random();
            var shuffleCurriculumCourses = curricumCourses.OrderBy(a => randomGenerator.Next()).ToList();
            foreach (String prCourse in shuffleCurriculumCourses) {
                Course course = courses.Where(cr => cr.getCourse().Equals(prCourse, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                Entry<Period, List<Room>> periodAndCourseRoom = getRequestedCourseRooms(course.get(), exams, inst, curricula, distance ,curricumCourses);
                if(periodAndCourseRoom != null) {
                      List<Room> selectedPeriod = periodAndCourseRoom.getValue().Where(r => r.getType().equals(course.get().getRoomsRequested().getType())).limit(course.get().getRoomsRequested().getNumber()).toList();
                        Exam exam = new Exam.Builder().course(course.get()).rooms(selectedPeriod)
                                .period(periodAndCourseRoom.getKey()).curriculum(curricula.getCurriculum()).build();
                        exams.Add(exam);
                        List<Event> events = new List<Event>();
                        // if(selectedPeriod.Count == 0) {
                        //     Event event = new Event.Builder().period(periodAndCourseRoom.getKey().getId()).periodDay(periodAndCourseRoom.getKey().getDay()).
                        //             periodTimeslot(periodAndCourseRoom.getKey().getTimeslot()).room("").build();
                        //     events.Add(event);
                        // } 
                        // else {
                        //     selectedPeriod.ForEach(period => {
                        //         Event event = new Event.Builder().period(periodAndCourseRoom.getKey().getId()).periodDay(periodAndCourseRoom.getKey().getDay()).
                        //                 periodTimeslot(periodAndCourseRoom.getKey().getTimeslot()).room(period.getRoom()).build();
                        //         events.Add(event);
                        //     });
                        // }
                        Assignment assignment = new Assignment.Builder().course(exam.getCourse().getCourse())
                                .events(events).build();
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
                    Period period = new Period.Builder().id(Convert.ToString(id)).day(i).timeslot(j).build();
                    periodRooms.Add(period, rooms);
                    id++;
                }
            }
            return periodRooms;
        }
        
        static Entry<Period, List<Room>> getRequestedCourseRooms(Course course, List<Exam> exams, Instance inst, Curricula curricula, BigDecimal distance, List<String> courses) {
            List<Room> rooms = inst.getRooms().Where(room => room.getType().Equals(course.getRoomsRequested().getType()))
                    .limit(course.getRoomsRequested().getNumber()).toList();
            Dictionary<Period, List<Room>> periodOfRooms = periodRoomRelation.entrySet().Where(e => CollectionUtils.containsAny(e.getValue(), rooms))
                    .collect(Collectors.toMap(e -> e.getKey(), e -> e.getValue()));
            if(exams.isEmpty()) {
                return periodOfRooms.Count == 0 ? periodRoomRelation.entrySet().iterator().next() : periodOfRooms.entrySet().iterator().next();
            } else {
                Dictionary<Period, List<Room>> availablePeriodOfRooms = periodOfRooms.Count == 0 ? periodRoomRelation : periodOfRooms;
                Entry<Period, List<Room>> softConstraintRoomPeriod = checkPeriodSoftConstraint(availablePeriodOfRooms, exams, curricula, course, courses, distance);
                if(softConstraintRoomPeriod != null) {
                    return softConstraintRoomPeriod;
                }
                Entry<Period, List<Room>> periodOfRoomSelected = periodOfRooms.entrySet().Where(
                        e => exams.stream().anyMatch(ex -> !ex.getCourse().getTeacher().equals(course.getTeacher()) && !ex.getPeriod().equals(e.getKey())))
                        .findFirst();
                return periodOfRoomSelected.isPresent() ? periodOfRoomSelected.get() : null;
            }
        }
        
        static Entry<Period, List<Room>> checkPeriodSoftConstraint(IDictionary<Period, List<Room>> periodOfRooms, List<Exam> exams, Curricula curricula, 
                Course course, List<String> courses, decimal distance) {
            List<String> allCurriculumCourses = new List<String>(curricula.getPrimaryCourses());
            allCurriculumCourses.AddRange(curricula.getSecondaryCourses());
            List<Exam> addedCurriculumCourses = exams.Where(exam => allCurriculumCourses.Contains(exam.getCourse().getCourse())).collect(Collectors.toList());
            IDictionary<Period, List<Room>> availablePeriodOfRooms = periodOfRooms.entrySet().Where(
                    e => addedCurriculumCourses.stream().anyMatch(ex -> !ex.getCourse().getTeacher().equals(course.getTeacher()) && !ex.getPeriod().equals(e.getKey())))
                    .collect(Collectors.toMap(Map.Entry::getKey, Map.Entry::getValue));
            Entry<Period, List<Room>> periodOfRoom = checkCourseDistanceSoftConstraint(availablePeriodOfRooms, exams, courses, course, distance);
            if(periodOfRoom != null) {
                return periodOfRoom;
            }
            Entry<Period, List<Room>> periodOfRoomSelected = periodOfRooms.entrySet().stream().filter(
                    e -> addedCurriculumCourses.WhereAny(ex => !ex.getCourse().getTeacher().equals(course.getTeacher()) && !ex.getPeriod().equals(e.getKey())))
                    .findFirst();
            if(periodOfRoomSelected.isPresent()) {
                return periodOfRoomSelected.get();
            }
            return null;
        }
        
        static Entry<Period, List<Room>> checkCourseDistanceSoftConstraint(IDictionary<Period, List<Room>> periodOfRooms, List<Exam> exams, List<String> courses, Course course, decimal distance) {
            List<Exam> addedCourses = exams.Where(exam => courses.Contains(exam.getCourse().getCourse())).collect(Collectors.toList());
            Collections.sort(addedCourses, Comparator.comparing(o -> ((Exam) o).getPeriod().getDay()).reversed());
            if(addedCourses.Count == 0) {
                return null;
            }
            decimal lastAddedExamDayPeriod = new decimal (addedCourses.get(0).getPeriod().getDay());
            Entry<Period, List<Room>> periodOfRoomSelected = periodOfRooms.entrySet().stream().filter(e -> new BigDecimal(e.getKey().getDay()).compareTo(lastAddedExamDayPeriod.add(distance)) > 1 ).findFirst();
            return periodOfRoomSelected.isPresent() ? periodOfRoomSelected.get() : null;
        }
        
        static void calculateCost(Solution solution, Instance inst) {
            Map<String, List<String>> periodOfCourses = new HashMap<String, List<String>>();
            solution.getAssignment().forEach(assignment -> {
                List<Event> assignmentEvents = assignment.getEvents();
                assignmentEvents.stream().forEach(event -> {
                    if(periodOfCourses.containsKey(event.getPeriod())) {
                        List<String> courses = periodOfCourses.get(event.getPeriod());
                        if(!courses.contains(assignment.getCourse())) {
                            courses.add(assignment.getCourse());
                        }
                    } else {
                        periodOfCourses.put(event.getPeriod(), new ArrayList<>(Arrays.asList(assignment.getCourse())));
                    }
                });
            });
            
            inst.getCurricula().stream().forEach(curricula -> {
                List<String> curriculaCourses = curricula.getPrimaryCourses();
                //Check second soft constraint 
                checkSecondConstraintCost(solution, inst, curriculaCourses);
                checkSecondConstraintCost(solution, inst, curricula.getSecondaryCourses());
                curriculaCourses.addAll(curricula.getSecondaryCourses());
                periodOfCourses.entrySet().stream().forEach(courses-> {
                    if(!curriculaCourses.containsAll(courses.getValue())) {
                        cost = cost + courses.getValue().size();
                    }
                });
            });
            solution.setCost(cost);
            
        }

        static void checkSecondConstraintCost(Solution solution, Instance inst, List<String> curriculaCourses) {
            List<Assignment> filteredAssignments = solution.getAssignment().stream().filter(a -> curriculaCourses.contains(a.getCourse())).collect(Collectors.toList());
            Collections.sort(filteredAssignments, Comparator.comparing(a -> ((Assignment) a).getEvents().get(0).getPeriodDay()).reversed());
            for (int i = 0; i < filteredAssignments.size()-1; i++) {
                if(filteredAssignments.get(i).getEvents().get(0).getPeriodDay() + inst.getPrimaryPrimaryDistance().intValue() 
                >=  filteredAssignments.get(i+1).getEvents().get(0).getPeriodDay()) {
                    cost = cost + 1;
                }
            }
            
        }

    }
}