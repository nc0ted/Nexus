using UnityEngine;

namespace Car
{
    public class Steering : MonoBehaviour
    {
        private CarVisual _carVisual;

        private void Awake()
        {
            _carVisual = GetComponentInParent<CarVisual>();
        }

        private void Update()
        {
            transform.localRotation = Quaternion.Euler(0, 0, -_carVisual.RotAngle / 2.5f);
        }
    }
}
