using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 offset;

    void Update()
    {
        gameObject.transform.position = player.transform.position + offset;
    }
}
