namespace LiveCodingSession
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] positionmatrix = new string[3,3] { { "00", "01", "02"}, { "11", "12", "13" }, { "21", "22", "23" } };
            PrintTable(positionmatrix);
            Console.WriteLine("Enter Player 1 Name:");
            String? Player1 = Console.ReadLine();
            Console.WriteLine("Enter Player 2 Name: ");
            String? Player2 = Console.ReadLine();
            int playerturn = 0;
            int position1 = 0;
            int position2 = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("Player X turn");
                    playerturn = 1;
                }
                else
                {
                    Console.WriteLine("Player Y turn");
                    playerturn = 2;
                }
                Console.WriteLine("Enter position 1 of the Table");
                position1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter position 2 of the Table");
                position2 = Convert.ToInt32(Console.ReadLine());
                if(playerturn == 1)
                {
                    positionmatrix[position1,position2] = "X";
                    PrintTable(positionmatrix);
                }
                else
                {
                    positionmatrix[position1,position2] = "O";
                    PrintTable(positionmatrix);
                }

            }
        }

        private static void PrintTable(string[,] positionmatrix)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j< 3; j++)
                {
                    Console.Write(positionmatrix[i,j]+" |");
                }
                Console.WriteLine();
            }
        }
    }
}
