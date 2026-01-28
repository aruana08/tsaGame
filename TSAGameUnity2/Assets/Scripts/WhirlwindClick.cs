using UnityEngine;

public class WhirlwindClick : MonoBehaviour
{
    public Tornado tornadoManager;

    void OnMouseDown()
    {
        tornadoManager.TornadoClicked();
    }
}
