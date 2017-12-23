using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utils;
using BL;

/*11. Вогл – http://igroflot.ru/logic/flash_game_2254/

Сделать обычные шарики.Шарики не нужно «таскать».
Вместо этого выделяем шарик, затем щелкаем по клетке, в которую он может «перепрыгнуть».
В новой клетке шарик также остается выделенным.
*/

namespace Waggle
{
    public partial class MainForm : Form
    {
        private const int CELL_SIZE = 25;

        private static StringFormat cellStringFormat = null;

        private WaggleGame game = new WaggleGame();


        static MainForm()
        {
            cellStringFormat = new StringFormat();
            cellStringFormat.Alignment = StringAlignment.Center;
            cellStringFormat.LineAlignment = StringAlignment.Center;
        }
        private void MainForm_Load_1(object sender, EventArgs e)
        {
            // настраиваем DataGridView
            GameField.RowTemplate.Height = CELL_SIZE;
            GameField.Font = new Font("Comic Sans MS", 12);
            DataGridViewUtils.InitGridForArr(GameField, CELL_SIZE, true, false, false, false, false);

            NewGameButton.PerformClick();
        }
        public MainForm()
        {
            InitializeComponent();
        }
        private void UpdateView()
        {
            switch (game.State)
            {
                case GameState.PLAYING:
                    gameStateLabel.Text = "Игра идет ...";
                    gameStateLabel.ForeColor = Color.Black;
                    break;
                case GameState.WIN:
                    gameStateLabel.Text = "ПОБЕДА :)";
                    gameStateLabel.ForeColor = Color.DarkGreen;
                    break;
            }

            GameField.Invalidate();
        }
        private void GameField_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                game.LeftMouseClick(e.RowIndex, e.ColumnIndex);
                UpdateView();
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e) // начать игру
        {
            game.NewGame();
            GameField.RowCount = 7;
            GameField.ColumnCount = 7;
            GameField.Width = game.ColCount * CELL_SIZE + 3;
            GameField.Height = game.RowCount * CELL_SIZE + 3;
            UpdateView();
        }
        private void gameFieldDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            WaggleCell cell = game[e.RowIndex, e.ColumnIndex];

            // отрисовка фона
            e.CellStyle.BackColor = cell.IsTriggered == false ? Color.White : Color.LightGray;
            e.PaintBackground(e.CellBounds, false);

            // отрисовка содержимого
            string content = "";
            Brush brush = Brushes.Black;
            if (cell.ball)
            {
                content = "⚫";
            }
            e.Graphics.DrawString(content, GameField.Font, brush, e.CellBounds, cellStringFormat);

            e.Handled = true;
        }
    }
}