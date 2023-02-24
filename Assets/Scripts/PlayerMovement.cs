using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private int movementSpeed = 1;

    private Vector3 nextPosition;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        InputManager.RegisterKey(InputKeyState.KeyHold, MoveUp, KeyCode.UpArrow, KeyCode.W);
        InputManager.RegisterKey(InputKeyState.KeyHold, MoveDown, KeyCode.DownArrow, KeyCode.S);
        InputManager.RegisterKey(InputKeyState.KeyHold, MoveRight, KeyCode.RightArrow, KeyCode.D);
        InputManager.RegisterKey(InputKeyState.KeyHold, MoveLeft, KeyCode.LeftArrow, KeyCode.A);
    }
    public void MoveUp() => nextPosition += Vector3.up;
    public void MoveDown() => nextPosition += Vector3.down;
    public void MoveRight() => nextPosition += Vector3.right;
    public void MoveLeft() => nextPosition += Vector3.left;

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        nextPosition = transform.position + (nextPosition.normalized * Time.deltaTime * movementSpeed);
        myRigidBody.MovePosition(nextPosition);
        nextPosition = Vector3.zero;
    }
}
