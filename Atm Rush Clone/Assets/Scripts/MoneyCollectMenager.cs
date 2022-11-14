using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyCollectMenager : MonoBehaviour
{
    public static MoneyCollectMenager instance;
    public List<GameObject> moneys = new List<GameObject>();
    public Transform CollectableMoneys;
    public Transform Collector;
    [SerializeField] UiMoneyMenager uiMoney;
    private float followTime = 0.05f;

    private void Awake()
    {
        // Set the tweens capacity and the instance.
        DOTween.SetTweensCapacity(3000, 50);

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        MoveMoneys();
    }
    
    public void StackMoney(GameObject other, int index)
    {
        // Get the position of the money in front of the stack
        other.transform.parent = transform;
        Vector3 newPos = moneys[index].transform.position;
        newPos.z += 1.5f;
        // Change collected money's position to that.
        other.transform.position = newPos;
        moneys.Add(other);
        StartCoroutine(StackMoneyEffect());
    }

    public void DestroyMoney(GameObject collidedMoney, bool isAtm)
    {
        // Get the index of the collected money.
        int index = moneys.IndexOf(collidedMoney);

        // Do these for every money on the stack.
        for (int i = moneys.Count; i > index; i--)
        {
            
            GameObject currentMoney = moneys[index];
            int status = currentMoney.GetComponent<MoneyCollision>().status;

            // Check if the current money is the collided money.
            if (currentMoney == collidedMoney)
            {
                // If it is, then destroy that money.
                moneys.Remove(currentMoney);
                DOTween.Kill(currentMoney.transform);
                Destroy(currentMoney);
                // If it is collided with atm, don't subtract the money amount.
                if (!isAtm)
                {
                    uiMoney.RemoveMoney(status);
                }
            }
            else 
            {
                // These are the money in front of the collided money.
                // Remove these moneys from the money list.
                moneys.Remove(currentMoney);
                currentMoney.GetComponent<MoneyCollision>().enabled = false;
                currentMoney.transform.parent = CollectableMoneys;
                // Make them jump to the random direction and subtract the money amount from the moneyUI.
                Vector3 jumpPos = currentMoney.transform.position + new Vector3(Random.Range(-3f,3f),0,Random.Range(0f,5f));
                currentMoney.transform.DOJump(jumpPos, 2, 1, 0.5f, false).OnComplete(() => MoneyJumpComplete(currentMoney));
                uiMoney.RemoveMoney(status);
            }
        }
        
    }
    // Remove moneys from the list and move them to the collector.
    public void MoneyFinish(GameObject finishedMoney)
    {
        finishedMoney.transform.parent = CollectableMoneys;
        moneys.Remove(finishedMoney);
        finishedMoney.transform.DOMoveX(Collector.position.x, 0.5f, false).SetEase(Ease.Linear).OnComplete(() => Destroy(finishedMoney.gameObject));
    }
    // This is called after moneys complete their jump.
    private void MoneyJumpComplete(GameObject currentMoney)
    {
        currentMoney.GetComponent<BoxCollider>().isTrigger = true;
        currentMoney.tag = "Money";
        DOTween.Kill(currentMoney.transform);
    }
    // Move moneys smoothly and make them follow the first money on the stack.
    private void MoveMoneys()
    {
        for (int i = 1; i < moneys.Count; i++)
        {
            Vector3 pos = moneys[i].transform.position;
            pos.x = moneys[i - 1].transform.position.x;
            moneys[i].transform.DOMoveX(pos.x, followTime);
        }
    }
    // This is not used now but it just move moneys to the center.
    private void MoveMoneysToOrigin()
    {
        for(int i = 1; i < moneys.Count; i++)
        {
            Vector3 pos = moneys[i].transform.position;
            pos.x = moneys[0].transform.position.x;
            moneys[i].transform.DOMoveX(pos.x, 0.7f);
        }
    }
    // Scale the moneys 1.2 times and then scale them back, giving a nice collecting effect.
    private IEnumerator StackMoneyEffect()
    {
        for(int i = moneys.Count - 1; i >0; i--)
        {
            int index = i;
            Vector3 FirstScale = moneys[i].transform.localScale;
            Vector3 Scale = FirstScale;
            Scale *= 1.2f;

            moneys[index].transform.DOScale(Scale, 0.1f).OnComplete(() =>
            moneys[index].transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
