using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    [SerializeField]
    private NaconPlayer player;

    [SerializeField]
    private Transform[] tunnelZones;

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
            StartCoroutine(TunnelCoroutine());
        }       
    }

    private IEnumerator TunnelCoroutine()
    {
        for(int i = 0; i < tunnelZones.Length; i++)
        {
            player.gameObject.transform.position = tunnelZones[i].position + new Vector3(0, player.transform.localScale.y / 2, 0);
            yield return new WaitForSecondsRealtime(0.2f);
        }
        player.canMove = true;
    }
}
