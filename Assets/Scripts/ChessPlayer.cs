using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPlayer : MonoBehaviour
{
    TeamColor team;
    BoardLayout board;

    public List<PieceBase> activePieces { get; private set; }

    public ChessPlayer(TeamColor _team,BoardLayout _board) 
    {
        team = _team;
        board = _board;
        activePieces = new List<PieceBase>();
    }

    public void AddPiece(PieceBase piece)
    {
        if (!activePieces.Contains(piece))
            activePieces.Add(piece);
        else
            Debug.LogError(piece.GetPieceType() + " piece is already in the list");
    }
    public void RemovePiece(PieceBase piece)
    {
        if (activePieces.Contains(piece))
            activePieces.Remove(piece);
        else
            Debug.LogError(piece.GetPieceType() + " piece is not in the list");
    }
}
