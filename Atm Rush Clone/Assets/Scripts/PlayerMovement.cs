using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float HorSpeed;
    private float hor;
   
    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(hor * HorSpeed * Time.deltaTime, 0, MovementSpeed * Time.deltaTime));
        transform.position = (new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), transform.position.y, transform.position.z)); 
    }
}
