using UnityEngine;

namespace Car
{
    public class CarMovement : MonoBehaviour
    {
        [SerializeField] private float speed, breakSpeed, rotationSpeed;

        private CarVisual _carVisual;
        private Rigidbody _rb;
        private PlayerInputAct _playerInputAct;
        private float _yaw;
        private Vector3 rot;
        private void Awake()
        {
            Application.targetFrameRate = -1;
            _carVisual = GetComponent<CarVisual>();
            _rb = GetComponent<Rigidbody>();
            _playerInputAct = new PlayerInputAct();
            _playerInputAct.Player.Movement.performed += ctx => Movement();
        }

        private void FixedUpdate()
        {
            print(_rb.velocity.magnitude);
            Movement();
        }

        private void Movement()
        {
            float angleRot=0;
            float forwardForce = Input.GetAxis("Vertical")*speed*Time.deltaTime;
            float sideForce = Input.GetAxis("Horizontal")*rotationSpeed;
            _rb.AddRelativeForce(0,0,forwardForce);
            _yaw += sideForce * Time.deltaTime;
            transform.localRotation=Quaternion.Euler(transform.localRotation.x, _yaw,-_carVisual.RotAngle);
        }
    
        private void OnEnable()
        {
            _playerInputAct.Enable();
        }
        private void OnDisable()
        {
            _playerInputAct.Disable();
        }
    }
}
