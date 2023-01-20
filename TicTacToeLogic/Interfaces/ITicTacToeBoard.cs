namespace TicTacToeLogic.Interfaces
{
    public interface ITicTacToeBoard
    {
        /// <summary>
        /// Returns Board with all moves
        /// </summary>
        /// <returns>Board with all moves</returns>
        public MoveEnum?[,] GetBoard();

        /// <summary>
        /// Make move on position
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        /// <param name="move">move</param>
        /// <returns>Success of try</returns>
        public bool TryMakeMove(int x, int y, MoveEnum move);
    }
}
