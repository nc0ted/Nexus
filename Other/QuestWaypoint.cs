using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestWaypoint : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Transform target;
    [SerializeField] TMP_Text meter;
    [SerializeField] Vector3 offset;

    private Camera _cachedCamera;
    private void Awake()
    {
        _cachedCamera=Camera.main;
    }
    private void LateUpdate()
    {
        float minX = img.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = img.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;
        Vector2 pos = _cachedCamera.WorldToScreenPoint(target.position + offset);
        if(Vector3.Dot((target.position - _cachedCamera.transform.position), _cachedCamera.transform.forward) < 0) 
        {
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            { 
                pos.x = minX;
            }
        }
            
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        img.transform.position = pos;
        meter.text = Mathf.Round((Vector3.Distance(target.position, _cachedCamera.transform.position))) + "m";
    }   
}