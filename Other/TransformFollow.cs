using System;
using UnityEngine;

public class TransformFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private void Update()
    {
        if (!target.gameObject.activeInHierarchy) return;
        transform.position = target.position;
        transform.localRotation = target.localRotation;
    }
}
