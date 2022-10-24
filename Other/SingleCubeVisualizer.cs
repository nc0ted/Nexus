using System;
using UnityEngine;

public class SingleCubeVisualizer : MonoBehaviour
{
  [SerializeField] private int band;
  [SerializeField] private float scaleMultiplier;

  private RectTransform _rectTransform;
  private float currVelocity;

  private void Awake()
  {
    _rectTransform = GetComponent<RectTransform>();
  }

  private void Update()
  {
   /* if (_rectTransform != null)
      _rectTransform.localScale = new Vector3(1f,
        Mathf.SmoothDamp(_rectTransform.localScale.y, (AudioParse.freqBand[band] * scaleMultiplier), ref currVelocity,
          0.05f), 1f);
    else*/
      transform.localScale = new Vector3(1f,
        Mathf.SmoothDamp(transform.localScale.y, (AudioParse.FreqBand[band] * scaleMultiplier), ref currVelocity,
          0.05f), 1f);
  }
}