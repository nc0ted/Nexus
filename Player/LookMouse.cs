using UnityEngine;
using UnityEngine.InputSystem;

public class LookMouse : MonoBehaviour
{
    [SerializeField] private float sensitivity=100;
    [SerializeField] private Transform playerBody;

    private PlayerInput _playerInput;
    private float _defaultSensitivity=15;
    private PlayerInputAct _playerInputAct;
    private float _xRot;

    private void Awake()
    {
        _playerInput = GetComponentInParent<PlayerInput>();
        _playerInput.onControlsChanged += ChangeSensitivityForDevice;
        _playerInputAct = new PlayerInputAct();
        _playerInputAct.Player.GetMouse.started += ctx => MouseLook();
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    private void Update()
    {
        MouseLook();  
    }
    private void OnEnable()
    {
        _playerInputAct.Enable();
    }

    private void MouseLook()
    {
        var mouseVector =_playerInputAct.Player.GetMouse.ReadValue<Vector2>();
        var turnX = mouseVector.x * sensitivity * Time.deltaTime;
        var turnY = mouseVector.y * sensitivity * Time.deltaTime;

        _xRot -= turnY;
        _xRot = Mathf.Clamp(_xRot, -50, 50);
        
        transform.localRotation=Quaternion.Euler(_xRot,0,0);
        playerBody.Rotate(Vector3.up*turnX);
    }

    private void ChangeSensitivityForDevice(PlayerInput obj)
    {
        print(_playerInput.currentControlScheme);
        switch (_playerInput.currentControlScheme)
        {
            case "Gamepad":
                sensitivity *= 10;
                break;
            case "keyboard":
                sensitivity /= 10;
                break;
        }
    }
    private void OnDisable()
    {
        _playerInputAct.Disable();
    }

    public void IncreaseSensitivity()
    {
        sensitivity += 1;
    }

    public void DecreaseSensitivity()
    {
        sensitivity -= 1;
    }
}