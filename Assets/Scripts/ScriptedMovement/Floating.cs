
using UnityEngine;

public class Floating : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private void Update()
    {
        transform.position = Vector3.Lerp(_pointA.position, _pointB.position, CalculateTransitionPercentage());
    }

    private float CalculateTransitionPercentage()
    {
        return Mathf.Abs(Mathf.Cos(Time.time * _speed));
    }
}
