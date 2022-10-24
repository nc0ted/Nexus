using UnityEngine;

namespace Car
{
    public class CarSounds : MonoBehaviour
    {
        [SerializeField] private AudioSource carMovementSound;
        [SerializeField] private float velocityDivider=100;
        [SerializeField] private float velocityMultiplier=10;

        private float currVelo;
        private Rigidbody _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            print(_rb.velocity.magnitude);
            if(_rb.velocity.magnitude>=5*velocityMultiplier)
                carMovementSound.pitch = _rb.velocity.magnitude/velocityDivider;
        }
    }
}