using UnityEngine;

namespace Car
{
    public class TakeOffControl : MonoBehaviour
    {
        [SerializeField] private float takeOffSpeed;
        private PlayerInputAct _playerInputAct;

        private void Awake()
        {
            _playerInputAct = new PlayerInputAct();
        }

        private void Update()
        {
            if(Input.GetMouseButton(0))
                GoUp();
            if(Input.GetMouseButton(1))
                GoDown();
        }

        private void GoUp()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * takeOffSpeed,transform.position.z);
        }

        private void GoDown()
        {
            transform.position = new Vector3(transform.position.x,transform.position.y-Time.deltaTime*takeOffSpeed,transform.position.z);
        }
    }
}