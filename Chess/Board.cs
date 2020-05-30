using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        //Сохраняем фен, чтоб могли к нему обращаться
        public string fen { get; private set; } 
        // Массив всех фигур, где какая находится
        Figure[,] figures; 
        //Цвет чей ход
        public Color moveColor { get; private set; } 
        // Номер хода, увеличивается после каждого хода черных
        public int moveNumber { get; private set; } 

        // Конструктор который примет строчку фен, сохранит ее, распарсит
        public Board(string fen) 
        {
            // принимаем строчку фен
            this.fen = fen; 
            //конструктор создает новую матрицу из всех всех фигур
            figures = new Figure[8, 8]; 
            Init(); // вызов метода
        }
        // Метод смотрит на фен и инициализирует располдожение всех фигур
        void Init() 
        {
            // вместо парсинга фена устанавливаем королей, с созданием клетки для каждой координаты
            SetFigureAt(new Square("a1"), Figure.whiteKing); 
            SetFigureAt(new Square("h8"), Figure.blackKing);
            moveColor = Color.white; // первые ходят белые
        }

        public Figure GetFigureAt(Square square)
        {
            // проверяем находится ли фигура на доске
            if (square.OnBoard()) 
                // только в этом месте указываем координаты
                return figures[square.x, square.y]; 
            return Figure.none; // если за доской
        }

        // метод для установки фигур, имутобл, выполняется при создании нового хода
        void SetFigureAt(Square square, Figure figure) 
        {
            if (square.OnBoard()) // на доске?
                // записываем фигуру
                figures[square.x, square.y] = figure; 
        }

        //метод реализующий ход
        public Board Move(FigureMoving fm)
        {
            //создаем новую доску на основе фен
            Board next = new Board(fen);
            //откуда пошла будет пусто
            next.SetFigureAt(fm.from, Figure.none);
            //куда пошла, если превратилась тогда новая фигура, если нет тогда фигура
            next.SetFigureAt(fm.to, fm.promotion == Figure.none ? fm.figure : fm.promotion);
            // если черный
            if (moveColor == Color.black)
                // увеличиваем номер хода на один
                next.moveNumber++;
            // переключаем цвет для хода следующего игрока
            next.moveColor = moveColor.FlipColor();
            return next;
        }
    }
}
