using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    public bool IsPlayer;
    public MoneyUpgrade upgrader;
    public int status = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Money")
        {
            if (!MoneyCollectMenager.instance.moneys.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collected";
                other.gameObject.AddComponent<MoneyCollision>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                upgrader = gameObject.GetComponent<MoneyUpgrade>();
                MoneyCollectMenager.instance.StackMoney(other.gameObject, MoneyCollectMenager.instance.moneys.Count - 1);
            }

        }

        if (other.gameObject.tag == "Obstacle" && !IsPlayer)
        {
            MoneyCollectMenager.instance.RemoveMoney(gameObject);
        }

        if(other.gameObject.tag == "Atm" && !IsPlayer)
        {
            MoneyCollectMenager.instance.RemoveMoney(gameObject);
        }

        if (other.gameObject.tag == "Upgrade" && !IsPlayer)
        {
            print("Upgrade");
            upgrader.ChangeMoney(status);
            status++;
        }
    }
}
