using UnityEngine;

public class Rotator : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.Rotate(.2f,.2f,.2f);
    }
}
