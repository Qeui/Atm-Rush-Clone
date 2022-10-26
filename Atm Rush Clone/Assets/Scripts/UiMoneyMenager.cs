using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiMoneyMenager : MonoBehaviour
{
    private int moneyUI = 0;
    public static UiMoneyMenager instance;
    public TextMeshProUGUI MoneyText;

    // Update is called once per frame
    void Update()
    {
        MoneyText.text = moneyUI.ToString();
    }

    public void AddMoney(int amount)
    {
        moneyUI += amount;
    }

    public void RemoveMoney(int status)
    {
        switch (status)
        {
            case 1:
                moneyUI -= 5;
                break;
            case 2:
                moneyUI -= 10;
                break;
            case 3:
                moneyUI -= 15;
                break;
            default:
                break;
        }
    }
}
