using UnityEngine;

namespace Player
{
    public class CharacCtrl : MonoBehaviour
    {
        [SerializeField] private float speed=12;
        [SerializeField] private float jumpForce;
        [SerializeField] Animator camAnimator;

        private bool _isSprinting;
        private PlayerInputAct _playerInputAct;
        private float gravity = -20;
        private CharacterController _controller;
        private Vector3 velocty;
        private static readonly int IsSprinting = Animator.StringToHash("isSprinting");

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            _playerInputAct = new PlayerInputAct();
            _controller = GetComponent<CharacterController>();
            _playerInputAct.Player.Movement.performed += ctx=>  Movement();
            _playerInputAct.Player.Sprint.started += ctx => StartSprint();
            _playerInputAct.Player.Sprint.canceled += ctx => EndSprint();
            _playerInputAct.Player.Jump.started += ctx => Jump();
        }

        private void Update()
        {
            Movement();

            velocty.y += gravity * Time.deltaTime; 
            _controller.Move(velocty * Time.deltaTime);
        }

        private void Movement()
        {
            Vector3 moveVector = _playerInputAct.Player.Movement.ReadValue<Vector2>();
            moveVector = transform.right * moveVector.x + transform.forward* moveVector.y;
            _controller.Move(moveVector * (speed * Time.deltaTime));
        }

        private void Jump()
        {
            camAnimator.SetBool(IsSprinting,false);
            if (_controller.isGrounded)
               velocty.y = Mathf.Sqrt(jumpForce);
            Invoke(nameof(ActivateHeadBob),0.5f);
            
        }

        private void StartSprint()
        {
            _isSprinting = true;
            camAnimator.SetBool(IsSprinting,true);
            speed += 3f;
        }

        private void EndSprint()
        {
            _isSprinting = false;
            camAnimator.SetBool(IsSprinting,false);
            speed -= 3f;
        }

        private void ActivateHeadBob()
        {
            if (!_controller.isGrounded) {Invoke(nameof(ActivateHeadBob), 0.3f);return;}
            if(_isSprinting)
                camAnimator.SetBool(IsSprinting,true);
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