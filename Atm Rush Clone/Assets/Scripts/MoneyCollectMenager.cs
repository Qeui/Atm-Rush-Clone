using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollectMenager : MonoBehaviour
{
    public Transform CollectedMoneys;
    public Transform TargetMoney;
    public Transform SavedMoney;
    public GameObject curMoney;

    public void CollectMoney(Collider other, bool isInFront, GameObject obj)
    {
        curMoney = other.gameObject;

        if(other.gameObject.GetComponent<MoneyCollector>() == null && other.gameObject.GetComponent<MoneyMovement>() == null)
        {
            curMoney.transform.parent = CollectedMoneys;
            curMoney.AddComponent<MoneyCollector>();
            curMoney.GetComponent<MoneyCollector>().moneyCollectMenager = this;
            curMoney.AddComponent<MoneyMovement>();

            if (isInFront)
            {
                TargetMoney = obj.transform;
                SavedMoney = other.transform;
                curMoney.GetComponent<MoneyMovement>().Target = TargetMoney;
            }
            else
            {
                TargetMoney = SavedMoney;
                SavedMoney = other.transform;
                curMoney.GetComponent<MoneyMovement>().Target = TargetMoney;
            }

            curMoney.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

}
