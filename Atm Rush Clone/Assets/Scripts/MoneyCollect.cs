using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyCollect : MonoBehaviour
{
    public static MoneyCollect instance;
    public List<GameObject> moneys = new List<GameObject>();
    private float followTime = 0.25f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveMoneys();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MoveMoneysToOrigin();
        }
    }

    public void StackMoney(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = moneys[index].transform.position;
        newPos.z += 1;
        other.transform.position = newPos;
        moneys.Add(other);
        StartCoroutine(StackMoneyEffect());
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
        for (int i = 1; i < moneys.Count; i++)
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
            moneys[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
