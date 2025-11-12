using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Mammal animals1 = new Mammal("Лев", 5, "Саванна", "Мясо", "Густой", 110);
        Bird animals2 = new Bird("Орёл", 3, "Горы", "Мясо", 2.3, "На скалах");
        Reptile animals3 = new Reptile("Крокодил", 15, "Болото", "Мясо", "Костяная чешуя", 30.0);
        Fish animals4 = new Fish("Акула", 8, "Океан", "Рыба", "Плакоидная", 200);

        animals1.DisplayInfo();
        Console.WriteLine();

        animals2.DisplayInfo();
        Console.WriteLine();

        animals3.DisplayInfo();
        Console.WriteLine();

        animals4.DisplayInfo();
        Console.WriteLine();
    }
}

public abstract class Animal
{
    public string Species { get; set; }
    public int Age { get; set; }
    public string Habitat { get; set; }
    public string Diet { get; set; }

    protected Animal(string species, int age, string habitat, string diet)
    {
        Species = species;
        Age = age;
        Habitat = habitat;
        Diet = diet;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Вид: {Species}, Возраст: {Age} лет, Среда обитания: {Habitat}, Рацион: {Diet}");
    }
}

public class Mammal : Animal
{
    public string FurType { get; set; }
    public int GestationPeriod { get; set; }

    public Mammal(string species, int age, string habitat, string diet, string furType, int gestationPeriod)
        : base(species, age, habitat, diet)
    {
        FurType = furType;
        GestationPeriod = gestationPeriod;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тип меха: {FurType}, Продолжительность беременности: {GestationPeriod} дней");
    }
}

public class Bird : Animal
{
    public double WingSpan { get; set; } 
    public string NestingType { get; set; }

    public Bird(string species, int age, string habitat, string diet, double wingSpan, string nestingType)
        : base(species, age, habitat, diet)
    {
        WingSpan = wingSpan;
        NestingType = nestingType;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Размах крыльев: {WingSpan} м, Тип гнездования: {NestingType}");
    }
}

public class Reptile : Animal
{
    public string SkinType { get; set; }
    public double PreferredTemperature { get; set; }

    public Reptile(string species, int age, string habitat, string diet, string skinType, double preferredTemperature)
        : base(species, age, habitat, diet)
    {
        SkinType = skinType;
        PreferredTemperature = preferredTemperature;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тип кожи: {SkinType}, Предпочтительная температура: {PreferredTemperature}°C");
    }
}

public class Fish : Animal
{
    public string ScaleType { get; set; }
    public int PreferredDepth { get; set; }

    public Fish(string species, int age, string habitat, string diet, string scaleType, int preferredDepth)
        : base(species, age, habitat, diet)
    {
        ScaleType = scaleType;
        PreferredDepth = preferredDepth;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Тип чешуи: {ScaleType}, Глубина обитания: {PreferredDepth} м");
    }
}
