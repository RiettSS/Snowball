using UnityEngine;
using Zenject;

namespace Camera
{
    public class CameraMovement : MonoBehaviour, IInitializable
    {
        [SerializeField] private float _x;
        [SerializeField] private float _y;
        [SerializeField] private float _z;

        private BallView _view;
        private Vector3 _offset;

        [Inject]
        public void Construct(BallView view)
        {
            _view = view;
        }
        
        public void Initialize()
        {
            _offset = new Vector3(_x, _y, _z);
        }

        private void Update()
        {
            transform.position = _view.transform.position + _offset;
        }
    }
}
