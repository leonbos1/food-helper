using FoodHelper.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodHelper
{
    public class FoodContext : IdentityDbContext<User>
    {
        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseBatch> ExerciseBatches { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }
        public DbSet<MealFood> MealFoods { get; set; }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

            builder.Entity<ExerciseBatch>()
                .HasMany(eb => eb.ExerciseSets)
                .WithOne(es => es.ExerciseBatch)
                .HasForeignKey(es => es.ExerciseBatchId);

            builder.Entity<Workout>()
                .HasMany(w => w.ExerciseBatches)
                .WithOne(eb => eb.Workout)
                .HasForeignKey(eb => eb.WorkoutId);

            builder.Entity<Food>()
                .HasOne(f => f.User)
                .WithMany(u => u.Foods)
                .HasForeignKey(f => f.UserId);

            builder.Entity<Food>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Foods)
                .HasForeignKey(f => f.CategoryId);

            builder.Entity<MealFood>()
                .HasKey(mf => new { mf.MealId, mf.FoodId });

            builder.Entity<MealFood>()
                .HasOne(mf => mf.Meal)
                .WithMany(m => m.MealFoods)
                .HasForeignKey(mf => mf.MealId);

            builder.Entity<MealFood>()
                .HasOne(mf => mf.Food)
                .WithMany(f => f.MealFoods)
                .HasForeignKey(mf => mf.FoodId);
        }
    }

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(50);
            builder.Property(u => u.LastName)
                .HasMaxLength(50);
        }
    }
}
