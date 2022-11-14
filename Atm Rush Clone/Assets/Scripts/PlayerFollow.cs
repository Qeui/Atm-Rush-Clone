using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
    public int FollowSpeed;

    // Update is called once per frame
    void Update()
    {
        // Follow the player's position smoothly and add a offset to it.
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, Time.deltaTime * FollowSpeed);
    }
}
