using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MemoryPuzzleManager : MonoBehaviour
{
    public MemoryTile[] tiles;
    public Transform monkey;
    public Animator monkeyAnimator;

    public GameObject emeraldPrefab;
    public Transform emeraldSpawnPoint;

    public TextMeshProUGUI messageText;

    private List<int> sequence = new List<int>();
    private int inputIndex = 0;
    private bool playerTurn = false;

    private int round = 0;
    public int maxRounds = 4;

    void Start()
    {
        messageText.gameObject.SetActive(false);
        StartNextRound();
    }

    void StartNextRound()
    {
        inputIndex = 0;
        playerTurn = false;
        round++;

        AddTilesForRound();
        StartCoroutine(ShowSequence());
    }

    // ALWAYS add exactly 2 new tiles
    void AddTilesForRound()
    {
        for (int i = 0; i < 2; i++)
        {
            int randomID = tiles[Random.Range(0, tiles.Length)].tileID;
            sequence.Add(randomID);
        }
    }

    IEnumerator ShowSequence()
    {
        monkey.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);

        foreach (int id in sequence)
        {
            MemoryTile tile = GetTileByID(id);

            monkey.position = tile.transform.position;
            monkey.gameObject.SetActive(true);
            monkeyAnimator.SetTrigger("Appear");

            yield return new WaitForSeconds(1f);

            monkey.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }

        playerTurn = true;
    }

    public void PlayerClickedTile(int tileID)
    {
        if (!playerTurn) return;

        MemoryTile clickedTile = GetTileByID(tileID);

        if (tileID != sequence[inputIndex])
        {
            clickedTile.Flash(Color.red);
            Fail();
            return;
        }

        clickedTile.Flash(Color.green);
        inputIndex++;

        if (inputIndex >= sequence.Count)
        {
            if (round >= maxRounds)
                Win();
            else
                StartNextRound();
        }
    }

    MemoryTile GetTileByID(int id)
    {
        foreach (MemoryTile tile in tiles)
        {
            if (tile.tileID == id)
                return tile;
        }
        return null;
    }

    void Fail()
    {
        playerTurn = false;
        sequence.Clear();
        round = 0;

        messageText.gameObject.SetActive(true);
        messageText.text = "FAILED";
    }

    void Win()
    {
        playerTurn = false;

        messageText.gameObject.SetActive(true);
        messageText.text = "PUZZLE COMPLETE";

        if (emeraldPrefab != null)
        {
            Instantiate(emeraldPrefab, emeraldSpawnPoint.position, Quaternion.identity);
        }
    }
}
