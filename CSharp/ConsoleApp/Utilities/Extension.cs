using System.Text;

namespace ConsoleApp.Utilities
{
    internal static class Extension
    {
        private static void AppendLineWithPrefix(this StringBuilder stringBuilder, string prefix, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                stringBuilder.AppendLine($"{prefix}: {value}");
            }
        }
    }
}