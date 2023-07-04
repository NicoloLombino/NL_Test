using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    [SerializeField]
    private NaconPlayer player;

    [SerializeField]
    private Transform[] tunnelZones;
    [SerializeField]
    private Collider tunnelEndZoneCol;
    [SerializeField]
    private Vector3 endRotation;

    [SerializeField]
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {        
            StopAllCoroutines();
            player.canMove = false;
            StartCoroutine(TunnelCoroutine(player.gameObject));
        }
        if(other.CompareTag("Arrow"))
        {
            arrow = other.gameObject;
            other.gameObject.GetComponent<Arrow>().speed = 0;
            StartCoroutine(TunnelCoroutine(arrow));
        }
    }

    private IEnumerator TunnelCoroutine(GameObject objEnter)
    {
        tunnelEndZoneCol.enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < tunnelZones.Length; i++)
        {
            objEnter.transform.position = tunnelZones[i].position + new Vector3(0, player.transform.localScale.y, 0);
            yield return new WaitForSecondsRealtime(0.2f);
        }
        if(arrow)
        {
            arrow.gameObject.GetComponent<Arrow>().speed = arrow.gameObject.GetComponent<Arrow>().startingSpeed;
            arrow.transform.eulerAngles = endRotation;
        }
        else
        {
            player.body.transform.eulerAngles = endRotation;
            player.canMove = true;
        }
        tunnelEndZoneCol.enabled = true;
    }
}
