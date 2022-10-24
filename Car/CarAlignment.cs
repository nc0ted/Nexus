using UnityEngine;

namespace Car
{
    public class CarAlignment : MonoBehaviour
    {
        [SerializeField] private float goDownRange,alignmentSpeed,goUpRange;
        [SerializeField] private bool enableGoDownAlignment;
        void Update()
        {
            if (enableGoDownAlignment)
            {
                if (!Physics.Raycast(transform.position, Vector3.down, out var hit, goDownRange))
                {
                    var transform1 = transform;
                    var position = transform1.position;
                    position = new Vector3(position.x, position.y - Time.deltaTime * alignmentSpeed, position.z);
                    transform1.position = position;
                }
            }
            if (Physics.Raycast(transform.position, Vector3.down, out _, goUpRange))
            {
                var transform1 = transform;
                var position = transform1.position;
                position = new Vector3(position.x, position.y+Time.deltaTime*alignmentSpeed, position.z);
                transform1.position = position;
            }
        }
    }
}
