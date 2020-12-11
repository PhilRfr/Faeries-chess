using Godot;
using System;
using System.Collections.Generic;

public class Debug : Node2D
{
    Board brd;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    void printList(HashSet<Vector2> l)
    {
        foreach (Vector2 elem in l)
            GD.Print(elem);
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        brd = new Board(8, 8);
        Piece pwn = new Piece(true, new Vector2[] { new Vector2(-1,-1),new Vector2(0,-1),new Vector2(1,-1),
new Vector2(-1,0),new Vector2(1,0),
new Vector2(-1,1),new Vector2(0,1),new Vector2(1,1) });
        brd.PutPiece(pwn, new Vector2(4, 4), 0);
        printList(brd.AvailableMotions(new Vector2(4, 4)));
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
