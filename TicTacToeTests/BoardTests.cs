using TicTacToeLogic;
using TicTacToeLogic.Interfaces;

namespace TicTacToeTests
{
    public class BoardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetBoard_InitializtionBoard_ReturnsArrayOfNull10x10()
        {
            var expected = new MoveEnum?[10, 10];
            ITicTacToeBoard board = new TicTacBoard10();
            var actual = board.GetBoard();
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TryMakeMove_MoveX_ReturnsArrayWithX()
        {
            var expected = new MoveEnum?[10, 10];
            expected[0, 0] = MoveEnum.X;

            ITicTacToeBoard board = new TicTacBoard10();
            board.TryMakeMove(0, 0, MoveEnum.X);
            var actual = board.GetBoard();
            CollectionAssert.AreEqual(expected, actual);

            expected[5, 5] = MoveEnum.X;
            board.TryMakeMove(5, 5, MoveEnum.X);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TryMakeMove_MoveO_ReturnsArrayWithO()
        {
            var expected = new MoveEnum?[10, 10];
            expected[0, 0] = MoveEnum.O;

            ITicTacToeBoard board = new TicTacBoard10();
            board.TryMakeMove(0, 0, MoveEnum.O);
            var actual = board.GetBoard();
            CollectionAssert.AreEqual(expected, actual);

            expected[5, 5] = MoveEnum.O;
            board.TryMakeMove(5, 5, MoveEnum.O);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TryMakeMove_RewriteCell_ReturnsFalseValueNotChanged()
        {
            ITicTacToeBoard board = new TicTacBoard10();
            var expectedCell = MoveEnum.X;
            board.TryMakeMove(0, 0, expectedCell);
            var actual = board.TryMakeMove(0, 0, MoveEnum.O);
            Assert.That(actual, Is.False);

            var actualCell = board.GetBoard()[0, 0];
            Assert.That(actualCell, Is.EqualTo(expectedCell));          

        }
    }
}