using NUnit.Framework;
using Otus.SpanningTree.Kruskal.Logic;
using Otus.SpanningTree.Kruskal.Logic.Dtos;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Can_Get_Spanning_Tree()
        {
            var firstEdge = new Edge(1, 2, 3);
            var secondEdge = new Edge(1, 5, 1);
            var forthEdge = new Edge(2, 3, 5);
            var fifthEdge = new Edge(2, 5, 4);
            var sixthEdge = new Edge(3, 4, 2);
            var seventhEdge = new Edge(5, 4, 7);
            var eighthEdge = new Edge(5, 3, 6);
            var edges = new Edge[]
            {
                firstEdge, secondEdge, forthEdge,
                fifthEdge, sixthEdge, seventhEdge, eighthEdge
            };


            var result = new KruskalAlgorithm().Run(edges);
            
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(secondEdge));
            Assert.That(result[1], Is.EqualTo(sixthEdge));
            Assert.That(result[2], Is.EqualTo(firstEdge));
            Assert.That(result[3], Is.EqualTo(forthEdge));
        }
    }
}