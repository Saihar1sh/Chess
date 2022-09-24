using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardLayout : MonoBehaviour
{
    Vector3[] squarePositions = new Vector3[64];
    //Displayed data
    [SerializeField]
    private Vector3 originPos;
    [SerializeField]
    private Vector2 diffPos;

    [SerializeField]
    private Transform boardParent;

    [SerializeField]
    private bool loadFromDefaultFEN = true;
    //

    private string defaultPlacementFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    private ArtAssetsData artAssets;

    private void Awake()
    {
        artAssets = ArtAssetsData.Instance;
    }

    private void Start()
    {
        int x = 0,y =0;
        for (int i = 0; i < squarePositions.Length; i++)
        {
            x = i % 8;
            if (x == 0)
            {
                y++;
            }

            squarePositions[i].x = originPos.x + (diffPos.x * x);
            squarePositions[i].y = originPos.y + (diffPos.y * y);

            int q = (x+y) % 2;
            GameObject obj = new GameObject(""+i);
            obj.transform.position = squarePositions[i] + Vector3.forward* originPos.z;
            obj.AddComponent<SpriteRenderer>().sprite = artAssets.chessSqChecks[q];
            obj.AddComponent<BoxCollider2D>();
            obj.layer = 6;
            obj.transform.SetParent(boardParent);
        }
        LoadThruFEN(defaultPlacementFEN);
    }
    private void LoadThruFEN(string fenStr)
    {
        Dictionary<char, PieceType> pieceTypeFromID = new Dictionary<char, PieceType> 
        {
            ['k'] = PieceType.King,
            ['q'] = PieceType.Queen,
            ['n'] = PieceType.Knight,
            ['b'] = PieceType.Bishop,
            ['r'] = PieceType.Rook,
            ['p'] = PieceType.Pawn
        };

        int rank = 7, file = 0;
        foreach (char item in fenStr)
        {
            if(item == '/')
            {
                file = 0;
                rank--;
            }
        }
    }

/*    public int GetPiecesCount()
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
*/
}