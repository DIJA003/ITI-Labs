namespace Lab2_Multiplication_Table
{
    internal class MutliplicationTable
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 12; i++)
            {
                for (int j = 1; j <= 12; j++)
                {
                    string res = $"{j} * {i} = {i * j}";
                    Console.Write(res.PadRight(16));
                }
                Console.WriteLine();
            }
        }
    }
}
