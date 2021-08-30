using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Updater
    void Update()
    {
        transform.position = player.transform.position + new Vector3(-1f, 25.6f, -9f);
    }
}
