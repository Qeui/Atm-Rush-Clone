using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    public MoneyCollectMenager moneyCollectMenager;
    public bool isInFront = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            other.gameObject.tag = "Collected";
            moneyCollectMenager.CollectMoney(other.gameObject.GetComponent<Collider>(), isInFront, gameObject);
            isInFront = false;
        }
    }
}
