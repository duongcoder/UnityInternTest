using System.Collections.Generic;
using UnityEngine;

public class TileManagerNew : MonoBehaviour
{
    [SerializeField] private Transform gridBoard;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private string[] tileTypes;
    [SerializeField] private Sprite[] tileSprites;

    private GameManagerNew gm;
    private BottomBarNew bar;
    private List<TileNew> boardTiles = new List<TileNew>();

    public void Setup(GameManagerNew gameManager, BottomBarNew bottomBar)
    {
        gm = gameManager;
        bar = bottomBar;
    }

    public void GenerateBoardEnsureAllTypes()
    {
        ClearBoard();
        var included = new HashSet<string>();
        int rows = 5;
        int cols = 5;
        float spacing = 1.2f;

        float xOffset = (cols - 1) * spacing / 2f;
        float yOffset = (rows - 1) * spacing / 2f;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                var go = Instantiate(tilePrefab, gridBoard);
                go.transform.localPosition = new Vector3(c * spacing - xOffset, -r * spacing + yOffset, 0);

                var tile = go.GetComponent<TileNew>();
                string type = tileTypes[Random.Range(0, tileTypes.Length)];
                if (included.Count < tileTypes.Length) type = tileTypes[included.Count];
                included.Add(type);

                tile.Item.Type = type;
                tile.Item.SetSprite(GetSprite(type));
                boardTiles.Add(tile);
            }
        }
    }

    private Sprite GetSprite(string type)
    {
        int idx = System.Array.IndexOf(tileTypes, type);
        return idx >= 0 ? tileSprites[idx] : null;
    }

    public void OnTileTapped(TileNew tile)
    {
        boardTiles.Remove(tile);
        bar.AddItem(tile.Item);
        if (boardTiles.Count == 0) gm.OnBoardEmptied();
    }

    public void ReturnItemToBoard(TileItemNew it)
    {
        var go = Instantiate(tilePrefab, gridBoard);
        var tile = go.GetComponent<TileNew>();
        tile.Item.Type = it.Type;
        tile.Item.SetSprite(it.GetComponent<SpriteRenderer>().sprite);
        boardTiles.Add(tile);
        Destroy(it.gameObject);
    }

    public bool IsBoardEmpty() => boardTiles.Count == 0;

    private void ClearBoard()
    {
        foreach (var t in boardTiles) if (t) Destroy(t.gameObject);
        boardTiles.Clear();
    }
}
