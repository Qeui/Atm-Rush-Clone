using UnityEngine;
using DG.Tweening;

public class ObstacleController : MonoBehaviour
{
    public bool SideWays, Pendulum;
    private float z = -180;

    // Start is called before the first frame update
    void Start()
    {
        // Check if this is a sideways obstacle or a pendulum obtacle.
        if(SideWays && !Pendulum)
        {
            SideWaysObstacle();
        }
        else if (Pendulum && !SideWays)
        {
            PendulumObstacle();
        }
        // If it is both or none log a warning.
        else
        {
            Debug.LogWarning("!!Wrong Obstacle Choosed!!");
        }

    }
    // Move the sideways obstacle left and right.
    private void SideWaysObstacle()
    {
        float x = transform.position.x;
        transform.DOMoveX( x + 16 , 3f, false).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
    // Rotate the pendulum obtacle left and right.
    private void PendulumObstacle()
    {
        z = z * -1;
        transform.DORotate(new Vector3(0, 0, z), 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine).OnComplete(() => PendulumObstacle());
    }
}
