
namespace Learning_Console{
    static class Program
    {

        private static readonly string[] _exercises =
        {
            "Classes 1",
            "Classes 2"
        };

        static void Main(string[] args)
        {
            for (int i=0; i<_exercises.Length; i++) {
                Console.WriteLine($"{i+1}: " + _exercises[i]);
            }
            Console.WriteLine("X - Exit");

            bool isExit = false;
            while (!isExit)
            {
                Console.Write("Choose exercise ");
                string? input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                        Classes_1.Main.Start();
                        break;
                    case "2":
                        Classes_2.Main.Start();
                        break;
                    case "x":
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid response");
                        break;
                }
            }
            
        }
    }
}