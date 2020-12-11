using Godot;

public class Piece
{
    public static Vector2[]
    MOVE_NONE =
        new Vector2[] { };

    public static Vector2[]
        MOVE_DIAG_LINE =
            new Vector2[] {
                new Vector2(-1, -1),
                new Vector2(0, -1),
                new Vector2(1, -1),
                new Vector2(-1, 0),
                new Vector2(1, 0),
                new Vector2(-1, 1),
                new Vector2(0, 1),
                new Vector2(1, 1)
            };

    public static Vector2[]
        MOVE_KNIGHT =
            new Vector2[] {
                new Vector2(-1, -2),
                new Vector2(1, -2),
                new Vector2(-1, 2),
                new Vector2(1, 2),
                new Vector2(-2, -1),
                new Vector2(2, -1),
                new Vector2(-2, 1),
                new Vector2(2, 1),
             };

    public static Vector2[]
        MOVE_DIAGONAL =
            new Vector2[] {
                new Vector2(-1, -1),
                new Vector2(1, -1),
                new Vector2(-1, 1),
                new Vector2(1, 1)
            };

    public static Vector2[]
        MOVE_LINEAR =
            new Vector2[] {
                new Vector2(0, -1),
                new Vector2(0, 1),
                new Vector2(1, 0),
                new Vector2(-1, 0)
            };

    bool hasReach;
    int value;

    public bool HasReach
    {
        get
        {
            return hasReach;
        }
    }

    Vector2[] moves;

    public Vector2[] Moves
    {
        get
        {
            return moves;
        }
    }

    public Piece(bool hasReach, Vector2[] moves, int value)
    {
        this.hasReach = hasReach;
        this.moves = moves;
        this.value = value;
    }
}
