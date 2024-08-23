using MossadSimulationServer.Services;

namespace MossadSimulationServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Extract arguments
            string apiServerUrl = GetArgumentValue(args, "--apiServerUrl");
            apiServerUrl = apiServerUrl ?? "http://localhost:5149/";
            Console.WriteLine($"API Server URL: {apiServerUrl}");

            string syncDelay = GetArgumentValue(args, "--syncDelay");
            string moveDelay = GetArgumentValue(args, "--moveDelay");
            string maxMoves = GetArgumentValue(args, "--maxMoves");
            string maxMatrixX = GetArgumentValue(args, "--maxMatrixX");
            string maxMatrixY = GetArgumentValue(args, "--maxMatrixY");

            Dictionary<string, int> dict = new Dictionary<string, int>();

            if (syncDelay != null) dict["syncDelay"] = int.Parse(syncDelay);
            if (moveDelay != null) dict["moveDelay"] = int.Parse(moveDelay);
            if (maxMoves != null) dict["maxMoves"] = int.Parse(maxMoves);
            if (maxMatrixX != null) dict["maxMatrixX"] = int.Parse(maxMatrixX);
            if (maxMatrixY != null) dict["maxMatrixY"] = int.Parse(maxMatrixY);

            // Create an instance of HttpClient
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiServerUrl);

            // Create a SimulationServer
            SimulationServer server = new SimulationServer(client, dict);
            server.Start();
        }

        static string GetArgumentValue(string[] args, string key)
        {
            foreach (string arg in args)
            {
                if (arg.StartsWith(key))
                {
                    return arg.Split('=')[1];
                }
            }
            return null; // or a default value
        }
    }
}