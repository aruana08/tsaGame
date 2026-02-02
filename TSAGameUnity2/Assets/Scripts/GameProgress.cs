using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance;

    public bool WaterStone;
    public bool ForestStone;
    public bool AirStone;
    public bool FireStone;

    public int emeraldsCollected;

    private bool level5Loaded = false; // prevents multiple loads

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        CheckFinalUnlock();
    }

    void CheckFinalUnlock()
    {
        if (level5Loaded) return;

        if (WaterStone && ForestStone && AirStone && FireStone)
        {
            level5Loaded = true;
            Debug.Log("ALL STONES COLLECTED — LOADING 08_Level5");
            SceneManager.LoadScene("08_Level5");
        }
    }

    // Optional helper
    public bool AllStonesCollected()
    {
        return WaterStone && ForestStone && AirStone && FireStone;
    }
}
