namespace ConsoleApp.Utilities
{
    internal class TryParse
    {
        internal void TryParseNull()
        {
            string s = null;

            bool result = Guid.TryParse(s, out Guid _OrganisationalUnit_UID);
            Console.WriteLine(result);
        }
    }
}