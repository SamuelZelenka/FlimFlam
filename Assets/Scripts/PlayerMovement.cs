using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private int movementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    public void move(){

        Vector3 nextPosition = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow)){
            
            nextPosition += new Vector3(0, 1, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow)){

            nextPosition += new Vector3(0, -1, 0);

        }

        if (Input.GetKey(KeyCode.RightArrow)){

            nextPosition += new Vector3(1, 0, 0);

        }

        if (Input.GetKey(KeyCode.LeftArrow)){

            nextPosition += new Vector3(-1, 0, 0);

        }

        nextPosition = nextPosition.normalized;

        myRigidBody.MovePosition(transform.position + nextPosition * Time.deltaTime * movementSpeed);
    }
}
