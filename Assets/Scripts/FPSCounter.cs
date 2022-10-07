using System;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text display_Text;
    
    private int _avgFrameRate;

    private void Awake()
    {
        Application.targetFrameRate = 100;
        DontDestroyOnLoad(gameObject);
    }

    public void Update ()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        _avgFrameRate = (int)current;
        display_Text.text = _avgFrameRate.ToString() + " FPS";
    }
}
