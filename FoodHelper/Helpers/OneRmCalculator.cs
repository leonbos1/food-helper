namespace FoodHelper.Logic.Helpers
{
    public static class OneRmCalculator
    {
        public static double Calculate(double weight, double reps)
        {
            if (weight <= 0 || reps <= 0)
            {
                return 0;
            }

            double oneRepMax = weight * (1 + reps / 30.0);

            return oneRepMax;
        }
    }
}
