using TicTacToeLogic.Interfaces;
using TicTacToeLogic;

namespace TicTacToeTests
{
    internal class GameEndsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OnWin_DrawCase_ReturnsDrawGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnWin += (o, e) => actual = e.WinMove;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board.TryMakeMove(i, j);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    board.TryMakeMove(i, j);
                }
                board.TryMakeMove(i, 0);
            }
            for (int j = 0; j < 10; j++)
            {
                board.TryMakeMove(9, j);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.Draw));
        }

        [Test]
        public void OnWin_VerticalLineXWin_ReturnsXWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnWin += (o, e) => actual = e.WinMove;
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i % 2, i / 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinX));
        }

        [Test]
        public void OnWin_VerticalLineOWin_ReturnsOWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnWin += (o, e) => actual = e.WinMove;
            board.TryMakeMove(9, 9);
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i % 2, i / 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinO));
        }

        [Test]
        public void OnWin_HorizontalLineXWin_ReturnsXWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnWin += (o, e) => actual = e.WinMove;
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i / 2, i % 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinX));
        }

        [Test]
        public void OnWin_HorizontalLineOWin_ReturnsOWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnWin += (o, e) => actual = e.WinMove;
            board.TryMakeMove(9, 9);
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i / 2, i % 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinO));
        }
    }
}
