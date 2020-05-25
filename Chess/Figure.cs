using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    // Перечисление обозначений фигур
    enum Figure
    {
        none,
        
        whiteKing = 'K', //Король
        whiteQueen = 'Q', //Ферзь
        whiteRook = 'R', //Ладья
        whiteBishop = 'B', //Слон
        whiteKnight = 'N', //Конь
        whitePawn = 'P', //Пешка

        blackKing = 'k',
        blackQueen = 'q',
        blackRook = 'r',
        blackBishop = 'b',
        blackKnight = 'n',
        blackPawn = 'p'
    }
}
