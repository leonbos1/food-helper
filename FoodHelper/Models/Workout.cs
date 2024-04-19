using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class Workout : BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public User? User { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int? Duration => (int?)EndTime?.Subtract(StartTime ?? DateTime.MinValue).TotalMinutes;

        public List<ExerciseBatch> ExerciseBatches { get; set; }

        public Workout()
        {
            ExerciseBatches = new List<ExerciseBatch>();
        }
    }
}
