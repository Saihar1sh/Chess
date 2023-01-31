using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBlock : MonoBehaviour
{
    public Vector2Int index;
    public string blockIndex;

    private SpriteRenderer blockSprite;

    public PieceBase currentlyPlacedPiece { get; private set; }

    private void Awake()
    {
        blockSprite = GetComponent<SpriteRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Init(int indX,int indY, Color color)
    {
        index = new Vector2Int(indX, indY);
        SetBlockColor(color);
    }

    public void SetBlockColor(Color color)
    {
        blockSprite.color = color;
    }
    public void Place_Piece(PieceBase piece)
    {
        piece.SetPieceCoord(transform.position);
        currentlyPlacedPiece = piece;
    }
    private void OnMouseDown()
    {
        if (currentlyPlacedPiece)
        {
            Debug.Log("clicked on " + currentlyPlacedPiece.gameObject.name);
            currentlyPlacedPiece.Dge();
        }
    }
}
