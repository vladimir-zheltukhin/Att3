using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public enum GameState
    {
        NOT_STARTED,
        PLAYING,
        WIN
    }
    public class WaggleCell
    {
        public bool ball { get; set; }
        public bool IsTriggered { get; set; }
    }
    public class WaggleGame
    {
        private GameState state = GameState.NOT_STARTED;
        public WaggleCell[,] field { get; set;}

        public int ballCount;

        public void NewGame()
        {
            ballCount = 13;
            WaggleCell[,] Field = new WaggleCell[7, 7];
            for (int n = 0; n < 7; n++) // Заполняем игровое поле 
            {
                for (int m = 0; m < 7; m++)
                {
                    Field[n, m] = new WaggleCell();
                    Field[n, m].ball = false;
                    Field[n, m].IsTriggered = false;
                }
            }
            Field[0, 1].ball = true;
            Field[0, 2].ball = true;
            Field[1, 0].ball = true;
            Field[1, 2].ball = true;
            Field[1, 3].ball = true;
            Field[2, 0].ball = true;
            Field[3, 0].ball = true;
            Field[3, 1].ball = true;
            Field[3, 3].ball = true;
            Field[3, 4].ball = true;
            Field[4, 1].ball = true;
            Field[4, 0].ball = true;
            Field[6, 0].ball = true;
            field = Field;
            CalcGameState();
        }

        public void LeftMouseClick(int row, int col)
        {
            if (state != GameState.PLAYING)
                return;

            if (field[row, col].ball)
            {
                if (field[row, col].IsTriggered) // если шар выделен, снимает выделение
                {
                    field[row, col].IsTriggered = false;
                }
                else  // если шар не выделен, выделяет его
                {
                    DeleteAllTrigers();
                    field[row, col].IsTriggered = true;
                }
                CalcGameState();
                return;
            }
            if (!field[row, col].ball)
            {
                if (QuantityOfTrigeredCell() == 1)
                {
                    if (row > 1) // Есть ли возможность хода сверху
                    {
                        if (field[row - 1, col].ball && field[row - 2, col].ball && field[row - 2, col].IsTriggered)
                        {
                            field[row, col].ball = true;
                            field[row, col].IsTriggered = true;
                            field[row - 1, col].ball = false;
                            field[row - 2, col].ball = false;
                            field[row - 2, col].IsTriggered = false;
                            ballCount -= 1;
                        }
                    }
                    if (row < 5) // Есть ли возможность хода снизу
                    {
                        if (field[row + 1, col].ball && field[row + 2, col].ball && field[row + 2, col].IsTriggered)
                        {
                            field[row, col].ball = true;
                            field[row, col].IsTriggered = true;
                            field[row + 1, col].ball = false;
                            field[row + 2, col].ball = false;
                            field[row + 2, col].IsTriggered = false;
                            ballCount -= 1;
                        }
                    }
                    if (col > 1) // Есть ли возможность хода слева
                    {
                        if (field[row, col - 1].ball && field[row, col - 2].ball && field[row, col - 2].IsTriggered)
                        {
                            field[row, col].ball = true;
                            field[row, col].IsTriggered = true;
                            field[row, col - 1].ball = false;
                            field[row, col - 2].ball = false;
                            field[row, col - 2].IsTriggered = false;
                            ballCount -= 1;
                        }
                    }
                    if (col < 5) // Есть ли возможность хода справа
                    {
                        if (field[row, col + 1].ball && field[row, col + 2].ball && field[row, col + 2].IsTriggered)
                        {
                            field[row, col].ball = true;
                            field[row, col].IsTriggered = true;
                            field[row, col + 1].ball = false;
                            field[row, col + 2].ball = false;
                            field[row, col + 2].IsTriggered = false;
                            ballCount -= 1;
                        }
                    }
                }
            }
            CalcGameState();
        }
        private void CalcGameState()
        {
            if (ballCount == 1)
            {
                state = GameState.WIN;
            }
            else
                state = GameState.PLAYING;
        }  // Проверка состояния игры
        public int QuantityOfTrigeredCell()
        {
            int Quantity = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int k = 0; k < 7; k++)
                {
                    if (field[i, k].IsTriggered)
                    {
                        Quantity += 1;
                    }
                }
            }
            return Quantity;
        } // Количество выделенных ячеек
        public void DeleteAllTrigers()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int k = 0; k < 7; k++)
                {
                    field[i, k].IsTriggered = false;
                }
            }
        }  // удаляет все тригеры
        public GameState State
        {
            get
            {
                return state;
            }
        } // Состояние игры
        public int RowCount
        {
            get
            {
                return field == null ? 0 : field.GetLength(0);
            }
        }

        public int ColCount
        {
            get
            {
                return field == null ? 0 : field.GetLength(1);
            }
        }
        public WaggleCell this[int row, int col]
        {
            get
            {
                return
                    row < 0 || row >= RowCount ||
                    col < 0 || col >= ColCount ?
                        new WaggleCell() :
                        field[row, col];
            }
        }
    }
}

