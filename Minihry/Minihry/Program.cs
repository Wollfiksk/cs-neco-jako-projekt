namespace Minihry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] options = { "kámen", "nůžky", "papír" };
            Random random = new Random();

            while (true)
            {
                Console.WriteLine("Vyberte kámen, nůžky, nebo papír (nebo napište 'konec' pro ukončení):");
                string userChoice = Console.ReadLine().ToLower();

                if (userChoice == "konec")
                {
                    break;
                }

                if (!Array.Exists(options, element => element == userChoice))
                {
                    Console.WriteLine("Neplatná volba, zkuste to znovu.");
                    continue;
                }

                int computerIndex = random.Next(0, 3);
                string computerChoice = options[computerIndex];

                Console.WriteLine($"Počítač zvolil: {computerChoice}");

                if (userChoice == computerChoice)
                {
                    Console.WriteLine("Remíza!");
                }
                else if ((userChoice == "kámen" && computerChoice == "nůžky") ||
                         (userChoice == "nůžky" && computerChoice == "papír") ||
                         (userChoice == "papír" && computerChoice == "kámen"))
                {
                    Console.WriteLine("Vyhráli jste!");
                }
                else
                {
                    Console.WriteLine("Prohráli jste.");
                }
            }
        }
    }
}
