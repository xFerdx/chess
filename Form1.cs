using System;
using System.Drawing;
using System.Windows.Forms;

namespace chess;

public partial class Form1 : Form
{
    private const int TileSize = 50;
    private const int BoardSize = 8;
    private const string PicturesFolder = "pictures";

    ulong whitePawns = 0x00FF000000000000;
    ulong whiteRooks = 0x8100000000000000;
    ulong whiteKnights = 0x4200000000000000;
    ulong whiteBishops = 0x2400000000000000;
    ulong whiteQueen = 0x0800000000000000;
    ulong whiteKing = 0x1000000000000000;
    ulong blackQueen = 0x0000000000000008;
    ulong blackPawns = 0x000000000000FF00;
    ulong blackRooks = 0x0000000000000081;
    ulong blackKnights = 0x0000000000000042;
    ulong blackBishops = 0x0000000000000024;
    ulong blackKing = 0x0000000000000010;

    public Form1()
    {
        this.Text = "Schachbrett";
        this.Size = new Size(BoardSize * TileSize + 16, BoardSize * TileSize + 39);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Paint += new PaintEventHandler(DrawChessboard);
    }

    private void DrawChessboard(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                bool isBlack = (row + col) % 2 == 0;
                Brush brush = isBlack ? Brushes.DarkGray : Brushes.White;
                g.FillRectangle(brush, col * TileSize, row * TileSize, TileSize, TileSize);
            }
        }

        DrawPieces(e.Graphics, whitePawns, "whitePawns.png");
        DrawPieces(e.Graphics, whiteRooks, "whiteRooks.png");
        DrawPieces(e.Graphics, whiteKnights, "whiteKnights.png");
        DrawPieces(e.Graphics, whiteBishops, "whiteBishops.png");
        DrawPieces(e.Graphics, whiteQueen, "whiteQueen.png");
        DrawPieces(e.Graphics, whiteKing, "whiteKing.png");
        DrawPieces(e.Graphics, blackPawns, "blackPawns.png");
        DrawPieces(e.Graphics, blackRooks, "blackRooks.png");
        DrawPieces(e.Graphics, blackKnights, "blackKnights.png");
        DrawPieces(e.Graphics, blackBishops, "blackBishops.png");
        DrawPieces(e.Graphics, blackQueen, "blackQueen.png");
        DrawPieces(e.Graphics, blackKing, "blackKing.png");


    }


    private void DrawPieces(Graphics g, ulong bitboard, string imageName)
    {
        string imagePath = Path.Combine(PicturesFolder, imageName);

        if (!File.Exists(imagePath))
        {
            Console.WriteLine($"Bild nicht gefunden: {imagePath}");
            return;
        }

        Image pieceImage = Image.FromFile(imagePath);

        for (int i = 0; i < 64; i++)
        {
            if ((bitboard & (1UL << i)) != 0)
            {
                int row = i / 8;
                int col = i % 8;
                g.DrawImage(pieceImage, col * TileSize, row * TileSize, TileSize, TileSize);
            }
        }
    }

}
