namespace Game_screen {
    using System.Text;
    public class GameScreen
    {
        private string[,] _frame;
        private static int _frameRate = 350;
        private int _fallDelay = 150;

        public string drop = "💧";
        public string protagonist = "🥹";


        public static string[,] GenerateMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = "  ";
                }
            }
            return matrix;
        }

        public void InsertProtagonistChar()
        {
            int row = _frame.GetLength(0) -1;
            int col = _frame.GetLength(1) / 2;
            
            _frame[row, col] = protagonist;
        }

        public void InsertRandomCharactersInFirstRow(int n, string character)
        {
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {   
                int col = random.Next(_frame.GetLength(1));
                
                if (_frame[0, col] != protagonist)
                {
                    _frame[0, col] = character;
                }
            }
        }

        public void CreateGameFrame(int rows, int cols)
        {
            GameScreen frame = new GameScreen(GenerateMatrix(rows, cols));
        }

        public GameScreen(string[,] initialFrame)
        {
            _frame = initialFrame;
        }

        public void MoveToLeft()
        {
            string[,] newFrame = (string[,])_frame.Clone();

            for (int y = 0; y < _frame.GetLength(0); y++)
            {
                for (int x = 0; x < _frame.GetLength(1); x++)
                {
                    if (_frame[y, x] == protagonist && x > 0 && _frame[y, x -1] == "  ")
                    {
                        newFrame[y, x - 1] = _frame[y, x];
                        newFrame[y, x] = "  ";
                    }
                }
            }
            _frame = newFrame;
        }

        public void MoveToRight()
        {
            string[,] newFrame = (string[,])_frame.Clone();

            for (int y = 0; y < _frame.GetLength(0); y++)
            {
                for (int x = 0; x < _frame.GetLength(1) - 1; x++)
                {
                    if (_frame[y, x] == protagonist && _frame[y, x + 1] == "  ")
                    {
                        newFrame[y, x + 1] = _frame[y, x];
                        newFrame[y, x] = "  ";
                    }
                }
            }
            _frame = newFrame;
        }

        public void MoveToTop()
        {
            string[,] newFrame = (string[,])_frame.Clone();

            for (int y = _frame.GetLength(0) -1; y > 0 ; y--) /* Linha */
            {
                for (int x = 0; x < _frame.GetLength(1); x++) /* Coluna */
                {
                    if (_frame[y, x] == protagonist && _frame[y -1, x] == "  " && y - 1 >= 0) /* se o elemtno for um caractere e  se a linha acima for maior que 0*/
                    {
                        newFrame[y -1, x] = _frame[y, x];
                        newFrame[y, x] = "  ";
                    }
                }
            }

            _frame = newFrame;
        }

        public void MoveToBottom()
        {
            string[,] newFrame = (string[,])_frame.Clone();

            for (int y = 0; y < _frame.GetLength(0); y++)
            {
                for (int x = 0; x < _frame.GetLength(1); x++)
                {
                    if (_frame[y, x] == protagonist && y + 1 < _frame.GetLength(0) -1 && _frame[y +1, x] == "  ")
                    {
                        newFrame[y + 1, x] = _frame[y, x];
                        newFrame[y, x] = "  ";
                    }
                }
            }
            _frame = newFrame;
        }

        public void StartCharactersFall()
        {
            string[,] newFrame = (string[,])_frame.Clone();

            for (int y = 0; y < _frame.GetLength(0); y++)
            {
                for (int x = 0; x < _frame.GetLength(1); x++)
                {   
                    if (y + 1 >= _frame.GetLength(0) -1  && _frame[y, x] != protagonist)
                    {
                        newFrame[y, x] = "  ";
                    }
                    if (_frame[y, x] != protagonist && _frame[y, x] != "  " && _frame[y + 1, x] == "  " && y + 1 < _frame.GetLength(0) - 1)
                    {
                        newFrame[y + 1, x] = _frame[y, x];
                        newFrame[y, x] = "  ";
                    }
                    else if (y + 1 >= _frame.GetLength(0) -1  && _frame[y, x] != protagonist)
                    {
                        newFrame[y, x] = "  ";
                    }
                }
            } 
            _frame = newFrame;
        }
        public async Task StartFrameRateLoop()
        {
            while (true)
            {
                await Task.Delay(_fallDelay);
                StartCharactersFall();
                Console.Clear();
                Display();
                await Task.Delay(_frameRate);
                InsertRandomCharactersInFirstRow(_frame.GetLength(1) / 2 , drop);
            }
        }

        private void Display()
        {   
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < _frame.GetLength(0); y++)
            {
                for (int x = 0; x < _frame.GetLength(1); x++)
                {
                    sb.Append(_frame[y, x]);
                }
                sb.AppendLine();
            }
            Console.WriteLine(sb.ToString());
        }
    }
}