using System;
using System.Collections.Generic;
using System.Linq;

namespace VegetablesStorage
{
    /// <summary>
    /// Container entity
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Minimum possible container capacity.
        /// </summary>
        private const int MinCapacity = 50;

        /// <summary>
        /// Maximum possible container capacity.
        /// </summary>
        private const int MaxCapacity = 1000;

        /// <summary>
        /// Minimum possible cost coefficient.
        /// </summary>
        public const double MinCostCoefficient = 0;

        /// <summary>
        /// Maximum possible cost coefficient.
        /// </summary>
        public const double MaxCostCoefficient = 0.5;

        /// <summary>
        /// Instance of Random class.
        /// This is necessary so that random numbers are not repeated.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Container id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Container capacity.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Container weight.
        /// Must be lower or equals to the capacity.
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// Container cost.
        /// </summary>
        public double Cost => Boxes.Sum(x => x.Cost * (1 - DamageCoefficient));

        /// <summary>
        /// Degree of damage to the container.
        /// Cost of each box will be multiplied by this coefficient.
        /// </summary>
        public double DamageCoefficient
        {
            get => _damageCoefficient;
            set
            {
                if (value < MinCostCoefficient && value >= MaxCostCoefficient)
                    throw new Exception("Damage coefficient must be in range [0, 0.5)");

                _damageCoefficient = value;
            }
        }

        /// <summary>
        /// Field for CostCoefficient property.
        /// </summary>
        private double _damageCoefficient;

        /// <summary>
        /// List of boxes inside container.
        /// </summary>
        public List<Box> Boxes { get; } = new List<Box>();

        /// <summary>
        /// Creates instance of Container class with random Capacity.
        /// </summary>
        public Container()
        {
            Capacity = Random.Next(MinCapacity, MaxCapacity);
        }

        /// <summary>
        /// Adds box to the container.
        /// </summary>
        /// <param name="box">Box to add</param>
        /// <returns>True if everything is ok, false if there is no space in container</returns>
        public bool AddBox(Box box)
        {
            if (box.Weight + Weight > Capacity)
                return false;

            Boxes.Add(box);
            Weight += box.Weight;
            return true;
        }

        /// <summary>
        /// Displays container.
        /// </summary>
        /// <param name="boxesTabCount">Number of tabs for boxes</param>
        /// <returns>String</returns>
        public string ToString(int boxesTabCount)
        {
            var content =
                $"Container (Capacity: {Capacity}, Weight: {Weight}, Damage: {DamageCoefficient}, Cost: {Cost}):"
                + Environment.NewLine;

            foreach (var box in Boxes)
            {
                for (var i = 0; i < boxesTabCount; i++)
                    content += "\t";

                content += box + Environment.NewLine;
            }

            return content.TrimEnd();
        }

        /// <summary>
        /// Parses container from line
        /// </summary>
        /// <param name="line">Line to parse</param>
        /// <returns>Parsed container if everything is ok, null if parse failed</returns>
        public static Container Parse(string line)
        {
            var splitLine = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

            if (splitLine.Length % 2 != 0)
                return null;
            
            var container = new Container();
            for (var i = 0; i < splitLine.Length; i += 2)
            {
                if (!int.TryParse(splitLine[i], out var weight)
                    || weight <= 0
                    || !double.TryParse(splitLine[i + 1], out var weightCost)
                    || !(weightCost > 0))
                    return null;

                container.AddBox(new Box(weight, weightCost));
            }

            return container;
        }
    }
}