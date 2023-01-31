using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardLayout : MonoBehaviour
{
    Vector3[] squarePositions = new Vector3[64];

    ChessBlock[] chessSquares = new ChessBlock[64];

    //Displayed data
    [SerializeField]
    private Vector3 originPos;
    [SerializeField]
    private Vector2 diffPos;

    [SerializeField]
    private Color color1, color2;

    [SerializeField]
    private Vector2Int screenRatio;

    [SerializeField]
    private Transform boardParent, cameraTransfrom;

    [SerializeField]
    private bool loadFromDefaultFEN_Bool = true;

    [SerializeField]
    private ChessBlock blockPrefab;

    public Sprite[] chessSqCheckSprites = new Sprite[2];
    public Transform bGTransform;
    //

    private string defaultPlacementFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR";

    private void Awake()
    {
        Camera.main.orthographicSize = bGTransform.localScale.x * Screen.height / Screen.width * 0.5f;

    }

    private void Start()
    {
        ArrangeChessBoard();
        if(loadFromDefaultFEN_Bool)
        LoadThruFEN(defaultPlacementFEN);
    }

    private void ArrangeChessBoard()
    {
        int x = 0, y = 0;
        for (int i = 0; i < squarePositions.Length; i++)
        {
            x = i % 8;
            if (x == 0)
            {
                y++;
            }

            squarePositions[i].x = originPos.x + (diffPos.x * x);
            squarePositions[i].y = originPos.y + (diffPos.y * y);

            
            chessSquares[i] = CreateChessSquare(i, x,y);

        }
        Camera.main.orthographicSize = bGTransform.localScale.x * Screen.height / Screen.width * 0.5f;
        //cameraTransfrom.position = new Vector3((float)screenRatio.x / 2 - 0.5f, (float)screenRatio.x / 2 - 0.5f, -10f);
    }

    private ChessBlock CreateChessSquare(int i, int indX, int indY)
    {
        ChessBlock chessBlock = Instantiate(blockPrefab);
        chessBlock.Init(indX,indY, (indX+indY)%2==0? color1:color2);
        GameObject obj = chessBlock.gameObject;
        obj.name = "" + i;
        obj.transform.position = squarePositions[i] + Vector3.forward * originPos.z;
        obj.transform.SetParent(boardParent);
        return chessBlock;
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
            else if (char.IsDigit(item))
            {
                file += (int)char.GetNumericValue(item);
            }
            else
            {
                TeamColor teamColor = char.IsUpper(item) ? TeamColor.White : TeamColor.Black;
                PieceType pieceType = pieceTypeFromID[char.ToLower(item)];
                //piece creation
                PieceBase piece = PieceCreatorService.Instance.CreatePiece(pieceType, teamColor);
                chessSquares[rank * 8 + file].Place_Piece(piece);
                file++;
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