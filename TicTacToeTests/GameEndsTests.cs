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
        public void OnGameEnd_DrawCase_ReturnsDrawGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board.TryMakeMove(i, j);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    board.TryMakeMove(i, j);
                }
                board.TryMakeMove(i, 0);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board.TryMakeMove(i, j);
                }
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.Draw));
        }

        [Test]
        public void OnGameEnd_VerticalLineXWin_ReturnsXWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i % 2, i / 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinX));
        }

        [Test]
        public void OnGameEnd_VerticalLineOWin_ReturnsOWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;
            board.TryMakeMove(9, 9);
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i % 2, i / 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinO));
        }

        [Test]
        public void OnGameEnd_HorizontalLineXWin_ReturnsXWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i / 2, i % 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinX));
        }

        [Test]
        public void OnGameEnd_HorizontalLineOWin_ReturnsOWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;
            board.TryMakeMove(9, 9);
            for (int i = 0; i < 9; i++)
            {
                board.TryMakeMove(i / 2, i % 2);
            }
            Assert.That(actual, Is.EqualTo(GameResultEnum.WinO));
        }

        [Test]
        public void OnGameEnd_DiagonalLineFromDownToUpXWin_ReturnsXWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;

            var steps = new (int, int)[]
            {
                (0,0),
                (1,0),
                (1,1),
                (1,2),
                (2,2),
                (2,3),
                (3,3),
                (3,4),
                (4,4),
                (4,5),
                (5,5)
            };
            foreach (var step in steps)
            {
                board.TryMakeMove(step.Item1, step.Item2);
            }           

            Assert.That(actual, Is.EqualTo(GameResultEnum.WinX));
        }

        [Test]
        public void OnGameEnd_DiagonalLineFromDownToUpOWin_ReturnsOWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;

            var steps = new (int, int)[]
            {
                (9,9),
                (0,0),
                (1,0),
                (1,1),
                (1,2),
                (2,2),
                (2,3),
                (3,3),
                (3,4),
                (4,4),
                (4,5),
                (5,5)
            };
            foreach (var step in steps)
            {
                board.TryMakeMove(step.Item1, step.Item2);
            }

            Assert.That(actual, Is.EqualTo(GameResultEnum.WinO));
        }

        [Test]
        public void OnGameEnd_DiagonalLineFromUpToDownXWin_ReturnsXWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;

            var steps = new (int, int)[]
            {
                (0,9),
                (1,0),
                (1,8),
                (1,2),
                (2,7),
                (2,3),
                (3,6),
                (3,4),
                (4,5),
                (4,5),
                (5,4)
            };
            foreach (var step in steps)
            {
                board.TryMakeMove(step.Item1, step.Item2);
            }

            Assert.That(actual, Is.EqualTo(GameResultEnum.WinX));
        }

        [Test]
        public void OnGameEnd_DiagonalLineFromUpToDownOWin_ReturnsOWinGameResult()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            GameResultEnum? actual = null;
            board.OnGameEnd += (o, e) => actual = e.FinalMove;

            var steps = new (int, int)[]
            {
                (9,9),
                (0,9),
                (1,0),
                (1,8),
                (1,2),
                (2,7),
                (2,3),
                (3,6),
                (3,4),
                (4,5),
            };
            foreach (var step in steps)
            {
                board.TryMakeMove(step.Item1, step.Item2);
            }

            Assert.That(actual, Is.EqualTo(GameResultEnum.WinO));
        }

    }
}
