namespace FullStack_BrianBuenJA.Services
{
    public class GreetingService:IGreetingService
    {
        public string GetGreeting() =>
            $"Welcome to the Pag-IBIG Fund Full-Stack .NET Development! ({DateTime.Now:t})";
    }
}
