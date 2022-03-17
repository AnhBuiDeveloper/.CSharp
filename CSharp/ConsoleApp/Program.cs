// See https://aka.ms/new-console-template for more information
using ConsoleApp.OOP.Inheritance;

Console.WriteLine("Hello, World!");

List<IDeveloper> _Developers = new List<IDeveloper>
{
    new Developer { Name = "A", Age = 20, ProgramingLanguage = "C#" },
    new Developer { Name = "B", Age = 30, ProgramingLanguage = "Java" },
};

List<IHuman> _Human = _Developers;