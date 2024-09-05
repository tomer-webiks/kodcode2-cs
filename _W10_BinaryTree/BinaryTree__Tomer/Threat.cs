using System.Text.Json;

namespace _W10_BinaryTree
{
    public class Threat
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public Threat(string threatType, int volume, int sophistication, string target)
        {
            ThreatType = threatType;
            Volume = volume;
            Sophistication = sophistication;
            Target = target;
        }

        // Calculate severity based on properties
        public int CalculateSeverity()
        {
            int targetValue = Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5
            };

            return (Volume * Sophistication) + targetValue;
        }

        public override string ToString()
        {
            return $"ThreatType: {ThreatType}, Volume: {Volume}, Sophistication: {Sophistication}, Target: {Target}, Severity: {CalculateSeverity()}";
        }

        public static List<Threat> LoadFromJSON(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var threats = JsonSerializer.Deserialize<List<Threat>>(jsonString);

                return threats;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return null;
            }
        }

    }
}