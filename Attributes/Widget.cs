namespace Attributes
{
    [Help("https://docs.microsoftcom/dotnet/csharp/tour-of-csharp/features")]
    public class Widget
    {
        [Help("https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/features",
        Topic = "Display")]
        public void Display(string text) {}
    }
}