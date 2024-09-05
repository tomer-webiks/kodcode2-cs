using System.Text.Json;

namespace _W10_BinaryTree
{
	public class DefenceStrategiesBST
	{
		private enum TRAVERSAL_TYPE
		{
			PRE_ORDER,
			IN_ORDER,
			POST_ORDER
		}

		private DefenceStrategyNode Root { get; set; }

		public DefenceStrategiesBST()
		{
			Root = null;
		}

		// Insert a new node into the tree
		private void Insert(DefenceStrategyNode newNode)
		{
			Root = InsertRec(Root, newNode);
		}

		private DefenceStrategyNode InsertRec(DefenceStrategyNode root, DefenceStrategyNode newNode)
		{
			if (root == null)
			{
				return newNode;
			}

			if (newNode.MinSeverity < root.MinSeverity)
			{
				root.Left = InsertRec(root.Left, newNode);
			}
			else if (newNode.MinSeverity > root.MinSeverity)
			{
				root.Right = InsertRec(root.Right, newNode);
			}

			return root;
		}

		// PRE-ORDER traversal
		// -- Execute Defences based on severity
		public void HandleAttack(int severity)
		{
            // Handle below minimum severity
            if (Root == null || severity < GetMinSeverity(Root))
            {
                Console.WriteLine($"Severity {severity} is below the minimum defined range. Attack is ignored.");
                return;
            }

            // Handle above maximum severity
            if (severity > GetMaxSeverity(Root))
            {
                Console.WriteLine($"Severity {severity} is above the maximum defined range. Brace for impact!");
                return;
            }

            HandleAttackRec(Root, severity);
		}

        private void HandleAttackRec(DefenceStrategyNode node, int severity)
		{
			if (node != null)
			{
				if (node.InRange(severity))
				{
					Console.Write($"Executing defenses for severity {severity}: ");
					for (int i=0; i<node.Defenses.Count; i++)
					{
						if (i > 0)
						{
							Console.Write(", ");
						}
						Console.Write(node.Defenses[i]);
						Thread.Sleep(2000);
					}
					Console.WriteLine();

				}
                HandleAttackRec(node.Left, severity);
                HandleAttackRec(node.Right, severity);
			}
        }

        // Helper method to get the minimum severity in the tree
        private int GetMinSeverity(DefenceStrategyNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.MinSeverity;
        }

        // Helper method to get the maximum severity in the tree
        private int GetMaxSeverity(DefenceStrategyNode node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }
            return node.MaxSeverity;
        }

        // PRE-ORDER traversal
        // -- Balance tree
        public void BalanceTree()
		{
			List<DefenceStrategyNode> nodes = ToList();
			Root = BalanceTreeRec(nodes, 0, nodes.Count - 1);
		}

		private DefenceStrategyNode BalanceTreeRec(List<DefenceStrategyNode> nodes, int start, int end)
		{
			if (start > end)
			{
				return null;
			}

			int mid = (start + end) / 2;
			DefenceStrategyNode node = nodes[mid];

			node.Left = BalanceTreeRec(nodes, start, mid - 1);
			node.Right = BalanceTreeRec(nodes, mid + 1, end);

			return node;
		}

		// PRE-ORDER
		// -- Print Tree Nodes
		public void PrintTree()
		{
			PrintTreeRec(Root, "", true, "Root");
		}

		private void PrintTreeRec(DefenceStrategyNode node, string indent, bool last, string position)
		{
			if (node != null)
			{
				Console.Write(indent);
				if (last)
				{
					Console.Write("└──");
					indent += "   ";
				}
				else
				{
					Console.Write("├──");
					indent += "|  ";
				}
				Console.WriteLine($"{position}: [{node.MinSeverity}-{node.MaxSeverity}] Defenses: {string.Join(", ", node.Defenses)}");

				PrintTreeRec(node.Left, indent, false, "Left Child");
				PrintTreeRec(node.Right, indent, true, "Right Child");
			}
		}

        // IN-ORDER traversal
        // -- Convert tree to a List
        public void PrintTreeAsList()
        {
            PrintTreeAsListRec(Root);
        }

        private void PrintTreeAsListRec(DefenceStrategyNode root)
        {
            if (root != null)
            {
                PrintTreeAsListRec(root.Left);
                Console.WriteLine($"Severity Range: {root.MinSeverity}-{root.MaxSeverity}, Defenses: {string.Join(", ", root.Defenses)}");
                PrintTreeAsListRec(root.Right);
            }
        }

        // Collect all nodes in the tree using in-order traversal
        private List<DefenceStrategyNode> ToList(int traversalType = (int)TRAVERSAL_TYPE.IN_ORDER)
		{
			List<DefenceStrategyNode> nodes = new List<DefenceStrategyNode>();
			ToListRec(Root, nodes, traversalType);
			return nodes;
        }

        private void ToListRec(DefenceStrategyNode node, List<DefenceStrategyNode> nodes, int traversalType)
        {
            if (node != null)
            {
				if (traversalType == (int)TRAVERSAL_TYPE.IN_ORDER)
				{
                    ToListRec(node.Left, nodes, traversalType);
                    nodes.Add(node); // Add the current node to the list
                } else if (traversalType == (int)TRAVERSAL_TYPE.PRE_ORDER)
                {
                    nodes.Add(node); // Add the current node to the list
                    ToListRec(node.Left, nodes, traversalType);
                }
                ToListRec(node.Right, nodes, traversalType);
            }
        }

        // Collect all nodes in the tree using in-order traversal and map them to SerializedDefenceStrategyNode
        private void ToSimplifiedListRec(DefenceStrategyNode node, List<object> simplifiedNodes)
        {
            if (node != null)
            {// Map the node to the simplified version (without Left and Right)
                var simplifiedNode = new
                {
                    MinSeverity = node.MinSeverity,
                    MaxSeverity = node.MaxSeverity,
                    Defenses = node.Defenses
                };
                simplifiedNodes.Add(simplifiedNode);

                ToSimplifiedListRec(node.Left, simplifiedNodes);
                ToSimplifiedListRec(node.Right, simplifiedNodes);
            }
        }

        // Save the tree to JSON without Left and Right references
        public void SaveToJSON(string filePath)
        {
            List<object> simplifiedNodes = new List<object>();
            ToSimplifiedListRec(Root, simplifiedNodes);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(simplifiedNodes, options);
            File.WriteAllText(filePath, jsonString);
        }

        // Method to load and deserialize the JSON file
        public static DefenceStrategiesBST LoadFromJSON(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var nodes = JsonSerializer.Deserialize<List<DefenceStrategyNode>>(jsonString);

                // Create a new binary search tree
                DefenceStrategiesBST tree = new DefenceStrategiesBST();

                // Insert each node into the tree
                foreach (var node in nodes)
                {
                    tree.Insert(node);
                }

                return tree;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
				return null;
            }
        }

        private class DefenceStrategyNode
        {
            public int MinSeverity { get; set; }
            public int MaxSeverity { get; set; }
            public List<string> Defenses { get; set; }
            public DefenceStrategyNode Left { get; set; }
            public DefenceStrategyNode Right { get; set; }

            public DefenceStrategyNode(int minSeverity, int maxSeverity, List<string> defenses)
            {
                MinSeverity = minSeverity;
                MaxSeverity = maxSeverity;
                Defenses = defenses;
                Left = null;
                Right = null;
            }

            public bool InRange(int severity)
            {
                return severity >= MinSeverity && severity <= MaxSeverity;
            }
        }
    }
}
