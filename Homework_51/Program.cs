using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Jail jail = new Jail();
        Menu prisonersMenu = new Menu(jail);

        prisonersMenu.Work();
    }
}

class Menu
{
    private readonly Jail _jail;

    public Menu(Jail jail)
    {
        _jail = jail;
    }

    public void Work()
    {
        ShowPrisoners();

        Console.WriteLine("\nВ нашей великой стране Арстоцка произошла амнистия!\n");

        _jail.ReleasePrisoners("Антиправительственное");

        ShowPrisoners();
    }

    private void ShowPrisoners()
    {
        Console.WriteLine("Список заключенных:\n");

        foreach (Prisoner prisoner in _jail.GetPrisoners())
        {
            Console.WriteLine($"{prisoner.FullName} - {prisoner.Crime}");
        }
    }
}

class Jail
{
    private List<Prisoner> _prisoners = new List<Prisoner>();

    public Jail()
    {
        _prisoners.Add(new Prisoner("Иванов Илья Алексеевич", "Уголовное"));
        _prisoners.Add(new Prisoner("Коновалов Роберт Константинович", "Административное"));
        _prisoners.Add(new Prisoner("Мельников Роман Даниилович", "Антиправительственное"));
        _prisoners.Add(new Prisoner("Богданов Святослав Фёдорович", "Административное"));
        _prisoners.Add(new Prisoner("Дементьев Ярослав Адамович", "Уголовное"));
        _prisoners.Add(new Prisoner("Исаков Даниил Львович", "Антиправительственное"));
    }

    public IReadOnlyList<Prisoner> GetPrisoners()
    {
        return _prisoners.AsReadOnly();
    }

    public void ReleasePrisoners(string amnestyCrime)
    {
        _prisoners = _prisoners.Where(prisoner => prisoner.Crime != amnestyCrime).ToList();
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