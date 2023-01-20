using TicTacToeLogic.Interfaces;

namespace TicTacToeLogic
{
    public class TicTacBoard10 : ITicTacToeBoard
    {
        MoveEnum?[,] _board;
        public TicTacBoard10()
        {
            _board = new MoveEnum?[10,10];
        }
        public MoveEnum?[,] GetBoard()
        {
            return _board;
        }

        public bool TryMakeMove(int x, int y, MoveEnum move)
        {
            if (_board[x, y] is not null) return false;
            _board[x,y] = move;
            return true;
        }

        public bool TryMakeXMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}