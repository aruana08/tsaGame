using UnityEngine;

public class CloseScreen : MonoBehaviour
{
    public GameObject instructionScreen;

    public void Close()
    {
        instructionScreen.SetActive(false);
    }
}
