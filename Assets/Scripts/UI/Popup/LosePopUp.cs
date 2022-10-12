using Model;
using TMPro;
using UnityEngine;
using Zenject;

public class LosePopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    private ScoreSystem _scoreSystem;
    
    [Inject]
    public void Construct(ScoreSystem scoreSystem)
    {
        _scoreSystem = scoreSystem;
    }

    private void OnEnable()
    {
        _scoreText.SetText(_scoreSystem.Score.ToString());
    }
}
