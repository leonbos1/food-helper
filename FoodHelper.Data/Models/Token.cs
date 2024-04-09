namespace FoodHelper.Data.Models
{
    public class Token
    {
        public Guid Id { get; set; }
        public string? Value { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}