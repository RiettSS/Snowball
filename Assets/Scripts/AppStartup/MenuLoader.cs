using UnityEngine;

public class MenuLoader : MonoBehaviour
{
    [SerializeField] private SceneLoader _loader;

    private void Start()
    {
        _loader.LoadScene("MainMenu");
    }
}
