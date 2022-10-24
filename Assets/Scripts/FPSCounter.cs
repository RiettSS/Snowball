using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private bool _showFps;
    
    public TMP_Text display_Text;
    private int _avgFrameRate;

    private void Awake()
    {
        Application.targetFrameRate = 100;
        DontDestroyOnLoad(gameObject);

        if (!_showFps)
        {
            display_Text.gameObject.SetActive(false);
        }
    }

    public void Update ()
    {
        if (!_showFps)
            return;
        
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        _avgFrameRate = (int)current;
        display_Text.text = _avgFrameRate.ToString() + " FPS";
    }
}
