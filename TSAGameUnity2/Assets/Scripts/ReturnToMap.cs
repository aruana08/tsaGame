using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMap : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("03_MainMap");
    }
}
