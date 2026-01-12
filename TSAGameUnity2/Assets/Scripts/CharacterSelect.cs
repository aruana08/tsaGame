using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public string characterID;
    public GameObject selectionCircle;

    private static CharacterSelect currentlySelected;

    void Start()
    {
        selectionCircle.SetActive(false);
    }

    void OnMouseDown()
    {
        // Turn off previous selection
        if (currentlySelected != null)
        {
            currentlySelected.selectionCircle.SetActive(false);
        }

        // Select this one
        currentlySelected = this;
        selectionCircle.SetActive(true);

        PlayerPrefs.SetString("SelectedCharacter", characterID);
        PlayerPrefs.Save();

        Debug.Log("Selected: " + characterID);
    }
}
