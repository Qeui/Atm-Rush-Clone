using UnityEngine;
using TMPro;

public class UiMoneyMenager : MonoBehaviour
{
    private int moneyUI = 0;
    public static UiMoneyMenager instance;
    public TextMeshProUGUI MoneyText;
    public TextMeshProUGUI FinishMoneyText;

    // Update is called once per frame
    void Update()
    {
        // Update the money counts.
        MoneyText.text = moneyUI.ToString();
        FinishMoneyText.text = "Collected: " + moneyUI.ToString();
    }
    // Add the given amount to the moneyUI.
    public void AddMoney(int amount)
    {
        moneyUI += amount;
    }
    // Subtract money from the moneyUI depending on the given status.
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
