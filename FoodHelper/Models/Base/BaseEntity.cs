namespace FoodHelper.Data.Models.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
