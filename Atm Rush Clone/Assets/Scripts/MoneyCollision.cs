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
        // Get the reference to the money upgrade script.
        upgrader = gameObject.GetComponent<MoneyUpgrade>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if player is colliding with a money.
        if(other.gameObject.tag == "Money")
        {
            // If so, check if other money already have the money collect menager script.
            if (!MoneyCollectMenager.instance.moneys.Contains(other.gameObject))
            {
                // If so, it is no longer a collectable money but it is a collected money.
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Collected";
                // Check if other object have the money collision script.
                if(other.gameObject.GetComponent<MoneyCollision>() == null)
                {
                    // If it is not, then add the script.
                    other.gameObject.AddComponent<MoneyCollision>();
                    other.gameObject.GetComponent<MoneyCollision>().uiMoney = uiMoney;
                }
                else
                {
                    // If it is, then activate the script.
                    other.gameObject.GetComponent<MoneyCollision>().enabled = true;
                }
                // Add and stack the money.
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                MoneyCollectMenager.instance.StackMoney(other.gameObject, MoneyCollectMenager.instance.moneys.Count - 1);
                uiMoney.AddMoney(5 * other.gameObject.GetComponent<MoneyCollision>().status);
            }

        }
        // Check if any money is colliding with an obstacle.
        if (other.gameObject.tag == "Obstacle" && !IsPlayer)
        {
            // If it is, then destroy that money and subtract the amount from the UI money.
            MoneyCollectMenager.instance.DestroyMoney(gameObject,false);
        }
        // Check if any money is colliding with an atm.
        if (other.gameObject.tag == "Atm" && !IsPlayer)
        {
            // If it is, then destroy that money but don't subtract the money amount from UI money.
            MoneyCollectMenager.instance.DestroyMoney(gameObject,true);
        }
        // Check if any money is colliding with the upgrader.
        if (other.gameObject.tag == "Upgrade" && !IsPlayer && status <=2 )
        {
            // If it is, then change the money and status then add the upgraded amount to the UI money
            upgrader.ChangeMoney(status);
            uiMoney.AddMoney(5);
            status++;
        }
        // Check if any money is colliding with the finish.
        if (other.gameObject.tag == "Finish" && !IsPlayer)
        {
            // If it is, then call the money finish function.
            MoneyCollectMenager.instance.MoneyFinish(gameObject);
        }
        // Check if player is colliding with the finish.
        if (other.gameObject.tag == "Finish" && IsPlayer)
        {
            // If it is, stop the player.
            PlayerAnim.isRunning = false;
        }
    }
}
