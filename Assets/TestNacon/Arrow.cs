using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    internal float speed;
    [SerializeField]
    private Rigidbody rb;

    internal float startingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startingSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            Destroy(other);
        }

        if(other.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
