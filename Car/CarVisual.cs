using UnityEngine;

namespace Car
{
    public class CarVisual : MonoBehaviour
    {
        [SerializeField] private float rotSpeed;
        [SerializeField] private float maxRotation;
        [SerializeField] private float backToNormalRotationTime=0.3f;
        [SerializeField] private float velocityMultiplier;
        [SerializeField] private float velocityDivider;
    
        private float currVelocity;
        private Rigidbody _rb;
  
        public float RotAngle { get; set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            maxRotation = _rb.velocity.magnitude*velocityMultiplier;
            maxRotation /= velocityDivider;
            if (Input.GetKey(KeyCode.A))
            {
                if(RotAngle>-maxRotation)
                    RotAngle -= rotSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                if(RotAngle<maxRotation)
                    RotAngle += rotSpeed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Horizontal") == 0)
                RotAngle = Mathf.SmoothDamp(RotAngle, 0,ref currVelocity, backToNormalRotationTime);
        }
    }
}
