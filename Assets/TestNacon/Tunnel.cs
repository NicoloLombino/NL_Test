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
            player.canMove = false;
            StartCoroutine(TunnelCoroutine(player.gameObject));
        }
        if(other.CompareTag("Arrow"))
        {
            arrow = other.gameObject;
            StartCoroutine(TunnelCoroutine(arrow));
        }
    }

    private IEnumerator TunnelCoroutine(GameObject objEnter)
    {
        for(int i = 0; i < tunnelZones.Length; i++)
        {
            objEnter.gameObject.transform.position = tunnelZones[i].position + new Vector3(0, player.transform.localScale.y / 2, 0);
            yield return new WaitForSecondsRealtime(0.2f);
        }
        player.canMove = true;
    }
}
