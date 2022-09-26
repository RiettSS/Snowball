using Model;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class FinishPopUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private ScoreSystem _scoreSystem;

    [Inject]
    public void Construct(ScoreSystem scoreSystem)
    {
        _scoreSystem = scoreSystem;
    }

    public void LoadScene(string sceneNum)
    {
        SceneManager.LoadSceneAsync(sceneNum);
    }

    private void OnEnable()
    {
        _scoreText.text = _scoreSystem.Score.ToString();
    }
}
