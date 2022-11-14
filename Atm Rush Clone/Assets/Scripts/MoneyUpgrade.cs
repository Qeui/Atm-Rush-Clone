using UnityEngine;

public class MoneyUpgrade : MonoBehaviour
{

    public GameObject[] MoneyUpgardes;

    // Change the money depending on the status.
    public void ChangeMoney(int status)
    {
        for(int i = 0; i <= 2; i++)
        {
            if(i == status)
            {
                MoneyUpgardes[i].SetActive(true);
            }
            else
            {
                MoneyUpgardes[i].SetActive(false);
            }
        }
    }
}
