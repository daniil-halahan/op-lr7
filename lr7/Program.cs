using System.Text;

namespace lr8
{
    class Program
    {
        public class GraphColoring
        {
            public int verticesCount;
            private List<int>[] adjacencyList;

            public GraphColoring(int verticesCount)
            {
                this.verticesCount = verticesCount;
                adjacencyList = new List<int>[verticesCount];
                for (int i = 0; i < verticesCount; i++)
                    adjacencyList[i] = new List<int>();
            }
            public void AddEdge(int v1, int v2)
            {
                adjacencyList[v1].Add(v2);
                adjacencyList[v2].Add(v1);
            }
            private bool IsColoreable(int vertex, int[] color, int currentColor)
            {
                foreach (var adj in adjacencyList[vertex])
                {
                    if (color[adj] == currentColor)
                        return false;
                }
                return true;
            }
            public bool GraphColoringMethod(int m, int[] color, int vertex)
            {
                if (vertex == verticesCount)
                    return true;

                for (int c = 1; c <= m; c++)
                {
                    if (IsColoreable(vertex, color, c))
                    {
                        color[vertex] = c;
                        if (GraphColoringMethod(m, color, vertex + 1))
                            return true;
                        color[vertex] = 0;
                    }
                }
                return false;
            }
            public int ChromaticNumber()
            {
                int[] color = new int[verticesCount];
                int m = 1;

                while (!GraphColoringMethod(m, color, 0))
                    m++;

                return m;
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            GraphColoring graph = new GraphColoring(15);

            string[] cities = { "Algiers", "Blida", "Boumerdès", "Tizi Ouzou", "Médéa",
                                "Tipaza", "Aïn Defla", "Chlef", "Bouira", "Djelfa",
                                "M'Sila", "Tiaret", "Tlemcen", "Oran", "Sidi Bel Abbès",};
            graph.AddEdge(0, 1); // Algiers - Blida
            graph.AddEdge(0, 2); // Algiers - Boumerdès
            graph.AddEdge(1, 2); // Blida - Boumerdès
            graph.AddEdge(1, 4); // Blida - Médéa
            graph.AddEdge(1, 5); // Blida - Tipaza
            graph.AddEdge(1, 6); // Blida - Aïn Defla
            graph.AddEdge(2, 3); // Boumerdès - Tizi Ouzou
            graph.AddEdge(2, 8); // Boumerdès - Bouira
            graph.AddEdge(3, 8); // Tizi Ouzou - Bouira
            graph.AddEdge(4, 6); // Médéa - Aïn Defla
            graph.AddEdge(4, 9); // Médéa - Djelfa
            graph.AddEdge(4, 10); // Médéa - M'Sila
            graph.AddEdge(5, 7); // Tipaza - Chlef
            graph.AddEdge(6, 7); // Aïn Defla - Chlef
            graph.AddEdge(7, 11); // Chlef - Tiaret
            graph.AddEdge(8, 10); // Bouira - M'Sila
            graph.AddEdge(9, 11); // Djelfa - Tiaret
            graph.AddEdge(9, 10); // Djelfa - M'Sila
            graph.AddEdge(10, 11); // M'Sila - Tiaret
            graph.AddEdge(11, 14); // Tiaret - Sidi Bel Abbès
            graph.AddEdge(12, 13); // Tlemcen - Oran
            graph.AddEdge(12, 14); // Tlemcen - Sidi Bel Abbès
            graph.AddEdge(13, 14); // Oran - Sidi Bel Abbès

            int[] color = new int[graph.verticesCount];
            int m = graph.ChromaticNumber();
            graph.GraphColoringMethod(m, color, 0);
            Console.WriteLine("Розфарбування:");
            for (int i = 0; i < graph.verticesCount; i++)
            {
                Console.WriteLine(cities[i] + $" - Колiр {color[i]}");
            }
            Console.WriteLine($"Хроматичне число: {m}");
        }
    }
}