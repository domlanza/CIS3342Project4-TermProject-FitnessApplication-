using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutLibrary
{
    public class Exercise
    {
        private String ExerciseName;
        private int Reps;
        private int Sets;
        private int exerciseID;

        public int ExerciseID
        {
            get { return exerciseID; }
            set { exerciseID = value; }
        }

        public String exerciseName
        {
            get { return ExerciseName; }
            set { ExerciseName = value; }
        }

        public int reps
        {
            get { return Reps; }
            set { Reps = value; }
        }

        public int sets
        {
            get { return Sets; }
            set { Sets = value; }
        }
    }
}
