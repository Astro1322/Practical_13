using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

public abstract class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public bool IsAvailable { get; set; }

    protected LibraryItem(string title, string author, int year, bool isAvailable = true)
    {
        Title = title;
        Author = author;
        Year = year;
        IsAvailable = isAvailable;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Название: {Title}, Автор: {Author}, Год: {Year}, Доступен: {(IsAvailable ? "Да" : "Нет")}");
    }

    public virtual void CheckOut()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
            Console.WriteLine($"'{Title}' выдан.");
        }
        else
        {
            Console.WriteLine($"'{Title}' уже выдан.");
        }
    }

    public virtual void Return()
    {
        if (!IsAvailable)
        {
            IsAvailable = true;
            Console.WriteLine($"'{Title}' возвращен.");
        }
        else
        {
            Console.WriteLine($"'{Title}' уже возвращен.");
        }
    }
}

public class Book : LibraryItem
{
    public int PageCount { get; set; }
    public string ISBN { get; set; }

    public Book(string title, string author, int year, int pageCount, string isbn, bool isAvailable = true)
        : base(title, author, year, isAvailable)
    {
        PageCount = pageCount;
        ISBN = isbn;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Страниц: {PageCount}, ISBN: {ISBN}");
    }
}

public class Magazine : LibraryItem
{
    public int IssueNumber { get; set; }
    public string Frequency { get; set; } 

    public Magazine(string title, string author, int year, int issueNumber, string frequency, bool isAvailable = true)
        : base(title, author, year, isAvailable)
    {
        IssueNumber = issueNumber;
        Frequency = frequency;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Выпуск: {IssueNumber}, Периодичность: {Frequency}");
    }
}

public class DVD : LibraryItem
{
    public int Duration { get; set; } 
    public string Rating { get; set; }

    public DVD(string title, string author, int year, int duration, string rating, bool isAvailable = true)
        : base(title, author, year, isAvailable)
    {
        Duration = duration;
        Rating = rating;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Длительность: {Duration} мин., Рейтинг: {Rating}");
    }
}

public class Audiobook : LibraryItem
{
    public int Duration { get; set; } 
    public string Narrator { get; set; }

    public Audiobook(string title, string author, int year, int duration, string narrator, bool isAvailable = true)
        : base(title, author, year, isAvailable)
    {
        Duration = duration;
        Narrator = narrator;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Длительность: {Duration} мин., Диктор: {Narrator}");
    }
}
