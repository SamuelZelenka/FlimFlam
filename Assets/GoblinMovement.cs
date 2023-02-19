using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class GoblinMovement : MonoBehaviour
{

    Transform target;
    Rigidbody2D myRigidBody;

    [SerializeField]
    private float goblinMovementSpeed = 1;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsTarget(target);
    }

    private void moveTowardsTarget(Transform target){

        Vector3 nextPosition = (transform.position - target.position).normalized;

         myRigidBody.MovePosition(transform.position - nextPosition * Time.deltaTime * goblinMovementSpeed);
    }
}
