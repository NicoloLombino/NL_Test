using UnityEngine;

public class RotatePlayerOnTunnel : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationToGive;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.eulerAngles = rotationToGive;
        }
        if (other.CompareTag("Arrow"))
        {
            other.transform.eulerAngles = rotationToGive;
        }
    }
}
