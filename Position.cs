namespace chess;

public class Position
{
    public enum PieceType
    {
        WhitePawn,
        WhiteRook,
        WhiteKnight,
        WhiteBishop,
        WhiteQueen,
        WhiteKing,
        BlackQueen,
        BlackPawn,
        BlackRook,
        BlackKnight,
        BlackBishop,
        BlackKing
    }

    public Dictionary<PieceType, ulong> pieces = new Dictionary<PieceType, ulong>();

    public void InitPos()
    {
        pieces[PieceType.WhitePawn] = 0x00FF000000000000;
        pieces[PieceType.WhiteRook] = 0x8100000000000000;
        pieces[PieceType.WhiteKnight] = 0x4200000000000000;
        pieces[PieceType.WhiteBishop] = 0x2400000000000000;
        pieces[PieceType.WhiteQueen] = 0x0800000000000000;
        pieces[PieceType.WhiteKing] = 0x1000000000000000;
        pieces[PieceType.BlackQueen] = 0x0000000000000008;
        pieces[PieceType.BlackPawn] = 0x000000000000FF00;
        pieces[PieceType.BlackRook] = 0x0000000000000081;
        pieces[PieceType.BlackKnight] = 0x0000000000000042;
        pieces[PieceType.BlackBishop] = 0x0000000000000024;
        pieces[PieceType.BlackKing] = 0x0000000000000010;
    }
}