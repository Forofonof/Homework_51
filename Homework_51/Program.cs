using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Jail jail = new Jail();
        ViewPrisoners viewPrisoners = new ViewPrisoners(jail);
        FreePrisoners freePrisoners = new FreePrisoners(jail);

        viewPrisoners.Work();
        freePrisoners.Work();
        viewPrisoners.Work();
    }
}

class ViewPrisoners
{
    private readonly Jail _jail;
    private readonly List<Prisoner> _prisoners;

    public ViewPrisoners(Jail jail)
    {
        _jail = jail;
        _prisoners = _jail.GetPrisoners();
    }

    public void Work()
    {
        ShowPrisoners();
    }

    public void ShowPrisoners()
    {
        Console.WriteLine("Список заключенных:\n");

        foreach (Prisoner prisoner in _prisoners)
        {
            Console.WriteLine($"{prisoner.FullName} - {prisoner.Crime}");
        }
    }
}

class FreePrisoners
{
    private readonly Jail _jail;

    public FreePrisoners(Jail jail)
    {
        _jail = jail;
    }

    public void Work()
    {
        Console.WriteLine("\nВ нашей великой стране Арстоцка произошла амнистия!\n");

        ReleasePrisoners();
    }

    private void ReleasePrisoners()
    {
        string amnestyCrime = "Антиправительственное";
        _jail.ReleasePrisonersByCrime(amnestyCrime);
    }
}

class Jail
{
    private readonly List<Prisoner> _prisoners = new List<Prisoner>();

    public Jail()
    {
        _prisoners.Add(new Prisoner("Иванов Илья Алексеевич", "Уголовное"));
        _prisoners.Add(new Prisoner("Коновалов Роберт Константинович", "Административное"));
        _prisoners.Add(new Prisoner("Мельников Роман Даниилович", "Антиправительственное"));
        _prisoners.Add(new Prisoner("Богданов Святослав Фёдорович", "Административное"));
        _prisoners.Add(new Prisoner("Дементьев Ярослав Адамович", "Уголовное"));
        _prisoners.Add(new Prisoner("Исаков Даниил Львович", "Антиправительственное"));
    }

    public List<Prisoner> GetPrisoners()
    {
        return _prisoners;
    }

    public void ReleasePrisonersByCrime(string crime)
    {
        _prisoners.RemoveAll(prisoner => prisoner.Crime == crime);
    }
}

class Prisoner
{
    public Prisoner(string fullName, string crime)
    {
        FullName = fullName;
        Crime = crime;
    }

    public string FullName { get; private set; }

    public string Crime { get; private set; } 
}