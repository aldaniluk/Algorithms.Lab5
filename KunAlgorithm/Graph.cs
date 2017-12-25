namespace KunAlgorithm
{
    public class Graph
    {
        public int Vertices { get; }
        public int[,] Matrix { get; }

        public Graph(int size)
        {
            Matrix = new int[size, size];
            Vertices = size;
        }

        public Graph(int[,] matrix)
        {
            Matrix = matrix;
            Vertices = matrix.GetLength(0);
        }
    }
}
