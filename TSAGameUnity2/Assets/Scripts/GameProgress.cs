using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance;

    public bool waterStone;
    public bool forestStone;
    public bool airStone;
    public bool fireStone;
    //public bool memoryStone; // tracks Memory Puzzle emerald


    public int emeraldsCollected = 0; // new

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEmerald()
    {
        emeraldsCollected++;
        Debug.Log("Emerald collected! Total: " + emeraldsCollected);
    }
}
