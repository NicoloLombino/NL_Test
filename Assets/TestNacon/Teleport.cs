using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //[SerializeField]
    //private Transform newPosition;

    //[SerializeField]
    //private GameObject teleportPanel;
    //[SerializeField]
    //private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        player = other.gameObject;
    //        StartCoroutine(Teleporting());
    //    }
    //}

    //private IEnumerator Teleporting()
    //{
    //    player.GetComponent<NaconPlayer>().canMove = false;
    //    yield return new WaitForSecondsRealtime(1f);
    //    teleportPanel.SetActive(true);
    //    yield return new WaitForSecondsRealtime(2);
    //    player.transform.position = newPosition.position + new Vector3(0, player.transform.localScale.y / 2, 0);
    //    teleportPanel.SetActive(false);
    //    yield return new WaitForSecondsRealtime(0.5f);
    //    player.GetComponent<NaconPlayer>().canMove = true;
    //}
}
