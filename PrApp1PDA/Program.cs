//#1.7
//Write console application for a diary. User should have ability to add/remove/edit tasks and also see tasks for today/tomorrow/week
//User should have ability to see all tasks, tasks that yet to be done and list of finished tasks. For a task its enough to store just the name, description and a deadline
//All data about tasks should be stored in separate .json file

using System.Text.Json;

namespace PrApp1PDA;
public class Task
{
    public Task(string name, string description, DateTime deadline, bool done)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
        Done = done;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public bool Done { get; set; }
}

static class Program
{
    static void Main()
    {
        string? input = String.Empty;
        string text = File.ReadAllText("task.json");
        List<Task>? items = JsonSerializer.Deserialize<List<Task>>(text);

        Console.WriteLine("Добро пожаловать в вас собственный ежедневник! \n" +
                          "Вот задачи на сегодня:");

        foreach (var ind in items!)
        {
            if (ind.Deadline == DateTime.Today && ind.Done == false)
                Console.WriteLine($"{ind.Name}\n" +
                                  $"        {ind.Description}" +
                                  "\n");
        }

        while (input != "@q")
        {
            Console.WriteLine("Управление........................................\n" +
                              "Посмотреть все задачи...........................@a\n" +
                              "Показать задачи на сегодня......................@t\n" +
                              "Показать задачи на завтра.......................@m\n" +
                              "Показать задачи на неделю.......................@w\n" +
                              "Показать все не завершённые задачи..............@u\n" +
                              "Показать все завершённые задачи.................@f\n" +
                              "Создать новую задачу............................@n\n" +
                              "Редактировать существующую задачу...............@e\n" +
                              "Удалить задачу из списка........................@d\n" +
                              "Выход из програмы...............................@q\n");
            input = Console.ReadLine();
            switch (input)
            {
                case "@a":
                    foreach (var task in items)
                    {
                        Console.WriteLine(task.Name);
                        Console.WriteLine(task.Description);
                        Console.WriteLine(task.Deadline);
                        Console.WriteLine(!task.Done ? "-Завершена" : "-В процессе");
                    }
                    break;
                case "@t":
                    foreach (var task in items)
                    {
                        if (task.Deadline == DateTime.Today)
                        {
                            Console.WriteLine($"{task.Name}\n" +
                                              $"{task.Description}");
                            Console.WriteLine(!task.Done ? "-Завершена" : "-В процессе");
                        }
                    }
                    break;
                case "@m":
                    foreach (var task in items)
                    {
                        if (task.Deadline == DateTime.Today.AddDays(1))
                        {
                            Console.WriteLine($"{task.Name}\n" +
                                              $"{task.Description}");
                            Console.WriteLine(!task.Done ? "-Завершена" : "-В процессе");
                        }
                    }
                    break;
                case "@w":
                    foreach (var task in items)
                    {
                        if (task.Deadline <= DateTime.Today.AddDays(7) && task.Deadline >= DateTime.Today)
                        {
                            Console.WriteLine($"{task.Name}\n" +
                                              $"{task.Description}\n" +
                                              $"{task.Deadline}");
                            Console.WriteLine(!task.Done ? "-Завершена" : "-В процессе");
                        }
                    }
                    break;
                case "@u":
                    foreach (var task in items)
                    {
                        if (task.Done == false)
                            Console.WriteLine($"{task.Name}\n" +
                                              $"{task.Description}\n" +
                                              $"{task.Deadline}");
                    }
                    break;
                case "@f":
                    foreach (var task in items)
                    {
                        if (task.Done)
                            Console.WriteLine($"{task.Name}\n" +
                                              $"{task.Description}\n" +
                                              $"{task.Deadline}");
                    }
                    break;
                case "@n":
                    Console.WriteLine("Введите название новой задачи");
                    var newName = Console.ReadLine();
                    Console.WriteLine("Введите описание новой задачи");
                    var newDesc = Console.ReadLine();
                    Console.WriteLine("Введите дату, до которой нужно выполнить задачу");
                    var newDeadline = DateTime.Parse(Console.ReadLine()!);
                    if (newName != null && newDesc != null)
                    {
                        Task newTask = new Task(newName, newDesc, newDeadline, false);
                        items.Add(newTask);
                    }

                    using (StreamWriter output = new StreamWriter("task.json", false))
                    {
                        Console.WriteLine("Сохранение...");
                        string jsonNewTask = "[";
                        foreach (var task in items)
                        {
                            jsonNewTask += JsonSerializer.Serialize(task) + ",";
                        }
                        jsonNewTask = jsonNewTask.Trim(',');
                        jsonNewTask += "]";
                        output.WriteLine(jsonNewTask);
                    }
                    break;
                case "@e":
                    Console.WriteLine("Введите название задачи, которую хотите модифицировать");
                    foreach (var task in items)
                    {
                        Console.WriteLine(task.Name);
                    }
                    var editName = Console.ReadLine();
                    Console.WriteLine("Введите что вы хотите изменить\n" +
                                      "1 - Название\n" +
                                      "2 - Описание\n" +
                                      "3 - Дату\n" +
                                      "4 - Статус\n");
                    var editVar = Console.ReadLine();
                    Console.WriteLine("Введите новое значение");
                    var editedValue = Console.ReadLine();
                    foreach (var t in items)
                    {
                        if (t.Name == editName)
                        {
                            switch (editVar)
                            {
                                case "1":
                                    if (editedValue != null) t.Name = editedValue;
                                    break;
                                case "2":
                                    if (editedValue != null) t.Description = editedValue;
                                    break;
                                case "3":
                                    if (editedValue != null) t.Deadline = DateTime.Parse(editedValue);
                                    break;
                                case "4":
                                    t.Done = Convert.ToBoolean(editedValue);
                                    break;
                            }
                        }
                    }
                    using (StreamWriter output = new StreamWriter("task.json", false))
                    {
                        Console.WriteLine("Сохранение...");
                        string jsonNewTask = "[";
                        foreach (var task in items)
                        {
                            jsonNewTask += JsonSerializer.Serialize(task) + ",";
                        }
                        jsonNewTask = jsonNewTask.Trim(',');
                        jsonNewTask += "]";
                        output.WriteLine(jsonNewTask);
                    }
                    break;
                case "@r":
                    Console.WriteLine("Введите название задачи, которую хотите удалить");
                    foreach (var task in items)
                    {
                        Console.WriteLine(task.Name);
                    }
                    string? toRemove = Console.ReadLine();
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Name == toRemove)
                        {
                            items.Remove(items[i]);
                        }
                    }
                    using (StreamWriter output = new StreamWriter("task.json", false))
                    {
                        Console.WriteLine("Сохранение...");
                        string jsonNewTask = "[";
                        foreach (var task in items)
                        {
                            jsonNewTask += JsonSerializer.Serialize(task) + ",";
                        }
                        jsonNewTask = jsonNewTask.Trim(',');
                        jsonNewTask += "]";
                        output.WriteLine(jsonNewTask);
                    }
                    break;
                case "@q":
                    break;
                default:
                    Console.WriteLine("Неправильно введена команда");
                    break;
            }
        }
        Console.WriteLine("До скорых встреч!");
    }
}

