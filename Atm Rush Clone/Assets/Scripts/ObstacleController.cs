using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{
    public bool SideWays, Pendulum;
    private float z = -180;

    // Start is called before the first frame update
    void Start()
    {
        if(SideWays && !Pendulum)
        {
            SideWaysObstacle();
        }
        else if (Pendulum && !SideWays)
        {
            PendulumObstacle();
        }
        else
        {
            Debug.LogWarning("!!Wrong Obstacle Choosed!!");
        }

    }

    private void SideWaysObstacle()
    {
        float x = transform.position.x;
        transform.DOMoveX( x + 16 , 3f, false).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void PendulumObstacle()
    {
        z = z * -1;
        transform.DORotate(new Vector3(0, 0, z), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine).OnComplete(() => PendulumObstacle());
    }
}
