using Game_screen;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ConsoleKeyInfo keyPressInfo;

        string[,] frameMatrix = GameScreen.GenerateMatrix(20, 40);
        GameScreen gameScreen = new GameScreen(frameMatrix);
        gameScreen.InsertProtagonistChar();
        
        string instruction = "\n\nVocê precisa atravessar o a chuva de lagrimas e chegar ao topo\n\nNão haverá aplousos por isso, nem final de jogo.\n\nPressione ENTER para começar".ToUpper();

        Console.Clear();
        Console.WriteLine(instruction);

        while (Console.ReadKey(true).Key != ConsoleKey.Enter) { };
        
        Task.Run(() => gameScreen.StartFrameRateLoop()); /* Executa loop da tela de maneira assincrona e não bloqueante */

        do
        {
            keyPressInfo = Console.ReadKey(true);
            switch (keyPressInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    gameScreen.MoveToTop();
                    break;
                case ConsoleKey.DownArrow:
                    gameScreen.MoveToBottom();
                    break;
                case ConsoleKey.LeftArrow:
                    gameScreen.MoveToLeft();
                    break;
                case ConsoleKey.RightArrow:
                    gameScreen.MoveToRight();
                    break;
            }
        } while (keyPressInfo.Key != ConsoleKey.Escape);
    }
}

