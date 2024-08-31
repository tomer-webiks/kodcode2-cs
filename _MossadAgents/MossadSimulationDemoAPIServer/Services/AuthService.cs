using MossadSimulationDemoAPIServer.ViewModels;

namespace MossadSimulationDemoAPIServer.Services
{
    public enum AUTH_TOKEN_TYPE
    {
        NONE,
        BODY,
        HEADER
    }

    public interface IAuthService
    {
        public bool ValidateToken(string token);
        public string Login(string clientId);
        public Dictionary<string, string> ClientTokens { get; }
    }

    public class AuthService : IAuthService
    {

        public Dictionary<string, string> ClientTokens { get; } = new Dictionary<string, string>();
        private (string, string) _allowedClientIds = ("SimulationServer", "MVCServer");

        public bool ValidateToken(string token)
        {
            // Iterate over the dictionary to find a matching token
            foreach (var entry in ClientTokens)
            {
                // If the token matches, check if the client ID is one of the allowed client IDs
                if (entry.Value == token && (entry.Key == _allowedClientIds.Item1 || entry.Key == _allowedClientIds.Item2))
                {
                    return true; // Token is valid and the client ID is allowed
                }
            }

            // If no match was found or the client ID is not allowed, return false
            return false;
        }

        public string Login(string clientId)
        {
            if (_allowedClientIds.Item1 == clientId || _allowedClientIds.Item2 == clientId)
            {
                ClientTokens[clientId] = Guid.NewGuid().ToString();
                return ClientTokens[clientId];
            } else
            {
                return null;
            }
        }
    }
}
