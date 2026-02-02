using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public Sprite[] tileSprites;
    public GameObject sapphirePrefab;

    
    public GameObject solvedText;

    public int width = 4;
    public int height = 3;
    public float tileSize = 1f;

    private Dictionary<Vector2Int, PuzzleTile> tiles = new();
    private Vector2Int emptySlot;

    private bool isShuffling = false;
    private bool puzzleSolved = false;

    void Start()
    {
        GeneratePuzzle();
        ShufflePuzzle();
    }

    void Update()
    {
        if (!puzzleSolved)
            HandleInput();
    }

    void GeneratePuzzle()
    {
        emptySlot = new Vector2Int(width - 1, height - 1);
        int index = 0;

        for (int y = height - 1; y >= 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == emptySlot.x && y == emptySlot.y)
                {
                    index++;
                    continue;
                }

                GameObject tileObj = Instantiate(tilePrefab, transform);
                tileObj.transform.position = GridToWorld(x, y);

                SpriteRenderer sr = tileObj.GetComponent<SpriteRenderer>();
                sr.sprite = tileSprites[index];

                PuzzleTile tile = tileObj.GetComponent<PuzzleTile>();
                tile.correctPos = new Vector2Int(x, y);
                tile.currentPos = tile.correctPos;

                tiles.Add(tile.currentPos, tile);
                index++;
            }
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) TryMove(Vector2Int.down);
        if (Input.GetKeyDown(KeyCode.DownArrow)) TryMove(Vector2Int.up);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) TryMove(Vector2Int.right);
        if (Input.GetKeyDown(KeyCode.RightArrow)) TryMove(Vector2Int.left);
    }

    void TryMove(Vector2Int dir)
    {
        Vector2Int target = emptySlot + dir;

        if (!tiles.ContainsKey(target))
            return;

        PuzzleTile tile = tiles[target];

        tiles.Remove(target);
        tiles.Add(emptySlot, tile);

        Vector2Int oldPos = tile.currentPos;
        tile.currentPos = emptySlot;
        emptySlot = oldPos;

        StartCoroutine(Slide(tile));

        if (!isShuffling && !puzzleSolved && IsSolved())
        {
            PuzzleSolved();
        }
    }

    System.Collections.IEnumerator Slide(PuzzleTile tile)
    {
        Vector3 start = tile.transform.position;
        Vector3 end = GridToWorld(tile.currentPos.x, tile.currentPos.y);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 7f;
            tile.transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        tile.transform.position = end;
    }

    Vector3 GridToWorld(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize, 0);
    }

    void ShufflePuzzle(int moves = 50)
    {
        isShuffling = true;

        Vector2Int[] directions = {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };

        for (int i = 0; i < moves; i++)
        {
            Vector2Int dir = directions[Random.Range(0, directions.Length)];
            TryMove(dir);
        }

        isShuffling = false;
    }

    bool IsSolved()
    {
        foreach (PuzzleTile tile in tiles.Values)
        {
            if (tile.currentPos != tile.correctPos)
                return false;
        }
        return true;
    }

    void PuzzleSolved()
{
    puzzleSolved = true;
    Debug.Log("PUZZLE SOLVED!");

    if (solvedText != null)
        solvedText.SetActive(true);

    // Spawn gem
    Instantiate(
        sapphirePrefab,
        new Vector3(6f, 1f, 0f),
        Quaternion.identity
    );

    // ✅ SAVE TO MAIN GAME PROGRESS
    if (GameProgress.Instance != null)
    {
        GameProgress.Instance.FireStone = true;
        Debug.Log("Fire Stone unlocked!");
    }
}

}
