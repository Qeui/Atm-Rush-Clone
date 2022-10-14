using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SideWaysObstacle();
    }

    private void SideWaysObstacle()
    {
        float x = transform.position.x;
        transform.DOMoveX( x + 16 , 3f, false).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void PendulumObstacle()
    {

    }
}
