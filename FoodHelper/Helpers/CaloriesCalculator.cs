namespace FoodHelper.Logic.Helpers
{
    public class CaloriesCalculator
    {
        public static double Calculate(double height, double weight, int age, int exercisesPerWeek, string gender)
        {
            if (height <= 0 || weight <= 0)
            {
                return 0;
            }

            if (height > 3)
            {
                height /= 100;
            }

            double bmr;
            if (gender == "Man")
            {
                bmr = 88.362 + (13.397 * weight) + (4.799 * height * 100) - (5.677 * age);
            }
            else if (gender == "Woman")
            {
                bmr = 447.593 + (9.247 * weight) + (3.098 * height * 100) - (4.330 * age);
            }
            else
            {
                return 0;
            }

            double activityFactor;
            switch (exercisesPerWeek)
            {
                case 0:
                    activityFactor = 1.2;
                    break;
                case 1:
                case 2:
                case 3:
                    activityFactor = 1.375;
                    break;
                case 4:
                case 5:
                case 6:
                    activityFactor = 1.55;
                    break;
                default:
                    activityFactor = 1.725;
                    break;
            }

            return (int)(bmr * activityFactor);
        }
    }
}
