using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text dialogueText;

    public string[] lines;

    int currentLine = 0;
    bool playerNear = false;

    void Update()
    {
        if (dialogueBox.activeSelf && Input.GetMouseButtonDown(0))
        {
            NextLine();
        }
    }

    void OnMouseDown()
    {
        if (playerNear)
            ShowDialogue();
    }

    void ShowDialogue()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = lines[currentLine];
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine < lines.Length)
            dialogueText.text = lines[currentLine];
        else
        {
            dialogueBox.SetActive(false);
            currentLine = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}
