namespace Otus.SpanningTree.Kruskal.Logic.Dtos
{
    public class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }


        public Edge(int first, int second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }


        public override bool Equals(object obj)
        {
            var otherEdge = (Edge) obj;

            return First == otherEdge.First && Second == otherEdge.Second;
        }

        public override string ToString()
        {
            return $"{First} -> {Second} ({Weight})";
        }
    }
}
