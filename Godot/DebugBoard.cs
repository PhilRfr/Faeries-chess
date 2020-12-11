using Godot;
using System;

public class DebugBoard : Node2D
{
    TileMap tmap;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        tmap = GetNode<TileMap>("TileMap");
        const int max = 8;
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < max; j++)
            {
                tmap.SetCell(i, j, (i + j) % 2);
            }
        }
        Board brd = new Board(8, 8);
        Piece pwn = new Piece(true, Piece.MOVE_KNIGHT, 3);
        Piece pwn2 = new Piece(true, Piece.MOVE_NONE, 1);
        brd.PutPiece(pwn, new Vector2(4, 4), 0);
        tmap.SetCellv(new Vector2(4, 4), 3);
        brd.PutPiece(pwn2, new Vector2(5, 5), 0);
        tmap.SetCellv(new Vector2(5, 5), 4);
        foreach (Vector2 move in brd.AvailableMotions(new Vector2(4, 4)))
        {
            tmap.SetCellv(move, 2);
        }
    }

}
