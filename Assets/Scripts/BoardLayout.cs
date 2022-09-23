using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Board_Layout")]
public class BoardLayout : ScriptableObject
{
    private string defaultPlacementFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    [Serializable]
    private class BoardSquareSetup
    {
        public Vector2Int position;
        public PieceType pieceType;
        public TeamColor teamColor;
    }

    //Displayed data
    [SerializeField] 
    private BoardSquareSetup[] boardSquares = new BoardSquareSetup[32];
    //

    public BoardLayout()
    {
        LoadThruFEN(defaultPlacementFEN);
    }

    private void LoadThruFEN(string fenStr)
    {

    }

    public int GetPiecesCount()
    {
        return boardSquares.Length;
    }


    public Vector2Int GetSquareCoordsAtIndex(int index)
    {
        return new Vector2Int(boardSquares[index].position.x - 1, boardSquares[index].position.y - 1);
    }
    public string GetSquarePieceNameAtIndex(int index)
    {
        return boardSquares[index].pieceType.ToString();
    }
    public TeamColor GetSquareTeamColorAtIndex(int index)
    {
        return boardSquares[index].teamColor;
    }

}