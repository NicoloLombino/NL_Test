using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaconPlayer : MonoBehaviour
{
    CharacterController cc;

    [SerializeField]
    private GameObject body;
    [SerializeField]
    private float movementOffset;
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private Transform arrowShooter;

    internal bool canMove = true;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            ReadMovementKey2();
            //cc.Move(Vector3.down * 10 * Time.deltaTime);
            //cc.Move(-transform.up * 10);
            ReadArrowKey();
        }

    }

    private void ReadMovementKey()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            //transform.Translate(Vector3.forward * movementOffset);
            cc.Move(Vector3.forward * movementOffset);
            transform.position += new Vector3(0, 0, movementOffset);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-movementOffset, 0, 0);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -movementOffset);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(movementOffset, 0, 0);

        }
    }

    private void ReadMovementKey2()
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
        if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, 2f, LayerMask.GetMask("Wall")))
        {
            transform.position += direction * movementOffset;
        }
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
}
