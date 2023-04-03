using System;
using Pool;
using UnityEngine;
using Utils;

namespace Projectile
{
    public class Projectile : MonoBehaviour, IPoolObject
    {
        public ProjectileType Type => ProjectileType.Default;
        
        [SerializeField] private float _speed;

        private Vector3 _direction;
        private bool _isInitialized;
        private Action _onCollision;

        public void Init(Vector3 direction, Action onCollision)
        {
            if (_isInitialized)
            {
                return;
            }
            
            _direction = direction;
            _onCollision = onCollision;
            _isInitialized = true;
        }
    
        private void Update()
        {
            if (_isInitialized == false)
            {
                return;
            }
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform == ObjectsScene.Wall)
            {
                _onCollision?.Invoke();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _isInitialized = false;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
