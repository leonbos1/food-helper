using FoodHelper.Data.Models;
using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class ExerciseBatch : BaseEntity
    {
        public Exercise? Exercise { get; set; }
        public Guid? ExerciseId { get; set; }
        public Workout? Workout { get; set; }
        public Guid? WorkoutId { get; set; }
        public List<ExerciseSet> ExerciseSets { get; set; }

        public ExerciseBatch()
        {
            ExerciseSets = new List<ExerciseSet>();
        }
    }
}
