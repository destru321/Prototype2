using System;

public interface IPrototype<T>
{
    T Clone();
}

public class Project : IPrototype<Project>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }

    public Project Clone()
    {
        return new Project
        {
            Name = this.Name,
            Description = this.Description,
            Date = this.Date
        };
    }

    public void Display()
    {
        Console.WriteLine($"Name - {Name}");
        Console.WriteLine($"Description - {Description}");
        Console.WriteLine($"Start Date - {Date}");
    }
}

public class ProjectPrototype : IPrototype<Project>
{
    private Project project;

    public ProjectPrototype(Project project)
    {
        this.project = project;
    }

    public Project Clone()
    {
        return project.Clone();
    }
}

class Program
{
    static void Main()
    {
        Project Project = new Project { Name = "lorem ipsum", Description = "lorem ipsum", Date = DateTime.Now };

        ProjectPrototype projectPrototype = new ProjectPrototype(Project);
        Project ProjectClone = projectPrototype.Clone();

        Console.WriteLine("Original project:");
        Project.Display();

        Console.WriteLine("Clone project:");
        ProjectClone.Display();
    }
}

