using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        VideoCourse courses1 = new VideoCourse("Основы C#", "Изучите основы программирования", "Алексей Петров", 2999, 30, 180);
        TextCourse courses2 = new TextCourse("История искусства", "Путешествие по эпохам", "Мария Соколова", 1499, 12, 25000);
        InteractiveCourse courses3 = new InteractiveCourse("JavaScript для начинающих", "Интерактивный курс", "Иван Смирнов", 3999, 50, "Auto-Grader");

        courses1.DisplayInfo();
        Console.WriteLine();

        courses2.DisplayInfo();
        Console.WriteLine();

        courses3.DisplayInfo();
        Console.WriteLine();
    }
}

public abstract class Course
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }

    protected Course(string name, string description, string author, decimal price)
    {
        Name = name;
        Description = description;
        Author = author;
        Price = price;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Курс: {Name}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Автор: {Author}");
        Console.WriteLine($"Цена: {Price:C}");
    }
}

public class VideoCourse : Course
{
    public int VideoCount { get; set; }
    public int TotalDuration { get; set; }

    public VideoCourse(string name, string description, string author, decimal price, int videoCount, int totalDuration)
        : base(name, description, author, price)
    {
        VideoCount = videoCount;
        TotalDuration = totalDuration;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тип: Видеокурс, Видео: {VideoCount}, Общая длительность: {TotalDuration} мин.");
    }
}

public class TextCourse : Course
{
    public int ChapterCount { get; set; }
    public int TotalWords { get; set; }

    public TextCourse(string name, string description, string author, decimal price, int chapterCount, int totalWords)
        : base(name, description, author, price)
    {
        ChapterCount = chapterCount;
        TotalWords = totalWords;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тип: Текстовый курс, Глав: {ChapterCount}, Слов: {TotalWords:N0}");
    }
}

public class InteractiveCourse : Course
{
    public int ExerciseCount { get; set; }
    public string AssessmentSystem { get; set; }

    public InteractiveCourse(string name, string description, string author, decimal price, int exerciseCount, string assessmentSystem)
        : base(name, description, author, price)
    {
        ExerciseCount = exerciseCount;
        AssessmentSystem = assessmentSystem;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тип: Интерактивный курс, Упражнений: {ExerciseCount}, Система проверки: {AssessmentSystem}");
    }
}
