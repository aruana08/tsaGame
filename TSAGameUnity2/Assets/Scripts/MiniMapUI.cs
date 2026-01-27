using UnityEngine;

public class MiniMapUI : MonoBehaviour
{
    public GameObject miniMapPanel;
    public Transform player;

    public Transform waterDropPoint;
    public Transform forestDropPoint;
    public Transform airDropPoint;
    public Transform fireDropPoint;

    public void ToggleMap()
    {
        miniMapPanel.SetActive(!miniMapPanel.activeSelf);
    }

    public void GoToWater()
    {
        player.position = waterDropPoint.position;
        miniMapPanel.SetActive(false);
    }

    public void GoToForest()
    {
        player.position = forestDropPoint.position;
        miniMapPanel.SetActive(false);
    }

    public void GoToAir()
    {
        player.position = airDropPoint.position;
        miniMapPanel.SetActive(false);
    }

    public void GoToFire()
    {
        player.position = fireDropPoint.position;
        miniMapPanel.SetActive(false);
    }
}
