using UnityEngine;
using System.Collections;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform spawnPoint;
    public float spawnInterval = 1f;
    public KeyCode[] possibleKeys = { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };
    
    private bool isSpawning = true;
    
    void Start()
    {
        StartCoroutine(SpawnNotes());
    }
    
    IEnumerator SpawnNotes()
    {
        while (isSpawning)
        {
            SpawnNote();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    void SpawnNote()
    {
        GameObject note = Instantiate(notePrefab, spawnPoint.position, Quaternion.identity);
        
        // Assign random key
        KeyCode randomKey = possibleKeys[Random.Range(0, possibleKeys.Length)];
        note.GetComponent<FallingNote>().keyToPress = randomKey;
        
        // Optional: color code by key
        // note.GetComponent<SpriteRenderer>().color = GetColorForKey(randomKey);
    }
    
    public void StopSpawning()
    {
        isSpawning = false;
    }
}