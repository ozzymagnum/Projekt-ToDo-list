


List<Task> tasks = new List<Task>()

    {
    new Task("House", "Clean House", "Not Done", Convert.ToDateTime("2015-10-17")),
    new Task("House", "Paint House", "Done", Convert.ToDateTime("2020-1-15")),
    new Task("Buy", "Buy Furniture", "Done", Convert.ToDateTime("2019-11-10")),
    new Task("Buy", "Buy Food", "Not Done", Convert.ToDateTime("2019-11-10"))

 

         };



        Console.WriteLine("Welcome to ToDoLy");

        while (true)
        {
            Console.WriteLine($"You have {tasks.Count} tasks to do and {tasks.Count(t => t.Status == "Done")} tasks are done!");
            Console.WriteLine("Pick an option:");
            Console.WriteLine("(1) Show Task List (by date or project)");
            Console.WriteLine("(2) Add New Task");
            Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
            Console.WriteLine("(4) Save and Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
            case "1":
                Console.WriteLine("How would you like to view the task list?");
                Console.WriteLine("(1) By Date");
                Console.WriteLine("(2) By Project");
                string viewOption = Console.ReadLine();

                if (viewOption == "1")
                {
                    // Sort tasks by date and display them
                    var sortedTasks = tasks.OrderBy(t => t.Date).ToList();
                    Console.WriteLine("Task List sorted by Date:");
                    foreach (var t in sortedTasks)
                    {
                        Console.WriteLine($"Project: {t.Project}, Title: {t.TaskTitle}, Status: {t.Status}, Due Date: {t.Date:yyyy-MM-dd}");
                    }
                }
                else if (viewOption == "2")
                {
                    // Group tasks by project and display them
                    var groupedTasks = tasks.GroupBy(t => t.Project);
                    Console.WriteLine("Task List grouped by Project:");
                    foreach (var group in groupedTasks)
                    {
                        Console.WriteLine($"Project: {group.Key}");
                        foreach (var t in group)
                        {
                            Console.WriteLine($"  Title: {t.TaskTitle}, Status: {t.Status}, Due Date: {t.Date:yyyy-MM-dd}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a valid option.");
                }
                break;
                
                case "2":
                Console.WriteLine("Enter Task Title:");
                string taskTitle = Console.ReadLine();

                Console.WriteLine("Enter Project:");
                string project = Console.ReadLine();

                Console.WriteLine("Enter Status (e.g., 'Not Done', 'Done'):");
                string status = Console.ReadLine();

                Console.WriteLine("Enter Due Date (e.g., 'yyyy-MM-dd'):");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    tasks.Add(new Task(taskTitle, project, status, date));
                    Console.WriteLine("Task added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Task not added.");
                }
                break;

            case "3":
                Console.WriteLine("Enter the task title you want to edit:");
                string taskToEdit = Console.ReadLine();

                // Find the task to edit
                Task task = tasks.FirstOrDefault(t => t.TaskTitle.Equals(taskToEdit, StringComparison.OrdinalIgnoreCase));

                if (task != null)
                {
                    Console.WriteLine("What would you like to do with this task?");
                    Console.WriteLine("(1) Update Task Title");
                    Console.WriteLine("(2) Update Status");
                    Console.WriteLine("(3) Mark as Done");
                    string editOption = Console.ReadLine();

                    switch (editOption)
                    {
                        case "1":
                            Console.WriteLine("Enter the new task title:");
                            string newTitle = Console.ReadLine();
                            task.TaskTitle = newTitle;
                            Console.WriteLine("Task title updated successfully.");
                            break;
                        case "2":
                            Console.WriteLine("Enter the new status (e.g., 'Not Done', 'Done'):");
                            string newStatus = Console.ReadLine();
                            task.Status = newStatus;
                            Console.WriteLine("Task status updated successfully.");
                            break;
                        case "3":
                            task.Status = "Done";
                            Console.WriteLine("Task marked as done.");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
                break;

                
                case "4":
                    // Implement the logic to save and quit
                    return;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }
    




class Task
{
    public Task(string project, string taskTitle, string status, DateTime date)
    {
        Project = project;
        TaskTitle = taskTitle;
        Status = status;
        Date = date;
    }

    public string Project { get; set; }
    public string TaskTitle { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
}




