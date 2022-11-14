using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fpsText;
    [SerializeField] private float _hudRefreshRate = 1f;

    private float _timer;

    private void Start()
    {
        // Default frame rate is 30 in android, this part changes that to 60.
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        // Calculate the frame rate based on frame delta
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}
