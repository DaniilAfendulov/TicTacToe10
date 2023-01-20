using TicTacToeLogic.Interfaces;

namespace TicTacToeLogic
{
    public class TicTacBoard10 : ITicTacToeBoard
    {
        MoveEnum?[,] _board;
        MoveEnum _lastStep = MoveEnum.O;

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

        public bool TryMakeMove(int x, int y)
        {
            var move = _lastStep == MoveEnum.O ? MoveEnum.X : MoveEnum.O;
            return TryMakeMove(x, y, move);
        }
    }
}