using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureOnSquare //Фигура на клетке
    {
        public Figure figure { get; private set; }
        public Square square { get; private set; }

        //Контейнер для фигур без вспомогательных методов
        public FigureOnSquare (Figure figure, Square square)
        {
            this.figure = figure;
            this.square = square;
        }
    }
}
