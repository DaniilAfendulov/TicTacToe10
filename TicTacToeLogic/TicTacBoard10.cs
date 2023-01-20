using TicTacToeLogic.Interfaces;

namespace TicTacToeLogic
{
    public class TicTacBoard10 : ITicTacToeBoard
    {
        MoveEnum?[,] _board;
        MoveEnum _lastStep = MoveEnum.O;
        private bool _gameIsEnded = false;

        private int maxX = 9;
        private int maxY = 9;
        private int minX = 0;
        private int minY = 0;
        private int WinRowLenght = 5;

        public TicTacBoard10()
        {
            _board = new MoveEnum?[10,10];
            OnGameEnd += OnGameEndHandler;
        }

        public event EventHandler<GameEndEventArgs> OnGameEnd;

        private void OnGameEndHandler(object? source, GameEndEventArgs gameEndArgs)
        {
            _gameIsEnded = true;
        }

        public MoveEnum?[,] GetBoard()
        {
            return _board;
        }

        public bool TryMakeMove(int x, int y, MoveEnum move)
        {
            if (_gameIsEnded) return false;
            if (_board[x, y] is not null) return false;
            _board[x,y] = move;
            if (IsGameEnd(x, y, out GameResultEnum? gameResult))
            {
                if(gameResult is not null)
                    OnGameEnd?.Invoke(this, new GameEndEventArgs((GameResultEnum)gameResult));
            }

            return true;
        }

        public bool TryMakeMove(int x, int y)
        {
            _lastStep = _lastStep == MoveEnum.O ? MoveEnum.X : MoveEnum.O;
            return TryMakeMove(x, y, _lastStep);
        }

        public bool IsGameEnd(int x, int y, out GameResultEnum? gameResult)
        {
            gameResult = null;
            if (_board[x, y] is null) return false;
            if (IsWin(x, y))
            {
                gameResult = MoveToGameResult(_board[x, y]);
                return gameResult is not null;
            }
            if (IsBoardFilled())
            {
                gameResult = GameResultEnum.Draw;
                return true;
            }
            return false;
        }

        private bool IsWin(int x, int y)
        {
            
            if (_board[x, y] is null) return false;
            MoveEnum move = (MoveEnum)_board[x, y];
            if (CountVerticalLine(x, y, move) >= WinRowLenght) return true;
            if (CountHorizontalLine(x, y, move) >= WinRowLenght) return true;
            if (CountUpToDownDiagonal(x, y, move) >= WinRowLenght) return true;
            if (CountDownToUpDiagonal(x, y, move) >= WinRowLenght) return true;

            return false;
        }

        private int CountLineUpper(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            for (int i = y+1; i <= maxY; i++)
            {
                if (_board[x,i] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountLineLower(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            for (int i = y - 1; i >= minY; i--)
            {
                if (_board[x, i] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountVerticalLine(int x, int y, MoveEnum move)
        {
            return CountLineUpper(x, y, move) + 1 + CountLineLower(x, y, move);
        }

        private int CountRightLine(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            for (int i = x + 1; i <= maxX; i++)
            {
                if (_board[i, y] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountLeftLine(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            for (int i = x - 1; i >= minX; i--)
            {
                if (_board[i, y] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountHorizontalLine(int x, int y, MoveEnum move)
        {
            return CountLeftLine(x, y, move) + 1 + CountRightLine(x, y, move);
        }

        private int CountLowerRight(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            while (x+count+1 <= maxX && y-count-1 >= minY)
            {
                if (_board[x + count + 1, y - count - 1] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountUpperLeft(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            while (x - count - 1 >= minX && y + count + 1 <= maxY)
            {
                if (_board[x - count - 1, y + count + 1] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountUpToDownDiagonal(int x, int y, MoveEnum move)
        {
            return CountLowerRight(x, y, move) + 1 + CountUpperLeft(x, y, move);
        }

        private int CountLowerLeft(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            while (x - count - 1 >= minX && y - count - 1 >= minY)
            {
                if (_board[x - count - 1, y - count - 1] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountUpperRight(int x, int y, MoveEnum move)
        {
            if (!CheckCoordinate(x, y)) return 0;

            int count = 0;
            while (x + count + 1 <= maxX && y + count + 1 <= maxY)
            {
                if (_board[x + count + 1, y + count + 1] == move)
                {
                    count++;
                    continue;
                }
                break;
            }
            return count;
        }
        private int CountDownToUpDiagonal(int x, int y, MoveEnum move)
        {
            return CountLowerLeft(x, y, move) + 1 + CountUpperRight(x, y, move);
        }

        private bool IsBoardFilled()
        {
            foreach (var cell in _board)
            {
                if (cell is null)
                {
                    return false;
                }
            }
            return true;
        }

        private GameResultEnum? MoveToGameResult(MoveEnum? move)
        {
            if (move is null) return null;
            switch (move)
            {
                case MoveEnum.X:
                    return GameResultEnum.WinX;
                case MoveEnum.O:
                    return GameResultEnum.WinO;
            }
            return null;
        }

        private bool CheckCoordinate(int x, int y) => !(y > maxY || x > maxX || y < minY || x < minX);
    }
}