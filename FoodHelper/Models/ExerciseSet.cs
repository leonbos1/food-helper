using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class ExerciseSet : BaseEntity
    {
        public int SetNumber { get; set; }

        public int? Reps { get; set; }

        public double? Weight { get; set; }

        public Guid? ExerciseBatchId { get; set; }

        public ExerciseBatch? ExerciseBatch { get; set; }
    }
}
