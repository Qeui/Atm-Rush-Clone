using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyCollectMenager : MonoBehaviour
{
    public static MoneyCollectMenager instance;
    public List<GameObject> moneys = new List<GameObject>();
    public Transform CollectableMoneys;
    [SerializeField] UiMoneyMenager uiMoney;
    private float followTime = 0.05f;

    private void Awake()
    {
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
        other.transform.parent = transform;
        Vector3 newPos = moneys[index].transform.position;
        newPos.z += 1.5f;
        other.transform.position = newPos;
        moneys.Add(other);
        StartCoroutine(StackMoneyEffect());
    }

    public void DestroyMoney(GameObject collidedMoney, int status, bool isAtm)
    {
        int index = moneys.IndexOf(collidedMoney);

        for (int i = moneys.Count; i > index; i--)
        {
            GameObject currentMoney = moneys[index];
            if(currentMoney == collidedMoney)
            {
                moneys.Remove(currentMoney);
                DOTween.Kill(currentMoney.transform);
                Destroy(currentMoney);
                if (!isAtm)
                {
                    uiMoney.RemoveMoney(status);
                }
            }
            else 
            {
                moneys.Remove(currentMoney);
                currentMoney.GetComponent<MoneyCollision>().enabled = false;
                currentMoney.transform.parent = CollectableMoneys;
                Vector3 jumpPos = currentMoney.transform.position + new Vector3(Random.Range(-3f,3f),0,Random.Range(0f,5f));
                currentMoney.transform.DOJump(jumpPos, 2, 1, 0.5f, false).OnComplete(() => MoneyJumpComplete(currentMoney));
                uiMoney.RemoveMoney(status);
            }
            print("count");
        }
        
    }

    private void MoneyJumpComplete(GameObject currentMoney)
    {
        currentMoney.GetComponent<BoxCollider>().isTrigger = true;
        currentMoney.tag = "Money";
        DOTween.Kill(currentMoney.transform);
    }

    private void MoveMoneys()
    {
        for (int i = 1; i < moneys.Count; i++)
        {
            Vector3 pos = moneys[i].transform.position;
            pos.x = moneys[i - 1].transform.position.x;
            moneys[i].transform.DOMoveX(pos.x, followTime);
        }
    }

    private void MoveMoneysToOrigin()
    {
        for(int i = 1; i < moneys.Count; i++)
        {
            Vector3 pos = moneys[i].transform.position;
            pos.x = moneys[0].transform.position.x;
            moneys[i].transform.DOMoveX(pos.x, 0.7f);
        }
    }

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
