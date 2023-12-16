//#1.7
//Write console application for a diary. User should have ability to add/remove/edit tasks and also see tasks for today/tomorrow/week
//User should have ability to see all tasks, tasks that yet to be done and list of finished tasks. For a task its enough to store just the name, description and a deadline
//All data about tasks should be stored in separate .json file

using System.Collections;
using System.Text.Json;

namespace PrApp1PDA;
public class Task
{
    public string Name;
    public string Description;
    public DateTime Deadline;

    public Task(string name, string description, DateTime deadline)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
class Program
{
    static void Main()
    {
        string text = File.ReadAllText("task.json");
        var items = JsonSerializer.Deserialize<Task>(text);

        Console.WriteLine("Добро пожаловать в вас собственный ежедневник! \n" +
                          "Вот задачи на сегодня:");
        foreach (var ind in items)
        {
            if(ind.)
        }
    }
}

