using UnityEngine;

public class ClickToShow : MonoBehaviour
{
    public GameObject instructionScreen;

    void OnMouseDown()
    {
        instructionScreen.SetActive(true);
    }
}
