using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    public bool IsPlayer;
    public MoneyUpgrade upgrader;
    public PlayerAnimController PlayerAnim;
    [SerializeField] UiMoneyMenager uiMoney;
    public int status = 1;

    private void Start()
    {
        upgrader = gameObject.GetComponent<MoneyUpgrade>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Money")
        {
            if (!MoneyCollectMenager.instance.moneys.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collected";

                if(other.gameObject.GetComponent<MoneyCollision>() == null)
                {
                    other.gameObject.AddComponent<MoneyCollision>();
                    other.gameObject.GetComponent<MoneyCollision>().uiMoney = uiMoney;
                }
                else
                {
                    other.gameObject.GetComponent<MoneyCollision>().enabled = true;
                }
                
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                MoneyCollectMenager.instance.StackMoney(other.gameObject, MoneyCollectMenager.instance.moneys.Count - 1);
                uiMoney.AddMoney(5 * other.gameObject.GetComponent<MoneyCollision>().status);
            }

        }

        if (other.gameObject.tag == "Obstacle" && !IsPlayer)
        {
            MoneyCollectMenager.instance.DestroyMoney(gameObject, status,false);
        }

        if(other.gameObject.tag == "Atm" && !IsPlayer)
        {
            MoneyCollectMenager.instance.DestroyMoney(gameObject, status,true);
        }

        if (other.gameObject.tag == "Upgrade" && !IsPlayer && status <=2 )
        {
            upgrader.ChangeMoney(status);
            uiMoney.AddMoney(5);
            status++;
        }

        if(other.gameObject.tag == "Finish" && !IsPlayer)
        {
            MoneyCollectMenager.instance.MoneyFinish(gameObject);
        }

        if (other.gameObject.tag == "Finish" && IsPlayer)
        {
            PlayerAnim.isRunning = false;
        }
    }
}
