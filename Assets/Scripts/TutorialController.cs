using System.Runtime.InteropServices;
using Model;
using UI.Popup;
using UnityEngine;
using Zenject;

public class TutorialController : MonoBehaviour
{
    private Tutorial _tutorial;
    private Ball _ball;

    [Inject]
    public void Construct(Tutorial tutorial, Ball ball)
    {
        _tutorial = tutorial;
        _ball = ball;
    }
    
    private void Start()
    {
        _ball.DisableControl();
        _tutorial.StartTutorial();
    }
}
