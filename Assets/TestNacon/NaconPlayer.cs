using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaconPlayer : MonoBehaviour
{
    CharacterController cc;

    [SerializeField]
    private float movementOffset;

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
            //ReadArrowKey();
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
            CheckCollisionAndMove(transform.forward);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CheckCollisionAndMove(-transform.right);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckCollisionAndMove(-transform.forward);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CheckCollisionAndMove(transform.right);
        }
    }

    private void CheckCollisionAndMove(Vector3 direction)
    {
        if (!Physics.Raycast(transform.position, direction, out RaycastHit hit, 2.0f, LayerMask.GetMask("Wall")))
        {
            transform.position += direction * movementOffset;
        }
    }

    private void ReadArrowKey()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
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
}