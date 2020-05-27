using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        public string fen { get, private set; } //Сохраняем фен, чтоб могли к нему обращаться
        Figure[,] figures; // Массив всех фигур, где какая находится
        public Color moveColor { get, private set; } //Цвет чей ход
        public int moveNumber { get, private set; } // Номер хода, увеличивается после каждого хода черных

        public Board(string fen) // Конструктор который примет строчку фен, сохранит ее, распарсит
        {
            this.fen = fen; // принимаем строчку фен

            figures = new Figure[8, 8]; //конструктор создает новую матрицу из всех всех фигур
            Init(); // вызов метода
        }

        void Init() // Метод смотрит на фен и инициализирует располдожение всех фигур
        {
            SetFigureAt(new Square("a1"), Figure.whiteKing); // вместо парсинга фена устанавливаем королей, с созданием клетки для каждой координаты
            SetFigureAt(new Square("h8"), Figure.blackKing);
            moveColor = Color.white; // первые ходят белые
        }

        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard()) // проверяем находится ли фигура на доске
                return figures[square.x, square.y]; // только в этом месте указываем координаты
            return Figure.none; // если за доской
        }

        void SetFigureAt(Square square. Figure figure) // метод для установки фигур, имутобл, выполняется при создании нового хода
        {
            if (square.OnBoard()) // на доске?
                figure[square.x, square.y] = figure; // записываем фигуру
        }

        public Board Move(FigureMoving)
        {
            Board next = new Board(fen)
            next.SetFigureAt(fm.from, Figure.none);
            next.SetFigureAt(fm.to, fm.promotion == Figure.none ? fm.figure : fm.promotion);
        }
    }
}
