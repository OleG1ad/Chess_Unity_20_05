using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Chess
    {
        public string fen { get; private set; }
        private Board board;

        // Начальная позиция в шахматах по Forsyth–Edwards Notation, FEN
        public Chess(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.fen = fen;
            // по фен при заходе через парадный вход
            board = new Board(fen);
        }

        // при заходе повторно от позиции на новой доске
        Chess(Board board)
        {
            this.board = board;
        }


        public Chess Move(string move) // Pe2e4    Pe7e8Q
        {
            // сгенерировали новый ход, передаем ход
            FigureMoving fm = new FigureMoving(move);
            // создаем следующую доску принимающую следующий ход
            Board nextBoard = board.Move(fm);
            // новые шахматы создаются не от фен а от новой доски
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        //метод получения фигуры
        public char GetFigureAt(int x, int y)
        {
            //return '.';
            //новый метод получения фигуры через получение клетки
            Square square = new Square(x, y);
            //смотрим какая фигура находится
            Figure f = board.GetFigureAt(square);
            //возвращаем если не нормальная фигура вернем точку,
            //а если нормальная возвращаем соответствующий символ фигуры
            return f == Figure.none ? '.' : (char) f;
        }
    }
}
