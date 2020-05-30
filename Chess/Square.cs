using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    struct Square
    {
        // Константа когда данные не коректны после проверки
        public static Square none = new Square(-1, -1);

        public int x { get; private set; }
        public int y { get; private set; }
        // Создание координаты по двум числам
        public Square (int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        // Конструктор для ввода координат типа e2e4 с проверками
        public Square (string e2)
        {
            if (e2.Length == 2 && // проверка длинны
                e2[0] >= 'a' && //1 символ от
                e2[0] <= 'h' && // 1 символ до
                e2[1] >= '1' && // 2 символ от
                e2[1] <= '8') // 2 символ до
            {
                x = e2[0] - 'a'; //от 1 символа вычитаем
                y = e2[1] - '1'; // от 2 символа вычитаем
            }
            else
                this = none; //данные не корректны
        }

        // Метод проверки находится ли клетка на доске
        public bool OnBoard ()
        {
            return x >= 0 && x < 8 &&
                   y >= 0 && y < 8;
        }
    }
}
