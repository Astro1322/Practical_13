using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {

        Manager manager = new Manager("Иван Иванов", 50000, "2020.5.15", 8);
        Developer developer = new Developer("Петр Петров", 40000, "2022.3.10", "C#");

        manager.PrintInfo();
        manager.runAMeeting();

        Console.WriteLine("");

        developer.PrintInfo();
        developer.writeCode();

        }
    }
    
    internal class Employee
{
        public string Name {  get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public string DateOfHire { get; set; }

        public Employee(string name, string position, int salary, string dateOfHire) 
        {
            Name = name;
            Position = position;
            Salary = salary;
            DateOfHire = dateOfHire;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Должность: {Position}");
            Console.WriteLine($"Зарплата: {Salary}");
            Console.WriteLine($"Дата приема: {DateOfHire}");
        }
}

    internal class Manager : Employee
    {
        public int TeamSize { get; set; }

        public Manager(string name, int salary, string dateOfHire, int teamSize) : base(name, "Manager", salary, dateOfHire)
        {
            TeamSize = teamSize;
        }

        public void runAMeeting()
        {
           Console.WriteLine("Manager: Провожу собрание");
        }

        public override void PrintInfo()
        { 
            base.PrintInfo();
            Console.WriteLine($"Размер команды: {TeamSize}");
        }
    }

    internal class Developer : Employee
    {
        public string ProgrammingLanguage { get; set; }

        public Developer(string name, int salary, string dateOfHire, string programmingLanguage) : base(name, "Developer", salary, dateOfHire)
        {
            ProgrammingLanguage = programmingLanguage;
        }

        public void writeCode()
        {
            Console.WriteLine("Developer: Пишу код");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Язык программирования: {ProgrammingLanguage}");
        }
}

    internal class Director : Employee
    {
        public string Department { get; set; }

        public Director(string name, int salary, string dateOfHire, string department) : base(name, "Director", salary, dateOfHire)
        {
            Department = department;
        }

        public void approveBudget()
        {
            Console.WriteLine("Director: Утверждаю бюджет");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Отдел: {Department}");
        }
}

