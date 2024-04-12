namespace FoodHelper.Logic.Helpers
{
    public class BmiCalculator
    {
        public static double Calculate(double height, double weight)
        {
            if (height <= 0 || weight <= 0)
            {
                return 0;
            }

            if (height > 3)
            {
                height /= 100;
            }

            var bmi = Math.Round(weight / (height * height), 2);

            return bmi;
        }
    }
}
