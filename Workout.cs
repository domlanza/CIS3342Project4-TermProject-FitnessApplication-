using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLibrary
{
    public class Workout
    {
        private String WorkoutDay;
        private String WorkoutDescription;

        public String workoutDay
        {
            get { return WorkoutDay; }
            set { WorkoutDay = value; }
        }

        public String workoutDescirption
        {
            get { return WorkoutDescription; }
            set { WorkoutDescription = value; }
        }
    }
}
