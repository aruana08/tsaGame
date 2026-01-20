using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [Header("Characters")]
    public GameObject player0;
    public GameObject player1;

    private SpriteRenderer r0;
    private SpriteRenderer r1;

    private Color normal = Color.white;
    private Color selected = Color.yellow;

    void Start()
    {
        r0 = player0.GetComponent<SpriteRenderer>();
        r1 = player1.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (!hit) return;

            if (hit.collider.gameObject == player0)
                Select(1);
            else if (hit.collider.gameObject == player1)
                Select(2);
        }
    }

    void Select(int id)
    {
        CharacterSelection.selectedCharacter = id;

        r0.color = (id == 1) ? selected : normal;
        r1.color = (id == 2) ? selected : normal;
    }

    public void StartGame()
    {
        if (CharacterSelection.selectedCharacter == 0)
        {
            Debug.Log("Select a character first!");
            return;
        }

        SceneManager.LoadScene("03_MainMap");
    }
}
