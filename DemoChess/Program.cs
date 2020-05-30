using System;

// После подключения библиотеки Chess в References

namespace DemoChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Chess.Chess chess = new Chess.Chess();
            while (true)
            {
                Console.WriteLine(chess.fen);
                // вызываем рисование доски
                Print(ChessToAscii(chess));
                string move = Console.ReadLine();
                if (move == "") break;
                chess = chess.Move(move);
            }
        }
        //метод для перевода шахмат в аски формат
        static string ChessToAscii(Chess.Chess chess)
        {
            // рисуем начало доски 16+1 по 2 на каждые 8 клеток
            string text = "  +" + new string('-', 17) + "+\n";
            // цикл рисования всех внутренних линий
            for (int y = 7; y >= 0; y--)
            {
                //добавляем номер строки 
                text += y + 1;
                // добавляем черту
                text += " | ";
                // 
                for (int x = 0; x < 8; x++)
                    // добавляем фигуру получая символ фигуры + пробел
                    text += chess.GetFigureAt(x, y) + " ";
                //
                text += "|\n";
            }
            //закрываем доску
            text += "  +" + new string('-', 17) + "+\n";
            //добавляем надписи
            text += "    a b c d e f g h\n";
            return text;
        }

        // функция рисования цветной доски
        static void Print(string text)
        {
            ConsoleColor oldForeColor = Console.ForegroundColor;
            foreach (char x in text)
            {
                if (x >= 'a' && x <= 'z')
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (x >= 'A' && x <= 'Z')
                    Console.ForegroundColor = ConsoleColor.White;
                else
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(x);
            }
            Console.ForegroundColor = oldForeColor;
        }
    }
}
