using UnityEngine;

namespace BallFeatures
{
    public class Movement : MonoBehaviour, IMovement
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _accelerationFactor;
        [SerializeField] private float _strafeFactor;

        private bool _isMovingAllowed = true;
        private const int _gravityFactor = 75;
    
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        private void Update()
        {
            if(_isMovingAllowed)
                MoveForward();
            
            AddGravity();
        }
        
        public void MoveLeft()
        {
            if(_isMovingAllowed)
                _rigidbody.AddForce(Vector3.left * _strafeFactor * Time.deltaTime);
        }

        public void MoveRight()
        {
            if(_isMovingAllowed)
                _rigidbody.AddForce(Vector3.right * _strafeFactor * Time.deltaTime);
        }

        public void StartMovement()
        {
            _isMovingAllowed = true;
        }

        public void StopMovement()
        {
            _isMovingAllowed = false;
        }
        
        private void MoveForward()
        {
            if(_rigidbody.velocity.z < _maxSpeed)
                _rigidbody.AddForce(Vector3.forward * (_accelerationFactor * Time.deltaTime));
        }

        private void AddGravity()
        {
            _rigidbody.AddForce(Vector3.down * _gravityFactor);
        }
    }
}
