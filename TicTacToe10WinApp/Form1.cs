using TicTacToeLogic;
using TicTacToeLogic.Interfaces;

namespace TicTacToe10WinApp
{
    public partial class Form1 : Form
    {
        private ITicTacToeBoard _board;
        public Form1()
        {
            InitializeComponent();
            CreateBoard();
        }

        private void CreateBoard()
        {
            _board = new TicTacBoard10();
            _board.OnGameEnd += OnGameEndHandler;

            tableLayoutPanel1.ColumnCount = 10;
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < 10; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle() { SizeType = SizeType.Percent, Height = 10 });
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle() { SizeType = SizeType.Percent, Width = 10 });
                for (int j = 0; j < 10; j++)
                {
                    var btn = CreateButton(i, j);
                    tableLayoutPanel1.Controls.Add(btn);
                }
            }
        }

        private void OnGameEndHandler(object? sender, GameEndEventArgs e)
        {
            string text = "";
            switch (e.FinalMove)
            {
                case GameResultEnum.WinX:
                    text = "ÂÛÈÃÐÀË X";
                    break;
                case GameResultEnum.WinO:
                    text = "ÂÛÈÃÐÀË O";
                    break;
                case GameResultEnum.Draw:
                    text = "ÍÈ×Üß";
                    break;
            }
            MessageBox.Show(text);

            if (MessageBox.Show("Ïåðåçàïóñòèòü èãðó") == DialogResult.OK)
            {
                _board.OnGameEnd -= OnGameEndHandler;
                CreateBoard();
            }
        }

        private Button CreateButton(int x, int y)
        {
            var btn = new Button()
            {
                Anchor = AnchorStyles.Top,
                Dock = DockStyle.Fill,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
            };
            btn.Click += BtnClickHandler(x, y);
            return btn;
        }

        private EventHandler BtnClickHandler(int x, int y)
        {
            return (sender, eventArgs) =>
            {
                if (_board.TryMakeMove(x, y))
                {
                    var move = _board.GetBoard()[x, y];
                    if (sender is Button)
                    {
                        PaintButton((Button)sender, move);
                    }
                }
            };
        }

        private void PaintButton(Button button, MoveEnum? move)
        {
            string text = "";
            switch (move)
            {
                case MoveEnum.X:
                    text = "X";
                    break;
                case MoveEnum.O:
                    text = "O";
                    break;
            }
            button.Text = text;
            button.Enabled = false;
        }

        

    }
}