using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using PeerGrade7.Library;
using PeerGrade7.Library.Task;

namespace PeerGrade7
{
    internal static class Program
    {
        /// <summary>
        /// App state
        /// </summary>
        private static readonly Stack<StateContainer> StateContainers = new Stack<StateContainer>();

        /// <summary>
        /// Projects list
        /// </summary>
        private static List<Project> _projects = new List<Project>();
        
        /// <summary>
        /// Users list
        /// </summary>
        private static List<User> _users = new List<User>();

        private static void Main()
        {
            _users = (List<User>) ReadOrSaveFile(typeof(List<User>), "users.json", FileMode.Open);
            _projects = (List<Project>) ReadOrSaveFile(typeof(List<Project>), "projects.json", FileMode.Open);

            if (_projects == null || _users == null)
            {
                _projects = new List<Project>();
                _users = new List<User>();
            }
            
            GoToMainMenu();
            Loop();
        }

        /// <summary>
        /// App main loop
        /// </summary>
        private static void Loop()
        {
            while (true)
            {
                // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
                switch (StateContainers.Peek().State)
                {
                    case State.MainMenu:
                        MainMenuState();
                        break;

                    case State.Projects:
                        ProjectsState();
                        break;

                    case State.Project:
                        ProjectState();
                        break;

                    case State.Users:
                        UsersState();
                        break;

                    case State.User:
                        UserState();
                        break;

                    case State.Task:
                        TaskState();
                        break;

                    case State.TaskUser:
                        TaskUserState();
                        break;
                }
            }
            
            // ReSharper disable once FunctionNeverReturns
        }

        /// <summary>
        /// Switches app state to main menu
        /// </summary>
        private static void GoToMainMenu()
        {
            StateContainers.Clear();
            StateContainers.Push(new StateContainer(State.MainMenu, null));
        }

        /// <summary>
        /// Goes to back app state
        /// </summary>
        private static void GoBack()
        {
            StateContainers.Pop();
        }

        /// <summary>
        /// MainMenu state
        /// </summary>
        private static void MainMenuState()
        {
            var menu = new Menu("Main menu:");

            menu.Append("Projects", index =>
                StateContainers.Push(new StateContainer(State.Projects, null)));

            menu.Append("Users", index =>
                StateContainers.Push(new StateContainer(State.Users, null)));

            menu.Append("Exit (Will save current state)", _ =>
            {
                ReadOrSaveFile(typeof(List<User>), "users.json", FileMode.Create, _users);
                ReadOrSaveFile(typeof(List<Project>), "projects.json", FileMode.Create, _projects);
                Environment.Exit(0);
            });

            menu.Run();
        }

        /// <summary>
        /// Reads of saves app state to/from file
        /// </summary>
        /// <param name="t">Type</param>
        /// <param name="path">File path</param>
        /// <param name="mode">File mode</param>
        /// <param name="toSer">Serializable object</param>
        /// <returns>Read object</returns>
        private static object ReadOrSaveFile(Type t, string path, FileMode mode, object toSer = null)
        {
            try
            {
                using var stream = new FileStream(path, mode);

                var temp = new DataContractJsonSerializer(t, new[]
                {
                    typeof(AbstractTask),
                    typeof(Story),
                    typeof(Bug),
                    typeof(Task),
                    typeof(Epic),
                    typeof(Entity),
                    typeof(Project),
                    typeof(User),
                });

                if (mode == FileMode.Create)
                    temp.WriteObject(stream, toSer);
                else
                    return temp.ReadObject(stream);
            }
            catch (FileNotFoundException)
            {
                // Ignored.
            }
            catch (Exception e)
            {
                ShowError($"Failed to {(mode == FileMode.Open ? "load" : "save")} state: {e.Message}");
            }

            return null;
        }

        /// <summary>
        /// Projects state
        /// </summary>
        private static void ProjectsState()
        {
            var menu = new Menu("Projects list:");

            menu.Append("Create project", _ => AddProject());
            menu.Append("Back to main menu", _ => GoToMainMenu());

            if (_projects.Count > 0)
                menu.NewSection();

            foreach (var project in Project.RenderProjects(_projects))
                menu.Append(project, index =>
                    StateContainers.Push(new StateContainer(State.Project, _projects[index])));

            menu.Run();
        }

        /// <summary>
        /// Project state
        /// </summary>
        private static void ProjectState()
        {
            if (!(StateContainers.Peek().Data is Project project))
                return;

            var menu = new Menu(project.ToString());

            menu.Append("Change name", _ => ChangeName(project));

            if (project.TasksLength < project.Capacity)
                menu.Append("Add task", _ => AddTaskToProject(project));

            menu.Append("Remove project", _ => RemoveProject());
            menu.Append("Back", _ => GoBack());
            menu.Append("Back to main menu", _ => GoToMainMenu());

            if (project.TasksLength > 0)
                menu.NewSection();

            for (var i = 0; i < project.TasksLength; i++)
            {
                var task = project.GetTask(i);
                menu.Append($"{i + 1}) {task}",
                    index => StateContainers.Push(new StateContainer(State.Task, task)));
            }

            menu.Run();
        }

        /// <summary>
        /// Users state
        /// </summary>
        private static void UsersState()
        {
            var menu = new Menu("Users list:");

            menu.Append("Create user", _ => AddUser());
            menu.Append("Back to main menu", _ => GoToMainMenu());

            if (_users.Count > 0)
                menu.NewSection();

            foreach (var user in User.RenderUsers(_users))
                menu.Append(user, index =>
                    StateContainers.Push(new StateContainer(State.User, _users[index])));

            menu.Run();
        }

        /// <summary>
        /// User state
        /// </summary>
        private static void UserState()
        {
            var user = StateContainers.Peek().Data as User;
            var menu = new Menu(user?.ToString());

            menu.Append("Change name", _ => ChangeName(user));
            menu.Append("Remove user (only from assignee list)", _ => RemoveUser());
            menu.Append("Back", _ => GoBack());
            menu.Append("Back to main menu", _ => GoToMainMenu());

            menu.Run();
        }

        /// <summary>
        /// Task state
        /// </summary>
        private static void TaskState()
        {
            if (!(StateContainers.Peek().Data is AbstractTask task))
                return;

            var menu = new Menu(task.ToString());

            menu.Append("Change name", _ => ChangeName(task));
            menu.Append("Change status", _ => ChangeStatus(task));

            if (task.UsersLength < task.UsersCount)
                menu.Append("Add user", _ => AddUserToTask(task));

            if (task.TasksLength < task.TasksCount)
                menu.Append("Add task", _ => AddTaskToTask(task));

            menu.Append("Remove task", _ => RemoveTask());
            menu.Append("Back", _ => GoBack());
            menu.Append("Back to menu", _ => GoToMainMenu());

            if (task.TasksLength > 0)
            {
                menu.NewSection();
                for (var i = 0; i < task.TasksLength; i++)
                {
                    var subTask = task.GetTask(i);

                    menu.Append($"{i + 1}) {subTask}",
                        index => StateContainers.Push(new StateContainer(State.Task, subTask)));
                }
            }

            if (task.UsersLength > 0)
            {
                menu.NewSection();
                for (var i = 0; i < task.UsersLength; i++)
                {
                    var subUser = task.GetUser(i);

                    menu.Append($"{i + 1}) {subUser}",
                        index => StateContainers.Push(new StateContainer(State.TaskUser, subUser)));
                }
            }

            menu.Run();
        }

        /// <summary>
        /// User in task state
        /// </summary>
        private static void TaskUserState()
        {
            if (!(StateContainers.Peek().Data is User user))
                return;

            var menu = new Menu(user.ToString());

            menu.Append("Change name", _ => ChangeName(user));
            menu.Append("Remove user (only from that task)", _ => RemoveUserFromTask());
            menu.Append("Back", _ => GoBack());
            menu.Append("Back to main menu", _ => GoToMainMenu());

            menu.Run();
        }

        /// <summary>
        /// Changes entity name
        /// </summary>
        /// <param name="entity">Entity to change</param>
        private static void ChangeName(Entity entity)
        {
            entity.Name = GetStringFromUser("Enter new name");
        }

        /// <summary>
        /// Changes task's state
        /// </summary>
        /// <param name="task">Task to change</param>
        private static void ChangeStatus(AbstractTask task)
        {
            task.TaskStatus = GetStatusFromUser("Enter new status");
        }

        /// <summary>
        /// Adds project to global project list
        /// </summary>
        private static void AddProject()
        {
            var name = GetStringFromUser("Enter project name");
            var capacity = GetPositiveIntFromUser("Enter project capacity");

            _projects.Add(new Project(name, capacity));
        }

        /// <summary>
        /// Removes project from global project list
        /// </summary>
        private static void RemoveProject()
        {
            _projects.Remove(StateContainers.Pop().Data as Project);
        }

        /// <summary>
        /// Adds user to global user list
        /// </summary>
        private static void AddUser()
        {
            _users.Add(new User(GetStringFromUser("Enter user name")));
        }

        /// <summary>
        /// Removes user from global user list
        /// </summary>
        private static void RemoveUser()
        {
            _users.Remove(StateContainers.Pop().Data as User);
        }

        /// <summary>
        /// Removes user from task
        /// </summary>
        private static void RemoveUserFromTask()
        {
            var user = StateContainers.Pop().Data as User;
            var task = StateContainers.Peek().Data as AbstractTask;

            task?.RemoveUser(user);
        }

        /// <summary>
        /// Adds task to the project
        /// </summary>
        /// <param name="project">Project to modify</param>
        private static void AddTaskToProject(Project project)
        {
            var taskTypeMenu = new Menu("Choose task type:");
            var name = GetStringFromUser("Enter task name");

            taskTypeMenu.Append("Bug", _ => project.AddTask(new Bug(name)));
            taskTypeMenu.Append("Epic", _ => project.AddTask(new Epic(name)));
            taskTypeMenu.Append("Story", _ => project.AddTask(new Story(name)));
            taskTypeMenu.Append("Task", _ => project.AddTask(new Task(name)));

            taskTypeMenu.Run();
        }

        /// <summary>
        /// Adds user to the task
        /// </summary>
        /// <param name="task">Task to modify</param>
        private static void AddUserToTask(AbstractTask task)
        {
            var index = PeekUser();

            if (index >= 0)
                task.AddUser(_users[index]);
        }

        /// <summary>
        /// Adds task to the task (if supported)
        /// </summary>
        /// <param name="task">Task to modify</param>
        private static void AddTaskToTask(AbstractTask task)
        {
            var taskTypeMenu = new Menu("Choose task type:");
            var name = GetStringFromUser("Enter task name");

            taskTypeMenu.Append("Story", _ => task.AddTask(new Story(name)));
            taskTypeMenu.Append("Task", _ => task.AddTask(new Task(name)));

            taskTypeMenu.Run();
        }

        /// <summary>
        /// Removes task from current project
        /// </summary>
        private static void RemoveTask()
        {
            var task = StateContainers.Pop().Data as AbstractTask;
            var some = StateContainers.Peek().Data;

            switch (some)
            {
                case Project project:
                    project.RemoveTask(task);
                    break;
                case AbstractTask parentTask:
                    parentTask.RemoveTask(task);
                    break;
            }
        }

        /// <summary>
        /// Asks client to peek user
        /// </summary>
        /// <returns>Index in global user list or -1 on error</returns>
        private static int PeekUser()
        {
            var result = 0;
            var menu = new Menu("Select user to add to the task:");

            if (_users.Count == 0)
            {
                ShowError("There are no active users, please create one");
                return -1;
            }

            foreach (var user in User.RenderUsers(_users))
                menu.Append(user, index => result = index);

            menu.Run();
            return result;
        }

        /// <summary>
        /// Gets positive integer from client
        /// </summary>
        /// <param name="hint">Hint to show</param>
        /// <returns>Entered integer</returns>
        private static int GetPositiveIntFromUser(string hint)
        {
            int result;
            do
            {
                Console.Clear();
                Console.Write($"{hint} (integer grater than zero): ");
            } while (!int.TryParse(Console.ReadLine(), out result) || result <= 0);

            return result;
        }

        /// <summary>
        /// Gets string from user
        /// </summary>
        /// <param name="hint">Hint to show</param>
        /// <returns>Entered string</returns>
        private static string GetStringFromUser(string hint)
        {
            Console.Clear();
            Console.Write($"{hint}: ");

            var result = Console.ReadLine();
            Console.Clear();

            return result;
        }

        /// <summary>
        /// Gets Task Status from the client
        /// </summary>
        /// <param name="hint">Hint to show</param>
        /// <returns>Entered task status</returns>
        private static TaskStatus GetStatusFromUser(string hint)
        {
            while (true)
            {
                int status;
                do
                {
                    Console.Clear();
                    Console.Write($"{hint} (1 - Open, 2 - InProgress, 3 - Closed): ");
                } while (!int.TryParse(Console.ReadLine(), out status));

                switch (status)
                {
                    case 1:
                        return TaskStatus.Open;

                    case 2:
                        return TaskStatus.InProgress;

                    case 3:
                        return TaskStatus.Closed;

                    default:
                        continue;
                }
            }
        }

        /// <summary>
        /// Shows error to the client
        /// </summary>
        /// <param name="msg">Error message</param>
        private static void ShowError(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}