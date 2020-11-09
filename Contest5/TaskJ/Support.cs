using System;
using System.Collections.Generic;
using System.Linq;

public class Support
{
    private readonly List<Task> tasks = new List<Task>();

    public IEnumerable<Task> Tasks => tasks;

    public int OpenTask(string text)
    {
        var task = new Task(tasks.Count + 1, text);
        tasks.Add(task);
        return task.Id;
    }

    public void CloseTask(int id, string answer)
    {
        var task = tasks[id - 1];
        task.IsResolved = true;
        task.Answer = answer;
    }

    public List<Task> GetAllUnresolvedTasks()
    {
        return tasks
            .Where(x => !x.IsResolved)
            .ToList();
    }

    public void CloseAllUnresolvedTasksWithDefaultAnswer(string answer)
    {
        for (var i = 0; i < tasks.Count; i++)
            if (!tasks[i].IsResolved)
                CloseTask(i + 1, answer);
    }

    public string GetTaskInfo(int id)
    {
        return tasks[id - 1].ToString();
    }
}