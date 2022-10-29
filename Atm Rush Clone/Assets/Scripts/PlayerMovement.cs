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
        if (PlayerAnim.isRunning)
        {
            //transform.position += Vector3.forward * MovementSpeed * Time.deltaTime;
            Player.DOMoveZ(Player.transform.position.z + 1, 0.2f, false);
            Move();
        }
        
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            float difX = endPos.x - firstPos.x;
            transform.Translate(difX * Time.deltaTime * HorizontalSpeed, 0, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
    }
}
