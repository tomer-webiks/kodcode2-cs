using MossadSimulationDemoAPIServer.Services;
using System.Text.RegularExpressions;

namespace MossadSimulationDemoAPIServer.Middlewares
{
    public class GridLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IGridService _gridService;
        private static readonly object consoleLock = new object();

        // The routes that will use this middleware
        private static readonly Regex[] _routePatterns = new[]
        {
            new Regex(@"^/agents/\d+/pin$", RegexOptions.Compiled),
            new Regex(@"^/agents/\d+/move$", RegexOptions.Compiled),
            new Regex(@"^/targets/\d+/pin$", RegexOptions.Compiled),
            new Regex(@"^/targets/\d+/move$", RegexOptions.Compiled),
            new Regex(@"^/missions/update$", RegexOptions.Compiled)
        };

        public GridLoggerMiddleware(RequestDelegate next, IGridService gridService)
        {
            _next = next;
            _gridService = gridService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Use the 'next' delegate before the middleware code, to make sure our code
            // is the last to be used
            await _next(context);

            string? path = context.Request.Path.Value;

            if (path != null && _routePatterns.Where(p => p.IsMatch(path)).Any())
            {
                string matrixRepresentation = GenerateMatrixRepresentation();
                lock (consoleLock)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine($"Current Matrix State:\n{matrixRepresentation}");
                }
            }
        }

        private string GenerateMatrixRepresentation()
        {
            char[,] matrix = new char[_gridService.MaxMatrixX, _gridService.MaxMatrixY];

            // Initialize matrix with empty spaces
            for (int i = 0; i < _gridService.MaxMatrixX; i++)
            {
                for (int j = 0; j < _gridService.MaxMatrixY; j++)
                {
                    matrix[i, j] = '.';
                }
            }

            // Place Agents in the matrix
            foreach (var agent in _gridService.Agents)
            {
                matrix[agent.Location.Y, agent.Location.X] = 'A';
                Console.WriteLine(agent.Location.Y + agent.Location.X);
            }

            // Place Targets in the matrix
            foreach (var target in _gridService.Targets)
            {
                matrix[target.Location.Y, target.Location.X] = 'T';
            }

            // Create the matrix
            var sb = new System.Text.StringBuilder();

            // Create the column headers
            sb.Append("".PadRight(3));
            for (int j = 0; j < _gridService.MaxMatrixY; j++)
            {
                sb.Append(j.ToString().PadRight(3));
            }
            sb.AppendLine();

            // Create the rows
            for (int i = 0; i < _gridService.MaxMatrixX; i++)
            {
                sb.Append(i.ToString().PadRight(3));

                for (int j = 0; j < _gridService.MaxMatrixY; j++)
                {
                    sb.Append(matrix[i, j].ToString().PadRight(3));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
