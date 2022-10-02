using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMovement : MonoBehaviour
{
    public bool PlayerMoney;
    public float MoneyDist = 2;
    public Transform Target;
    private Vector3 thisMoneyPos;

    private void Start()
    {
        if (PlayerMoney)
        {
            MoneyDist = 5;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float xPosValue = Mathf.Lerp(transform.position.x, Target.position.x, Time.deltaTime * 8);
        thisMoneyPos = new Vector3(xPosValue, 0, Target.position.z + MoneyDist);
        transform.position = thisMoneyPos;
    }
}
