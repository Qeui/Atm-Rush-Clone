using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    public bool IsPlayer;

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

                MoneyCollectMenager.instance.StackMoney(other.gameObject, MoneyCollectMenager.instance.moneys.Count - 1);
            }

        }

        if (other.gameObject.tag == "Obstacle" && !IsPlayer)
        {
            MoneyCollectMenager.instance.RemoveMoney(gameObject);
        }
    }
}
