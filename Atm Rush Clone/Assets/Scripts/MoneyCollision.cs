using UnityEngine;

public class MoneyCollision : MonoBehaviour
{
    public bool IsPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Money")
        {
            if (!MoneyCollect.instance.moneys.Contains(other.gameObject))
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collected";
                other.gameObject.AddComponent<MoneyCollision>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                MoneyCollect.instance.StackMoney(other.gameObject, MoneyCollect.instance.moneys.Count - 1);
            }

        }

        if (other.gameObject.tag == "Obstacle" && !IsPlayer)
        {
            MoneyCollect.instance.RemoveMoney(gameObject);
        }
    }
}
