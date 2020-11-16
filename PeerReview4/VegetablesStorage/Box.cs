namespace VegetablesStorage
{
    /// <summary>
    /// Box entity
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Weight of box in kilograms.
        /// </summary>
        public int Weight { get; }

        /// <summary>
        /// Cost of one kilogram.
        /// </summary>
        public double WeightCost { get; }

        /// <summary>
        /// Total box cost.
        /// </summary>
        public double Cost => Weight * WeightCost;

        /// <summary>
        /// Creates new box instance.
        /// </summary>
        /// <param name="weight">Weight of box in kilograms</param>
        /// <param name="weightCost">Cost of one kilogram</param>
        public Box(int weight, double weightCost)
        {
            Weight = weight;
            WeightCost = weightCost;
        }

        public override string ToString()
        {
            return $"Box (Weight: {Weight}, WeightCost: {WeightCost}, Cost: {Cost})";
        }
    }
}