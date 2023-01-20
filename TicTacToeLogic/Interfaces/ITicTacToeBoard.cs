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
        /// <returns>Success of try</returns>
        public bool TryMakeMove(int x, int y);

        /// <summary>
        /// Make move X on position
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        /// <returns>Success of try</returns>
        public bool TryMakeXMove(int x, int y);

        /// <summary>
        /// Make move O on position
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        /// <returns>Success of try</returns>
        public bool TryMakeOMove(int x, int y);
    }
}
