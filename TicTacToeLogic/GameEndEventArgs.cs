namespace TicTacToeLogic
{
    public class GameEndEventArgs: EventArgs
    {
        public GameEndEventArgs(GameResultEnum finalMove)
        {
            FinalMove = finalMove;
        }
        public GameResultEnum FinalMove;        
    }
}
