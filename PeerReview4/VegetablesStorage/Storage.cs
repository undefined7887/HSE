using System;
using System.Linq;

namespace VegetablesStorage
{
    /// <summary>
    /// Storage entity
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Instance of Random class.
        /// This is necessary so that random numbers are not repeated.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Singleton for storage.
        /// </summary>
        public static Storage Singleton { get; set; }

        /// <summary>
        /// Containers array.
        /// </summary>
        public Container[] Containers { get; }

        /// <summary>
        /// Current containers count.
        /// </summary>
        public int ContainersCount { get; private set; }

        /// <summary>
        /// Cost of container storage.
        /// </summary>
        public double ContainerCost { get; }

        /// <summary>
        /// Container identificator.
        /// Used to find oldest added container.
        /// </summary>
        private int _containerId;

        /// <summary>
        /// Creates new instance of Storage class
        /// </summary>
        /// <param name="capacity">Storage capacity</param>
        /// <param name="containerCost">Cost of container storage.</param>
        public Storage(int capacity, double containerCost)
        {
            Containers = new Container[capacity];
            ContainerCost = containerCost;
        }

        /// <summary>
        /// Adds new container to the storage
        /// </summary>
        /// <param name="container">Container to add</param>
        /// <returns>True if everything is ok, false if container.Cost lower or equals ContainerCost</returns>
        public bool AddContainer(Container container)
        {
            container.DamageCoefficient = Random.NextDouble() / 2;
            container.Id = _containerId;

            if (container.Cost <= ContainerCost)
                return false;

            _containerId++;
            if (ContainersCount != Containers.Length)
            {
                for (var i = 0; i < Containers.Length; i++)
                {
                    if (Containers[i] != null)
                        continue;

                    Containers[i] = container;
                    ContainersCount++;

                    return true;
                }
            }

            var minId = Containers.Min(x => x.Id);

            for (var i = 0; i < Containers.Length; i++)
            {
                if (Containers[i].Id != minId)
                    continue;

                Containers[i] = container;
                ContainersCount++;

                break;
            }

            return true;
        }

        /// <summary>
        /// Removes container from 
        /// </summary>
        /// <param name="index">Container index</param>
        /// <returns>True if everything is ok, false if index doesn't exists</returns>
        public bool RemoveContainer(int index)
        {
            if (index >= Containers.Length)
                return false;

            if (Containers[index] == null)
                return true;

            Containers[index] = null;
            ContainersCount--;

            return true;
        }

        /// <summary>
        /// Displays storage.
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            var content =
                $"Storage (Capacity: {Containers.Length}, ContainerCost: {ContainerCost}, ContainersCount: {ContainersCount})"
                + Environment.NewLine;

            for (var i = 0; i < Containers.Length; i++)
            {
                content += $"\t{i}) ";

                if (Containers[i] == null)
                    content += "Empty" + Environment.NewLine;
                else
                    content += Containers[i].ToString(2) + Environment.NewLine;
            }

            return content.TrimEnd();
        }
    }
}