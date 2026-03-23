using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public void OnNoteHit()
    {
        Debug.Log("Hit!");
    }

    public void OnNoteMiss()
    {
        Debug.Log("Miss!");
    }
}