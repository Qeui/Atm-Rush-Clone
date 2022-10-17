using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyUpgrade : MonoBehaviour
{

    public GameObject[] MoneyUpgardes;

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
