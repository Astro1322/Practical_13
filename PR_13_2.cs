using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        CheckingAccount checking = new CheckingAccount("CHK001", "Иван Иванов", 1000, 500);
        SavingsAccount savings = new SavingsAccount("SAV001", "Петр Петров", 2000, 5.5);
        CreditAccount credit = new CreditAccount("CRD001", "Сидор Сидоров", 10000, new DateTime(2026, 12, 31), 0); // вот ещё дата тайм

        Console.WriteLine(checking);
        checking.Withdraw(1200);
        Console.WriteLine();

        Console.WriteLine(savings);
        savings.AddInterest();
        Console.WriteLine();

        Console.WriteLine(credit);
        credit.Withdraw(3000);
        credit.Deposit(500);
        Console.WriteLine();
    }
}
public abstract class BankAccount
{
    public string AccountNumber { get; protected set; }
    public decimal Balance { get; protected set; }
    public string Owner { get; protected set; }

    protected BankAccount(string accountNumber, string owner, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = initialBalance;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Внесено: {amount}. Новый баланс: {Balance}");
        }
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Снято: {amount}. Новый баланс: {Balance}");
        }
        else
        {
            Console.WriteLine("Недостаточно средств или неверная сумма.");
        }
    }
}

public class CheckingAccount : BankAccount
{
    public decimal OverdraftLimit { get; set; }

    public CheckingAccount(string accountNumber, string owner, decimal initialBalance = 0, decimal overdraftLimit = 0)
        : base(accountNumber, owner, initialBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Withdraw(decimal amount)
    {
        if (amount > 0 && Balance + OverdraftLimit >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Снято: {amount}. Новый баланс: {Balance}");
        }
        else
        {
            Console.WriteLine("Превышен лимит овердрафта или неверная сумма.");
        }
    }
}

public class SavingsAccount : BankAccount
{
    public double InterestRate { get; set; }

    public SavingsAccount(string accountNumber, string owner, decimal initialBalance = 0, double interestRate = 0)
        : base(accountNumber, owner, initialBalance)
    {
        InterestRate = interestRate;
    }

    public void AddInterest()
    {
        var interest = Balance * (decimal)(InterestRate / 100);
        Balance += interest;
        Console.WriteLine($"Начислены проценты: {interest}. Новый баланс: {Balance}");
    }
}

public class CreditAccount : BankAccount
{
    public decimal CreditLimit { get; set; }
    public DateTime DueDate { get; set; } // Эту штуку мы не изучали ещё

    public CreditAccount(string accountNumber, string owner, decimal creditLimit, DateTime dueDate, decimal initialBalance = 0)
        : base(accountNumber, owner, initialBalance)
    {
        CreditLimit = creditLimit;
        DueDate = dueDate; // Эту штуку мы не изучали ещё
    }

    public override void Withdraw(decimal amount)
    {
        if (amount > 0 && (CreditLimit - Balance) >= amount)
        {
            Balance += amount; 
            Console.WriteLine($"Выдано (в долг): {amount}. Новый баланс (долг): {Balance}");
        }
        else
        {
            Console.WriteLine("Превышен кредитный лимит или неверная сумма.");
        }
    }

    public override void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance -= amount;
            if (Balance < 0) Balance = 0; // нельзя чтоб был отрицательный долг
            Console.WriteLine($"Погашено: {amount}. Остаток долга: {Balance}");
        }
    }
}