using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using PeerGrade7.Library.Task;

namespace PeerGrade7.Library
{
    /// <summary>
    /// Describes project
    /// </summary>
    [DataContract]
    public class Project : Entity
    {
        /// <summary>
        /// Project capacity
        /// </summary>
        [DataMember] public readonly int Capacity;

        /// <summary>
        /// Project tasks
        /// </summary>
        [DataMember] private readonly List<AbstractTask> _tasks = new List<AbstractTask>();

        public int TasksLength => _tasks.Count;

        public Project(string name, int capacity) : base(name)
        {
            Capacity = capacity;
        }

        /// <summary>
        /// Adds task to the project
        /// </summary>
        /// <param name="task">Task to add</param>
        /// <exception cref="InvalidOperationException">If project exceeded capacity</exception>
        public void AddTask(AbstractTask task)
        {
            if (_tasks.Count == Capacity)
                throw new InvalidOperationException("project capacity reached");

            _tasks.Add(task);
        }

        /// <summary>
        /// Removes task from the project
        /// </summary>
        /// <param name="task">Task to remove</param>
        public void RemoveTask(AbstractTask task)
        {
            _tasks.Remove(task);
        }

        /// <summary>
        /// Returns task from project
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public AbstractTask GetTask(int index) => _tasks[index];

        /// <summary>
        /// Renders project tasks
        /// </summary>
        /// <param name="projects">Projects to render</param>
        /// <returns>Rendered projects</returns>
        public static IEnumerable<string> RenderProjects(IEnumerable<Project> projects)
            => projects.Select((t, i) => $"{i + 1}) {t}").ToList();

        public override string ToString()
            => $"Project '{Name}' (tasks: {TasksLength}, capacity: {Capacity})";
    }
}