using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceCreatorService : MonoBehaviour
{
    #region Singleton Instance
    private static PieceCreatorService instance;
    public static PieceCreatorService Instance { get { return instance; } }
    private void SingletonInstantiate()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null || instance != this)
        {
            Destroy(this);
        }
    }
    #endregion

    [SerializeField] PawnPiece pawn;
    [SerializeField] BishopPiece bishop;
    [SerializeField] KnightPiece knight;
    [SerializeField] RookPiece rook;
    [SerializeField] QueenPiece queen;
    [SerializeField] KingPiece king;

    private void Awake()
    {
        SingletonInstantiate();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public PieceBase CreatePiece(PieceType pieceType, TeamColor teamColor)
    {
        PieceBase piece = null;
        switch (pieceType)
        {
            case PieceType.Pawn:
                piece = Instantiate(pawn);
                break;
            case PieceType.Bishop:
                piece = Instantiate(bishop);

                break;
            case PieceType.Knight:
                piece = Instantiate(knight);

                break;
            case PieceType.Rook:
                piece = Instantiate(rook);

                break;
            case PieceType.Queen:
                piece = Instantiate(queen);

                break;
            case PieceType.King:
                piece = Instantiate(king);

                break;
            default:
                break;
        }
        piece.Init(teamColor);
        return piece;
    }
}
