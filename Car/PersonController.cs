using UnityEngine;
using UnityEngine.Serialization;

namespace Car
{
    public class PersonController : MonoBehaviour
    {
        [SerializeField] private Transform firstPersonPos,thirdPersonPos;
        [SerializeField] private GameObject firstPersonCar, thirdPersonCar;
        [FormerlySerializedAs("camera")] [SerializeField] private Transform cam;

        private bool _thirdPerson=true;
        private PlayerInputAct _playerInputAct;

        private void Awake()
        {
            _playerInputAct = new PlayerInputAct();
            _playerInputAct.Car.ChangeView.started += ctx => ChangePerson();
            ChangePerson();
        }
        private void ChangePerson()
        {
            _thirdPerson = !_thirdPerson;
            print(_thirdPerson+ " 1 person");
            if (_thirdPerson)
            {
                firstPersonCar.SetActive(true);
                thirdPersonCar.SetActive(false);
                cam.position = firstPersonPos.position;
            }
            else
            {
                thirdPersonCar.SetActive(true);
                firstPersonCar.SetActive(false);
                cam.position = thirdPersonPos.position;
            }
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
