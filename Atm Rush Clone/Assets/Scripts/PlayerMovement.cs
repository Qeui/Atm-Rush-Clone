using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Transform Player;
    public PlayerAnimController PlayerAnim;
    public float MovementSpeed;
    public float HorizontalSpeed;
    private Vector3 firstPos, endPos;

    // Update is called once per frame
    void Update()
    {
        // Check if the player is running.
        if (PlayerAnim.isRunning)
        {
            // If player is running, it moves player forward and runs the move function.
            Player.DOMoveZ(Player.transform.position.z + MovementSpeed, 0.2f, false);
            Move();
        }
    }

    // Move player left or right depending on the mouse position change.
    private void Move()
    {
        // Get the first mouse position.
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        // Get the current mouse position and change the player position acording to the difference between these positions.
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            float difX = endPos.x - firstPos.x;
            transform.Translate(difX * Time.deltaTime * HorizontalSpeed, 0, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);
        }
        // Reset the mouse positions.
        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }
}
