using System.Text.Json;

namespace _W10_BinaryTree
{ 
    class Program
    {
        static void Main(string[] args)
        {

            // Read JSON from file and deserialize it
            Console.WriteLine("\n-- 1 -- Load the Tree");
            string currentDirectory = Directory.GetCurrentDirectory();
            string jsonFilePath = Path.Combine(currentDirectory, @"..\..\..\Data", "defenceStrategies.json");
            DefenceStrategiesBST tree = DefenceStrategiesBST.LoadFromJSON(jsonFilePath);
            Thread.Sleep(4000);

            // Print the tree structure with left/right distinctions
            Console.WriteLine("\n-- 2 -- Print the Tree");
            tree.PrintTree();
            Thread.Sleep(4000);

            Console.WriteLine("\n-- 3 -- Balance and print the Tree");
            tree.BalanceTree();
            tree.PrintTree();
            Thread.Sleep(4000);

            Console.WriteLine("\n-- 4 -- Printing the Tree In-Order, as a list");
            tree.PrintTreeAsList();
            Thread.Sleep(4000);

            Console.WriteLine("\n-- 5 -- Save the balanced tree to JSON");
            string jsonBalancedFilePath = Path.Combine(currentDirectory, @"..\..\..\Data", "defenceStrategiesBalanced.json");
            tree.SaveToJSON(jsonBalancedFilePath);
            Thread.Sleep(4000);

            Console.WriteLine("\n-- 6 / 3 -- Import Threats from JSON");
            string jsonThreatsFilePath = Path.Combine(currentDirectory, @"..\..\..\Data", "threats.json");
            List<Threat> threats = Threat.LoadFromJSON(jsonThreatsFilePath);
            Thread.Sleep(4000);

            Console.WriteLine("\n-- 7 / 4 -- Calculate severity for each Threat");
            foreach (Threat threat in threats)
            {
                Console.WriteLine($"{threat.CalculateSeverity()} -- {threat.ToString()}");
            }
            Thread.Sleep(4000);

            Console.WriteLine("\n-- 8 / 5 -- Run defence for every attack");
            foreach (Threat threat in threats)
            {
                tree.HandleAttack(threat.CalculateSeverity());
            }
            Thread.Sleep(4000);
        }
    }
}