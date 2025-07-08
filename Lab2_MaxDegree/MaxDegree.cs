namespace Lab2_MaxDegree
{
    internal class MaxDegree
    {
        static void Main(string[] args)
        {
            int size;
            Console.Write("Enter the size: ");
            size = int.Parse(Console.ReadLine());
            int [] degrees = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter degree number {i+1}: ");
                degrees[i] = int.Parse(Console.ReadLine());
            }
            int max = degrees[0];
            for (int i = 0; i < size; i++)
            {
                if (degrees[i] > max) max = degrees[i];
            }
            Console.WriteLine($"Maximum Degree is: {max}");
        }
    }
}
