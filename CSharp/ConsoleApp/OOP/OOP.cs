using ConsoleApp.OOP.Inheritance;

namespace ConsoleApp.OOP
{
    internal class OOP
    {
        internal void TestAAA()
        {
            List<IDeveloper> _Developers = new()
            {
                new Developer { Name = "A", Age = 20, ProgramingLanguage = "C#" },
                new Developer { Name = "B", Age = 30, ProgramingLanguage = "Java" },
            };

            // These wont work
            //List<IHuman> _Humans = _Developers;
            //List<IHuman> _Humans = new List<IHuman> { _Developers };

            List<IHuman> _Humans = new();
            _Humans.AddRange(_Developers);
        }
    }
}
