using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CurveRotator : MonoBehaviour
    {
        [SerializeField] private AnimationCurve animationCurve;
        private float _currTime, _totalTime;

        private void Awake()
        {
            _totalTime = animationCurve.keys[animationCurve.keys.Length - 1].time;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0,0,animationCurve.Evaluate(_currTime));
            _currTime += Time.deltaTime;
            if (_currTime >= _totalTime)
                _currTime = 0;
        }
    }
}