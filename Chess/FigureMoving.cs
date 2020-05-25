using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureMoving
    {
        public Figure figure { get, private set; } // что за фигура?
        public Square from { get, private set; } // где находится? откуда
        public Square to { get, private set; } // куда пошла
        public Figure promotion { get, private set; } //вспомогательное поле для преврящяющейся пешки в другую фигуру

        // Конструктор что приходит, куда, в какую фигуру превратились или не превратились
        public FigureMoving (FigureOnSquare fs, Square to, Figure promotion = Figure.none)
        {
            this.figure = fs.figure; // какая была фигура
            this.from = fs.square; //откуда пришла фигура
            this.to = to; //куда пошла
            this.promotion = promotion; // во что превратилась
        }

        // вспомогательный конструктор для принятия хода в текстовом варианте
        public.FigureMoving (string move) // Pe2e4      Pe7e8Q - последняя буква в кого превратилась
        {                                 // 01234      012345
            this.figure = (figure)move[0]; //распарсили, взяли нулевой символ
            this.from = new Square(move.Substring(1, 2)); // координата откуда отпервой позиции два символа
            this.to = new Square(move.Substring(3, 2)); // координата куда
            this.promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none; // превращение берем только если длина строки 6 символов, тогда берем 5 символ, если нет то ничего не берем

        }    
    }
}
