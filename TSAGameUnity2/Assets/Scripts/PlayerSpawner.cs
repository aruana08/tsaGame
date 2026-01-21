using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Player Prefabs")]
    public GameObject player0Prefab;
    public GameObject player1Prefab;

    [Header("Spawn Point")]
    public Transform spawnPoint;

    void Start()
    {
        int id = CharacterSelect.SelectedCharacter;

        GameObject playerToSpawn = null;

        if (id == 0)
            playerToSpawn = player0Prefab;
        else if (id == 1)
            playerToSpawn = player1Prefab;
        else
        {
            Debug.LogError("No character selected!");
            return;
        }

        Instantiate(playerToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
