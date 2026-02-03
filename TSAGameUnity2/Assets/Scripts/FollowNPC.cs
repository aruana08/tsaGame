using UnityEngine;

public class FollowNPC : MonoBehaviour
{
    public Transform npc;
    public Vector3 offset;

    void Update()
    {
        transform.position = npc.position + offset;
    }
}
