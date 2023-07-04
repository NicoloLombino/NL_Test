using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaconPlayer : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    internal GameObject body;
    //[SerializeField]
    //private Camera camera;
    [SerializeField]
    private float movementOffset;
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private Transform arrowShooter;

    internal bool canMove = true;

    void Update()
    {
        if (canMove)
        {
            ReadMovementKey();
            ReadArrowKey();
        }
        SeeInFogOfWar();
    }


    private void ReadMovementKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CheckCollisionAndMove(transform.forward, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CheckCollisionAndMove(-transform.right, -90);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckCollisionAndMove(-transform.forward, 180);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CheckCollisionAndMove(transform.right, 90);
        }
    }

    private void CheckCollisionAndMove(Vector3 direction, float rotY)
    {
        if (body.transform.eulerAngles.y != rotY)
        {
            body.transform.eulerAngles = new Vector3(0, rotY, 0);
        }
        if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, 2f, LayerMask.GetMask("Wall")) || hit.collider.isTrigger)
        {
            Vector3 actualPosition = transform.position;
            Vector3 nextPosition = transform.position + direction * movementOffset;
            StartCoroutine(Move(actualPosition, nextPosition));    
        }
    }

    private IEnumerator Move(Vector3 startPosition, Vector3 newPosition)
    {
        canMove = false;
        float percentageTimer = 0;
        float timer = 0;
        while (percentageTimer <= 1)
        {
            Debug.Log("while");
            transform.position = Vector3.Lerp(startPosition, newPosition, percentageTimer);
            timer += Time.deltaTime;
            percentageTimer = timer / 0.1f;
            yield return null;
        }
        canMove = true;
        transform.position = newPosition;
        //transform.position = new Vector3((int)/*Mathf.FloorToInt(*/transform.position.x, (int)/*Mathf.FloorToInt(*/transform.position.y, (int)/*Mathf.FloorToInt(*/transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, body.transform.forward * 2f);
    }

    private void ReadArrowKey()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            RotateAndShoot(0);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            RotateAndShoot(-90);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            RotateAndShoot(180);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            RotateAndShoot(90);
        }
    }

    private void RotateAndShoot(float angle)
    {
        body.transform.localEulerAngles = new Vector3(0, angle, 0);
        GameObject arrow = Instantiate(arrowPrefab, arrowShooter.position, body.transform.rotation);
    }
    private void SeeInFogOfWar()
    {
        if (Physics.Raycast(transform.position, transform.up, out RaycastHit hit, 10, LayerMask.GetMask("FogOfWar")))
        {
            Destroy(hit.collider.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Teleport"))
        {
            gameManager.TeleportPlayer(this);
            StopAllCoroutines();
        }
        if (other.gameObject.layer == 9)
        {
            StopAllCoroutines();
            canMove = false;
        }
        //if (other.CompareTag("WarningArea"))
        //{
        //    switch(other.get)
        //}
    }
}
