namespace TicTacToeLogic
{
    public class WinEventArgs: EventArgs
    {
        public WinEventArgs(GameResultEnum winMove)
        {
            WinMove = winMove;
        }
        public GameResultEnum WinMove;        
    }
}
