using System;
using System.Collections.Generic;
using Godot;

public class Board
{
    Square[,] board;
    int width;
    int height;

    public List<Vector2> NonEmptySquares()
    {
        List<Vector2> result = new List<Vector2>();
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                if (!board[i, j].IsEmpty())
                    result.Add(new Vector2(i, j));
        return result;
    }

    public Board(int width, int height)
    {
        this.width = width;
        this.height = height;
        board = new Square[width, height];
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++) board[i, j] = new Square();
        dimensions = new Vector2(width, height);
    }

    public bool IsEmpty(Vector2 position)
    {
        if (this.ValidSquare(position))
        {
            Square pos = board[(int)position.x, (int)position.y];
            return pos.IsEmpty();
        }
        return false;
    }

    public bool MovePiece(Vector2 start, Vector2 end)
    {
        Square startSquare = At(start);
        Square endSquare = At(end);
        bool result = false;
        if (startSquare != null && endSquare != null && startSquare != endSquare)
        {
            if (!startSquare.IsEmpty())
            {
                Piece tmpPiece = startSquare.Piece;
                startSquare.Piece = null;
                endSquare.Piece = tmpPiece;
                endSquare.Side = startSquare.Side;
                result = true;
            }
        }
        return result;
    }

    public bool PutPiece(Piece piece, Vector2 position, int side)
    {
        if (this.ValidSquare(position))
        {
            Square pos = At(position);
            if (pos.IsEmpty())
            {
                pos.Side = side;
                pos.Piece = piece;
                return true;
            }
        }
        return false;
    }

    Vector2 dimensions;

    public Vector2 Dimensions
    {
        get
        {
            return dimensions;
        }
    }

    public bool ValidSquare(Vector2 square)
    {
        return square.x < dimensions.x &&
        square.x >= 0 &&
        square.y >= 0 &&
        square.y < dimensions.y;
    }

    public Square At(Vector2 position)
    {
        if (this.ValidSquare(position))
        {
            return board[(int)position.x, (int)position.y];
        }
        return null;
    }

    public HashSet<Vector2> AvailableMotions(Vector2 position)
    {
        HashSet<Vector2> list = new HashSet<Vector2>();
        if (!IsEmpty(position))
        {
            Square square = At(position);
            Piece p = square.Piece;
            if (p.HasReach)
            {
                foreach (Vector2 delta in p.Moves)
                {
                    list.UnionWith(MaximalReach(position, delta, square.Side));
                }
            }
            else
            {
                foreach (Vector2 delta in p.Moves)
                {
                    Vector2 target = position + delta;
                    Square sqt = At(target);
                    if (sqt != null && sqt.CanTake(square.Side))
                        list.Add(target);
                }
            }
        }
        return list;
    }

    public HashSet<Vector2> MaximalReach(Vector2 start, Vector2 delta, int side)
    {
        HashSet<Vector2> list = new HashSet<Vector2>();
        Vector2 next = start + delta;
        while (ValidSquare(next))
        {
            Square target = At(next);
            if (target.CanTake(side)) list.Add(next);
            if (!target.IsEmpty()) break;
            next += delta;
        }
        return list;
    }
}
