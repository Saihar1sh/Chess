using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class PieceBase : MonoBehaviour
{
    protected PieceType pieceType;
    protected TeamColor teamColor;
    protected SpriteRenderer pieceImage;

    [SerializeField]
    protected Sprite piece_B, piece_W;

    protected Vector2Int[] possibleRoute;

    protected abstract void CalCulateAvailableMoves();

    public virtual void Dge()
    {
        Debug.Log("This is base");
    }
    private void Awake()
    {
        pieceImage = GetComponent<SpriteRenderer>();
    }
    public void CheckPossibleRoute(Vector2Int[] routeOptions)
    {

    }
    public void Init(TeamColor teamColor)
    {
        pieceImage.sprite = teamColor == TeamColor.White ? piece_W :piece_B;
    }

    public void SetPieceCoord(Vector3 pos)
    {
        transform.position = pos;
    }
    public PieceType GetPieceType() 
    {
        return pieceType;
    }
}
